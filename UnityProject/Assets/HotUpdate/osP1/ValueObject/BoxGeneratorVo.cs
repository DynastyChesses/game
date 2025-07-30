using System.Collections.Generic;
using System.Linq;

namespace HotUpdate.osP1.ValueObject
{

    public enum BoxGeneratorDirection
    {
        up,
        left,
        right,
    }
    
    public class BoxGeneratorVo: BoxVo
    {
        public float Pos;
        public int ColIndex;
        public int ChildNumber;
        public BoxGeneratorDirection Direction;

        public const int ActiveRowIndex = 2;
        
        public Queue<BoxVo> BoxQueue = new Queue<BoxVo>();

        public bool IsActive => Row <= ActiveRowIndex;

        
        public BoxGeneratorVo(BoxState state) : base(state)
        {
            
        }
        
        public override BoxVo Clone()
        {
            var ret = new BoxGeneratorVo(State);
            ret.Bullets = new List<StackableBulletVo>(BoxCapacity);
            for (int i = 0; i < Bullets.Count; i++)
            {
                ret.Bullets.Add(Bullets[i].Clone());
            }
            ret.Row = Row;
            ret.Col = Col;
            ret.SlotIndex = SlotIndex;
            ret.BoxQueue = new Queue<BoxVo>();

            var tempList = BoxQueue.ToList();
            for (int i = 0; i < tempList.Count; i++)
            {
                ret.BoxQueue.Enqueue(tempList[i].Clone());
            }
            
            return ret;
        }
    }
}