using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine;

public class MediatorCreator
{
    // 生成
    private static bool isCreateHide = false;
    private static bool isAnimate = false;

    
    public static void GenerateItemRenderSkin(string skinName, string skinPath)
    {
        // TemplateSubMediatorSkin.txt
        string template = GeSkintTemplateFilePath("TemplateItemRender");
        string tempContent = File.ReadAllText(template);
        tempContent = tempContent.Replace("${TemplateItemRenderClass}", skinName);
        StringBuilder sb = new StringBuilder();
        sb.Append(tempContent);
        
        // 判断路径
        string dirTemp = Path.GetDirectoryName(skinPath);
        if (dirTemp != "")
        {
            if (!Directory.Exists(dirTemp))
            {
                CreateFolderIfNotExists(dirTemp, "");
            }
        }
        
        File.WriteAllText(skinPath, sb.ToString());
    }
    
    public static void GenerateSubSkin(string skinName, string skinPath)
    {
        // TemplateSubMediatorSkin.txt
        string template = GeSkintTemplateFilePath("TemplateSubMediatorSkin");
        string tempContent = File.ReadAllText(template);
        tempContent = tempContent.Replace("${TemplateSkin}", skinName);
        StringBuilder sb = new StringBuilder();
        sb.Append(tempContent);
        // Skin
        // isAnimate = EditorUtility.DisplayDialog("提示", $"是否重写动画模式？", "重写", "取消");
        // if (isAnimate)
        // {
        //     string animate_data =
        //         "\tprivate BasePopupAnimation _popupAnimation;\n\tpublic override BasePopupAnimation popupAnimation\n\t{\n\t\tget\n\t\t{\n\t\t\tif (_popupAnimation == null)\n\t\t\t{\n\t\t\t\t_popupAnimation = new AnimatorPopupAnimation(this);\n\t\t\t}\n\t\t\treturn _popupAnimation;\n\t\t}\n\t}";
        //     sb.Replace("// __ANIMATE__", animate_data);
        // }
        // else
        // {
        //     sb.Replace("// __ANIMATE__", "");
        // }
        sb.Replace("// __ANIMATE__", "");
        
        // 判断路径
        string dirTemp = Path.GetDirectoryName(skinPath);
        if (dirTemp != "")
        {
            if (!Directory.Exists(dirTemp))
            {
                CreateFolderIfNotExists(dirTemp, "");
            }
        }
        
        File.WriteAllText(skinPath, sb.ToString());
    }
    
    public static void GenerateSkin(string skinName, string skinPath)
    {
        string template = GeSkintTemplateFilePath("TemplateSkin");
        string tempContent = File.ReadAllText(template);
        tempContent = tempContent.Replace("${TemplateSkin}", skinName);
        StringBuilder sb = new StringBuilder();
        sb.Append(tempContent);
        // Skin
        // isAnimate = EditorUtility.DisplayDialog("提示", $"是否重写动画模式？", "重写", "取消");
        // if (isAnimate)
        // {
        //     string animate_data =
        //         "\tprivate BasePopupAnimation _popupAnimation;\n\tpublic override BasePopupAnimation popupAnimation\n\t{\n\t\tget\n\t\t{\n\t\t\tif (_popupAnimation == null)\n\t\t\t{\n\t\t\t\t_popupAnimation = new AnimatorPopupAnimation(this);\n\t\t\t}\n\t\t\treturn _popupAnimation;\n\t\t}\n\t}";
        //     sb.Replace("// __ANIMATE__", animate_data);
        // }
        // else
        // {
        //     sb.Replace("// __ANIMATE__", "");
        // }
        
        // 判断路径
        string dirTemp = Path.GetDirectoryName(skinPath);
        if (dirTemp != "")
        {
            if (!Directory.Exists(dirTemp))
            {
                CreateFolderIfNotExists(dirTemp, "");
            }
        }
        
        File.WriteAllText(skinPath, sb.ToString());
    }
    
    public static void GenerateMediator(string mediatorName, string madiatorPath, string skinName, string name)
    {
        string template = GeSkintTemplateFilePath("TemplateMediator");
        string tempContent = File.ReadAllText(template);
        tempContent = tempContent.Replace("${TemplateMediatorClass}", mediatorName);
        tempContent = tempContent.Replace("${TemplateMediatorName}", ConvertToMediatorNames(name));
        // 判断是否添加隐藏界面
        isCreateHide = EditorUtility.DisplayDialog("提示", $"是否创建Hide界面通知？", "创建", "取消");
        if (isCreateHide)
        {
            tempContent = tempContent.Replace("${ShowTemplateMediator}", "${ShowTemplateMediator},NotificationConst.${HideTemplateMediator}");
            tempContent = tempContent.Replace("${HideTemplateMediator}", ConvertToMediatorNames("Hide" + name));
        }
        tempContent = tempContent.Replace("${ShowTemplateMediator}", ConvertToMediatorNames("Show" + name));
        tempContent = tempContent.Replace("${TemplateSkin}", skinName);
        
        File.WriteAllText(madiatorPath, tempContent);
        
        
    }
    
    public static void GenerateSubMediator(string mediatorName, string madiatorPath, string skinName, string name)
    {
        string template = GeSkintTemplateFilePath("TemplateSubMediator");
        string tempContent = File.ReadAllText(template);
        tempContent = tempContent.Replace("${TemplateMediatorClass}", mediatorName);
        tempContent = tempContent.Replace("${TemplateMediatorName}", ConvertToMediatorNames(name));
        tempContent = tempContent.Replace("${TemplateSkin}", skinName);
        
        File.WriteAllText(madiatorPath, tempContent);
    }

    public static void GenerateMediatorNameConst(string name)
    {
        string generatedCode = $"public const string {ConvertToMediatorNames(name)} = \"{name}\";" ;
        string targetScriptPath = 
            "Assets/HotUpdate/Const/MediatorNames.cs";
        string functionName = "";
        bool MediatorNamesExist = false;
        if (File.Exists(targetScriptPath))
        {
            string fileContent = File.ReadAllText(targetScriptPath);
            if (fileContent.Contains(ConvertToMediatorNames(name)))
            {
                MediatorNamesExist = true;
            }
        }
        if (!MediatorNamesExist)
        {
            functionName = "MediatorNames";
            functionName = $"public class {functionName}";
            //mediatorName
            InsertCodeToTargetScript(generatedCode, targetScriptPath, functionName, 0);
        }
        else
        {
            EditorUtility.DisplayDialog("提示", "MediatorNames中已经存在" + ConvertToMediatorNames(name) + "的配置!", "确定");
        }
    }
    
    public static void GenerateUIConfig(string name, string path)
    {
        // 判断
        string generatedCode = string.Empty;
        string functionName = "RegisterUIPanelConfig";
        bool UIConfigExist = false;
        string Str = $"UIConfig.instance.AddPanelConfig({"MediatorNames." + ConvertToMediatorNames(name)}, new UIPanelConfig()";
        string targetScriptPath =
            "Assets/HotUpdate/Core/States/LoadingInitSettingState.cs";
        string exist = ConvertToMediatorNames(name);
        if (File.Exists(targetScriptPath))
        {
            string fileContent = File.ReadAllText(targetScriptPath);
            if (fileContent.Contains(exist))
            {
                UIConfigExist = true;
            }
        }

        if (!UIConfigExist)
        {
            // path
            path = path.Replace("Assets/Arts/Prefabs/", "");
            path = path.Replace(".prefab", "");
            StringBuilder strUIConfig = new StringBuilder();
            strUIConfig.AppendLine(Str);
            strUIConfig.AppendLine("{");
            strUIConfig.AppendLine($"    panelPath = \"{path}\",");
            if (isAnimate)
            {
                strUIConfig.AppendLine("    popupMode = PopupMode.ADD_BLUR_MASK | PopupMode.ANIMATED,");
            }
            else
            {
                strUIConfig.AppendLine("    popupMode = PopupMode.ADD_BLUR_MASK,");
            }
        
            strUIConfig.AppendLine("});");
            //
            generatedCode = strUIConfig.ToString();
            
            functionName = $"public static void {functionName}()";
            //uiconfig
            InsertCodeToTargetScript(generatedCode, targetScriptPath, functionName, 2, true);
        }
        else
        {
            EditorUtility.DisplayDialog("提示", "LoadingInitSettingState中已经存在" + name + "的配置，请手动修改!", "确定");
        }

        bool MediatorNamesExist = false;
        targetScriptPath = 
            "Assets/HotUpdate/Const/MediatorNames.cs";
        if (File.Exists(targetScriptPath))
        {
            string fileContent = File.ReadAllText(targetScriptPath);
            if (fileContent.Contains(ConvertToMediatorNames(name)))
            {
                MediatorNamesExist = true;
            }
        }

        if (!MediatorNamesExist)
        {
            generatedCode = $"public const string {ConvertToMediatorNames(name)} = \"{name}\";" ;
            functionName = "MediatorNames";
            functionName = $"public class {functionName}";
            //mediatorName
            InsertCodeToTargetScript(generatedCode, targetScriptPath, functionName, 0);
        }
        else
        {
            EditorUtility.DisplayDialog("提示", "MediatorNames中已经存在" + ConvertToMediatorNames(name) + "的配置!", "确定");
        }
        
        var strNotify = "Show" + name;
        targetScriptPath = 
            "Assets/HotUpdate/Const/NotificationConst.cs";
        bool NotificationConstShow = false;
        bool NotificationConstHide = false;
        if (File.Exists(targetScriptPath))
        {
            string fileContent = File.ReadAllText(targetScriptPath);
            if (fileContent.Contains(strNotify))
            {
                NotificationConstShow = true;
            }
        }
        
        var strNotifyHide = "Hide" + name;
        if (File.Exists(targetScriptPath))
        {
            string fileContent = File.ReadAllText(targetScriptPath);
            if (fileContent.Contains(strNotifyHide))
            {
                NotificationConstHide = true;
            }
        }

        if (!NotificationConstShow)
        {
            generatedCode = $"public const string {ConvertToMediatorNames(strNotify)} = \"{strNotify}\";" ;
        }
        else
        {
            generatedCode = "";
            EditorUtility.DisplayDialog("提示", "NotificationConst已经存在" + strNotify + "的配置!", "确定");
        }
        
        string generatedCodeHide = string.Empty;
        //
        if (isCreateHide)
        {
            if (!NotificationConstHide)
            {
                generatedCodeHide = $"public const string {ConvertToMediatorNames("Hide" + name)} = \"{"Hide" + name}\";" ;
            }
            else
            {
                generatedCodeHide = "";
                EditorUtility.DisplayDialog("提示", "NotificationConst已经存在" + strNotifyHide + "的配置!", "确定");
            }
        }
        
        functionName = "NotificationConst";
        functionName = $"public static partial class {functionName}";
        
        //notifyName
        InsertCodeToTargetScript(generatedCode, targetScriptPath, functionName, 0);
        if (generatedCodeHide != string.Empty)
        {
            InsertCodeToTargetScript(generatedCodeHide, targetScriptPath, functionName, 0);
        }
    }

    [MenuItem("GameObject/创建UI/ItemRender", false, 0)]
    public static void MediatorCreateUIItemRender1()
    {
        bool confirm = EditorUtility.DisplayDialog("提示", "确定要创建么？", "确认", "取消");
        if (!confirm)
        {
            return;
        }
        CreateItemRenderer();
    }
    
    [MenuItem("Assets/上传Asset&Hash", false, 0)]
    public static void UpdateHash()
    {
        bool confirm = EditorUtility.DisplayDialog("提示", "确定要上传么？", "确认", "取消");
        if (!confirm)
        {
            return;
        }
        var select = Selection.activeObject;
        var perfab_path = AssetDatabase.GetAssetOrScenePath(select);
        var ext = perfab_path.Split(".")[^1];
        var dir = Directory.GetParent(Application.dataPath);
        string fileName = $"{dir.FullName}/{perfab_path}";
        if (File.Exists(fileName))
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                GameLaunch.UploadFile($"game/{select.name}.{ext}", null, fileStream);
                // 上传完成
                Debug.Log($"上传Assets完成:game/{select.name}.{ext}!!!!!!!!!!!!!!!");
            }
        }

        //
        string hashStr = GameLaunch.GetMD5Hash(fileName);
        
        // 写入hash.txt
        string hashFile = $"{Application.persistentDataPath}/{select.name}_hash.txt";
        File.WriteAllText(hashFile, hashStr);
        // 自动上传
        using (FileStream fileStream = new FileStream(hashFile, FileMode.Open))
        {
            GameLaunch.UploadFile($"game/{select.name}_hash.txt", null, fileStream);
            Debug.Log($"上传Hash成功:game/{select.name}_hash.txt");
        }
    }
    
    [MenuItem("Assets/创建UI/ItemRender", false, 3)]
    public static void MediatorCreateUIItemRender2()
    {
        bool confirm = EditorUtility.DisplayDialog("提示", "确定要创建么？", "确认", "取消");
        if (!confirm)
        {
            return;
        }
        CreateItemRenderer();
    }

    public static void CreateItemRenderer()
    {
        var select = Selection.activeGameObject;
        var perfab_path = AssetDatabase.GetAssetPath(select);
        ScriptViewSkin skin = select.GetComponent<ScriptViewSkin>();
        if (skin == null)
        {
            skin = select.AddComponent<ScriptViewSkin>();
        }
        string basePath = "Assets/HotUpdate/Game/";
        if (skin != null)
        {
            //
            skin.exportType = ScriptViewSkin.ExportType.ItemRenderer;
            // 更新skin
            string objName = skin.gameObject.name;
            string dirName = string.Empty;
            // 根据驼峰命名法创建
            string[] names = SplitCamelCase(objName);
            if (names.Length > 0)
            {
                dirName = names[0];
            }

            string skinName = objName;
            string skinPath = $"{basePath}{dirName}//View/Skin/{skinName}.cs";
            string dirTemp = Path.GetDirectoryName(skinPath);
            if (dirTemp != "")
            {
                if (!Directory.Exists(dirTemp))
                {
                    CreateFolderIfNotExists(dirTemp, "");
                }
            }
            skin.exportId = skinName;
            
            if (!string.IsNullOrEmpty(dirName))
            {
                skin.exportPath = skinPath;
            }
            
            // 清空
            // bool isChoose = EditorUtility.DisplayDialog("提示", "即将清空该对象的PropList", "同意", "取消");
            // if (isChoose)
            // {
            //     skin.singlePropList.Clear();
            //     skin.multiplePropList.Clear();
            // }
            bool isChoose = false;
            // 生成skin
            if (File.Exists(skinPath))
            {
                isChoose = EditorUtility.DisplayDialog("提示", $"已经存在【ItemRender】 {skinPath}，是否重置?", "重置", "取消");
                if (isChoose)
                {
                    File.Delete(skinPath);
                    GenerateItemRenderSkin(skinName, skinPath);
                }
            }
            else
            {
                GenerateItemRenderSkin(skinName, skinPath);
            }

            if (!string.IsNullOrEmpty(perfab_path))
            {
                PrefabUtility.SavePrefabAsset(select);
            }
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogError("不存在SkiView，无法生成");
        }
    }

    [MenuItem("Assets/创建UI/SubMediator", false, 1)]
    public static void MediatorCreateUINormal()
    {
        bool confirm = EditorUtility.DisplayDialog("提示", "确定要创建么？", "确认", "取消");
        if (!confirm)
        {
            return;
        }
        // {Name}SubSkin
        var select = Selection.activeGameObject;
        var perfab_path = AssetDatabase.GetAssetPath(select);
        ScriptViewSkin skin = select.GetComponent<ScriptViewSkin>();
        if (skin == null)
        {
            skin = select.AddComponent<ScriptViewSkin>();
        }
        string basePath = "Assets/HotUpdate/Game/";
        if (skin != null)
        {
            //
            skin.exportType = ScriptViewSkin.ExportType.Normal;
            // 更新skin
            string objName = skin.gameObject.name + "Sub";
            string dirName = string.Empty;
            // 根据驼峰命名法创建
            string[] names = SplitCamelCase(objName);
            if (names.Length > 0)
            {
                dirName = names[0];
            }
            
            string skinName = objName + "Skin";
            string skinPath = $"{basePath}{dirName}//View/Skin/{skinName}.cs";
            string dirTemp = Path.GetDirectoryName(skinPath);
            if (dirTemp != "")
            {
                if (!Directory.Exists(dirTemp))
                {
                    CreateFolderIfNotExists(dirTemp, "");
                }
            }
            skin.exportId = skinName;
            
            string mediatorName = objName + "Mediator";
            string mediatorPath = $"{basePath}{dirName}//View/Mediator/{mediatorName}.cs";
            dirTemp = Path.GetDirectoryName(mediatorPath);
            if (dirTemp != "")
            {
                if (!Directory.Exists(dirTemp))
                {
                    CreateFolderIfNotExists(dirTemp, "");
                }
            }
            if (!string.IsNullOrEmpty(dirName))
            {
                skin.exportPath = skinPath;
            }
            
            // 清空
            // bool isChoose = EditorUtility.DisplayDialog("提示", "即将清空该对象的PropList", "同意", "取消");
            // if (isChoose)
            // {
            //     skin.singlePropList.Clear();
            //     skin.multiplePropList.Clear();
            // }
            bool isChoose = false;
            
            // 生成skin
            if (File.Exists(skinPath))
            {
                isChoose = EditorUtility.DisplayDialog("提示", $"已经存在【SubSkin】 {skinPath}，是否重置?", "重置", "取消");
                if (isChoose)
                {
                    File.Delete(skinPath);
                    GenerateSubSkin(skinName, skinPath);
                }
            }
            else
            {
                GenerateSubSkin(skinName, skinPath);
            }
            
            // 生成Mediator
            if (File.Exists(mediatorPath))
            {
                isChoose = EditorUtility.DisplayDialog("提示", $"已经存在【SubMediator】{mediatorPath}，是否重置?", "重置", "取消");
                if (isChoose)
                {
                    File.Delete(mediatorPath);
                    GenerateSubMediator(mediatorName, mediatorPath, skinName, objName);
                }
            }
            else
            {
                GenerateSubMediator(mediatorName, mediatorPath,  skinName, objName);
            }
            
            // 注册Const
            GenerateMediatorNameConst(objName);
            
            // 提醒注册 RegisterSubMediator
            EditorUtility.DisplayDialog("提示", "请将其注册到对应的主Mediator中，在LoadingInitSettingState", "确定");
            

            PrefabUtility.SavePrefabAsset(select);
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogError("不存在SkiView，无法生成");
        }
    }
    
    [MenuItem("Assets/创建UI/Popup", false, 0)]
    public static void MediatorCreateUI()
    {
        bool confirm = EditorUtility.DisplayDialog("提示", "确定要创建么？", "确认", "取消");
        if (!confirm)
        {
            return;
        }
        var select = Selection.activeGameObject;
        var perfab_path = AssetDatabase.GetAssetPath(select);
        ScriptViewSkin skin = select.GetComponent<ScriptViewSkin>();
        if (skin == null)
        {
            skin = select.AddComponent<ScriptViewSkin>();
        }
        string basePath = "Assets/HotUpdate/Game/";
        if (skin != null)
        {
            //
            skin.exportType = ScriptViewSkin.ExportType.Popup;
            // 更新skin
            string objName = skin.gameObject.name;
            string dirName = string.Empty;
            // 根据驼峰命名法创建
            string[] names = SplitCamelCase(objName);
            if (names.Length > 0)
            {
                dirName = names[0];
            }
            
            string skinName = objName + "Skin";
            string skinPath = $"{basePath}{dirName}//View/Skin/{skinName}.cs";
            string dirTemp = Path.GetDirectoryName(skinPath);
            if (dirTemp != "")
            {
                if (!Directory.Exists(dirTemp))
                {
                    CreateFolderIfNotExists(dirTemp, "");
                }
            }
            skin.exportId = skinName;
            
            string mediatorName = objName + "Mediator";
            string mediatorPath = $"{basePath}{dirName}//View/Mediator/{mediatorName}.cs";
            dirTemp = Path.GetDirectoryName(mediatorPath);
            if (dirTemp != "")
            {
                if (!Directory.Exists(dirTemp))
                {
                    CreateFolderIfNotExists(dirTemp, "");
                }
            }
            if (!string.IsNullOrEmpty(dirName))
            {
                skin.exportPath = skinPath;
            }
            
            // 清空
            // bool isChoose = EditorUtility.DisplayDialog("提示", "即将清空该对象的PropList", "同意", "取消");
            // if (isChoose)
            // {
            //     skin.singlePropList.Clear();
            //     skin.multiplePropList.Clear();
            // }

            bool isChoose = false;
            
            // 生成skin
            if (File.Exists(skinPath))
            {
                isChoose = EditorUtility.DisplayDialog("提示", $"已经存在【Skin】 {skinPath}，是否重置?", "重置", "取消");
                if (isChoose)
                {
                    File.Delete(skinPath);
                    GenerateSkin(skinName, skinPath);
                }
            }
            else
            {
                GenerateSkin(skinName, skinPath);
            }
            
            // 生成Mediator
            if (File.Exists(mediatorPath))
            {
                isChoose = EditorUtility.DisplayDialog("提示", $"已经存在【Mediator】{mediatorPath}，是否重置?", "重置", "取消");
                if (isChoose)
                {
                    File.Delete(mediatorPath);
                    GenerateMediator(mediatorName, mediatorPath, skinName, objName);
                }
            }
            else
            {
                GenerateMediator(mediatorName, mediatorPath,  skinName, objName);
            }
            
            // 通用注册
            GenerateUIConfig(objName, perfab_path);
            
            // 是否注册
            if (true)
            {
                // 主动注册
                // 判断
                bool isExist = false;
                string targetScriptPath = "Assets/HotUpdate/Core/Manager/SceneFacade.cs";
                var keyword = mediatorName;
                if (File.Exists(targetScriptPath))
                {
                    string fileContent = File.ReadAllText(targetScriptPath);
                    if (fileContent.Contains(keyword))
                    {
                        isExist = true;
                    }
                }
                if (!isExist)
                {
                    string generatedCode = $"new {mediatorName}(),";
                    string functionName = "RegisterSceneMediators(new List<Mediator>()";
                    // 注册
                    InsertCodeToTargetScript(generatedCode, targetScriptPath, functionName, 2);
                }
                else
                {
                    EditorUtility.DisplayDialog("提示", "HomeMapScene 中已经存在" + keyword + "的配置，请手动处理!", "确定");
                }
            }

            PrefabUtility.SavePrefabAsset(select);
            AssetDatabase.Refresh();
        }
        else
        {
            Debug.LogError("不存在SkiView，无法生成");
        }
    }
    
    
    
    ///////// 功能
    
    protected static string GeSkintTemplateFilePath(string name)
    {
	    var thisScriptPath = Application.dataPath;
	    var thisScriptDir = Path.GetDirectoryName(thisScriptPath);
	    var res = Path.Combine(thisScriptDir, $"{name}.txt");
	    return res;
    }
    
    static string ConvertToMediatorNames(string input)
    {
        string result = Regex.Replace(input, "([A-Z])", "_$1").ToUpper().TrimStart('_');
        return result;
    }
    
    public static string[] SplitCamelCase(string input)  
    {  
        // 正则表达式匹配驼峰命名中的单词边界  
        // \B 匹配一个非单词边界的位置（即位于一个单词字符和一个非单词字符之间的位置）  
        // [A-Z] 匹配任何大写字母  
        // (?<=[a-z]) 断言要匹配的大写字母前面必须是一个小写字母  
        // 因此，整个表达式匹配的是驼峰命名中大写字母前面的位置  
        var pattern = @"(?<=[a-z])[A-Z]|(?<=[A-Z])[A-Z][a-z]";  
          
        // 使用Regex.Split，但注意这里的split不是真正的分割，而是找到匹配项并保留它们  
        // 所以我们需要使用零宽度的匹配项来“分割”字符串，同时保留匹配的部分  
        var matches = Regex.Split(input, pattern);  
          
        // 过滤掉空字符串，并返回结果数组  
        return matches.Where(m => !string.IsNullOrEmpty(m)).ToArray();  
    } 
    
    private static void InsertCodeToTargetScript(string generatedCode, string targetScriptPath, string functionName, int indentCount, bool isSp = false)
    {
        if (!File.Exists(targetScriptPath))
        {
            Debug.LogError($"Target script not found: {targetScriptPath}");
            return;
        }

        string fileContent = File.ReadAllText(targetScriptPath);
        
        string functionSignature = functionName;
        int functionStartIndex = fileContent.IndexOf(functionSignature);

        if (functionStartIndex == -1)
        {
            Debug.LogError($"Function '{functionName}' not found in target script.");
            return;
        }

        int braceCount = 0;
        int functionEndIndex = -1;

        for (int i = functionStartIndex; i < fileContent.Length; i++)
        {
            if (fileContent[i] == '{')
            {
                braceCount++;
            }
            else if (fileContent[i] == '}')
            {
                braceCount--;

                if (braceCount == 0)
                {
                    functionEndIndex = i;
                    break;
                }
            }
        }

        if (functionEndIndex == -1)
        {
            Debug.LogError($"Function '{functionName}' end brace not found in target script.");
            return;
        }

        var indentStr = "";
        for (int i = 0; i < indentCount; i++)
        {
            indentStr += "    ";
        }
        string indentedGeneratedCode = "    " + generatedCode.Replace("\n", "\n" + indentStr);
        string updatedFileContent = fileContent.Remove(functionEndIndex, 1).Insert(functionEndIndex, indentedGeneratedCode + "\n"+indentStr+"}");
        if (isSp)
        {
            updatedFileContent = fileContent.Remove(functionEndIndex, 1).Insert(functionEndIndex, indentedGeneratedCode + "\n"+"    "+"}");
        }

        File.WriteAllText(targetScriptPath, updatedFileContent);

        Debug.Log($"Inserted generated code into {targetScriptPath}.");
    }
    
    private static string CreateFolderIfNotExists(string parentPath, string folderName, bool showTip = false)
    {
        string folderPath = Path.Combine(parentPath, folderName);

        if (Directory.Exists(folderPath))
        {
            Debug.LogError($"Folder '{folderName}' already exists at '{parentPath}'.");
            if (showTip)
            {
                EditorUtility.DisplayDialog("注意", $"{parentPath}存在同名文件夹{folderName}!!!", "OK");
            }
        }
        else
        {
            Directory.CreateDirectory(folderPath);
            Debug.Log($"Folder '{folderName}' created at '{parentPath}'.");
        }

        return folderPath;
    }
    
}
