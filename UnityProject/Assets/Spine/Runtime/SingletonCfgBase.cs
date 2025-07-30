using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

#if UNITY_EDITOR
using System.Linq;
using System;
using System.Reflection;
using UnityEditor;
#endif
public class SingletonCfgBase : ScriptableObject
    {
        const string k_SaveDir = "Assets/Plugins/Settings";
        [HideInInspector] public bool runtimeCfg;
        private static HashSet<string> s_ErrorAssets = new HashSet<string>();


        static string GetAssetPath(string fileName, bool runtimeAsset)
        {
            var subDir = runtimeAsset ? "Resources" : "Editor";
            return $"{k_SaveDir}/{subDir}/{fileName}.asset";
        }

        protected static T LoadOrCreate<T>(bool runtimeAsset) where T : SingletonCfgBase
        {
            SingletonCfgBase obj = null;
#if UNITY_EDITOR
            var assetPath = GetAssetPath(typeof(T).Name, runtimeAsset);
#endif
            if (runtimeAsset)
            {
                obj = Resources.Load<T>(typeof(T).Name);
            }
#if UNITY_EDITOR
            else
            {
                obj = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            }

            if (obj == null)
            {
                // 有可能文件存在但加载失败，比如切分支编译内容有变化，被AssetSettingsProvider调用时，
                // 为了不改变文件内容返回空
                if (File.Exists(assetPath))
                {
                    if (!s_ErrorAssets.Contains(assetPath))
                        Debug.LogError($"{assetPath}, exists but loading failed");
                    s_ErrorAssets.Add(assetPath);
                    return null;
                }

                obj = CreateInstance<T>();
                obj.runtimeCfg = runtimeAsset;
                {
                    string assetDictionary = Path.GetDirectoryName(assetPath);
                    if (!Directory.Exists(assetDictionary))
                    {
                        Directory.CreateDirectory(assetDictionary);
                    }
                }
                AssetDatabase.CreateAsset(obj, assetPath);
                AssetDatabase.SaveAssets();
            }
#endif
            return obj as T;
        }
    }

#if UNITY_EDITOR

    // Register a SettingsProvider using IMGUI for the drawing framework:
    // 反射找到所有FibSingletonCfgBase子类，在ProjectSetting中显示出编辑界面
    static class FibSettingsIMGUIRegister
    {
        // Register a SettingsProvider using IMGUI for the drawing framework:
        [SettingsProviderGroup]
        public static SettingsProvider[] CreateMyCustomSettingsProvider()
        {
            // 所有dll中FibSingletonCfgBase的子类
            var subclasses = from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.IsSubclassOf(typeof(SingletonCfgBase))
                select type;
            List<SettingsProvider> providers = new List<SettingsProvider>();

            HashSet<String> uniqueNames = new HashSet<string>();

            const string propName = "Instance";
            foreach (var subClass in subclasses)
            {
                // 查找Instance属性，创建AssetSettingsProvider进行ProjectSetting中的显示
                var subClassName = subClass.ToString();
                var property = subClass.GetProperty(propName, BindingFlags.Public | BindingFlags.Static);
                if (property == null)
                {
                    Debug.LogError($"{propName} property not found in {subClassName}, can't add to ProjectSetting");
                    continue;
                }

                var settingAsset = property.GetValue(null) as SingletonCfgBase;
                if (settingAsset == null)
                {
                    Debug.LogError($"asset for {subClassName} not found, can't add to project Setting");
                    continue;
                }

                var name = settingAsset.GetType().Name;
                if (uniqueNames.Contains(name))
                {
                    Debug.LogError($"duplicated class name for {subClassName}, can't add to project Setting");
                    continue;
                }

                string typeStr = settingAsset.runtimeCfg ? "Runtime" : "Editor";
                var provider =
                    AssetSettingsProvider.CreateProviderFromObject($"Project/Equine-{typeStr}/{name}", settingAsset);
                provider.keywords =
                    SettingsProvider.GetSearchKeywordsFromSerializedObject(new SerializedObject(settingAsset));

                providers.Add(provider);
                uniqueNames.Add(name);
            }

            return providers.ToArray();
        }
    }
#endif