/******************************************************************************
 * Spine 运行时缓存：
 * 缓存最终 Mesh，降低计算消耗，内存换时间，适用于内存消耗不高的动画
 * 大致内存：动画总时长 * 帧率 * { 
 *		vertex count * (vertex 3 + uv 2 + color 1) float * 4 byte
 *		* readable ? 2 : 1  // 但缓存其实不需要 readable，一方面没有对同一对象修改数据的需求，另一方面，考虑内存
 *		+ index buffer bytes
 *		+ empty mesh size }
 * 
 * 对于循环动画，现在离散为关键帧，则需要处理对齐的情况，采用平均时长
 * 对于动画切换，一般都配置了 mix，但缓存是不处理 mix 的，此时还是实时运算，等 mix 结束，才生成或使用缓存
 * 关于帧的选择，如果时间处于两帧之间，向下取整，非循环动画第一轮取当前帧超过一轮选最后一帧
 * 有必要的话，可以做二级缓存，这样，index buffer、uv等，也能一定程度上共享，动画之间应该都不能复用，同一动画应该大多是相同的，建造类动画应该都不同
 * 如果觉得帧卡顿的话，可能是资源按30fps播放本身就卡顿，可以从spine editor导出视频进行确认
 * 
 * 对于材质，当前情况只有一个材质，所以没做缓存
 * 
 * 对于换装，当前没有换装，且将来的坐骑换装好像遮罩，实际还是两个实体
 * 
 * 对于动画多的资源，也许只有几个动画是高频的，可以考虑仅对这些进行缓存
 * 
 * 最初想完全实现一份完备的bake功能，但没能解决动画切换时附件切换问题，最后选择偏移runtime的时间，使用默认的更新流程得到mesh并缓存
 *****************************************************************************/

using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using Object = UnityEngine.Object;

namespace Spine.Unity
{
	/// <summary>
	/// 一个spine skeletonAsset的一个动画的一个Mesh缓存
	/// </summary>
	internal struct MeshEntry
	{
		public Mesh mesh;

		// 识别isReadable的变化
		private int mark => mesh == null || !mesh.isReadable ? -1 : 1;
		
		// 是否把此内存计入总内存了，防止重复统计
		int memoryRecorded;

		private int m_RuntimeMemorySizeInBytes;
		[ShowInInspector]
		public int runtimeMemorySizeInBytes
		{
			get
			{
				// 把 bool 藏到 int 里 ...
				if (m_RuntimeMemorySizeInBytes == 0 || m_RuntimeMemorySizeInBytes * mark < 0)
				{
					m_RuntimeMemorySizeInBytes = (mesh == null || mesh.vertexCount == 0) ? 0 :(int)mesh.GetRuntimeMemorySizeLong() * mark;
				}

				return Math.Abs(m_RuntimeMemorySizeInBytes);
			}
		}

#if UNITY_EDITOR
		public float time;
		public float trackTime;
		public float animationTime;
		public float duration;
#endif

		/// <summary>
		/// 标记已经统计到内存里了
		/// </summary>
		internal void MarkMemoryRecorded()
		{
			if (memoryRecorded != 0)
				Debug.LogError($"重复统计内存:{mesh?.name}");
			memoryRecorded = 1;
		}

		public void Clear()
		{
			if (mesh != null)
			{
#if UNITY_EDITOR
				if (Application.isEditor && !Application.isPlaying)
				{
					UnityEngine.Object.DestroyImmediate(mesh);
				}
				else
				{
					UnityEngine.Object.Destroy(mesh);
				}
#else
				UnityEngine.Object.Destroy(mesh);
#endif
			}

			mesh = null;
			m_RuntimeMemorySizeInBytes = 0;
			memoryRecorded = 0;

#if UNITY_EDITOR
			time = 0;
			trackTime = 0;
			animationTime = 0;
			duration = 0; 
#endif
		}
	}

	/// <summary>
	/// 一个spine skeletonAsset的一个动画的所有Mesh缓存，
	/// 这里缓存的是未处理mix的原始插值数据，也仅供非mix时候使用
	/// 当mix的时候，不可取多个mesh进行插值，而应使用 skeleton 进行混合，否则会有问题，比如：
	/// 假如胳膊初始伸向前方，一个动作将胳膊左转90°，另一个将其右转90°，骨骼混合结果是胳膊依旧伸向前方；但mesh混合的话，可能就都归于中心点了
	/// </summary>
	internal class SkeletonMeshFrameCache
	{
		[ShowInInspector]
		internal MeshEntry[] entries { get; private set; }
		
		[ShowInInspector]
		[LabelText("缓存字节")]
		internal long allFrameMeshCacheBytesInOneAnimation;

		[ShowInInspector]
		[LabelText("未填充mesh数")]
		internal int unfilledMeshCount;

		internal MeshEntry this[int index]
		{
			get
			{
				return entries[index];
			}
			set
			{
				entries[index] = value;
			}
		}

		/// <summary>
		/// 用于创建初始化数组，或采样率变化时重新创建
		/// </summary>
		/// <param name="length"></param>
		public void Resize(int length, string assetName)
		{
			if (entries == null || entries.Length != length)
			{
				if (entries != null)
				{
					Clear(assetName);
				}

				// 运行时修改采样间隔才会resize，那时不应该复制老值
				entries = new MeshEntry[length];
				unfilledMeshCount = length;
				allFrameMeshCacheBytesInOneAnimation = 0;
				lastUseTime = Time.time;
			}
		}

		/// <summary>
		/// 动画缓存的时间数据，是固定间隔离散的，跟spine原生时间不同
		/// </summary>
		public struct AnimationTimeData
		{
			public string animation;
			public float start;
			public float trackTime;
			public float duration;
			public float interval;  // 这个只是当前动画的 interval，注意跟 SkeletonMeshFrameCache.interval 区别
			public bool loop;
			public bool cacheReady;	// 这个动画当前时间对应的mesh缓存是否存在
			//public int nframe;

			public bool Valid()
			{
				return !string.IsNullOrEmpty(animation);
			}
		}

		// 同一个asset各实例对象对应的当前播放时间？
		public Dictionary<int, AnimationTimeData> TimeDataDictionary = new Dictionary<int, AnimationTimeData>(2);

		public float interval;  // 每个动画可以有自己的 interval，但假设同一动画的不同实例均使用相同的 interval

		public float lastUseTime = float.MinValue;

#if false
		// 由于需要标记 readable false，之后无法逆向标记，也就是不再能修改mesh数据，缓存池也就无法实现
		internal static int MeshPoolCapacity = 4096;
		internal static Stack<Mesh> MeshPool = new Stack<Mesh>(MeshPoolCapacity);

		// 先不封装通用Pool了
		public static Mesh PopMesh()
		{
			if (MeshPool.Count > 0)
			{
				return MeshPool.Pop();
			}

			var mesh = new Mesh
			{
				name = "new skeleton mesh"
			};

			return mesh;
		}

		public static void PushMesh(ref Mesh mesh)
		{
			if (mesh == null)
			{
				return;
			}

			if (MeshPool.Count > MeshPoolCapacity)
			{
#if UNITY_EDITOR
				if (Application.isEditor && !Application.isPlaying)
				{
					UnityEngine.Object.DestroyImmediate(mesh);
				}
				else
				{
					UnityEngine.Object.Destroy(mesh);
				}
#else
				UnityEngine.Object.Destroy(mesh);
#endif
			}
			else
			{
				mesh.Clear(false);
				mesh.name = "cached skeleton mesh";
				MeshPool.Push(mesh);
			}

			mesh = null;
		}
#endif

		/// <summary>
		/// 
		/// </summary>
		/// <param name="assetName">用asset进行相应内存的统计</param>
		public void Clear(string assetName)
		{
			lastUseTime = Time.time;

			if (entries == null)
			{
				return;
			}
			
			SkeletonMeshCache.OnReleaseSpineAnimationCache(assetName, allFrameMeshCacheBytesInOneAnimation);

			unfilledMeshCount = entries.Length;
			for (int i = 0; i < entries.Length; i++)
			{
				entries[i].Clear();
			}

			allFrameMeshCacheBytesInOneAnimation = 0;
		}
	}

	/// <summary>
	/// 一个spine skeletonAsset的所有动画的mesh缓存
	/// </summary>
	internal class SkeletonMeshCacheEntry : Dictionary<string, SkeletonMeshFrameCache>
	{
		/// <summary>
		/// 引用，同一个asset的各实例对象？
		/// </summary>
		public HashSet<ISkeletonComponent> references { get; } = new HashSet<ISkeletonComponent>();

		public int lastCheckRecycleCacheFrame { get; private set; } = -1;
		
		[ShowInInspector]
		internal long allAnimMeshCacheBytesInOneSpine = 0;

		public string skeletonDataAssetName { get; set; }

		public SkeletonMeshCacheEntry(ISkeletonComponent skeletonComponent)
		{
			allAnimMeshCacheBytesInOneSpine = 0;
			skeletonDataAssetName = skeletonComponent.SkeletonDataAsset.name;
		}

		public static int GetISkeletonComponentInstanceId(ISkeletonComponent skel)
		{
			return (skel as UnityEngine.Object).GetInstanceID();
		}

		/// <summary>
		/// 开始动画，主要是记录播放数据，为插值做基础准备
		/// </summary>
		/// <param name="animation">动画名字</param>
		/// <param name="currentTime">当前时间</param>
		/// <param name="interval">间隔时间</param>
		public SkeletonMeshFrameCache StartAnimation(ISkeletonComponent skeletonComponent, 
			ref SkeletonMeshFrameCache.AnimationTimeData data)
		{
			if (string.IsNullOrEmpty(data.animation) || string.IsNullOrWhiteSpace(data.animation))
			{
				return null;
			}

			if (!TryGetValue(data.animation, out var skeletonMeshFrameCache))
			{
				skeletonMeshFrameCache = new SkeletonMeshFrameCache();

				skeletonMeshFrameCache.interval = data.interval;

				Add(data.animation, skeletonMeshFrameCache);
			}

			data.interval = Mathf.Max(data.interval, SpineRuntimeCfg.MinInterval);

			if (skeletonMeshFrameCache.interval != data.interval)
			{
				skeletonMeshFrameCache.Clear(skeletonComponent.SkeletonDataAsset.name);

				skeletonMeshFrameCache.interval = data.interval;
			}

			var instId = GetISkeletonComponentInstanceId(skeletonComponent);
			skeletonMeshFrameCache.TimeDataDictionary[instId] = new SkeletonMeshFrameCache.AnimationTimeData
			{
				animation = data.animation,
				start = data.start,
				duration = data.duration,
				interval = data.interval,
				loop = data.loop,
			};

			GetRasterizedTimeData(skeletonComponent, data.animation, data.duration, 
				out var time, out var frame, out var frames);

			skeletonMeshFrameCache.Resize(frames, skeletonComponent.SkeletonDataAsset.name);

			return skeletonMeshFrameCache;
		}

		/// <summary>
		/// 获取结果SmartMesh，当需要跟别的animation进行mix的时候，需要多个SmartMesh插值生成最终Mesh
		/// </summary>
		/// <param name="animation">动画名字</param>
		/// <param name="trackTime"></param>
		/// <param name="skeletonRendererInstruction"></param>
		/// <returns></returns>
		internal MeshEntry GetAnimationMesh(ISkeletonComponent skeletonComponent, string animation, 
			float trackTime, out bool ready)
		{
			GetRasterizedTimeData(skeletonComponent, animation, trackTime, 
				out var time, out var frame, out var frames);

			var mesh = GetAnimationMesh(animation, frame, out ready);

			return mesh;
		}

		internal MeshEntry GetAnimationMesh(string animation, int frame, out bool ready)
		{
			ready = false;

			if (frame < 0)
			{
				return default;
			}

			if (!TryGetValue(animation, out var skeletonMeshFrameCache))
			{
				return default;
			}

			if (skeletonMeshFrameCache[frame].mesh == null)
			{
				var t = skeletonMeshFrameCache[frame];
				t.mesh = new Mesh();
				skeletonMeshFrameCache[frame] = t;
			}

			ready = skeletonMeshFrameCache[frame].mesh.vertexCount > 0;

			skeletonMeshFrameCache.lastUseTime = Time.time;

			return skeletonMeshFrameCache[frame];
		}

		/// <summary>
		/// 获取栅格化时间数据，动画时长跟interval可能不是完全匹配，这时候四舍五入为完整帧
		/// </summary>
		/// <param name="skeletonComponent"></param>
		/// <param name="animation"></param>
		/// <param name="trackTime"></param>
		/// <param name="currentOrNextTrackTime">从动画开始到现在，最接近的缓存帧时间戳</param>
		/// <param name="frame">动画帧</param>
		public void GetRasterizedTimeData(ISkeletonComponent skeletonComponent, string animation, float trackTime, 
			out float currentOrNextTrackTime, out int frame, out int frames)
		{
			currentOrNextTrackTime = float.NaN;
			frame = int.MinValue;
			frames = 0;

			var instId = GetISkeletonComponentInstanceId(skeletonComponent);
			if (!TryGetValue(animation, out var skeletonMeshFrameCache)
				|| skeletonMeshFrameCache == null
				|| !skeletonMeshFrameCache.TimeDataDictionary.TryGetValue(instId, out var animationTimeData))
			{
				return;
			}

			if (animationTimeData.duration < 1e-5)
			{
				currentOrNextTrackTime = trackTime;
				frame = 0;
				frames = 1;
				return;
			}

			// |-~~~~----____--|-~~~~----____--
			// 0 _ 1 _ 2 _ 3 _ 4/0
			frames = Mathf.CeilToInt(animationTimeData.duration / skeletonMeshFrameCache.interval);
			var interval = animationTimeData.duration / frames;

			frame = Mathf.FloorToInt(trackTime / interval);
			currentOrNextTrackTime = frame * interval;
			frame = animationTimeData.loop ? frame % frames : Mathf.Min(frames - 1, frame);
		}

		public void TryRecycleCacheOncePerFrame()
		{
			if (Time.frameCount > lastCheckRecycleCacheFrame)
			{
				float now = Time.time;
				float threshold = SpineRuntimeCfg.RecycleTimeAfterLastUse;
				foreach (var kv in this)
				{
					if (now - kv.Value.lastUseTime > threshold)
					{
						kv.Value.Clear(skeletonDataAssetName);
					}
				}

				lastCheckRecycleCacheFrame = Time.frameCount;
			}
		}

		public new void ClearAnimMeshCache()
		{
			foreach (var skeletonMeshFrameCache in Values)
			{
				skeletonMeshFrameCache.Clear(skeletonDataAssetName);
			}

			base.Clear();
		}

		//public void Dispose()
		//{
		//	Clear();

		//	GC.SuppressFinalize(this);
		//}

		//~SkeletonMeshCacheEntry()
		//{
		//	Dispose();
		//}
	}

	/// <summary>
	/// 所有spine skeleton的mesh缓存
	/// </summary>
	public static class SkeletonMeshCache
	{
		// SkeletonDataAsset.name做key去关联mesh缓存，不能用其对象，因为实力都销毁后仍然需要缓存mesh防止再次创建时卡顿
		internal static Dictionary<string, SkeletonMeshCacheEntry> Cache { get; } = 
			new Dictionary<string, SkeletonMeshCacheEntry>(20);

		const double Megabytes = 1 << 20;

		static float MetricsUpdateTimeLast = 0.0f;
#if UNITY_EDITOR
		public static float MetricsUpdateInterval { get { return 0.0f; } set { } }
#else
		public static float MetricsUpdateInterval { get; set; } = 1.0f;
#endif

		static int s_AnimationCount;
		public static int AnimationCount { get { TryUpdateMetrics(); return s_AnimationCount; } }

		static int s_MeshCount;
		public static int MeshCount { get { TryUpdateMetrics(); return s_MeshCount; } }

		static int s_VerticesCount;
		public static int VerticesCount { get { TryUpdateMetrics(); return s_VerticesCount; } }

		static long s_MemoryInBytes;

		public static long MemoryInBytes
		{
			get
			{
				// 换用低消耗实现，并不改变脚本域的接口
				// TryUpdateMetrics();
				// return s_MemoryInBytes;
				return AllSpineMeshCacheBytes;
			}
		}

		static float s_MemoryInMegabytes;
		public static float MemoryInMegabytes { get { TryUpdateMetrics(); return s_MemoryInMegabytes; } }
		
		[ShowInInspector]
		public static long AllSpineMeshCacheBytes { get; private set; }

		/// <summary>
		/// 填充新spine缓存mesh时计入内存统计
		/// </summary>
		/// <param name="asset"></param>
		/// <param name="animCache"></param>
		/// <param name="mesh"></param>
		internal static void OnNewSpineMeshFilled(SkeletonDataAsset asset, SkeletonMeshFrameCache animCache, MeshEntry mesh)
		{
			long bytes = mesh.runtimeMemorySizeInBytes;
			mesh.MarkMemoryRecorded();
			AllSpineMeshCacheBytes += bytes;
			if (Cache.TryGetValue(asset.name, out var skeletonMeshCacheEntry))
			{
				skeletonMeshCacheEntry.allAnimMeshCacheBytesInOneSpine += bytes;
			}
			else
			{
				Debug.LogError(asset.name);
			}

			if (animCache != null)
			{
				animCache.allFrameMeshCacheBytesInOneAnimation += bytes;
				animCache.unfilledMeshCount--;
			}
			else
			{
				Debug.LogError("aa");
			}
		}

		internal static void OnReleaseSpineAnimationCache(string assetName, long animMeshCacheBytes)
		{
			AllSpineMeshCacheBytes -= animMeshCacheBytes;
			if (!string.IsNullOrEmpty(assetName) && Cache.TryGetValue(assetName, out var skeletonMeshCacheEntry))
			{
				skeletonMeshCacheEntry.allAnimMeshCacheBytesInOneSpine -= animMeshCacheBytes;
			}
		}

		private static float s_LastReleaseTime = 0;
		private static List<string> s_UnCachedSpine = new List<string>();
		internal static void TryReleaseOldMeshCache()
		{
			// 不用traverse，节省内部属性的使用次数
			float now = Time.time;
			if (now - s_LastReleaseTime < 1)
				return;
			s_LastReleaseTime = now;

			float thresholdBytes = 0;
			if (SpineRuntimeCfg.Instance != null)
				thresholdBytes = SpineRuntimeCfg.Instance.autoReleaseMeshCacheThreshold * 1e6f;
			if (AllSpineMeshCacheBytes < thresholdBytes) 
				return;
			
			Profiler.BeginSample("TryReleaseOldMeshCache");
			float threshold = SpineRuntimeCfg.RecycleTimeAfterLastUse;
			s_UnCachedSpine.Clear();
			bool breakFlag = false;
			foreach (var kv in Cache)
			{
				var entry = kv.Value;
				if (entry != null)
				{
					long thisSpineCacheByte = 0;
					foreach (var cache in entry.Values)
					{
						if (cache != null && (now - cache.lastUseTime > threshold))
						{
							cache.Clear(entry.skeletonDataAssetName);
							if (AllSpineMeshCacheBytes < thresholdBytes)
							{
								thisSpineCacheByte = -1;		// 此spine没完全遍历，用非0表示可能还有缓存
								breakFlag = true;
								break;
							}
						}
						thisSpineCacheByte += cache.allFrameMeshCacheBytesInOneAnimation;
					}
					// if (entry.allAnimMeshCacheBytesInOneSpine == 0)	// 担心asset为null时此变量不准
					if (thisSpineCacheByte == 0 && entry.references.Count == 0)		// 没用时才移除
						s_UnCachedSpine.Add(entry.skeletonDataAssetName);
				}
				else
				{
					s_UnCachedSpine.Add(kv.Key);
				}

				if (breakFlag)
					break;
			}

			// 移除没用缓存的spine asset
			if (s_UnCachedSpine.Count > 0)
			{
				foreach (var v in s_UnCachedSpine)
				{
					// Debug.LogWarning($"remove: {v.name}");
					Cache.Remove(v);
				}
				s_UnCachedSpine.Clear();
			}

#if UNITY_EDITOR
			// 比较2种统计方式是否一致
			TryUpdateMetrics(true);
#endif
			Profiler.EndSample();
		}
		

		static void TryUpdateMetrics(bool forceUpdate = false)
		{
			if (forceUpdate || Time.time - MetricsUpdateTimeLast < MetricsUpdateInterval)
			{
				return;
			}

			Profiler.BeginSample("SkeletonMeshCache.TryUpdateMetrics");
			MetricsUpdateTimeLast = Time.time;

			s_AnimationCount = 0;
			s_MeshCount = 0;
			s_VerticesCount = 0;
			s_MemoryInBytes = 0L;
			s_MemoryInMegabytes = 0;

			TraverseSkeletonMeshFrameCache((cache) =>
			{
				s_AnimationCount++;

				for (int i = 0; i < cache.entries.Length; i++)
				{
					if (cache.entries[i].mesh != null)
					{
						s_MeshCount++;

						s_VerticesCount += cache.entries[i].mesh.vertexCount;

						s_MemoryInBytes += cache.entries[i].runtimeMemorySizeInBytes;
					}
				}
			});
			
			// 延迟销毁，在退出play后有残留，只在play时验证
			if (s_MemoryInBytes != AllSpineMeshCacheBytes && Application.isPlaying && Application.isEditor)
				Debug.LogError($"内存统计不一致，遍历：{s_MemoryInBytes}, 累计：{AllSpineMeshCacheBytes}");

			s_MemoryInMegabytes = (float)(s_MemoryInBytes / Megabytes);
			Profiler.EndSample();
		}

		static SkeletonMeshCache()
		{
			if (SpineRuntimeCfg.LowMemoryCallbackEnabled)
			{
				Application.lowMemory += LowMemoryCallback;
			}
		}

		public static void LowMemoryCallback()
		{
			TraverseSkeletonMeshFrameCache((cache) => { cache.Clear(null); });
		}

		static void TraverseSkeletonMeshFrameCache(Action<SkeletonMeshFrameCache> action)
		{
			foreach (var entry in Cache.Values)
			{
				if (entry != null)
				{
					foreach (var cache in entry.Values)
					{
						if (cache != null)
						{
							action?.Invoke(cache);
						}
					}
				}
			}
		}

		/// <summary>
		/// 查询是否注册了
		/// </summary>
		/// <param name="skeletonComponent"></param>
		/// <returns></returns>
		internal static bool Registered(ISkeletonComponent skeletonComponent)
		{
			return skeletonComponent != null && Cache.ContainsKey(skeletonComponent.SkeletonDataAsset.name);
		}

		/// <summary>
		/// 注册
		/// </summary>
		/// <param name="skeletonComponent"></param>
		/// <returns></returns>
		internal static WeakReference<SkeletonMeshCacheEntry> Register(ISkeletonComponent skeletonComponent, WeakReference<SkeletonMeshCacheEntry> handle)
		{
			if (skeletonComponent == null || skeletonComponent.SkeletonDataAsset == null)
			{
				return default;
			}

			if (!Cache.TryGetValue(skeletonComponent.SkeletonDataAsset.name, out var entry))
			{
				entry = new SkeletonMeshCacheEntry(skeletonComponent);

				Cache.Add(skeletonComponent.SkeletonDataAsset.name, entry);

			}

			if (!entry.references.Add(skeletonComponent))
			{
				//
			}

			handle?.SetTarget(entry);

			return handle ?? new WeakReference<SkeletonMeshCacheEntry>(entry);
		}

		/// <summary>
		/// 解注册
		/// </summary>
		/// <param name="skeletonComponent"></param>
		internal static void Deregister(ISkeletonComponent skeletonComponent)
		{
			if (skeletonComponent == null || skeletonComponent.SkeletonDataAsset == null)
			{
				return;
			}

			if (Cache.TryGetValue(skeletonComponent.SkeletonDataAsset.name, out var entry))
			{
				if (entry.references.Remove(skeletonComponent))
				{
					if (entry.references.Count == 0 && (!Application.isPlaying || 
					    (SpineRuntimeCfg.Instance != null && !SpineRuntimeCfg.Instance.keepCacheEvenWithoutActiveSpine)))
					{
						entry.ClearAnimMeshCache();
						Cache.Remove(skeletonComponent.SkeletonDataAsset.name);
					}
				}
			}
		}
	}
}
