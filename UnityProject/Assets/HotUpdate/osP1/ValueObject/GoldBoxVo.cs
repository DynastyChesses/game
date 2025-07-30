using System.Collections.Generic;

namespace HotUpdate.osP1.ValueObject
{
    public class GoldBoxVo: BoxVo
    {
        public bool IsStatic;
        
        public GoldBoxVo(BoxState state) : base(state)
        {
            
        }

        public override BoxVo Clone()
        {
            var ret = new GoldBoxVo(State);
            ret.Bullets = new List<StackableBulletVo>(BoxCapacity);
            for (int i = 0; i < Bullets.Count; i++)
            {
                ret.Bullets.Add(Bullets[i].Clone());
            }
            ret.Row = Row;
            ret.Col = Col;
            ret.SlotIndex = SlotIndex;
            ret.IsMoving = IsMoving;
            
            ret.IsStatic = IsStatic;
            return ret;
        }
    }
}