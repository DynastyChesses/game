using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Editor.osP1
{
    public class ToolEditor:OdinEditorWindow
    {
        private static ToolEditor _window;
        
        [MenuItem("OneSonic/ToolEditor")]
        private static void OpenWindow()
        {
            _window = GetWindow<ToolEditor>();
            _window.Show();
        }
        
        [Button]
        private static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
            Debug.Log("Clear PlayerPrefs");
        }
    }
}