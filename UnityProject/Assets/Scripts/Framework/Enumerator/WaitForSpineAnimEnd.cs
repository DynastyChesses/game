using System;
using System.Collections;
using Spine;

public class WaitForSpineAnimEnd : IEnumerator
{
    private AnimationState _animationState;
    private string         _animName;
    private bool           _isEnd;
    
    public WaitForSpineAnimEnd(AnimationState state, string animName)
    {
        _animationState          =  state;
        _animName                =  animName;
        _animationState.End      += OnAnimTrackEnd;
        _animationState.Complete += OnAnimTrackComplete;
    }


    public bool MoveNext()
    {
        if (!_isEnd)
        {
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _isEnd = false;
    }

    public object Current => null;

    private void OnAnimTrackComplete(TrackEntry trackentry)
    {
        if (trackentry.Animation.Name == _animName)
        {
            _isEnd = true;
            ClearInnerState();
        }
    }

    private void OnAnimTrackEnd(TrackEntry trackentry)
    {
        if (trackentry.Animation.Name == _animName)
        {
            _isEnd = true;
            ClearInnerState();
        }
    }

    private void ClearInnerState()
    {
        _animationState.End      -= OnAnimTrackEnd;
        _animationState.Complete -= OnAnimTrackComplete;
    }
}