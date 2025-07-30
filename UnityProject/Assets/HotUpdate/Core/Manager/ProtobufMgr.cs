using Google.Protobuf;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.Text;

public class ProtobufMgr
{
    public static int StringToMD5Hash(string input)
    {
        using (MD5 md5Hash = MD5.Create())
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
 
            // 将MD5的byte数组转换为一个整数
            // 注意：这将丢失MD5输出的一部分信息，因为整数位数小于byte数组
            int hash = (int)data[0] << 24;
            hash |= (int)data[1] << 16;
            hash |= (int)data[2] << 8;
            hash |= (int)data[3];
 
            return hash;
        }
    }
    
    public static bool Serialize(IMessage message, out byte[] data)
    {
        // 
        var mId = ProxyNames.GetId(message.Descriptor.FullName);
        if (mId > 0)
        {
            // 4byte, 分别表示ID和长度，是否增加终止符?? TODO
            var dat = message.ToByteArray();
            byte[] sendByte = new byte[dat.Length + 4];
            sendByte[0] = (byte)(mId / 256);
            sendByte[1] = (byte)(mId % 256);
            sendByte[2] = (byte)(dat.Length / 256);
            sendByte[3] = (byte)(dat.Length % 256);
            System.Array.Copy(dat, 0, sendByte, 4, dat.Length);
            data = sendByte;
            return true;
        }
        else
        {
            data = null;
            return false;
        }
    }
 
    public static T DeSerialize<T>(byte[] packet)where T:IMessage, new()
    {
        IMessage message = new T();
        try
        {
            return (T)message.Descriptor.Parser.ParseFrom(packet);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"协议解析报错：" + e.Message.ToString());
            throw;
        }
    }
    
    public static IMessage DeSerialize(byte[] packet, IMessage message)
    {
        try
        {
            return message.Descriptor.Parser.ParseFrom(packet);
        }
        catch (Exception e)
        {
            Debug.LogError($"协议解析报错：" + e.Message.ToString());
            throw e;
        }
    }
}