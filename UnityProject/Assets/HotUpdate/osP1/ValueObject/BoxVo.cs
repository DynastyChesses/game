using System;
using System.Collections.Generic;
using HotUpdate.osP1.EntitySystem;
using HotUpdate.osP1.SkillSystem;
using HotUpdate.osP1.SkillSystem.Skill;
using HotUpdate.osP1.ValueObject.Interface;

namespace HotUpdate.osP1.ValueObject
{
    public enum BoxState
    {
        Move2Slot,
        PlaceHolder,//可以在Matrix，也可以在slot，但是只充当站位作用，不显示
        InMatrix,
        InSlot
    }
    
    public class BoxVo: IFetch<BaseScriptItemRendererView>,IEntity
    {
        public BoxState State;
        public List<StackableBulletVo> Bullets;
        public int Row;
        public int Col;

        public int SlotIndex;

        public bool IsMoving;

        public CommonItemRenderer Cir;//移动到slot时可用

        public BoxVo Data4Ai;
        
        public const int BoxCapacity = 4;

        public bool IsLoadBullet;
        
        
        public BoxVo(BoxState state)
        {
            Bullets = new List<StackableBulletVo>(BoxCapacity);
            this.State = state;
        }
        
        public virtual BoxVo Clone()
        {
            var ret = new BoxVo(State);
            ret.Bullets = new List<StackableBulletVo>(BoxCapacity);
            for (int i = 0; i < Bullets.Count; i++)
            {
                ret.Bullets.Add(Bullets[i].Clone());
            }
            ret.Row = Row;
            ret.Col = Col;
            ret.SlotIndex = SlotIndex;
            ret.IsMoving = IsMoving;
            return ret;
        }

        public BaseScriptItemRendererView Item { get; set; }
        
        private bool _isMovingInSlot;
        private bool _isLoadingBulletInSlot;
        
        public void Start()
        {

        }

        public void Update(UpdateTimeInfo updateTimeInfo)
        {
            var gameData = GamePlay.instance.GamePlayData;
            if(_isMovingInSlot || _isLoadingBulletInSlot)
                return;
            
            if (SlotIndex != 0 && gameData.IsSlotEmpty[SlotIndex - 1])
            {
                _isMovingInSlot = true;

                var startPos = gameData.SlotPos[SlotIndex];
                var endPos = gameData.SlotPos[SlotIndex - 1];
                
                var box = Item as Box;
                box.AnimationMoveInSlot(startPos, endPos,(() =>
                {
                    _isMovingInSlot = false;
                }));

                gameData.IsSlotEmpty[SlotIndex] = true;
                gameData.IsSlotEmpty[SlotIndex - 1] = false;
                SlotIndex -= 1;
            }
            else if(Data4Ai.State != BoxState.PlaceHolder && !BrickGeneratorVo.IsGenerating && !IsLoadBullet)
            {
                var skill = new LoadBullet(this);
                SkillManager.instance.UseSkill(skill);
                IsLoadBullet = true;

                
            }
        }
    }
}