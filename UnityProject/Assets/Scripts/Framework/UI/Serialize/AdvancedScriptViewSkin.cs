using System;
using System.Collections.Generic;

public class AdvancedScriptViewSkin :ScriptViewSkin
{

	[System.Serializable]
	public class SkinSingleIntProperty
	{
		public string propName;
		public int propVal;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
		public bool generateScript = true;
	}

	[System.Serializable]
	public class SkinSingleFloatProperty
	{
		public string propName;
		public float propVal;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
		public bool generateScript = true;
	}

	[System.Serializable]
	public class SkinSingleBoolProperty
	{
		public string propName;
		public bool propVal;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
		public bool generateScript = true;
	}

	[System.Serializable]
	public class SkinSingleStringProperty
	{
		public string propName;
		public string propVal;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
		public bool generateScript = true;
	}

    [System.Serializable]
    public class SkinSingleColorProperty
    {
        public string propName;
        public UnityEngine.Color propVal;
#if !UNITY_EDITOR
		[NonSerialized]
#endif
        public bool generateScript = true;
    }


	public List<SkinSingleIntProperty> singleIntPropList;

	public List<SkinSingleFloatProperty> singleFloatPropList;

	public List<SkinSingleBoolProperty> singleBoolPropList;

	public List<SkinSingleStringProperty> singleStringPropList;

    public List<SkinSingleColorProperty> singleColorPropList;

	public int GetSingleIntProperty(string propName)
	{
		int singleLen = singleIntPropList != null ? singleIntPropList.Count : 0;
		for (int i = 0; i < singleLen; ++i)
		{
			if (singleIntPropList[i].propName == propName)
			{
				return singleIntPropList[i].propVal;
			}
		}
		return -1;
	}

	public float GetSingleFloatProperty(string propName)
	{
		int singleLen = singleFloatPropList != null ? singleFloatPropList.Count : 0;
		for (int i = 0; i < singleLen; ++i)
		{
			if (singleFloatPropList[i].propName == propName)
			{
				return singleFloatPropList[i].propVal;
			}
		}
		return float.NaN;
	}

	public bool GetSingleBoolProperty(string propName)
	{
		int singleLen = singleBoolPropList != null ? singleBoolPropList.Count : 0;
		for (int i = 0; i < singleLen; ++i)
		{
			if (singleBoolPropList[i].propName == propName)
			{
				return singleBoolPropList[i].propVal;
			}
		}
		return false;
	}

	public string GetSingleStringProperty(string propName)
	{
		int singleLen = singleStringPropList != null ? singleStringPropList.Count : 0;
		for (int i = 0; i < singleLen; ++i)
		{
			if (singleStringPropList[i].propName == propName)
			{
				return singleStringPropList[i].propVal;
			}
		}
		return null;
	}

    public UnityEngine.Color GetSingleColorProperty(string propName)
    {
        int singleLen = singleColorPropList != null ? singleColorPropList.Count : 0;
        for (int i = 0; i < singleLen; ++i)
        {
            if (singleColorPropList[i].propName == propName)
            {
                return singleColorPropList[i].propVal;
            }
        }
        return UnityEngine.Color.black;
    }
}
