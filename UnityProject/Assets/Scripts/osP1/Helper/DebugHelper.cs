using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace osP1.Helper
{
    public static class DebugHelper
    {
        public static string ToData(this IEnumerable array)
        {
            var isEmpty = true;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("[ ");
            foreach (var item in array)
            {
                stringBuilder.Append(item);
                stringBuilder.Append(", ");
                isEmpty = false;
            }
            if(!isEmpty)
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(" ]");
            
            return stringBuilder.ToString();
        }

        public static string ToData<T1, T2>(this Dictionary<T1, T2> dict)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("[ ");
            foreach (var (key,value) in dict)
            {
                if (value is IEnumerable enumerable)
                {
                    stringBuilder.Append($"{{ {key}: {enumerable.ToData()} }}");
                    stringBuilder.Append(", ");
                }
                else
                {
                    stringBuilder.Append($"{{{key}: {value}}}");
                    stringBuilder.Append(", ");
                }
            }
            if(dict.Count != 0)
                stringBuilder.Remove(stringBuilder.Length - 2, 2);
            stringBuilder.Append(" ]");
            
            return stringBuilder.ToString();
        }

        public static string ToRed(this string str) => "<color=red>" + str + "</color>";
        public static string ToGreen(this string str) => "<color=green>" + str + "</color>";
        public static string ToBlue(this string str) => "<color=#2EAEFF>" + str + "</color>";
        public static string ToYellow(this string str) => "<color=yellow>" + str + "</color>";
        
        public static string ToBold(this string str) => "<b>" + str + "</b>";
    }
}