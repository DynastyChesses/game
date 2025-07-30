using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class BakedAnimationPlayer : MonoBehaviour
{
	class RuntimeClipContext
	{
		public float speed = 1.0f;
	}

	private static BakedAnimationUpdateFacade _updateManager = null;

	[HideInInspector]
	public string defaultClip;

//	[NonSerialized]
//	public bool calculateNormal;

	public BakedAnimationClip[] clips;

	public BakedAnimationModel model;

	private float _currentTime = 0;
	private MeshFilter _filter;
	private BakedAnimationClip _currentClip;
	public BakedAnimationClip currentClip
	{
		get { return _currentClip; }
	}
	private BakedFrameInfo[] _currentFrames;
	private float _currentFps;
	private BakedFrameInfo _lastFrame;
	public BakedFrameInfo currentFrame
	{
		get { return _lastFrame; }
	}
	private int _currentFrameLen;
	private bool _currentLoop = true;
	private RuntimeClipContext _currentContext;
	private Dictionary<string, BakedAnimationClip> _clipMap;
	private Dictionary<string, RuntimeClipContext> _contextMap;
	private bool _isPlaying = true;
	// Use this for initialization
	void Awake ()
	{
//		this.calculateNormal = true;
		this.enabled = true;
#if UNITY_EDITOR
		if (Application.isPlaying)
		{
#endif
			if (!_updateManager)
			{
				GameObject aniObj = new GameObject("BakedAnimationUpdateManager");
				_updateManager = aniObj.AddComponent<BakedAnimationUpdateFacade>();
			}
			_updateManager.updateEvent += DoUpdate;
#if UNITY_EDITOR
		}
		else
		{
			DoInitialize();
		}
#endif
	}


	void DoInitialize()
	{
		_clipMap = new Dictionary<string, BakedAnimationClip>();
		int totalClipCount = clips != null ? clips.Length : 0;
		if (string.IsNullOrEmpty(defaultClip) && totalClipCount > 0 && clips[0] != null)
		{
			defaultClip = clips[0].clipName;
		}
		for (int i = 0; i < totalClipCount; ++i)
		{
			BakedAnimationClip clip = clips[i];
			if (clip != null)
			{
				if (clip.clipName == defaultClip)
				{
					_currentClip = clip;
					_currentFrames = clip.frames;
					_currentFps = clip.fps;
					_currentLoop = clip.loop;
					_currentFrameLen = _currentFrames.Length;
					_currentContext = GetContext(clip.clipName);
					_currentContext.speed = clip.speed;
				}
				_clipMap.Add(clip.clipName, clip);
			}
		}

		GenerateMesh();
	}

	void GenerateMesh()
	{
		if (_currentClip != null && model != null)
		{
//			_currentMesh = new Mesh();
//			_currentMesh.vertices = _currentClip.frames[0].vertices;
//			_currentMesh.uv = uv;
//			_currentMesh.triangles = triangles;

			_filter = GetComponent<MeshFilter>();

			BakedFrameInfo frame = _lastFrame = _currentClip.frames[0];
			Mesh mesh = frame.mesh;
			if (!frame.mesh)
			{
				mesh = new Mesh();
				mesh.vertices = frame.vertices;
				mesh.uv = model.uv;
				mesh.triangles = model.triangles;
				int subLen = model.subMeshTriangles != null ? model.subMeshTriangles.Length : 0;
				if (subLen > 0)
				{
					mesh.subMeshCount = subLen;
					for (int i = 0; i < subLen; ++i)
					{
						mesh.SetTriangles(model.subMeshTriangles[i].triangles, i);
					}
				}
//				if (calculateNormal)
//				{
//					mesh.RecalculateNormals();
//				}
				frame.mesh = mesh;
				BakedAnimationUpdateFacade.allMeshes.Add(mesh);
			}
			_filter.sharedMesh = mesh;
		}
	}

#if UNITY_EDITOR
	public void ValidateClipMap()
	{
		int clipLen = clips != null ? clips.Length : 0;
		int clipCount = _clipMap != null ? _clipMap.Count : 0;

		if (clipLen != clipCount)
		{
			_clipMap = _clipMap ?? new Dictionary<string, BakedAnimationClip>();
			_clipMap.Clear();
			for (int i = 0; i < clipLen; ++i)
			{
				BakedAnimationClip clip = clips[i];
				if (clip != null)
				{
					if (clip.clipName == defaultClip)
					{
						_currentClip = clip;
						_currentFrames = clip.frames;
						_currentFps = clip.fps;
						_currentFrameLen = _currentFrames.Length;
						_currentContext = GetContext(clip.clipName);
						_currentContext.speed = clip.speed;
					}
					_clipMap.Add(clip.clipName, clip);
				}
			}
		}
	}

	public void SetCurrentFrame(int index)
	{
		if (!_filter)
		{
			return;
		}
		if (_currentClip != null)
		{
			_lastFrame = _currentClip.frames[index];
			Mesh mesh = _lastFrame.mesh;
			if (!mesh)
			{
				mesh = new Mesh();
				mesh.vertices = _lastFrame.vertices;
				mesh.uv = model.uv;
				mesh.triangles = model.triangles;
				if (model.subMeshTriangles != null && model.subMeshTriangles.Length > 0)
				{
					mesh.subMeshCount = model.subMeshTriangles.Length;
					for (int i = 0; i < model.subMeshTriangles.Length; ++i)
					{
						mesh.SetTriangles(model.subMeshTriangles[i].triangles, i);
					}
				}
//				if (calculateNormal)
//				{
//					mesh.RecalculateNormals();
//				}
				_lastFrame.mesh = mesh;
				BakedAnimationUpdateFacade.allMeshes.Add(mesh);
			}
			_filter.sharedMesh = mesh;
		}
	}
#endif

	public BakedAnimationClip GetClip(string clipName)
	{
		if (_clipMap != null)
		{
			BakedAnimationClip clip;
			_clipMap.TryGetValue(clipName, out clip);
			return clip;
		}

		int count = clips != null ? clips.Length : 0;
		for (int i = 0; i < count; ++i)
		{
			if (clips[i] != null && clips[i].clipName == clipName)
			{
				return clips[i];
			}
		}
		return null;
	}

	private RuntimeClipContext GetContext(string clipName)
	{
		_contextMap = _contextMap ?? new Dictionary<string, RuntimeClipContext>();
		RuntimeClipContext context;
		if (!_contextMap.TryGetValue(clipName, out context))
		{
			context = new RuntimeClipContext();
			_contextMap.Add(clipName, context);
		}
		return context;
	}
	public void SetRuntimeClipSpeed(string clipName, float speed)
	{
		BakedAnimationClip clip = GetClip(clipName);
		RuntimeClipContext context = GetContext(clipName);
		context.speed = speed * clip.speed;
	}

	public float GetRuntimeClipSpeed(string clipName)
	{
		return GetContext(clipName).speed;
	}

	public float GetRuntimeClipLength(string clipName)
	{
		BakedAnimationClip clip = GetClip(clipName);
		return clip != null ? clip.length / GetContext(clipName).speed : 0;
	}

//	Mesh GetMesh(BakedFrameInfo frame)
//	{
//		Mesh mesh = frame.mesh;
//		if (!frame.mesh)
//		{
//			mesh = new Mesh();
//			mesh.vertices = frame.vertices;
//			mesh.uv = uv;
//			mesh.triangles = triangles;
//			frame.mesh = mesh;
//			BakedAnimationUpdateManager.allMeshes.Add(mesh);
//		}
//		return mesh;
//	}

	
	// Update is called once per frame
	void DoUpdate (float deltaTime)
	{
		if (!enabled)
		{
			return;
		}

		if (_clipMap == null)
		{
			DoInitialize();
		}

		if (_currentClip != null && model != null && _isPlaying)
		{
			_currentTime += deltaTime * _currentContext.speed;
			int frameIndex = _currentLoop ? ((int)(_currentTime * _currentFps)) % _currentFrameLen : Mathf.Clamp(((int)(_currentTime * _currentFps)), 0, _currentFrameLen - 1);
			BakedFrameInfo currentFrame = _currentFrames[frameIndex];
			if (_lastFrame != currentFrame)
			{
				_lastFrame = currentFrame;
				Mesh mesh = currentFrame.mesh;
				if (!mesh)
				{
					mesh = new Mesh();
					mesh.vertices = currentFrame.vertices;
					mesh.uv = model.uv;
					mesh.triangles = model.triangles;
					int subLen = model.subMeshTriangles != null ? model.subMeshTriangles.Length : 0;
					if (subLen > 0)
					{
						mesh.subMeshCount = subLen;
						for (int i = 0; i < subLen; ++i)
						{
							mesh.SetTriangles(model.subMeshTriangles[i].triangles, i);
						}
					}

//					if (calculateNormal)
//					{
//						mesh.RecalculateNormals();
//					}
					currentFrame.mesh = mesh;
					BakedAnimationUpdateFacade.allMeshes.Add(mesh);
				}
				_filter.sharedMesh = mesh;
			}
		}
	}

	void OnDestroy()
	{
#if UNITY_EDITOR
		if (Application.isPlaying)
		{
#endif
			if (_updateManager)
			{
				_updateManager.updateEvent -= DoUpdate;
			}
			if (_clipMap != null)
			{
				_clipMap.Clear();
				_clipMap = null;
			}
			_currentClip = null;

//			if (_currentMesh)
//			{
//				Destroy(_currentMesh);
//				_currentMesh = null;
//			}
			_lastFrame = null;
#if UNITY_EDITOR
		}
#endif
	}

	public void Play(string clipName, float time = 0)
	{
		if (_clipMap == null)
		{
			defaultClip = clipName;
			_currentTime = time;
			_isPlaying = true;
		}
		else if ((_currentClip != null && _currentClip.clipName == clipName) || _clipMap.TryGetValue(clipName, out _currentClip))
		{
			_currentContext = GetContext(clipName);
            _currentContext.speed = _currentClip.speed;
			_currentFrames = _currentClip.frames;
			_currentFps = _currentClip.fps;
			_currentFrameLen = _currentFrames.Length;
			_currentLoop = _currentClip.loop;
			if (!_filter)
			{
				GenerateMesh();
			}
			_currentTime = time;
			_isPlaying = true;
		}
	}

	public void Stop()
	{
		_isPlaying = false;
		_currentTime = 0;
	}

	public void Pause()
	{
		_isPlaying = false;
	}

	public void Resume()
	{
		_isPlaying = true;
	}

//	public 
}
