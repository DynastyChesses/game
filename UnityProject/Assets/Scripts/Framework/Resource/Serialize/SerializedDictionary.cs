// Dictionary<TKey, TValue> 

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] 
public class SerializedDictionary<TKey, TValue> : ISerializationCallbackReceiver
{
    [SerializeField] 
    private List<TKey> _keys; 

    [SerializeField] 
    private List<TValue> _values; 

    private Dictionary<TKey, TValue> _target;

    public Dictionary<TKey, TValue> ToDictionary()
    {
        return _target;
    }

    public SerializedDictionary(Dictionary<TKey, TValue> target) 
    { 
        this._target = target; 
    } 

    public void OnBeforeSerialize() 
    { 
        _keys = new List<TKey>(_target.Keys); 
        _values = new List<TValue>(_target.Values); 
    } 

    public void OnAfterDeserialize() 
    { 
        var count = Math.Min(_keys.Count, _values.Count); 
        _target = new Dictionary<TKey, TValue>(count); 

        for (var i = 0; i < count; ++i) 
        { 
            _target.Add(_keys[i], _values[i]); 
        } 
    } 
}