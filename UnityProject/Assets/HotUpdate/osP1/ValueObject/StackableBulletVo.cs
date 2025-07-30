using System;
using DG.Tweening;
using HotUpdate.osP1.EntitySystem;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.ValueObject.Interface;
using UnityEngine;

namespace HotUpdate.osP1
{
    public enum StackableBulletState
    {
        Empty,
        InPanel,
        InBarrel,
        Move2Slot
    }
    
    public class StackableBulletVo: IEntity,IFetch<StackableBullet>
    {
        public StackableBulletState State;
        public BattleColor Color;
        public int Number;

        public bool IsReady;
        public int BarrelIndex;
        
        public int AttackTargetRow;
        public int AttackTargetCol;

        public bool IsFeverStackableBullet;
        
        public CommonItemRenderer CommonItemRenderer;//dispose用，实际上最好新建一个类，该类包含vo和commonItemRenderer

        private float _moveSpeed = 1.75f;

        private int _barrelIndex;
        private bool _isMovingInBarrel;
        
        public static float StackableBulletScaleInScene => 0.8f;

        public StackableBulletVo(StackableBulletState state)
        {
            State = state;
            Color = new BattleColor();
            Number = 0;
        }

        public StackableBulletVo Clone()
        {
            var ret = new StackableBulletVo(State)
            {
                Color = Color,
                Number = Number,
                IsReady = IsReady,
                AttackTargetRow = AttackTargetRow,
                AttackTargetCol = AttackTargetCol,
                CommonItemRenderer = CommonItemRenderer,
                IsFeverStackableBullet = IsFeverStackableBullet,
            };
            return ret;
        }
        
        public StackableBullet Item { get; set; }
        
        public void Start()
        {
            State = StackableBulletState.InBarrel;
            _barrelIndex = BarrelIndex;
            IsReady = _barrelIndex == 0;
            Item.viewObject.transform.SetParent(GamePlay.instance.UI.path[_barrelIndex].transform);
        }

        public void Update(UpdateTimeInfo time)
        {
            if(_isMovingInBarrel)
                return;
            
            if (State != StackableBulletState.InBarrel)
                return;
            
            if(_barrelIndex == 0)//发射位置
                return;
            
            var currentIndex = _barrelIndex;
            var nextIndex = _barrelIndex - 1;
            if (GamePlay.instance.IsBarrelEmpty[nextIndex])//下一个位置为空，则前进
            {
                GamePlay.instance.IsBarrelEmpty[currentIndex] = true;
                GamePlay.instance.IsBarrelEmpty[nextIndex] = false;
                _barrelIndex = nextIndex;

                var currentPos = GamePlay.instance.UI.path[currentIndex].transform.position;
                var nextPos = GamePlay.instance.UI.path[nextIndex].transform.position;
                var duration = Vector3.Distance(currentPos, nextPos) / _moveSpeed;
                
                Item.viewObject.gameObject.transform.SetParent(GamePlay.instance.UI.path[nextIndex].transform);
                
                _isMovingInBarrel = true;
                Item.skelBall.AnimationState.SetAnimation(0, "move", true);
                Item.viewObject.transform.DOMove(nextPos, duration).onComplete += () =>
                {
                    _isMovingInBarrel = false;
                    Item.skelBall.AnimationState.SetAnimation(0, "idle", true);
                    if(nextIndex == 0)//到达 Index0 的位置，可以发射
                        IsReady = true;
                };
            }
            
        }

    }
}