using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class RuntimeQualitySettings
{
    private static UniversalRenderPipelineAsset urpAsset;
    private static Type urpType;
        
    public static void SyncCurrentSettingField()
    {
        urpAsset = QualitySettings.renderPipeline as UniversalRenderPipelineAsset;
        urpType = urpAsset.GetType();
    }

    public static void SetURPAssetValue(string fieldName, object value)
    {
        if (urpType == null)
        {
            SyncCurrentSettingField();
        }
        var field = urpType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (field != null)
        {
            field.SetValue(urpAsset, value);
        }
#if UNITY_EDITOR
        else
        {
            Debug.LogError($"找不到指定的urpAsset字段：{fieldName}");
        }
#endif
    }

    public static object GetURPAssetValue(string fieldName)
    {
        if (urpType == null)
        {
            SyncCurrentSettingField();
        }
        var field = urpType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        if (field != null)
        {
            return field.GetValue(urpAsset);
        }
#if UNITY_EDITOR
        else
        {
            Debug.LogError($"找不到指定的urpAsset字段：{fieldName}");
        }
#endif
        return null;
    }
}