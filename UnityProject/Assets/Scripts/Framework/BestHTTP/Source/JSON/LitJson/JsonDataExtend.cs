using System.Collections.Generic;
namespace BestHTTP.JSON.LitJson {
    /// <summary>
    /// JsonData 扩展方法
    /// </summary>
    public static class JsonDataExtend {
        public static int AsInt(this JsonData data) {
            if (data.IsInt) {
                return data.inst_int;
            }
            return 0;
        }

        public static bool AsBool(this JsonData data) {
            if (data.IsBoolean) {
                return data.inst_boolean;
            }
            return false;
        }

        public static string AsString(this JsonData data) {
            if (data.IsString) {
                return data.inst_string;
            }
            return "";
        }

        public static double AsDouble(this JsonData data) {
            if (data.IsDouble) {
                return data.inst_double;
            }
            return 0;
        }

        public static long AsLong(this JsonData data) {
            if (data.IsLong) {
                return data.inst_long;
            }
            return 0;
        }

        public static IList<JsonData> AsArray(this JsonData data) {
            if (data.IsArray) {
                return data.inst_array;
            }
            return null;
        }

        public static JsonData Parse(string jsonStr) {
            var data = JsonMapper.ToObject(new JsonReader(jsonStr));
            return data;
        }
    }
}
