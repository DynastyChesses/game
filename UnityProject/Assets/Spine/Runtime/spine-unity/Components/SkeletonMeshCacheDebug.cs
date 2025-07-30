
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spine.Unity
{
	public class SkeletonMeshCacheDebug : MonoBehaviour
	{
		int size = 32;
		int oldScreenWidth = 0;

		GUIStyle m_Style = null;
		GUILayoutOption m_ButtonWidth = null;

		string m_CurrentGroup = string.Empty;
		Vector2 m_ScrollPosition = Vector2.zero;
		GameObject target;
		SkeletonAnimation skeletonAnimation;
		MeshFilter meshFilter;

		float mixingStart = 0.0f;
		float mixingStop = 0.0f;

		[ShowInInspector]
		[OnValueChanged("UpdateTimeScale")]
		[Range(0.05f, 1.0f)]
		float m_TimeScale = 1.0f;
		float m_TimeScaleOld = float.NaN;

		[ShowInInspector]
		[OnValueChanged("UpdateTimeScale")]
		[Range(1, 120)]
		int m_FrameRate = 60;
		int m_FrameRateOld = -1;

		List<string> m_AnimationPlayOrder { get; } = new List<string>();

		public static class MeshPool
		{
			public static readonly int LoopCount = 30;

			internal static List<MeshEntry> Pool = new List<MeshEntry>(60 * LoopCount);

			internal static MeshEntry Next()
			{
				Pool.Add(new MeshEntry());

				return Pool[Pool.Count - 1];
			}

			public static void Clear()
			{
				foreach (var sm in Pool)
				{
					sm.Clear();
				}

				Pool.Clear();
			}

			public static float Start = 0.0f;
			public static float Track = 0.0f;
		}

		void UpdateTimeScale()
		{
			Time.timeScale = m_TimeScale;
			Application.targetFrameRate = m_FrameRate;
		}

		[ShowInInspector]
		bool m_AutoPauseAfterSpawn = false;

		[ShowInInspector]
		bool m_ShowDebugDetail = false;

		[ShowInInspector]
		float generateGameObjectInterval = 1.0f;
		[ShowInInspector]
		int generateGameObjectCount = 60;

		[Button("Low Memory Callback")]
		void LowMemoryCallback()
		{
			SkeletonMeshCache.LowMemoryCallback();

			MeshPool.Clear();
		}

#if UNITY_EDITOR
		[ShowInInspector]
		[InlineButton("GenerateGameObject")]
		GameObject skeletonMeshCacheRoot;

		void GenerateGameObject()
		{
			if (skeletonMeshCacheRoot != null)
			{
				Destroy(skeletonMeshCacheRoot);
				skeletonMeshCacheRoot = null;
			}

			if (SpineRuntimeCfg.SkeletonMeshCacheEnabled)
			{
				GenerateGameObjectByCache();
			}
			else
			{
				GenerateGameObjectByRuntime();
			}
		}

		void GenerateGameObjectByCache()
		{
			if (!skeletonAnimation.skeletonMeshCacheEntry.TryGetTarget(out var entry))
			{
				return;
			}

			skeletonMeshCacheRoot = new GameObject("skeleton_mesh_cache");

			foreach (var animationkv in entry)
			{
				var first = true;

				var go = new GameObject(animationkv.Key);
				go.transform.parent = skeletonMeshCacheRoot.transform;

				for (int i = 0; i < animationkv.Value.entries.Length; i++)
				{
					var mesh = new GameObject(i.ToString());
					mesh.transform.parent = go.transform;

					var distance = animationkv.Value[i].animationTime * SpineRuntimeCfg.MaxFrame;

					mesh.transform.position += Vector3.right * distance * generateGameObjectInterval / ((float)SpineRuntimeCfg.MaxFrame / Mathf.Max(generateGameObjectCount, animationkv.Value.entries.Length));

					mesh.AddComponent<MeshRenderer>();
					var filter = mesh.AddComponent<MeshFilter>();
					filter.sharedMesh = animationkv.Value[i].mesh;

					//mesh.SetActive(first);

					first = false;
				}
			}
		}

		void GenerateGameObjectByRuntime()
		{
			skeletonMeshCacheRoot = new GameObject("skeleton_mesh_runtime");

			foreach (var animation in new[] { skeletonAnimation.AnimationState.GetCurrent(0).animation.name })
			{
				var first = true;

				var go = new GameObject(animation);
				go.transform.parent = skeletonMeshCacheRoot.transform;

				for (int i = 0; i < MeshPool.Pool.Count; i++)
				{
					var sm = MeshPool.Pool[i];

					if (sm.mesh.vertexCount == 0)
					{
						continue;
					}

					var mesh = new GameObject(i.ToString());
					mesh.transform.parent = go.transform;

					var trackTime = sm.trackTime - MeshPool.Track;

					var offset = Vector3.zero;
					offset.x = trackTime % sm.duration * Application.targetFrameRate / ((float)Application.targetFrameRate / Mathf.Max(generateGameObjectCount, Application.targetFrameRate));
					offset.y = -(Mathf.CeilToInt(trackTime / sm.duration) + 1);

					mesh.transform.position += offset * generateGameObjectInterval;

					mesh.AddComponent<MeshRenderer>();
					var filter = mesh.AddComponent<MeshFilter>();
					filter.sharedMesh = MeshPool.Pool[i].mesh;

					//mesh.SetActive(first);

					first = false;
				}
			}

		}

		[ShowInInspector]
		[InlineButton("SaveGeneratedGameObject", "Save")]
		string skeletonMeshCacheFile = "Assets/Spine/Runtime/spine-cache-test/spine_skeleton_mesh_cache_generated.prefab";
		void SaveGeneratedGameObject()
		{
			if (skeletonMeshCacheRoot == null)
			{
				return;
			}

			var mfs = skeletonMeshCacheRoot.GetComponentsInChildren<MeshFilter>(true);

			// backup
			Dictionary<string, Mesh> meshes = new Dictionary<string, Mesh>(60);
			foreach (var mf in mfs)
			{
				meshes.Add(mf.name, mf.sharedMesh);
			}

			Dictionary<Mesh, HideFlags> flags = new Dictionary<Mesh, HideFlags>(60);
			foreach (var mf in mfs)
			{
				flags.Add(mf.sharedMesh, mf.sharedMesh.hideFlags);
				mf.sharedMesh.hideFlags = HideFlags.None;
			}

			// save
			if (File.Exists(skeletonMeshCacheFile))
			{
				File.Delete(skeletonMeshCacheFile);
			}

			UnityEditor.PrefabUtility.SaveAsPrefabAsset(skeletonMeshCacheRoot, skeletonMeshCacheFile);

			var prefab = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(skeletonMeshCacheFile);

			mfs = prefab.GetComponentsInChildren<MeshFilter>(true);

			foreach (var mf in mfs)
			{
				mf.sharedMesh = meshes[mf.name];
				UnityEditor.AssetDatabase.AddObjectToAsset(mf.sharedMesh, skeletonMeshCacheFile);
			}

			UnityEditor.AssetDatabase.SaveAssets();
			UnityEditor.AssetDatabase.Refresh();

			// recovery
			foreach (var flagkv in flags)
			{
				flagkv.Key.hideFlags = flagkv.Value;
			}

			meshes.Clear();
			flags.Clear();

			//if (!File.Exists(skeletonMeshCacheFile))
			//{
			//	PrefabUtility.SaveAsPrefabAssetAndConnect(gameObject, skeletonMeshCacheFile, InteractionMode.AutomatedAction);
			//}

			//var meshAsset = AssetDatabase.LoadAssetAtPath(PrefabPskeletonMeshCacheFileath, typeof(Mesh));
			//if (meshAsset != null)
			//{
			//	AssetDatabase.RemoveObjectFromAsset(meshAsset);
			//}

			//AssetDatabase.AddObjectToAsset(mesh, skeletonMeshCacheFile);

			//Object prefab = AssetDatabase.LoadAssetAtPath(skeletonMeshCacheFile, typeof(GameObject));
			//GameObject instance = (GameObject)PrefabUtility.InstantiatePrefab(prefab);
			//instance.GetComponentInChildren<MeshFilter>(true).mesh = mesh;
			//PrefabUtility.SaveAsPrefabAsset(instance, skeletonMeshCacheFile);
			//Object.DestroyImmediate(instance);
		}
#endif

		[ShowInInspector]
		[InlineButton("SaveIndexBuffer")]
		string IndexBufferFileName = "index_buffer_with_cache";

		void SaveIndexBuffer()
		{
			StringBuilder sb = new StringBuilder(10240);

			var mesh = meshFilter.sharedMesh;

			var indices = mesh.GetIndices(0);

			for (var i = mesh.GetIndexStart(0); i < mesh.GetIndexCount(0) - 2; i += 3)
			{
				sb.Append(indices[i]).Append("\t").Append(indices[i + 1]).Append("\t").Append(indices[i + 2]).AppendLine();
			}

			File.WriteAllText(IndexBufferFileName, sb.ToString());
		}

		void Awake()
		{
			m_TimeScaleOld = Time.timeScale;
			m_FrameRateOld = Application.targetFrameRate;
		}

		private void OnEnable()
		{
			UpdateTimeScale();

			//StartCoroutine(CoroutinePrintFrame());
		}

		private void OnDisable()
		{
			if (!float.IsNaN(m_TimeScaleOld) && m_TimeScaleOld > 0.0f)
			{
				Time.timeScale = m_TimeScaleOld;
			}

			Application.targetFrameRate = m_FrameRateOld;

			//StopAllCoroutines();
		}

		private void Update()
		{
			if (SpineRuntimeCfg.SkeletonMeshCacheEnabled)
			{
				MeshPool.Clear();
			}

			timeTotal += Time.deltaTime;
		}

		float timeTotal = 0.0f;

		// 目标帧率30的时候，Unity 2019每5秒左右会比目标帧数少1（2022 测试正常，暂不清楚哪个版本修复的）
		// 对Spine的loop动画来讲，更新并不完全一致，蝴蝶资源闪烁的问题，大抵由此
		// 缓存是绝对平均的，且一次性的，就可能正好命中了跨越幅度较大的一些帧，看起来像是飞的特别快，加速了，其实并没有
		// 给缓存加个偏移时间（0.5 * interval），验证通过
		IEnumerator CoroutinePrintFrame()
		{
			Debug.Log($"time {Time.time} total {timeTotal} frame {Time.frameCount}");

			while (true)
			{
				yield return new WaitForSeconds(5.0f);

				Debug.Log($"time {Time.time} total {timeTotal} frame {Time.frameCount}");
			}
		}

		void SetTarget(GameObject go)
		{
			if (target != null && target != gameObject)
			{
#if UNITY_EDITOR
				Destroy(target);
#else
				DestroyImmediate(target);
#endif
			}

			if (go == null)
			{
				return;
			}

			target = Instantiate(go);
			target.SetActive(true);

			if (target != null)
			{
				skeletonAnimation = target.GetComponentInChildren<SkeletonAnimation>();
				meshFilter = target.GetComponentInChildren<MeshFilter>();
			}

			if (target.name.StartsWith("sushe"))
			{
				skeletonAnimation.Initialize(false);
				skeletonAnimation.AnimationState.SetAnimation(0, "chusheng", false);
				skeletonAnimation.AnimationState.AddAnimation(0, "daiji", true, 0f);
			}

#if UNITY_EDITOR
			if (m_AutoPauseAfterSpawn)
			{
				UnityEditor.EditorApplication.isPaused = true;
			}
#endif
		}

		#region 测试攻击动画切换待机动画时，待机动作首帧显示的是攻击动作0.2s左右（混合结束）的画面问题
		Coroutine m_CoroutineTestSwitch;

		IEnumerator CoroutineTestAutoSwitch(float t)
		{
			skeletonAnimation.AnimationState.SetAnimation(0, "idle", false);

			yield return new WaitForSeconds(1.0f);

			skeletonAnimation.AnimationState.SetAnimation(0, "attack", false);

			skeletonAnimation.AnimationState.Complete += RestartCoroutineTestAutoSwitch;
		}

		void RestartCoroutineTestAutoSwitch(TrackEntry trackEntry)
		{
			if (trackEntry == null)
			{
				if (m_CoroutineTestSwitch != null)
				{
					StopCoroutine(m_CoroutineTestSwitch);

					m_CoroutineTestSwitch = null;
				}

				return;
			}

			if (trackEntry.animation.name == "attack")
			{
				skeletonAnimation.AnimationState.Complete -= RestartCoroutineTestAutoSwitch;

				m_CoroutineTestSwitch = StartCoroutine(CoroutineTestAutoSwitch(0.0f));
			}
		}
		#endregion

		#region 测试每帧设置相同动作，帧率限制到10fps进行测试
		bool m_SetSameAnimation = false;
		bool m_SetDiffAnimation = false;
		Coroutine m_SetAnimationEveryFrameCoroutine;

		void SetAnimationEveryFrame(bool same, bool diff)
		{
			m_SetSameAnimation = same && !diff;
			m_SetDiffAnimation = diff;

			if (m_SetSameAnimation || m_SetDiffAnimation)
			{
				if (m_SetAnimationEveryFrameCoroutine == null)
				{
					m_SetAnimationEveryFrameCoroutine = StartCoroutine(CoroutineSetAnimationEveryFrame());
				}
			}
			else
			{
				if (m_SetAnimationEveryFrameCoroutine != null)
				{
					StopCoroutine(m_SetAnimationEveryFrameCoroutine);
					m_SetAnimationEveryFrameCoroutine = null;
				}
			}
		}

		IEnumerator CoroutineSetAnimationEveryFrame()
		{
			if (m_SetSameAnimation || m_SetDiffAnimation)
			{
				yield return new WaitForEndOfFrame();

				// 通过 Time.deltaTime > 0 规避暂停时鼠标移动会驱动帧率更新问题
				if (skeletonAnimation != null && m_AnimationPlayOrder.Count > Convert.ToInt32(m_SetDiffAnimation) && Time.deltaTime > 0)
				{
					skeletonAnimation.AnimationState.SetAnimation(0, "idle", true);
					skeletonAnimation.AnimationState.SetAnimation(0, m_AnimationPlayOrder[m_AnimationPlayOrder.Count - 1], true);
				}
			}

			if (m_SetDiffAnimation)
			{
				yield return new WaitForEndOfFrame();

				if (skeletonAnimation != null && m_AnimationPlayOrder.Count > 1 && Time.deltaTime > 0)
				{
					skeletonAnimation.AnimationState.SetAnimation(0, m_AnimationPlayOrder[m_AnimationPlayOrder.Count - 2], true);
				}
			}

			if (m_SetSameAnimation || m_SetDiffAnimation)
			{
				m_SetAnimationEveryFrameCoroutine = StartCoroutine(CoroutineSetAnimationEveryFrame());
			}
		}

		void OnMixingTimeGUI()
		{
			if (!m_SetSameAnimation && !m_SetDiffAnimation)
			{
				return;
			}

			if (skeletonAnimation == null)
			{
				return;
			}

			var current = skeletonAnimation.AnimationState.GetCurrent(0);

			if (current == null)
			{
				return;
			}

			GUILayout.BeginVertical();

			OnMixingTimeGUI(current);

			GUILayout.EndVertical();
		}

		void OnMixingTimeGUI(TrackEntry to, int tab = 0)
		{
			var from = to.mixingFrom;

			if (from == null)
			{
				return;
			}

			GUILayout.BeginHorizontal();

			GUILayout.Label($"{tab,2}", m_Style);
			GUILayout.Label($"mixing {to.mixTime,4:f4}", m_Style, GUILayout.Width(256));
			GUILayout.Label($"next {to.nextTrackLast,4:f4}", m_Style, GUILayout.Width(256));
			GUILayout.Label($"from ", m_Style);
			GUILayout.Label($"{from.animation.name}", m_Style, GUILayout.Width(128));
			GUILayout.Label($"to   ", m_Style);
			GUILayout.Label($"{to.animation.name}", m_Style, GUILayout.Width(128));
			//GUILayout.Label($"{new string(' ', tab)}", m_Style);

			GUILayout.EndHorizontal();

			OnMixingTimeGUI(from, tab + 1);
		}
		#endregion

		private void InitGUI()
		{
			if (oldScreenWidth != Screen.width)
			{
				oldScreenWidth = Screen.width;

				size = (int)(32.0f / 1080.0f * oldScreenWidth);

				ResetGUI();
			}

			if (m_Style == null)
			{
				m_Style = new GUIStyle(GUI.skin.button);
				m_Style.fontSize = size;
			}

			if (m_ButtonWidth == null)
			{
				m_ButtonWidth = GUILayout.Width(256.0f / 1080.0f * oldScreenWidth);
			}
		}

		private void ResetGUI()
		{
			m_Style = null;
			m_ButtonWidth = null;
		}

		private void OnGUI()
		{
			InitGUI();

			if (target == null)
			{
				GUILayout.BeginVertical();

				foreach (Transform child in transform)
				{
					if (GUILayout.Button(child.name, m_Style))
					{
						m_CurrentGroup = child.name;
						m_ScrollPosition = Vector2.zero;
					}

					if (m_CurrentGroup == child.name)
					{
						m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition, m_Style);

						foreach (Transform subchild in child)
						{
							if (GUILayout.Button(subchild.name, m_Style))
							{
								SetTarget(subchild.gameObject);
							}
						}

						GUILayout.EndScrollView();
					}
				}

				GUILayout.EndVertical();
			}

			if (skeletonAnimation != null)
			{
				SkeletonData skeletonData = skeletonAnimation.skeletonDataAsset.GetSkeletonData(false);

				GUILayout.BeginVertical();

				if (GUILayout.Button("Destory", m_Style))
				{
					RestartCoroutineTestAutoSwitch(null);

					SetTarget(null);

					LowMemoryCallback();

					m_AnimationPlayOrder.Clear();
				}

				if (GUILayout.Button("Test Auto Switch", m_Style))
				{
					RestartCoroutineTestAutoSwitch(null);

					m_CoroutineTestSwitch = StartCoroutine(CoroutineTestAutoSwitch(0.0f));
				}

				SetAnimationEveryFrame(
					GUILayout.Toggle(m_SetSameAnimation, "Test Same Animation", m_Style)
					, GUILayout.Toggle(m_SetDiffAnimation, "Test Diff Animation", m_Style)
					);


				for (int i = 0; i < skeletonData.animations.Count; i++)
				{
					var animation = skeletonData.animations.Items[i];

					GUILayout.BeginHorizontal();

					if (animation == null)
					{
						if (GUILayout.Button(skeletonData.headers[i].animation, m_Style, GUILayout.Width(256)) || GUILayout.Button($"load", m_Style, GUILayout.Width(64)))
						{
							skeletonAnimation.skeletonDataAsset.ReadAnimation(skeletonData.headers[i].animation);
						}

						GUILayout.EndHorizontal();

						continue;
					}

					if (GUILayout.Button(animation.name, m_Style, GUILayout.Width(256)))
					{
						RestartCoroutineTestAutoSwitch(null);

						skeletonAnimation.loop = true;

						mixingStart = Time.time;

						skeletonAnimation.AnimationName = animation.name;

						m_AnimationPlayOrder.Remove(animation.name);
						m_AnimationPlayOrder.Add(animation.name);
					}


					GUILayout.BeginVertical();
					if (m_ShowDebugDetail)
					{
						if (skeletonAnimation.AnimationName == animation.name)
						{
							TrackEntry trackEntry = skeletonAnimation.state?.GetCurrent(0);

							if (trackEntry != null)
							{
								//GUILayout.Label($"frame {Time.frameCount} mixing {mixingStop - mixingStart}", m_Style);
								// trackEntry.MixTime < trackEntry.MixDuration
								GUILayout.Label($"frame {Time.frameCount} mixing {skeletonAnimation.AnimationState.Mixing} cache {skeletonAnimation.supportCache} s{meshFilter.sharedMesh.subMeshCount} v{meshFilter.sharedMesh.vertexCount} i{meshFilter.sharedMesh.GetIndexCount(0)}", m_Style);

								if (trackEntry != null)
								{
									var mixingFromLength = 0;
									var from = trackEntry.mixingFrom;

									while (from != null)
									{
										mixingFromLength++;
										from = from.mixingFrom;
									}

									GUILayout.Label($"mixTime {trackEntry.MixTime,8:f4} mixDuration {trackEntry.MixDuration} alpha {trackEntry.alpha} mixFrom {mixingFromLength}", m_Style);
								}

								if (skeletonAnimation.state.Mixing)
								{
									mixingStop = Time.time;
								}
							}
						}
						else
						{
							GUILayout.Label(string.Empty);
						}
					}
					GUILayout.EndVertical();

					GUILayout.EndHorizontal();
				}
				GUILayout.EndVertical();

				OnMixingTimeGUI();

			}
		}
	}
}
