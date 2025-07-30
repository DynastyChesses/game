using System;
using System.Collections.Generic;
using System.Linq;
using HybridCLR;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace osP1.Helper
{
    public static class HybridCLRHelper
    {
        public static readonly IReadOnlyList<string> PatchedAOTAssemblyList = new List<string>
        {
            "DOTween.dll",
            "EquineNexus.dll",
            "Google.Protobuf.dll",
            "Main.dll",
            "Newtonsoft.Json.dll",
            "System.Core.dll",
            "System.dll",
            "Unity.Addressables.dll",
            "Unity.ResourceManager.dll",
            "UnityEngine.AndroidJNIModule.dll",
            "UnityEngine.CoreModule.dll",
            "UnityEngine.JSONSerializeModule.dll",
            "mscorlib.dll",
        };
        
        /// <summary>
        /// 补充元数据给aot，没在aot中使用过的泛型，在HotUpdate中将无法使用，采用补充元数据方法
        /// </summary>
        public static void LoadMetaData4AOT(Action cb)
        {
            var temp = Addressables.ResourceLocators;
            
            var count = 0;
            foreach (var aotDllName in PatchedAOTAssemblyList)
            {
                
                ResourceFacade.instance.LoadObjectAsync<TextAsset>($"Assets/Arts/Dll/{aotDllName}.bytes", textAsset =>
                {
                    byte[] dllBytes = textAsset.bytes;
                    // 执行补充元数据时内部会自动将dllBytes复制一份，调用完成后请不要将dllBytes保存，造成无谓的内存浪费
                    var err = HybridCLR.RuntimeApi.LoadMetadataForAOTAssembly(dllBytes, HomologousImageMode.SuperSet);
                    // Debug.Log($"LoadMetadataForAOTAssembly:{aotDllName}. ret:{err}");

                    count++;
                    if (count == PatchedAOTAssemblyList.Count)
                    {
                        cb?.Invoke();
                    }
                    
                    return 0;
                });
            }
        }
    }
}