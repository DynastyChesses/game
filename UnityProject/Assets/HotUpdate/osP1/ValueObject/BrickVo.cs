using System;
using System.Collections.Generic;
using HotUpdate.osP1.EntitySystem;
using HotUpdate.osP1.Enum;
using HotUpdate.osP1.ValueObject.Interface;

namespace HotUpdate.osP1.ValueObject
{
    public enum BrickState
    {
        Live,
        Dead,
    }

    public class BrickVo: IFetch<BaseScriptItemRendererView>
    {
        public BrickState State;
        public BattleColor Color;
        public int Life;
        
        public int Row;
        public int Col;

        public int GenerateGroup;

        public int OriginRow;
        public int OriginCol;

        public bool IsMoving;
        
        //GuideLevel
        public bool IsGuideFever;

        public BrickVo(BrickState state)
        {
            State = state;
            Color = new BattleColor();
            Life = 0;
            Row = 0;
            Col = 0;
        }

        public virtual BrickVo Clone()
        {
            var brickVo = new BrickVo(State);
            CopyValue(brickVo,this);
            return brickVo;
        }

        protected void CopyValue(BrickVo newVo, BrickVo oldVo)
        {
            newVo.Color = oldVo.Color;
            newVo.Life = oldVo.Life;
            newVo.Row = oldVo.Row;
            newVo.Col = oldVo.Col;
            newVo.GenerateGroup = oldVo.GenerateGroup;
            newVo.Item = oldVo.Item;
            newVo.OriginRow = oldVo.OriginRow;
            newVo.OriginCol = oldVo.OriginCol;
            newVo.IsMoving = oldVo.IsMoving;
            newVo.IsGuideFever = oldVo.IsGuideFever;
        }
        
        //仅能修改数据
        public virtual void BeforeDead()
        {
        }

        public virtual void AfterDead(Action callback)
        {
            callback?.Invoke();
        }

        public virtual void BeforeMoveDown()
        {
        }

        public virtual void AfterMoveDown()
        {
        }

        public virtual void OnAddBox2Slot()
        {
        }

        public virtual void OnRemoveBox2Slot()
        {
        }

        public BaseScriptItemRendererView Item { get; set; }
        
    }
}