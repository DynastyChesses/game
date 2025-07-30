using System;
using UnityEngine;
using System.Collections.Generic;

public class AdvancedUnitySpritePack :MonoBehaviour
{
	[Serializable]
	public class SingleSpriteInfo
	{
		public string path;
		public Sprite sprite;
		public Vector3 pos;
		public Quaternion rotation;
		public Vector3 scale;

		[NonSerialized]
		public Material mat;

		// [NonSerialized]
		// public Matrix4x4 matrix;
	}	

	[Serializable]
	public class UnitySpriteGroup
	{
		public Material mat;
		public SingleSpriteInfo[] sprites;
	}

	public UnitySpriteGroup[] groups;

	private Dictionary<string, SingleSpriteInfo> _spriteMap = null;
	// private Dictionary<string, Material> _matMap = null;

#if UNITY_EDITOR
    private string[] _spriteNames = null;

    public string[] spriteNames
    {
        get
        {
            if (_spriteNames == null || _spriteNames.Length == 0)
            {
                if (_spriteMap == null)
                {
                    InitMap();    
                }
                int count = _spriteMap.Count;
				if (_spriteNames == null || count != _spriteNames.Length)
				{
                	_spriteNames = new string[count];
				}
                int index = 0;
                foreach(var pair in _spriteMap)
                {
                    _spriteNames[index] = pair.Key;
                    ++index;
                }
            }
            return _spriteNames;
        }
    }

	public List<string> GetListOfSprites (string match)
	{
		List<string> list = new List<string>();
		if (string.IsNullOrEmpty(match))
		{
			foreach(var name in spriteNames)
			{
				list.Add(name);
			}
			return list;
		}

		// First try to find an exact match
		for (int i = 0, imax = spriteNames.Length; i < imax; ++i)
		{
			string name = spriteNames[i];
			
			if (name != null && !string.IsNullOrEmpty(name) && string.Equals(match, name, StringComparison.OrdinalIgnoreCase))
			{
				list.Add(name);
				return list;
			}
		}

		// No exact match found? Split up the search into space-separated components.
		string[] keywords = match.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < keywords.Length; ++i) keywords[i] = keywords[i].ToLower();

		// Try to find all sprites where all keywords are present
		for (int i = 0, imax = spriteNames.Length; i < imax; ++i)
		{
			string name = spriteNames[i];
			
			if (name != null && !string.IsNullOrEmpty(name))
			{
				string tl = name.ToLower();
				int matches = 0;

				for (int b = 0; b < keywords.Length; ++b)
				{
					if (tl.Contains(keywords[b])) ++matches;
				}
				if (matches == keywords.Length) list.Add(name);
			}
		}
		return list;
	}
#endif

    void InitMap()
	{
		_spriteMap = _spriteMap ?? new Dictionary<string, SingleSpriteInfo>();
		// _matMap = _matMap ?? new Dictionary<string, Material>();
		int count = groups != null ? groups.Length : 0;

        for (int i = 0; i < count; ++i)
		{
			UnitySpriteGroup group = groups[i];
			Material mat =
#if UNITY_EDITOR
				new Material(group.mat);
#else
				group.mat;
#endif
            SingleSpriteInfo[] sprites = group != null ? group.sprites : null;
			int spCount = sprites != null ? sprites.Length : 0;
			for (int j = 0; j < spCount; ++j)
			{
				// if (group.mat != null)
				// {
				// 	_matMap.Add(sprites[j].path, mat);
				// }
				SingleSpriteInfo sp = sprites[j];
				sp.mat = mat;
				// sp.matrix = Matrix4x4.TRS(sp.pos, sp.rotation, sp.scale);
				_spriteMap.Add(sprites[j].path, sp);
			}
		}
	}

	public SingleSpriteInfo GetSprite(string prefabPath)
	{
		if (!string.IsNullOrEmpty(prefabPath))
		{
			if (_spriteMap == null)
			{
				InitMap();
			}
			SingleSpriteInfo sprite;
			if (_spriteMap.TryGetValue(prefabPath, out sprite))
			{
				return sprite;
			}
		}
		return null;
	}

	public bool HasSprite(string prefabPath)
	{
		if (!string.IsNullOrEmpty(prefabPath))
		{
			if (_spriteMap == null)
			{
				InitMap();
			}
			return _spriteMap.ContainsKey(prefabPath);
		}
		return false;
	}

	public Material GetSpriteMat(string spriteName)
	{
		if (!string.IsNullOrEmpty(spriteName))
		{
			if (_spriteMap == null)
			{
				InitMap();
			}
			SingleSpriteInfo sprite;
			if (_spriteMap.TryGetValue(spriteName, out sprite))
			{
				return sprite.mat;
			}
		}
		return null;
	}
}
