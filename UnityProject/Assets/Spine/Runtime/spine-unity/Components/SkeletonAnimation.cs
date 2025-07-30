/******************************************************************************
 * Spine Runtimes License Agreement
 * Last updated January 1, 2020. Replaces all prior versions.
 *
 * Copyright (c) 2013-2020, Esoteric Software LLC
 *
 * Integration of the Spine Runtimes into software or otherwise creating
 * derivative works of the Spine Runtimes is permitted under the terms and
 * conditions of Section 2 of the Spine Editor License Agreement:
 * http://esotericsoftware.com/spine-editor-license
 *
 * Otherwise, it is permitted to integrate the Spine Runtimes into software
 * or otherwise create derivative works of the Spine Runtimes (collectively,
 * "Products"), provided that each user of the Products must obtain their own
 * Spine Editor license and redistribution of the Products in any form must
 * include this license and copyright notice.
 *
 * THE SPINE RUNTIMES ARE PROVIDED BY ESOTERIC SOFTWARE LLC "AS IS" AND ANY
 * EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
 * WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
 * DISCLAIMED. IN NO EVENT SHALL ESOTERIC SOFTWARE LLC BE LIABLE FOR ANY
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
 * (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES,
 * BUSINESS INTERRUPTION, OR LOSS OF USE, DATA, OR PROFITS) HOWEVER CAUSED AND
 * ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 * (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 * THE SPINE RUNTIMES, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 *****************************************************************************/

#if UNITY_2018_3 || UNITY_2019 || UNITY_2018_3_OR_NEWER
#define NEW_PREFAB_SYSTEM
#endif

using System;
using System.Text;
using UnityEngine;
using UnityEngine.Profiling;

namespace Spine.Unity {

	#if NEW_PREFAB_SYSTEM
	[ExecuteAlways]
	#else
	[ExecuteInEditMode]
	#endif
	[AddComponentMenu("Spine/SkeletonAnimation")]
	public class SkeletonAnimation : SkeletonRenderer, ISkeletonAnimation, IAnimationStateComponent {

		#region IAnimationStateComponent
		/// <summary>
		/// This is the Spine.AnimationState object of this SkeletonAnimation. You can control animations through it.
		/// Note that this object, like .skeleton, is not guaranteed to exist in Awake. Do all accesses and caching to it in Start</summary>
		public Spine.AnimationState state;
		/// <summary>
		/// This is the Spine.AnimationState object of this SkeletonAnimation. You can control animations through it.
		/// Note that this object, like .skeleton, is not guaranteed to exist in Awake. Do all accesses and caching to it in Start</summary>
		public Spine.AnimationState AnimationState { get { return this.state; } }
		// 需要在lataUpdate之前执行一次update
		private bool needUpdateInLate = false;
		#endregion

		#region Bone Callbacks ISkeletonAnimation
		protected event UpdateBonesDelegate _UpdateLocal;
		protected event UpdateBonesDelegate _UpdateWorld;
		protected event UpdateBonesDelegate _UpdateComplete;

		/// <summary>
		/// Occurs after the animations are applied and before world space values are resolved.
		/// Use this callback when you want to set bone local values.
		/// </summary>
		public event UpdateBonesDelegate UpdateLocal { add { _UpdateLocal += value; } remove { _UpdateLocal -= value; } }

		/// <summary>
		/// Occurs after the Skeleton's bone world space values are resolved (including all constraints).
		/// Using this callback will cause the world space values to be solved an extra time.
		/// Use this callback if want to use bone world space values, and also set bone local values.</summary>
		public event UpdateBonesDelegate UpdateWorld { add { _UpdateWorld += value; } remove { _UpdateWorld -= value; } }

		/// <summary>
		/// Occurs after the Skeleton's bone world space values are resolved (including all constraints).
		/// Use this callback if you want to use bone world space values, but don't intend to modify bone local values.
		/// This callback can also be used when setting world position and the bone matrix.</summary>
		public event UpdateBonesDelegate UpdateComplete { add { _UpdateComplete += value; } remove { _UpdateComplete -= value; } }
		#endregion

		#region Serialized state and Beginner API
		[SerializeField]
		[SpineAnimation]
		private string _animationName;

		/// <summary>
		/// Setting this property sets the animation of the skeleton. If invalid, it will store the animation name for the next time the skeleton is properly initialized.
		/// Getting this property gets the name of the currently playing animation. If invalid, it will return the last stored animation name set through this property.</summary>
		public string AnimationName {
			get {
				if (!valid) {
					return _animationName;
				} else {
					TrackEntry entry = state.GetCurrent(0);
					return entry == null ? null : entry.Animation.Name;
				}
			}
			set {
				if (_animationName == value) {
					TrackEntry entry = state.GetCurrent(0);
					if (entry != null && entry.loop == loop)
						return;
				}
				_animationName = value;

				if (string.IsNullOrEmpty(value)) {
					state.ClearTrack(0);
				} else {
					var animationObject = skeletonDataAsset.GetSkeletonData(false).FindAnimation(value);
					if (animationObject != null)
						state.SetAnimation(0, animationObject, loop);
				}
			}
		}

		/// <summary>Whether or not <see cref="AnimationName"/> should loop. This only applies to the initial animation specified in the inspector, or any subsequent Animations played through .AnimationName. Animations set through state.SetAnimation are unaffected.</summary>
		public bool loop;

		/// <summary>
		/// The rate at which animations progress over time. 1 means 100%. 0.5 means 50%.</summary>
		/// <remarks>AnimationState and TrackEntry also have their own timeScale. These are combined multiplicatively.</remarks>
		public float timeScale = 1;
		#endregion

		#region Runtime Instantiation
		/// <summary>Adds and prepares a SkeletonAnimation component to a GameObject at runtime.</summary>
		/// <returns>The newly instantiated SkeletonAnimation</returns>
		public static SkeletonAnimation AddToGameObject (GameObject gameObject, SkeletonDataAsset skeletonDataAsset) {
			return SkeletonRenderer.AddSpineComponent<SkeletonAnimation>(gameObject, skeletonDataAsset);
		}

		/// <summary>Instantiates a new UnityEngine.GameObject and adds a prepared SkeletonAnimation component to it.</summary>
		/// <returns>The newly instantiated SkeletonAnimation component.</returns>
		public static SkeletonAnimation NewSkeletonAnimationGameObject (SkeletonDataAsset skeletonDataAsset) {
			return SkeletonRenderer.NewSpineGameObject<SkeletonAnimation>(skeletonDataAsset);
		}
		#endregion

		#region Cache
		private bool m_SupportCache = false;  // 潜在的时序问题，切换动画后置为 false；LateUpdate结束后，检查是否可 true
		public override bool supportCache => m_SupportCache && base.supportCache;

		SkeletonMeshFrameCache.AnimationTimeData m_LatestAnimationTimeData;
		internal SkeletonMeshFrameCache.AnimationTimeData latestAnimationTimeData => m_LatestAnimationTimeData;
		#endregion

		// 限制更新间隔
		public float updateInterval;

		// 计划哪帧执行LateUpdate，不用bool的原因是一帧内可能多次主动调用，置为false需要拿到帧尾就得启动协程，否则执行一次之后就置为false可能导致后续的调用无法执行
		private int scheduledLateUpdateFrameCount { get; set; } = -1;

		[NonSerialized]
		private float _CumulativeTime = -1f;

		/// <summary>
		/// Clears the previously generated mesh, resets the skeleton's pose, and clears all previously active animations.</summary>
		public override void ClearState () {
			base.ClearState();
			if (state != null) state.ClearTracks();
		}

		/// <summary>
		/// Initialize this component. Attempts to load the SkeletonData and creates the internal Spine objects and buffers.</summary>
		/// <param name="overwrite">If set to <c>true</c>, force overwrite an already initialized object.</param>
		public override void Initialize (bool overwrite) {
			if (valid && !overwrite)
				return;
			base.Initialize(overwrite);

			if (!valid)
				return;
			state = new Spine.AnimationState(skeletonDataAsset.GetAnimationStateData());
			needUpdateInLate = true;
			scheduledLateUpdateFrameCount = -1;

			AnimationState.Start += OnStart;
			AnimationState.Interrupt += OnInterrupt;
			AnimationState.End += OnEnd;

			if (!string.IsNullOrEmpty(_animationName)) {
				var animationObject = skeletonDataAsset.GetSkeletonData(false).FindAnimation(_animationName);
				if (animationObject != null) {
					state.SetAnimation(0, animationObject, loop);
					#if UNITY_EDITOR
					if (!Application.isPlaying)
						Update(0f);
					#endif
				}
			}
		}

		protected override void RegisterCache()
		{
			base.RegisterCache();

			// 恢复最后一个动画的状态
			if (skeletonMeshCacheEntry.TryGetTarget(out var target) && m_LatestAnimationTimeData.Valid())
			{
				skeletonMeshFrameCache.SetTarget(target.StartAnimation(this, ref m_LatestAnimationTimeData));
			}
		}

		protected override void DeregisterCache(bool release = true)
		{
			var currentMesh = rendererBuffers.GetNextMesh();

			// 替换正在使用的缓存 mesh，否则缓存释放后，mesh 不正常，会影响 OnBecameVisible 等
			if (currentMesh != null && skeletonMeshFrameCache.TryGetTarget(out var cache) && skeletonMeshFrame >= 0 && cache[skeletonMeshFrame].mesh is Mesh mesh && mesh != null)
			{
#if false
				if (mesh.vertexCount > 0)
				{
					currentMesh.mesh.vertices = mesh.vertices;
					currentMesh.mesh.uv = mesh.uv;
					currentMesh.mesh.colors32 = mesh.colors32;
					currentMesh.mesh.bounds = mesh.bounds;

					int submeshCount = mesh.subMeshCount;
					currentMesh.mesh.subMeshCount = submeshCount;
					for (int i = 0; i < submeshCount; i++)
					{
						currentMesh.mesh.SetTriangles(mesh.GetIndices(i), i, false);
					}
				}
#endif

				currentMesh.mesh.bounds = mesh.bounds;
				currentMesh.instructionUsed.Clear();
			}

			if (meshFilter != null)
				meshFilter.sharedMesh = currentMesh?.mesh;

			m_SupportCache = false;
			skeletonMeshFrame = -1;

			base.DeregisterCache(release);
		}

		protected override void OnDestroy()
		{
			if (AnimationState != null)
			{
				AnimationState.Start -= OnStart;
				AnimationState.Interrupt -= OnInterrupt;
				AnimationState.End -= OnEnd;
			}

			base.OnDestroy();
		}

		// 通过以下代码形成 link list，等播放的时候，会触发 AnimationState.Start 事件
		// AnimationState.SetAnimation(0, "chusheng", false);
		// AnimationState.AddAnimation(0, "daiji", true, 0f);
		void OnStart(TrackEntry current)
		{
			Profiler.BeginSample(skeletonDataAsset.profilerTag, this);
			Profiler.BeginSample("OnStart", this);

			// ClearInstructions();
			// 防止不ApplyMIxFrom时导致残留上一个动画的附件
			// if (SpineRuntimeCfg.SkeletonMeshCacheEnabled && !SpineRuntimeCfg.GlobalMixingEnabled)
			// {
			// 	skeleton.SetSlotAttachmentsToSetupPose();	
			// 	// skeleton.ClearSlotAttachments();	// 传送门的附件会消失
			// }

			// 需跟项目组碰一下连续指定相同动画如何播放？单帧跟循环应该有不同逻辑？还是交由项目组控制？
			// 1. 交由项目组控制
			// 1.1 检测持续移动状态，如果是持续移动，那么中间不会切换到idle
			//if (!string.IsNullOrEmpty(m_LatestAnimationTimeData.animation)
			//	&& m_LatestAnimationTimeData.animation.CompareTo(current.animation.name) == 0
			//	&& current.loop
			//	&& m_LatestAnimationTimeData.start - Time.time < 1e-5)
			//{
			//	return;
			//}

			// 实例化   -> 初始化    -> 注册缓存，latestAnimationTimeData == null
			// 移出视线 -> Invisible -> skeletonMeshCacheEntry.TryGetTarget(null)
			// 移入视线 -> Visible   -> 此时需要 latestAnimationTimeData 来还原动画播放缓存
			m_LatestAnimationTimeData = new SkeletonMeshFrameCache.AnimationTimeData
			{
				animation = current.animation.name,
				start = Time.time,
				trackTime = current.trackTime,
				duration = current.animation.duration,
				interval = updateInterval,
				loop = current.loop,
			};

			if (skeletonMeshCacheEntry.TryGetTarget(out var cacheEntry))
			{
				skeletonMeshFrameCache.SetTarget(cacheEntry.StartAnimation(this, ref m_LatestAnimationTimeData));
			}

			// // 连续指定相同动画会导致频繁播放，仅考虑最近一帧使用的是缓存才需要刷新
			// if (m_SupportCache)
			// {
			// 	m_SupportCache = false;
			//
			// 	// 这里强制刷新一下运行时的双缓冲数据
			// 	// 解决：attack --自动切换-> idle，此时 idle 的第一帧显示的是 attack 0.2s 左右的 画面
			// 	// 错误现象可通过SkeletonMeshCacheDebug里面的TestAutoSwitch查看，配合Time.timeScale调小更易观察
			// 	Update(0.0f);
			//
			// 	// 只是为了刷新初始骨骼状态，其实还未开始混合，或者考虑 Update(0.0f) 时机放到切换动画前
			// 	current.nextAnimationLast = -1;
			// 	current.nextTrackLast = -1;
			// }
			//
			// // 假设默认是混合的，至少跳过一帧再记录缓存
			skeletonMeshFrame = 0;
			_CumulativeTime = -1;
			float placeHolderDT = 0;
			RatererizeTimeAndCheckCache(ref placeHolderDT);
			needUpdateInLate = true;	

			Profiler.EndSample();
			Profiler.EndSample();
		}

		// frame    current            set        state              m_LatestAnimationTimeData
		// 0        run_old            idle       run_old -> idle    idle
		// 0        run_old -> idle    run_new    run_old            idle
		// 由于idle还未参与混合，被干掉，得到run_old -> run_new，同是run，则run_new依旧可以被干掉，得到run_old，此时需要更新m_LatestAnimationTimeData为run_old
		void OnInterrupt(TrackEntry trackEntry)
		{
			Profiler.BeginSample(skeletonDataAsset.profilerTag, this);
			Profiler.BeginSample("OnInterrupt", this);

			if (state != null && state.GetCurrent(0) is var current && current != null)
			{
				if (m_LatestAnimationTimeData.animation.CompareTo(current.animation.name) != 0)
				{
					OnStart(current);

					m_LatestAnimationTimeData.start = Time.time - current.trackTime;
					m_LatestAnimationTimeData.trackTime = current.trackTime;
				}
			}

			Profiler.EndSample();
			Profiler.EndSample();
		}

		void OnEnd(TrackEntry trackEntry)
		{

		}

		void Update () {
			#if UNITY_EDITOR
			if (!Application.isPlaying) {
				Update(0f);
				return;
			}
			#endif

			// 存在一些 Update(0.0)的情况，会导致(_CumulativeTime < 0 ? Time.deltaTime : _CumulativeTime) => (_CumulativeTime)
			// 也怪 Update(deltaTime) 中调用了 _CumulativeTime = deltaTime，干掉
			// 也可以考虑 _CumulativeTime < 0 改为 _CumulativeTime < 1e-5
			if (!SpineRuntimeCfg.LimitFrameRateEnabled || float.IsNaN(updateInterval) || _CumulativeTime < 0 || _CumulativeTime >= updateInterval)
			{
				Update(_CumulativeTime < 0 ? Time.deltaTime : _CumulativeTime);
				_CumulativeTime = Time.deltaTime;
			}
			else
			{
				_CumulativeTime += Time.deltaTime;
			}
		}

		/// <summary>
		/// 将自然deltaTime变为等距离散的，之后这个离散时间应用到spine内存，让其根据这个时间算动画，以生成时间等距的mesh
		/// </summary>
		/// <param name="deltaTime"></param>
		/// <returns></returns>
		protected void RatererizeTimeAndCheckCache(ref float deltaTime)
		{
			skeletonMeshCacheEntry.TryGetTarget(out var cacheEntry);

			skeletonMeshFrame = -1;

			m_LatestAnimationTimeData.cacheReady = false;
			m_LatestAnimationTimeData.trackTime += deltaTime * timeScale;

			if (supportCache)
			{
				var current = state?.GetCurrent(0);

				if (current != null  && cacheEntry != null)
				{
					cacheEntry.GetRasterizedTimeData(this, current.animation.name, 
						m_LatestAnimationTimeData.trackTime, out var currentOrNextTrackTime, 
						out var frame, out var frames);

					if (!float.IsNaN(currentOrNextTrackTime))
					{
						if (currentOrNextTrackTime >= 0.0f)
						{
							var currentMesh = cacheEntry.GetAnimationMesh(current.animation.name, frame, 
								out m_LatestAnimationTimeData.cacheReady);

							skeletonMeshFrame = frame;
						}

						deltaTime = Mathf.Max(0.0f, currentOrNextTrackTime - current.TrackTime);
						deltaTime /= Mathf.Abs(timeScale) > 1e-5 ? timeScale : 1.0f;
					}
				}
			}
#if UNITY_EDITOR && false  // 保存prefab，调试对比运行时mesh与缓存mesh区别
			else
			{
				var current = state?.GetCurrent(0);

				if (current != null && SkeletonMeshCacheDebug.MeshPool.Pool.Count == 0)
				{
					SkeletonMeshCacheDebug.MeshPool.Start = Time.time + (current.animation.duration - 1.0f / Application.targetFrameRate - current.AnimationTime);
					SkeletonMeshCacheDebug.MeshPool.Track = Mathf.CeilToInt(current.TrackTime);
					SkeletonMeshCacheDebug.MeshPool.Next();
				}

				var start = SkeletonMeshCacheDebug.MeshPool.Start;

				if (current != null && Time.time >= start && Time.time < start + current.animation.duration * SkeletonMeshCacheDebug.MeshPool.LoopCount)
				{
					var currentMesh = SkeletonMeshCacheDebug.MeshPool.Next();

					// 修改为struct后改调试功能暂时忽略
					//cachedMeshHandle.SetTarget(currentMesh);
				}
			}
#endif
		}


		/// <summary>Progresses the AnimationState according to the given deltaTime, and applies it to the Skeleton. Use Time.deltaTime to update manually. Use deltaTime 0 to update without progressing the time.</summary>
		public void Update (float deltaTime)
		{
			Profiler.BeginSample(skeletonDataAsset.profilerTag, this);

			// cacheEntry?.TryRecycleCacheOncePerFrame();
			SkeletonMeshCache.TryReleaseOldMeshCache();

			if (!valid || state == null)
			{
				Profiler.EndSample();
				return;
			}

			RatererizeTimeAndCheckCache(ref deltaTime);
			needUpdateInLate = false;
			scheduledLateUpdateFrameCount = Time.frameCount;

			if (updateMode < UpdateMode.OnlyAnimationStatus || m_LatestAnimationTimeData.cacheReady)
			{
				Profiler.EndSample();
				return;
			}
			// 更新animStatus但不执行下面的State.Apply会导致下次再appy时可能无法ApplyMixingFrom，进而残留前一个动画的附件
			UpdateAnimationStatus(deltaTime);	// 内部可能触发AddAnimation的动画

			if (updateMode == UpdateMode.OnlyAnimationStatus) {
				state.ApplyEventTimelinesOnly(skeleton, issueEvents: false);
			}
			else
			{
				ApplyAnimation(m_LatestAnimationTimeData.cacheReady);
			}

			Profiler.EndSample();
		}
		
		protected void UpdateAnimationStatus (float deltaTime) {
			deltaTime *= timeScale;
			skeleton.Update(deltaTime);

			state.Update(deltaTime);
		}

		protected void ApplyAnimation (bool cacheReady = false) {
			if (cacheReady)
			{
				state.ApplyEventTimelinesOnly(skeleton, issueEvents: true);
				return;
			}

			//if (!string.IsNullOrEmpty(latestAnimationTimeData.animation)) Debug.Log((Time.time - latestAnimationTimeData.start) % 1.0f);

#if UNITY_EDITOR
			if (skeletonMeshFrameCache.TryGetTarget(out var cache) && skeletonMeshFrame >= 0 &&
			    cache[skeletonMeshFrame].mesh is Mesh mesh && mesh != null && mesh.vertexCount == 0)
			{
				var t = cache[skeletonMeshFrame];
				t.time = Time.time;
				t.trackTime = (state.GetCurrent(0)?.trackTime).Value;
				t.animationTime = (state.GetCurrent(0)?.AnimationTime).Value;
				t.duration = (state.GetCurrent(0)?.animation.duration).Value;
				cache[skeletonMeshFrame] = t;
			}
#endif

			if (updateMode != UpdateMode.OnlyEventTimelines)
			{
				// DebugInfo3($"Apply, {AnimationName}, frame:{skeletonMeshFrame}");
				state.Apply(skeleton);
			}
			else
				state.ApplyEventTimelinesOnly(skeleton, issueEvents : true);

			if (_UpdateLocal != null)
				_UpdateLocal(this);

			skeleton.UpdateWorldTransform();

			if (_UpdateWorld != null) {
				_UpdateWorld(this);
				skeleton.UpdateWorldTransform();
			}

			if (_UpdateComplete != null) {
				_UpdateComplete(this);
			}
		}

		public override void LateUpdate () {
			Profiler.BeginSample(skeletonDataAsset.profilerTag, this);
			// instantiation can happen from Update() after this component, leading to a missing Update() call.
			if (needUpdateInLate) Update(0);

			if (scheduledLateUpdateFrameCount == Time.frameCount || scheduledLateUpdateFrameCount == -1)
			{
				base.LateUpdate();

				// 潜在时序问题，必须在帧尾修改状态
				// m_SupportCache = state != null && state.GetCurrent(0) != null && !state.Mixing;
			}
			Profiler.EndSample();
		}

		public override void OnBecameVisible () {
			RegisterCache();

			UpdateMode previousUpdateMode = updateMode;
			updateMode = UpdateMode.FullUpdate;

			// OnBecameVisible is called after LateUpdate()
			if (previousUpdateMode != UpdateMode.FullUpdate &&
				previousUpdateMode != UpdateMode.EverythingExceptMesh)
				Update(0);
			if (previousUpdateMode != UpdateMode.FullUpdate)
				LateUpdate();
		}

		[System.Diagnostics.Conditional("DEBUG_ANIM_PLAY")]
		void DebugInfo3(string info)
		{
			Profiler.BeginSample("DebugInfo3");
			if (skeletonDataAsset.name.ToLower().Contains("archer"))
			{
				var s = StackTraceUtility.ExtractStackTrace();	// 多占时间
				Debug.LogError($"{Time.frameCount}: {skeletonDataAsset.name} , {info}, {m_SupportCache}");
			}

			Profiler.EndSample();
			
		}
	}

}
