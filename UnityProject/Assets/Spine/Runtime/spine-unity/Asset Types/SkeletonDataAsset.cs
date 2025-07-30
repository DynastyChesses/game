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

using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Profiling;
using static Spine.SkeletonData;
using CompatibilityProblemInfo = Spine.Unity.SkeletonDataCompatibility.CompatibilityProblemInfo;

namespace Spine.Unity {

	[CreateAssetMenu(fileName = "New SkeletonDataAsset", menuName = "Spine/SkeletonData Asset")]
	public class SkeletonDataAsset : ScriptableObject {
		#region Inspector
		public AtlasAssetBase[] atlasAssets = new AtlasAssetBase[0];

		#if SPINE_TK2D
		public tk2dSpriteCollectionData spriteCollection;
		public float scale = 1f;
		#else
		public float scale = 0.01f;
		#endif
		public TextAsset skeletonJSON;
		protected byte[] _cachedSkeletonJSONBytes;
		protected byte[] skeletonJSONBytes 
		{
			get
			{
				byte[] res = null;
				Profiler.BeginSample("skeletonJSONBytes");
				if (SpineRuntimeCfg.LazyLoadingEnabled)
				{
					// 避免延迟解析动画时每次解析都创建bytes数组，对其进行缓存
					if (_cachedSkeletonJSONBytes == null)
						_cachedSkeletonJSONBytes = skeletonJSON.bytes;
					res = _cachedSkeletonJSONBytes;
				}
				else
				{
					res = skeletonJSON.bytes;
				}
				Profiler.EndSample();
				return res;
			}
		}
		

		[Tooltip("Use SkeletonDataModifierAssets to apply changes to the SkeletonData after being loaded, such as apply blend mode Materials to Attachments under slots with special blend modes.")]
		public List<SkeletonDataModifierAsset> skeletonDataModifiers = new List<SkeletonDataModifierAsset>();

		[SpineAnimation(includeNone: false)]
		public string[] fromAnimation = new string[0];
		[SpineAnimation(includeNone: false)]
		public string[] toAnimation = new string[0];
		public float[] duration = new float[0];
		public float defaultMix;
		public RuntimeAnimatorController controller;

		[SerializeField]
		internal string headersHash = string.Empty;
		[SerializeField]
		internal List<AnimationHeaderEntry> headers;

		public bool IsLoaded { get { return this.skeletonData != null; } }

		string m_ProfilerTag = string.Empty;
		internal string profilerTag
		{
			get
			{
				if (string.IsNullOrEmpty(m_ProfilerTag))
				{
					m_ProfilerTag = name.LastIndexOf('_') > 0 ? name.Substring(0, name.LastIndexOf('_')) : name;
				}

				return !string.IsNullOrEmpty(m_ProfilerTag) ? m_ProfilerTag : "empty";
			}
		}

		void Reset () {
			Clear();
		}
		#endregion

		SkeletonData skeletonData;
		AnimationStateData stateData;

		#region Runtime Instantiation
		/// <summary>
		/// Creates a runtime SkeletonDataAsset.</summary>
		public static SkeletonDataAsset CreateRuntimeInstance (TextAsset skeletonDataFile, AtlasAssetBase atlasAsset, bool initialize, float scale = 0.01f) {
			return CreateRuntimeInstance(skeletonDataFile, new [] {atlasAsset}, initialize, scale);
		}

		/// <summary>
		/// Creates a runtime SkeletonDataAsset.</summary>
		public static SkeletonDataAsset CreateRuntimeInstance (TextAsset skeletonDataFile, AtlasAssetBase[] atlasAssets, bool initialize, float scale = 0.01f) {
			SkeletonDataAsset skeletonDataAsset = ScriptableObject.CreateInstance<SkeletonDataAsset>();
			skeletonDataAsset.Clear();
			skeletonDataAsset.skeletonJSON = skeletonDataFile;
			skeletonDataAsset.atlasAssets = atlasAssets;
			skeletonDataAsset.scale = scale;

			if (initialize)
				skeletonDataAsset.GetSkeletonData(true);

			return skeletonDataAsset;
		}
		#endregion

		/// <summary>Clears the loaded SkeletonData and AnimationStateData. Use this to force a reload for the next time GetSkeletonData is called.</summary>
		public void Clear () {
			skeletonData = null;
			stateData = null;
		}

		public AnimationStateData GetAnimationStateData () {
			if (stateData != null)
				return stateData;
			GetSkeletonData(false);
			return stateData;
		}

		/// <summary>Loads, caches and returns the SkeletonData from the skeleton data file. Returns the cached SkeletonData after the first time it is called. Pass false to prevent direct errors from being logged.</summary>
		public SkeletonData GetSkeletonData (bool quiet) {
			if (skeletonJSON == null) {
				if (!quiet)
					Debug.LogError("Skeleton JSON file not set for SkeletonData asset: " + name, this);
				Clear();
				return null;
			}

			// Disabled to support attachmentless/skinless SkeletonData.
			//			if (atlasAssets == null) {
			//				atlasAssets = new AtlasAsset[0];
			//				if (!quiet)
			//					Debug.LogError("Atlas not set for SkeletonData asset: " + name, this);
			//				Clear();
			//				return null;
			//			}
			//			#if !SPINE_TK2D
			//			if (atlasAssets.Length == 0) {
			//				Clear();
			//				return null;
			//			}
			//			#else
			//			if (atlasAssets.Length == 0 && spriteCollection == null) {
			//				Clear();
			//				return null;
			//			}
			//			#endif

			if (skeletonData != null)
				return skeletonData;

			AttachmentLoader attachmentLoader;
			float skeletonDataScale;
			Atlas[] atlasArray = this.GetAtlasArray();

			#if !SPINE_TK2D
			attachmentLoader = (atlasArray.Length == 0) ? (AttachmentLoader)new RegionlessAttachmentLoader() : (AttachmentLoader)new AtlasAttachmentLoader(atlasArray);
			skeletonDataScale = scale;
			#else
			if (spriteCollection != null) {
				attachmentLoader = new Spine.Unity.TK2D.SpriteCollectionAttachmentLoader(spriteCollection);
				skeletonDataScale = (1.0f / (spriteCollection.invOrthoSize * spriteCollection.halfTargetHeight) * scale);
			} else {
				if (atlasArray.Length == 0) {
					Reset();
					if (!quiet) Debug.LogError("Atlas not set for SkeletonData asset: " + name, this);
					return null;
				}
				attachmentLoader = new AtlasAttachmentLoader(atlasArray);
				skeletonDataScale = scale;
			}
			#endif

			bool isBinary = skeletonJSON.name.ToLower().Contains(".skel");
			SkeletonData loadedSkeletonData = null;

			try {
				if (isBinary)
					loadedSkeletonData = ReadSkeletonData(skeletonJSONBytes, attachmentLoader, skeletonDataScale);
				else
					loadedSkeletonData = ReadSkeletonData(skeletonJSON.text, attachmentLoader, skeletonDataScale);
			} catch (Exception ex) {
				if (!quiet)
					Debug.LogError("Error reading skeleton JSON file for SkeletonData asset: " + name + "\n" + ex.Message + "\n" + ex.StackTrace, this);
			}

			#if UNITY_EDITOR
			if (loadedSkeletonData == null && !quiet && skeletonJSON != null) {
				SkeletonDataCompatibility.VersionInfo fileVersion = SkeletonDataCompatibility.GetVersionInfo(skeletonJSON);
				CompatibilityProblemInfo compatibilityProblemInfo = SkeletonDataCompatibility.GetCompatibilityProblemInfo(fileVersion);
				if (compatibilityProblemInfo != null) {
					SkeletonDataCompatibility.DisplayCompatibilityProblem(compatibilityProblemInfo.DescriptionString(), skeletonJSON);
					return null;
				}
			}
			#endif
			if (loadedSkeletonData == null)
				return null;

			loadedSkeletonData.loadAnimation = (animation) =>
			{
				return this.ReadAnimation(animation);
			};

			if (skeletonDataModifiers != null) {
				foreach (var m in skeletonDataModifiers) {
					if (m != null) m.Apply(loadedSkeletonData);
				}
			}

			this.InitializeWithData(loadedSkeletonData);

			return skeletonData;
		}

		public Animation ReadAnimation(string animation)
		{
			if (skeletonJSON == null) {
				Debug.LogError("Skeleton JSON file not set for SkeletonData asset: " + name, this);
				return null;
			}
			
			bool isBinary = skeletonJSON.name.ToLower().Contains(".skel");

			if (!isBinary)
			{
				Debug.LogError("Skeleton JSON file is not binary format for SkeletonData asset: " + name, this);
				return default;
			}

			Animation result = default;

			Profiler.BeginSample("LazyReadAnimation");
			Profiler.BeginSample(profilerTag);
			//for (int i = 0; i < 1; i++)
			{
				var binary = new SkeletonBinary() {
					Scale = scale
				};

				result = binary.ReadAnimation(skeletonData, skeletonJSONBytes, animation);
			}
			Profiler.EndSample();
			Profiler.EndSample();

			return result;
		}

		internal void InitializeWithData (SkeletonData sd) {
			this.skeletonData = sd;
			this.stateData = new AnimationStateData(skeletonData);
			FillStateData();
		}

		public void FillStateData () {
			if (stateData != null) {
				stateData.defaultMix = SpineRuntimeCfg.GlobalMixingEnabled ? defaultMix : 0;

				for (int i = 0, n = fromAnimation.Length; i < n; i++) {
					if (fromAnimation[i].Length == 0 || toAnimation[i].Length == 0)
						continue;
					stateData.SetMix(fromAnimation[i], toAnimation[i], duration[i]);
				}
			}
		}

		internal Atlas[] GetAtlasArray () {
			var returnList = new System.Collections.Generic.List<Atlas>(atlasAssets.Length);
			for (int i = 0; i < atlasAssets.Length; i++) {
				var aa = atlasAssets[i];
				if (aa == null) continue;
				var a = aa.GetAtlas();
				if (a == null) continue;
				returnList.Add(a);
			}
			return returnList.ToArray();
		}

		internal SkeletonData ReadSkeletonData (byte[] bytes, AttachmentLoader attachmentLoader, float scale) {
			using (var input = SpineRuntimeCfg.ParseAccelerateEnabled ? 
				       new MemoryStream(bytes, 0, bytes.Length, false, true) : 
				       new MemoryStream(bytes)) {
				SkeletonData result = new SkeletonData();
				
				//for (int i = 0; i < 1; i++)
				{
					UnityEngine.Profiling.Profiler.BeginSample("ReadSkeletonData");

					var binary = new SkeletonBinary(attachmentLoader) {
						Scale = scale
					};

					result.headersHash = headersHash;
					result.headers = headers;

					if (headers != null)
					{
						result.indices = new Dictionary<string, AnimationHeaderEntry>(headers.Count);

						for (int i = 0; i< headers.Count; i++)
						{
							result.indices[headers[i].animation] = headers[i];
						}
					}

					result = binary.ReadSkeletonData(input, result);

					UnityEngine.Profiling.Profiler.EndSample();

					input.Seek(0, SeekOrigin.Begin);
				}

				return result;
			}
		}

		internal static SkeletonData ReadSkeletonData (string text, AttachmentLoader attachmentLoader, float scale) {
			var input = new StringReader(text);
			var json = new SkeletonJson(attachmentLoader) {
				Scale = scale
			};
			return json.ReadSkeletonData(input);
		}

	}

}
