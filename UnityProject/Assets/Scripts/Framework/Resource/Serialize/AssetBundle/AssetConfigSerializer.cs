using System;
using UnityEngine;
using System.IO;
using System.Text;
using LZ4;
public class AssetConfigSerializer
{
    public static void SerializeAssetsConfig(Stream outStream, bool compressed, AssetConfig config, Func<object, string> jsonConvertFunc = null)
    {
        jsonConvertFunc = jsonConvertFunc ?? JsonUtility.ToJson;
        string json = jsonConvertFunc(config);

        byte[] bytes = Encoding.UTF8.GetBytes(json);
        outStream.SetLength(0);
        if (compressed)
        {
            int oriLen = bytes.Length;
            bytes = LZ4Codec.Encode(bytes, 0, bytes.Length);
            outStream.WriteByte((byte)(oriLen >> 24));
            outStream.WriteByte((byte)((oriLen >> 16) & 0xFF));
            outStream.WriteByte((byte)((oriLen >> 8) & 0xFF));
            outStream.WriteByte((byte)(oriLen & 0xFF));
        }
        outStream.Write(bytes, 0, bytes.Length);
    }

    public static void SerializeAssetsList(Stream outStream, AssetList assetList, Func<object, string> jsonConvertFunc = null)
    {
        jsonConvertFunc = jsonConvertFunc ?? JsonUtility.ToJson;
        string json = jsonConvertFunc(assetList);

        byte[] bytes = Encoding.UTF8.GetBytes(json);
        int oriLen = bytes.Length;
        bytes = LZ4Codec.Encode(bytes, 0, bytes.Length);
        outStream.SetLength(0);
        outStream.WriteByte((byte)(oriLen >> 24));
        outStream.WriteByte((byte)((oriLen >> 16) & 0xFF));
        outStream.WriteByte((byte)((oriLen >> 8) & 0xFF));
        outStream.WriteByte((byte)(oriLen & 0xFF));
        outStream.Write(bytes, 0, bytes.Length);
    }

    public static void DecompressAndCopyTo(string sourcePath, string destPath, bool overwrite)
    {
        if (!StorageManager.Exists(destPath) || overwrite)
        {
            byte[] src = StorageManager.ReadAllBytes(sourcePath);
            int oriLen = (src[0] << 24) | (src[1] << 16) | (src[2] << 8) | src[3];
            var dest = LZ4Codec.Decode(src, 4, src.Length - 4, oriLen);
            StorageManager.WriteAllBytes(destPath, dest);
        }
    }

    public static AssetConfig DeserializeAssetsConfig(byte[] src, bool compressed, Func<string, AssetConfig> jsonParseFunc = null)
    {
        AssetConfig ac = null;
        if (src != null)
        {
            try
            {
                jsonParseFunc = jsonParseFunc ?? JsonUtility.FromJson<AssetConfig>;
                byte[] dest = src;
                if (compressed)
                {
                    int oriLen = (src[0] << 24) | (src[1] << 16) | (src[2] << 8) | src[3];
                    dest = LZ4Codec.Decode(src, 4, src.Length - 4, oriLen);
                }

                string rawJson = Encoding.UTF8.GetString(dest);
                ac = jsonParseFunc(rawJson);
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogException(e);
            }
        }

        return ac;
    }

    public static AssetList DeserializeAssetsList(byte[] src, Func<string, AssetList> jsonParseFunc)
    {
        jsonParseFunc = jsonParseFunc ?? JsonUtility.FromJson<AssetList>;
        int oriLen = (src[0] << 24) | (src[1] << 16) | (src[2] << 8) | src[3];
        byte[] dest = LZ4Codec.Decode(src, 4, src.Length - 4, oriLen);
        string rawJson = Encoding.UTF8.GetString(dest);
        AssetList al = jsonParseFunc(rawJson);
        return al;
    }

    public static string DeserializeAssetsList(byte[] src)
    {
        int oriLen = (src[0] << 24) | (src[1] << 16) | (src[2] << 8) | src[3];
        byte[] dest = LZ4Codec.Decode(src, 4, src.Length - 4, oriLen);
        return Encoding.UTF8.GetString(dest);
    }
}
