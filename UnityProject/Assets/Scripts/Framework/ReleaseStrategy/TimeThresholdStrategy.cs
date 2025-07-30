using UnityEngine;
using System.Collections.Generic;
using System;
using System.Text;

public class TimeThresholdStrategy : IReleaseStrategy
{
    private Dictionary<ResourceReleaseFacade.ResourceToken, ResourceUnitHint> _unitHintMap;
    private Dictionary<ResourceReleaseFacade.ResourceToken, int> _unitHintNotRecycleCountMap;
    
    private const int check_pointer = 10000;

    private int _lastTickTimes = 0;
    private int _currentTickTimes = 0;

    public TimeThresholdStrategy()
    {
        _unitHintMap = new Dictionary<ResourceReleaseFacade.ResourceToken, ResourceUnitHint>();
        _unitHintNotRecycleCountMap = new Dictionary<ResourceReleaseFacade.ResourceToken, int>();
    }

    #region IReleaseStrategy implementation

    public ResourceReleaseFacade.ResourceToken Recycle(IResourceUnit unit, Action<IResourceUnit, ResourceReleaseFacade.ResourceToken> disposeCallback)
    {
        ResourceReleaseFacade.ResourceToken token = new ResourceReleaseFacade.ResourceToken(unit.id);
        ResourceUnitHint hint = new ResourceUnitHint(unit);
        hint.disposeCallback = disposeCallback;
        hint.lastRecycleTickNum = _currentTickTimes;
        _unitHintMap.Add(token, hint);
        _unitHintNotRecycleCountMap.Add(token, 0);
        return token;
    }

    public IResourceUnit Acquire(ResourceReleaseFacade.ResourceToken token)
    {
        ResourceUnitHint hint;
        if(!_unitHintMap.TryGetValue(token, out hint))
        {
            Debug.LogError("Cant't find ResourceUnit: " + token.id);
            return null;
        }
        _unitHintMap.Remove(token);
        _unitHintNotRecycleCountMap.Remove(token);
        return hint.unit;
    }

    private List<ResourceReleaseFacade.ResourceToken> _tokenToRemove = new List<ResourceReleaseFacade.ResourceToken>(10);
    public void Tick()
    {
        if (_currentTickTimes - _lastTickTimes > check_pointer)
        {
            _lastTickTimes = _currentTickTimes;
            _tokenToRemove.Clear();
            var iter = _unitHintMap.GetEnumerator();
            while(iter.MoveNext())
            {
                ResourceUnitHint hint = iter.Current.Value;
                if(_currentTickTimes - hint.lastRecycleTickNum > check_pointer)
                {
                    _tokenToRemove.Add(iter.Current.Key);
                }
            }

            int count = _tokenToRemove.Count;
            for(int i = 0; i < count; ++i)
            {
                ResourceReleaseFacade.ResourceToken token = _tokenToRemove[i];
                ResourceUnitHint hint = _unitHintMap[token];
                if(hint.disposeCallback != null)
                {
                    hint.disposeCallback(hint.unit, token);
                }
                _unitHintMap.Remove(token);
                _unitHintNotRecycleCountMap.Remove(token);
            }
        }
        ++_currentTickTimes;
    }

    public void Reset()
    {
        _currentTickTimes = 0;
		_lastTickTimes = 0;
		try
		{
			var iter = _unitHintMap.GetEnumerator();
			while (iter.MoveNext())
			{
				ResourceUnitHint hint = iter.Current.Value;
				if (hint.disposeCallback != null)
				{
					hint.disposeCallback(hint.unit, iter.Current.Key);
				}
			}
		}
		catch (Exception e)
		{
            Debug.LogError(e);
		}
	    _unitHintMap.Clear();
        _unitHintNotRecycleCountMap.Clear();
    }
    #endregion

    private void LogHintMapError()
    {
        bool hasSomeThingNotRecycled = false;
        StringBuilder sb = new StringBuilder();
        List<ResourceReleaseFacade.ResourceToken> tempList = new List<ResourceReleaseFacade.ResourceToken>(_unitHintNotRecycleCountMap.Keys);
        foreach (ResourceReleaseFacade.ResourceToken token in tempList)
        {
            int notRecycledCount = _unitHintNotRecycleCountMap[token] + 1;
            _unitHintNotRecycleCountMap[token] = notRecycledCount;
            if(notRecycledCount > 1)
            {
                hasSomeThingNotRecycled = true;
            }
        }
        if(hasSomeThingNotRecycled)
        { 
            // TODO
        }
    }

    class ResourceUnitHint
    {
        public IResourceUnit unit;
        public int lastRecycleTickNum;
        public Action<IResourceUnit, ResourceReleaseFacade.ResourceToken> disposeCallback;

        public ResourceUnitHint(IResourceUnit unit)
        {
            this.unit = unit;
        }
    }
}