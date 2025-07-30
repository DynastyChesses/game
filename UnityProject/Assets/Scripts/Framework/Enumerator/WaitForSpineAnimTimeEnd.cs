using System;
using System.Collections;
using Spine;
using UnityEngine;

public class WaitForSpineAnimTimeEnd : IEnumerator
{
    private float _endTime;
    
    public WaitForSpineAnimTimeEnd(TrackEntry trackEntry)
    {
        _endTime = Time.realtimeSinceStartup + trackEntry.Animation.Duration;

    }
    public bool MoveNext()
    {
        if (Time.realtimeSinceStartup > _endTime)
        {
            return true;
        }

        return false;
    }

    public void Reset()
    {
    }

    public object Current => null;
}