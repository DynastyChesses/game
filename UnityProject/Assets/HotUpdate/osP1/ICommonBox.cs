using System;
using UnityEngine;

namespace HotUpdate.osP1
{
    public interface ICommonBox
    {
        public CanvasGroup CanvasGroup { get; }
        
        public void AnimationMoveUp(Vector3 startPos, Vector3 endPos, Action callBack);

        public void AnimationMoveLeft(Vector3 startPos, Vector3 endPos, Action callBack);

        public void AnimationMoveRight(Vector3 startPos, Vector3 endPos, Action callBack);
    }
}