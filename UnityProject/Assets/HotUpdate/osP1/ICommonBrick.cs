using System;
using UnityEngine;

namespace HotUpdate.osP1
{
    public interface ICommonBrick
    {
        public void AnimationMove(Vector3 endPos,float delay,Action callback);

        public void AnimationDead(Action cb);

        public void AnimationHurt();

        public void AnimAdd();

        public void Revive();
    }
}