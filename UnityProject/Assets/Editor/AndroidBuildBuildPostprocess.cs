using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor.Android;
using UnityEngine;

namespace MobileSDK.IPA.GoogleBilling
{
    public class AndroidBuildBuildPostprocess : IPostGenerateGradleAndroidProject
    {
        public int callbackOrder => int.MaxValue;

        public void OnPostGenerateGradleAndroidProject(string path)
        {
            // Debug.Log("OnPostGenerateGradleAndroidProject");
            // string manifestPath = Path.Combine(path, "src/main/AndroidManifest.xml");
            // Debug.Log($"ManifestPath:{manifestPath}");

            // // 加载AndroidManifest.xml
            // XmlDocument doc = new XmlDocument();
            // doc.Load(manifestPath);

            // // 查找manifest标签
            // XmlNode manifestNode = doc.SelectSingleNode("/manifest");
            // if (manifestNode == null)
            // {
            //     Debug.LogError("Unable to find 'manifest' node in AndroidManifest.xml.");
            //     return;
            // }

            // // 创建uses-permission标签
            // XmlElement permissionElement = doc.CreateElement("uses-permission");
            // permissionElement.SetAttribute(
            //     "name",
            //     "http://schemas.android.com/apk/res/android",
            //     "com.android.vending.BILLING"
            // );

            // // 将新的uses-permission标签添加到manifest标签中
            // manifestNode.AppendChild(permissionElement);

            // // 保存更改
            // doc.Save(manifestPath);
        }
    }
}
