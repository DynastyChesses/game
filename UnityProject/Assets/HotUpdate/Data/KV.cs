
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Luban;
using SimpleJSON;


namespace cfg
{
public sealed partial class KV : Luban.BeanBase
{
    public KV(JSONNode _buf) 
    {
        { if(!_buf["Key"].IsString) { throw new SerializationException(); }  Key = _buf["Key"]; }
        { if(!_buf["Value"].IsString) { throw new SerializationException(); }  Value = _buf["Value"]; }
    }

    public static KV DeserializeKV(JSONNode _buf)
    {
        return new KV(_buf);
    }

    public readonly string Key;
    public readonly string Value;
   
    public const int __ID__ = 2411;
    public override int GetTypeId() => __ID__;

    public  void ResolveRef(Tables tables)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Key:" + Key + ","
        + "Value:" + Value + ","
        + "}";
    }
}

}

