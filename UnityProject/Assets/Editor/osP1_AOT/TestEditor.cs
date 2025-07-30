#if UNITY_EDITOR

using System.IO;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using UnityEditor;
using UnityEngine;

namespace Editor.osP1
{
    public class TestEditor: OdinEditorWindow
    {
        private static TestEditor _window;
        
        [MenuItem("OneSonic/TestEditor")]
        private static void OpenWindow()
        {
            _window = GetWindow<TestEditor>();
            _window.Show();
        }
        
        [Button]
        private static void CopyMetaData()
        {
            Debug.Log("CopyMetaData start");
            var srcPath = Directory.GetParent(Application.dataPath) +
                       $"/HybridCLRData/AssembliesPostIl2CppStrip/{EditorUserBuildSettings.activeBuildTarget}/";

            var desPath = Application.dataPath + "/Arts/Dll/";
            
            //清理文件夹
            var oldFiles = Directory.GetFiles(desPath);
            foreach (var file in oldFiles)
            {
                File.Delete(file);
            }

            var newFiles = Directory.GetFiles(srcPath);
            foreach (var file in newFiles)
            {
                var fileName = Path.GetFileName(file);
                File.Copy(file, desPath + fileName + ".bytes");//if you use dll, unity editor will load it
            }
            AssetDatabase.Refresh();
            Debug.Log("Finished CopyMetaData");
        }
    }
}

#endif