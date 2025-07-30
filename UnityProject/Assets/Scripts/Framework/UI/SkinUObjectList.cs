using System;
using System.Collections.Generic;

public class SkinUObjectList<T> where T:UnityEngine.Object
{
    private readonly object[] _objects = null;
    private readonly Object[] _nativeObjects = null;
    private int _length;

    public SkinUObjectList(ScriptViewSkin skin, string propName, int predicatedIndex)
    {
        _length = 0;
        try
        {
            _nativeObjects = skin.GetMultipleProperty(propName, out _length, predicatedIndex);
        }
        catch (MissingMethodException)
        {
            _nativeObjects = GetMultiplePropertyFallback(skin, propName, out _length, predicatedIndex);
        }

        _objects = _length > 0 ? new object[_length] : null;
    }
    
    private Object[] GetMultiplePropertyFallback(ScriptViewSkin skin, string propName, out int length, int predicateIndex = -1)
    {
        List<ScriptViewSkin.SkinMultipleProperty> multiplePropList = skin.multiplePropList; 
        int multiLen = multiplePropList != null ? multiplePropList.Count : 0;
        Object[] propVal = null;
        if (predicateIndex >= 0 && predicateIndex < multiLen)
        {
            ScriptViewSkin.SkinMultipleProperty multipleProperty = multiplePropList[predicateIndex];
            if (multipleProperty.propName == propName)
            {
                propVal = multipleProperty.propVal;
            }
        }
        if (propVal == null)
        {
            for (int i = 0; i < multiLen; ++i)
            {
                ScriptViewSkin.SkinMultipleProperty multipleProperty = multiplePropList[i];
                if (multipleProperty.propName == propName)
                {
                    propVal = multipleProperty.propVal;
                    break;
                }
            }
        }

        length = propVal != null ? propVal.Length : 0;
        
        return propVal;
    }

    public int length => _length;

    public T GetItem(int index)
    {
        return this[index];
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _length)
            {
                throw new IndexOutOfRangeException();
            }

            object obj = _objects[index];
            if (obj == null)
            {
                obj = _objects[index] = _nativeObjects[index];
            }

            return obj as T;
        }
    }
}