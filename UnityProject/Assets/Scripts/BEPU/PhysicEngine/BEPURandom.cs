using UnityEngine;
using Random = System.Random;

namespace Simulation
{
    public class BEPURandom
    {
        //当前随机次数
        public static int CurrentRandomTimes { get; set; } = 0;
        //可以用房间ID 匹配ID来当作SeedOffset TODO...
        public static int SeedOffset { get; set; } = 1;

        public static void Reset()
        {
            CurrentRandomTimes = 0;
            SeedOffset = 1;
        }
        
        public static void SetSeed(int seed)
        {
            SeedOffset = seed;
            if (GameSimulation.Inst.CurrentTick > 0)
            {
                Debug.LogError("Error: 游戏已经开始，修改随机种子会造成不确定。！！！");
            }
        }
        /// <summary>
        /// 不包含最大值
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int RandomInt(int minValue, int maxValue)
        {
            // return maxValue;
            Random random = new Random(SeedOffset + GameSimulation.Inst.CurrentTick + CurrentRandomTimes);
            var value = random.Next(minValue, maxValue);
            CurrentRandomTimes++;
            return value;
        }
    }
}