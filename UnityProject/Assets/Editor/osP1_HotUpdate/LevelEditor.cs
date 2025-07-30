#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using System.Text;
using cfg;
using HotUpdate.osP1;
using SimpleJSON;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;


namespace Editor.osP1
{
    
    public class LevelEditor : OdinEditorWindow
    {
        private const string TabSimulate = "Simulate";
        private const string TabBrickArrangement = "Brick Arrangement";

        private static LevelEditor _window;

        private TbLevelConfig _level;
        private TbKV _kv;

        [MenuItem("OneSonic/LevelEditor")]
        private static void OpenWindow()
        {
            _window = GetWindow<LevelEditor>();


            var path = Application.dataPath + "/Arts/Data";
            var tables = new cfg.Tables(file => JSON.Parse(File.ReadAllText($"{path}/{file}.json")));
            _window._level = tables.TbLevelConfig;
            _window._kv = tables.TbKV;

            _window.DebugItem = BoxProduction.DebugItem;
            MetaManager.instance.LoadMetas(null);
            _window.Show();
            _window.OnClose += () =>
            {
                MetaManager.instance.Dispose();
            };
        }

        #region TabSimulate

        [TabGroup(TabSimulate)] public int LevelId = 2;

        [FormerlySerializedAs("ProductTime")] [TabGroup(TabSimulate)]
        public int ProductCount = 9;

        [TabGroup(TabSimulate)] public List<(string, bool)> DebugItem;

        [TabGroup(TabSimulate)]
        [Button(ButtonSizes.Medium)]
        private static void Simulate()
        {
            var level = new LevelData(_window.LevelId);
            var least = level.BoxCol * 4;//显示4行
            var queueCount = 0;
            var count = 0;
            var isInit = true;
            for (int i = 0; i < _window.ProductCount; i++)
            {
                var list =level.BoxProduction.ProductBox();
                
                if (isInit)
                {
                    count += list.Count;
                    if (count > least)
                    {
                        level.BoxProduction.ComboNum += count - least;//此时队列中有 count -least 个，需要点击 count -least 个，才能触发下一次 ProductBox
                        isInit = false;
                    }
                    continue;
                }
                
                level.BoxProduction.ComboNum += list.Count;
            }
        }

        #endregion

        #region TabBrickArrangement

        [TabGroup(TabBrickArrangement)] public int minLevel = 1;
        [TabGroup(TabBrickArrangement)] public int maxLevel = 21;
        [TabGroup(TabBrickArrangement)] public int BrickGenerateCount = 10;

        [TabGroup(TabBrickArrangement)]
        [Button(ButtonSizes.Medium)]
        private static void GenerateBrickArrangement()
        {
            for (int i = _window.minLevel; i <= _window.maxLevel; i++)
            {
                GenerateBrickArrangementInner(i);
            }
        }

        private static void GenerateBrickArrangementInner(int levelId)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Level: {levelId}");
            sb.AppendLine("");
            sb.AppendLine("");

            for (int i = 0; i < _window.BrickGenerateCount; i++)
            {
                var level = new LevelData(levelId,false);
                var ret = level.BoxProduction.BrickArrangement();
                sb.Append(ret);
                sb.AppendLine("");
            }

            var dir = $"{Application.dataPath}/../../TempLevelBrickData/";
            var file = $"Level{levelId}.txt";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(Path.Combine(dir, file), sb.ToString());
            Debug.Log($"Export Level {levelId} Brick Arrangement Finished");
        }

        #endregion
    }
}

#endif