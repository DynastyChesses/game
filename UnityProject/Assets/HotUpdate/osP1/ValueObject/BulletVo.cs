using System;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.ValueObject.Interface;
using UnityEngine;

namespace HotUpdate.osP1.ValueObject
{
    public class BulletVo: IFetch<Bullet>
    {
        public BattleColor Color;

        public Vector3 TargetPos;
        
        public bool IsFeverBullet;
        
        public Bullet Item { get; set; }
    }
}