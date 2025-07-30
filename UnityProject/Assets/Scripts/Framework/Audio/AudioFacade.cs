using UnityEngine;
using System.Collections.Generic;

public class AudioFacade: Singleton<AudioFacade>
{
	public bool IsMusicOn { get; set; }
	public bool IsSoundOn { get; set; }
	
	private Transform _audioManger;
	private static AudioFacade _instance = new AudioFacade();
	private List<AudioSource> sources = new List<AudioSource>();
	private Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();
	private Dictionary<string, AudioSource> map_sources = new Dictionary<string, AudioSource>();
	private List<int> intervals = new List<int>();

	private void InitAudioManager()
	{
		if (_audioManger == null)
		{
			_audioManger = ResourceFacade.NewGameObject("Audio Manager").transform;
			_audioManger.gameObject.AddComponent<AudioListener>();
			GameObject.DontDestroyOnLoad(_audioManger); 
		}
	}


	public string AudioIdToPath(string audioId)
	{
		if (!audioId.Contains("."))
		{
			return $"Assets/Arts/Audios/{audioId}.mp3";
		}
		else
		{
			return $"Assets/Arts/Audios/{audioId}";
		}
	}
	
	// 播放
	public void PlayClip(string audioId, bool loop, float volume = 1.0f)
	{
		var audioPath = AudioIdToPath(audioId);
		if (audios.ContainsKey(audioPath))
		{
			// 直接播放
			if (sources.Count == 0)
			{
				RequestHandle();
			}

			AudioSource source = null;
			if (!map_sources.ContainsKey(audioPath))
			{
				source = sources[0];
				sources.RemoveAt(0);
			}
			else
			{
				source = map_sources[audioPath];
			}
			source.clip = audios[audioPath];
			source.Play();
			source.loop = loop;
			source.volume = volume;
			if (source.clip.name == "Bgm_Fever1_13s" || source.clip.name == "Bgm_Main")
			{
				if (!IsMusicOn)
					source.volume = 0f;
			}
			else
			{
				if(!IsSoundOn)
					source.volume = 0f;
			}
			
			map_sources[audioPath] = source;
			if (!loop)
			{
				// 等待关闭
				int interval = EquineScheduler.INVALID;
				interval = EquineScheduler.CallOnce(source.clip.length, (a, b, c) =>
				{
					EquineScheduler.RemoveLimitUpdator(ref interval);
					intervals.Remove(interval);
					// 
					if (map_sources.ContainsKey(audioPath))
					{
						var oldSource = map_sources[audioPath];
						sources.Add(oldSource);
						map_sources.Remove(audioPath);
						oldSource = null;
					}
				});
				intervals.Add(interval);
			}
		}
		else
		{
			var req = ResourceFacade.instance.LoadObjectAsync<AudioClip>(audioPath);
			req.callback = request =>
			{
				// 进入缓存, 调用PlayClip
				if (request.asset != null)
				{
					audios[audioPath] = request.asset as AudioClip;
					PlayClip(audioId, loop);
					request.Dispose();
					request = null;
				}
				else
				{
					Debug.LogError($"[SOUND] ERROR!" + audioPath);
				}
			};
		}
	}

	public void StopClip(string audioId)
	{
		var audioPath = AudioIdToPath(audioId);
		if (map_sources.ContainsKey(audioPath))
		{
			var oldSource = map_sources[audioPath];
			oldSource.Stop();
			oldSource.clip = null;
			oldSource.loop = false;
			sources.Add(oldSource);
			map_sources.Remove(audioPath);
			oldSource = null;
		}
	}

	public void SetMusicOn(bool isMusicOn)
	{
		foreach (var audioSource in map_sources.Values)
		{
			if(audioSource.clip.name == "Bgm_Main" || audioSource.clip.name == "Bgm_Fever1_13s")
				audioSource.volume = isMusicOn ? 1f : 0f;
		}
	}

	public void SetSoundOn(bool isSoundOn)
	{
		foreach (var audioSource in map_sources.Values)
		{
			if(audioSource.clip.name == "Bgm_Main" || audioSource.clip.name == "Bgm_Fever1_13s")
				continue;
			
			audioSource.volume = isSoundOn ? 1f : 0f;
		}
	}

	private void RequestHandle()
	{
		InitAudioManager();
		GameObject sourceObject = ResourceFacade.NewGameObject("AudioSource");
		sourceObject.transform.SetParent(_audioManger);
		sourceObject.transform.localPosition = Vector3.zero;
		AudioSource source = sourceObject.AddComponent<AudioSource>();
		source.loop = false;
		source.dopplerLevel = 0;
		source.spread = 180;
		source.minDistance = 0;
		source.maxDistance = 50;
		source.rolloffMode = AudioRolloffMode.Linear;
		sources.Add(source);
	}

	public override void Dispose()
	{
		// TODO
	}
}
