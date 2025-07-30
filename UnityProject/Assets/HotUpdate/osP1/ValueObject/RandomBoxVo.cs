using System.Collections.Generic;

namespace HotUpdate.osP1.ValueObject
{
    public class RandomBoxVo: BoxVo
    {
        public RandomBoxVo(BoxState state) : base(state)
        {
            
        }

        public RandomBoxVo(BoxVo vo) : base(vo.State)
        {
            Bullets = vo.Bullets;
        }

        public override BoxVo Clone()
        {
            var ret = new RandomBoxVo(State);
            ret.Bullets = new List<StackableBulletVo>(BoxCapacity);
            for (int i = 0; i < Bullets.Count; i++)
            {
                ret.Bullets.Add(Bullets[i].Clone());
            }

            ret.Row = Row;
            ret.Col = Col;
            ret.SlotIndex = SlotIndex;
            return ret;
        }

        public BoxVo ToBoxVo()
        {
            var ret = new BoxVo(State);
            ret.Bullets = new List<StackableBulletVo>();
            for (int i = 0; i < Bullets.Count; i++)
            {
                ret.Bullets.Add(Bullets[i].Clone());
            }
            ret.Row = Row;
            ret.Col = Col;
            ret.SlotIndex = SlotIndex;
            return ret;
        }
    }
}