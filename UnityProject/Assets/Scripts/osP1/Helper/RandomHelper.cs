using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace osP1.Helper
{
    public static class RandomHelper
    {
        public static T[] Shuffle<T>(this T[] arr)
        {
            for (var i = arr.Length - 1; i > 0; i--)
            {
                var j = RandomInt(0, i);
                (arr[i], arr[j]) = (arr[j], arr[i]);
            }
            return arr;
        }

        public static List<T> Shuffle<T>(this List<T> list)
        {
            for (var i = list.Count - 1; i > 0; i--)
            {
                var j = RandomInt(0, i);
                (list[i], list[j]) = (list[j], list[i]);
            }
            return list;
        }
        
        
        /// <summary>
        /// 闭区间整数随机
        /// </summary>
        public static int RandomInt(int min, int max)
        {
            return Random.Range(min, max + 1);
        }
        
        /// <summary>
        /// 闭区间浮点数随机
        /// </summary>
        public static float RandomFloat(float min, float max)
        {
            return Random.Range(min, max);
        }
        
        /// <summary>
        /// 权重转区间，[0,1]
        /// </summary>
        public static List<(float,float)> Weight2Range(IEnumerable<float> weights)
        {
            var weightSum = weights.Sum();
            var current = 0f;
            
            var ret = new List<(float,float)>();
            foreach (var weight in weights)
            {
                var lowerLimit = current;
                current += weight / weightSum;
                var upperLimit = current;
                ret.Add((lowerLimit, upperLimit));
            }
            
            //修正最后一个元素的上限为 1f
            var last = ret[^1];
            last.Item2 = 1f;
            ret[^1] = last;

            return ret;
        }
    }
}