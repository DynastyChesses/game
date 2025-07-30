using System.Collections.Generic;

public class PopupParam
{
	public IPopupView popupView;
	public uint popupMode;
	public Dictionary<uint, object> externalActionParamMap;
	public int popDepth;
	//public int popZ;
	public int popupLayer;
	public PopupQueueMode popQueueMode;
	public bool isHiding = false;
	public int delayShowOneFrameHandle;
    public int delayOpenHandle;
	public int delayCloseHandle;
	public Dictionary<uint, object> internalActionParamMap;

	public bool isFullScreen = false;
	public object GetExternalParam(uint key)
	{
		object param = null;
		if (externalActionParamMap != null && externalActionParamMap.TryGetValue(key, out param))
		{
			return param;
		}
		return null;
	}

	public void SetExternalParam(uint key, object param)
	{
		externalActionParamMap = externalActionParamMap ?? new Dictionary<uint, object>();
		if (externalActionParamMap.ContainsKey(key))
		{
			externalActionParamMap[key] = param;
		}
		else
		{
			externalActionParamMap.Add(key, param);
		}
	}

	public void SetInternalParamMap(uint key, object val)
	{
		if (internalActionParamMap == null)
		{
			internalActionParamMap = new Dictionary<uint, object>();
		}
		internalActionParamMap[key] = val;
	}

	public object GetInternalParam(uint key)
	{
		object param = null;
		if (internalActionParamMap != null && internalActionParamMap.TryGetValue(key, out param))
		{
			return param;
		}
		return null;
	}
}
