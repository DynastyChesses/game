using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spine.Unity
{
	public class SpineRuntimeCfg : SingletonCfgBase
	{
		// ------------- 子类必须实现的指定签名的静态单例方法才能显示在ProjectSetting界面
		static SpineRuntimeCfg s_Inst;
		public static SpineRuntimeCfg Instance
		{
			get
			{
				if (s_Inst == null)
					s_Inst = LoadOrCreate<SpineRuntimeCfg>(runtimeAsset: true);
				return s_Inst;
			}
		}
		// --------------------------------------------

		[LabelText("启用延迟解析")]
		[SerializeField]
		bool m_LazyLoadingEnabled = false;
		public static bool LazyLoadingEnabled
		{
			get
			{
				return Invalid ? false : Instance.m_LazyLoadingEnabled;
			}
			set
			{
				Instance.m_LazyLoadingEnabled = value;
			}
		}

		[LabelText("启用解析加速"), Tooltip("数组下标替换流式解析，有30%~40%的解析速度提升")]
		[SerializeField]
		bool m_ParseAccelerateEnabled = true;
		public static bool ParseAccelerateEnabled
		{
			get
			{
				return Invalid ? false : Instance.m_ParseAccelerateEnabled;
			}
			set
			{
				Instance.m_ParseAccelerateEnabled = value;
			}
		}

		[LabelText("启用帧率限制")]
		[SerializeField]
		bool m_LimitFrameRateEnabled = true;
		public static bool LimitFrameRateEnabled
		{
			get
			{
				return Invalid ? false : Instance.m_LimitFrameRateEnabled;
			}
			set
			{
				Instance.m_LimitFrameRateEnabled = value;
			}
		}

		[LabelText("全局混合开关")]
		[SerializeField]
		bool m_GlobalMixingEnabled = true;
		public static bool GlobalMixingEnabled
		{
			get
			{
				return Invalid ? true : Instance.m_GlobalMixingEnabled;
			}
			set
			{
				Instance.m_GlobalMixingEnabled = value;
			}
		}

		[LabelText("WGL混合开关"), Tooltip("WebGL 小游戏混合开关")]
		[SerializeField]
		bool m_WebGLMixingEnabled = false;
		public static bool WebGLMixingEnabled
		{
			get
			{
				return Invalid ? true : Instance.m_WebGLMixingEnabled;
			}
			set
			{
				Instance.m_WebGLMixingEnabled = value;
			}
		}

		[LabelText("跳过重复动画"), Tooltip("新设置的动画时，如果跟之前动画同名，且是 loop 的，则跳过设置；如果上一动画未开始，会被自动忽略，此时如果还有更老的动画，且同名且loop，则依然忽略")]
		[SerializeField]
		bool m_SkipDuplicateLoopAnimationEnabled = true;
		public static bool SkipDuplicateLoopAnimationEnabled
		{
			get
			{
				return Invalid ? false : Instance.m_SkipDuplicateLoopAnimationEnabled;
			}
			set
			{
				Instance.m_SkipDuplicateLoopAnimationEnabled = value;
			}
		}

		[LabelText("忽略混合阈值"), Tooltip("新设置动画时，如果上一动画刚开始或快结束，则认为其对混合没有多少贡献，直接结束其混合，无论是loop还是非loop，计算时使用 MixDuration * Threshold 的结果作为比较依据")]
		[SerializeField, Range(0, 1)]
		float m_KillMixingThreshold = 0.2f;  // Spine默认混合时长 0.2s，0.2s * 20% = 0.04s，30 fps 时候大致 1 帧时间，但逻辑帧是50ms
		public static float KillMixingThreshold
		{
			get
			{
				return Invalid ? 0.0f : Instance.m_KillMixingThreshold;
			}
			set
			{
				Instance.m_KillMixingThreshold = Mathf.Clamp01(value);
			}
		}

		[LabelText("启用数据压缩"), Tooltip("运行时 timeline 内的 float[] 内存优化")]
		[SerializeField]
		bool m_MemoryCompressEnabled = true;
		public static bool MemoryCompressEnabled
		{
			get
			{
				return Invalid ? false : Instance.m_MemoryCompressEnabled;
			}
			set
			{
				Instance.m_MemoryCompressEnabled = value;
			}
		}

		[LabelText("启用动画缓存")]
		[SerializeField]
		bool m_SkeletonMeshCacheEnabled = true;
		public static bool SkeletonMeshCacheEnabled
		{
			get
			{
				return Invalid ? false : Instance.m_SkeletonMeshCacheEnabled;
			}
			set
			{
				Instance.m_SkeletonMeshCacheEnabled = value;
			}
		}

		[MinValue(0)]
		[LabelText("动画缓存释放阈值M")]
		[Tooltip("超过此阈值才自动释放动画Mesh缓存")]
		public float autoReleaseMeshCacheThreshold = 20;

		[LabelText("动画缓存延迟"), Tooltip("混合结束多久之后再记录缓存，遇到的问题是当根节点禁用再显示后，Profiler抓取内存使得编辑器卡顿后，重新生成的缓存不正常，当前通过控制supportCache的顺序看似解决了，这个配置暂时没用到")]
		//[SerializeField]
		int m_SkeletonMeshCacheDelay = 16;
		public static int SkeletonMeshCacheDelay
		{
			get
			{
				return Invalid ? 0 : Instance.m_SkeletonMeshCacheDelay;
			}
			set
			{
				Instance.m_SkeletonMeshCacheDelay = value;
			}
		}

		[LabelText("多久未用释放(秒)")]
		[SerializeField]
		float m_RecycleTimeAfterLastUse = 10.0f;  // second
		public static float RecycleTimeAfterLastUse
		{
			get
			{
				return Invalid ? 0.0f : Instance.m_RecycleTimeAfterLastUse;
			}
			set
			{
				Instance.m_RecycleTimeAfterLastUse = value;
			}
		}

		[LabelText("实例销毁后保留缓存")]
		[Tooltip("当某种spine都被inative，disable或销毁时仍然保留spine缓存，缓存会被延迟释放机制释放，下次有spine实例可复用缓存")]
		public bool keepCacheEvenWithoutActiveSpine = false;
		
		[LabelText("缓存动画帧率")]
		[SerializeField, Range(1, 120)]
		int m_MaxFrame = 30;
		public static int MaxFrame
		{
			get
			{
				return Mathf.Clamp(Invalid ? 30 : Instance.m_MaxFrame, 1, 120);
			}
			set
			{
				Instance.m_MaxFrame = Mathf.Clamp(value, 1, 120);
			}
		}
		public static float MinInterval
		{
			get
			{
				return 1.0f / MaxFrame;
			}
			set
			{
				MaxFrame = Mathf.CeilToInt(1.0f / Mathf.Max(1e-5f, value));
			}
		}
		
		[LabelText("视锥剔除释放"), Tooltip("移出视锥后是否释放缓存，默认不开启，优先使用基于时间的释放，内存要求严格的时候再开启")]
		[SerializeField]
		bool m_FrustumCullingEnabled = false;  // 默认不开启，优先使用基于时间的释放
		public static bool FrustumCullingEnabled
		{
			get
			{
				return Invalid ? false : Instance.m_FrustumCullingEnabled;
			}
			set
			{
				Instance.m_FrustumCullingEnabled = value;
			}
		}

		[LabelText("低内存时释放")]
		[SerializeField]
		bool m_LowMemoryCallbackEnabled = true;
		public static bool LowMemoryCallbackEnabled
		{
			get
			{
				return Invalid ? false : Instance.m_LowMemoryCallbackEnabled;
			}
			set
			{
				Instance.m_LowMemoryCallbackEnabled = value;
			}
		}

		[LabelText("强制不可见的不更新")]
		public bool forceNotUpdateWhenInvisableForAll = false;

		[LabelText("不可见时的强制更新模式")]
		[ShowIf("forceNotUpdateWhenInvisableForAll")]
		public UpdateMode invisableUpdateMode = UpdateMode.Nothing;

		static bool Valid => Instance != null;

		static bool Invalid => Instance == null;

		//HashSet<ISkeletonComponent> visibles = new HashSet<ISkeletonComponent>();
		//[ShowInInspector, ReadOnly]
		//public static HashSet<ISkeletonComponent> Visibles => Instance.visibles;

		const string CacheDetailInfo = "CacheDetailInfo";

		[BoxGroup(CacheDetailInfo), ShowInInspector]
		int AnimationCount => SkeletonMeshCache.AnimationCount;

		[BoxGroup(CacheDetailInfo), ShowInInspector]
		int MeshCount => SkeletonMeshCache.MeshCount;

		[BoxGroup(CacheDetailInfo), ShowInInspector]
		int VerticesCount => SkeletonMeshCache.VerticesCount;

		[BoxGroup(CacheDetailInfo), ShowInInspector]
		long MemoryInBytes => SkeletonMeshCache.MemoryInBytes;

		[BoxGroup(CacheDetailInfo), ShowInInspector]
		[LabelText("累计方式统计的内存字节数")]
		private long MemoryInMegabytesAccumulated => SkeletonMeshCache.AllSpineMeshCacheBytes;

		[BoxGroup(CacheDetailInfo), ShowInInspector]
		float MemoryInMegabytes => SkeletonMeshCache.MemoryInMegabytes;

		[BoxGroup(CacheDetailInfo), ShowInInspector]
		Dictionary<string, SkeletonMeshCacheEntry> Cache => SkeletonMeshCache.Cache;
	}
}
