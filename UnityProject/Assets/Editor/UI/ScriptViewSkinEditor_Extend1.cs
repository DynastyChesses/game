using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using Object = UnityEngine.Object;

public partial class ScriptViewSkinEditor : UnityEditor.Editor
{
    public static Func<string, GameObject, Object> onGetCompType;

    void DrawAutoButton()
    {
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("自动匹配-UI", GUILayout.Width(140))) {
            var name_objDic = new Dictionary<string, int>();
            for (int i = 0; i < _sPropTypeList.Count; ++i) {
                SerializedProperty propRef = this._singlePropList.GetArrayElementAtIndex(i);
                SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
                SerializedProperty valRef = propRef.FindPropertyRelative("propVal");
                SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
                var name = _sPropTypeList[i].Name;

                Debug.Log($"显示物体....{i}....{name}/{nameRef.stringValue}....{generateScriptRef.boolValue}......{valRef.objectReferenceValue}");
                if (valRef.objectReferenceValue != null && valRef.objectReferenceValue.name.ToLower().StartsWith("m_", StringComparison.Ordinal)) {
                    _RemoveComp(i);
                    i--;
                } else {
                    if (name_objDic.TryGetValue(name, out int number)) {
                        name_objDic[name] = number + 1;
                    } else {
                        name_objDic[name] = 1;
                    }
                }
            }

            var arr = asset.GetComponentsInChildren<RectTransform>(true).Where(n => n.name.ToLower().StartsWith("m_", StringComparison.Ordinal)).ToArray();
            for (int i = 0; i < arr.Length; i++) {
                _AddComp(arr[i], name_objDic);
            }
            //Debug.Log($"添加数量.......{arr.Length}");
            AssetDatabase.Refresh();
        }

        if (GUILayout.Button("匹配规则说明", GUILayout.Width(100))) {
            // TODO
        }
        EditorGUILayout.EndHorizontal();
    }

    void _AddComp(RectTransform obj, Dictionary<string, int> name_objDic)
    {
        var skin = obj.gameObject.GetComponentInParent<ScriptViewSkin>();
        if (asset != skin) {
            //Debug.LogError($"不能添加.......{asset.name}/{skin.name}");
            return;
        }
        var compObj = _MatchingRules(obj);

        var _name = obj.name.Substring(2);
        if (name_objDic.TryGetValue(_name, out int number)) {
            name_objDic[_name] = number + 1;
            _name = $"{_name}{number + 1}";
        } else {
            name_objDic[_name] = 1;
        }

        this._singlePropList.InsertArrayElementAtIndex(this._singlePropList.arraySize);
        var propRef = this._singlePropList.GetArrayElementAtIndex(this._singlePropList.arraySize - 1);
        propRef.FindPropertyRelative("generateScript").boolValue = true;
        propRef.FindPropertyRelative("propName").stringValue = _name;
        propRef.FindPropertyRelative("propVal").objectReferenceValue = (Object)compObj;
    }

    void _RemoveComp(int index)
    {
        this._singlePropList.DeleteArrayElementAtIndex(index);
        _sPropTypeList.RemoveAt(index);
    }

    object _MatchingRules(RectTransform go1)
    {
        GameObject go2 = go1.gameObject;
        var _name = go2.name;
        var len = _name.Length;
        for (int i = 0; i < len; i++) {
            var index = len - i - 1;
            var a = _name[index];
            if (a >= 65 && a <= 90) {
                var typeName = _name.Substring(index);
                try {
                    if (GetTypeObj(typeName, go2, out object compObj)) {
                        return compObj;
                    }
                } catch (Exception ex) {
                    Debug.LogError($"ScriptViewSkinEditor..错误..{ex.Message}...{ex.Message}");
                }
                break;
            }
        }

        bool GetTypeObj(string nameKey, GameObject go, out object compObj)
        {
            compObj = null;
            string typeStr = _name;
            switch (nameKey) {
                case "Bg":
                case "Img":
                case "Icon":
                case "Image":
                    compObj = go.GetComponent<Image>();
                    if (compObj == null) {
                        compObj = go.GetComponent<RawImage>();
                    }
                    if (compObj == null) {
                        compObj = go.GetComponent<MaskableGraphic>();
                    }
                    typeStr = "Image";
                    break;
                case "Btn":
                case "Button":
                    compObj = go.GetComponent<Button>();
                    typeStr = "Button";
                    break;
                case "Txt":
                case "Text":
                    compObj = go.GetComponent<Text>();
                    if (compObj == null) {
                        compObj = go.GetComponent<TMP_Text>();
                    }
                    if (compObj == null) {
                        compObj = go.GetComponent<MaskableGraphic>();
                    }
                    typeStr = "Text";
                    break;
                case "Go":
                    compObj = go.gameObject;
                    break;
                case "Bar":
                case "Scrollbar":
                    compObj = go.GetComponent<Scrollbar>();
                    break;
                case "Field":
                    if (_name.EndsWith("Field") || _name.EndsWith("InputField")) {
                        compObj = go.GetComponent<InputField>();
                    }
                    if (compObj == null) {
                        compObj = go.GetComponent<MaskField>();
                    }
                    break;
//                case "View":
//                    if (_name.EndsWith("View") || _name.EndsWith("ScrollView") || _name.EndsWith("Scroll View")) {
//                        compObj = go.GetComponent<UnityEngine.UI.ScrollView>();
//                    }
//                    break;
                case "Rect":
                    if (_name.EndsWith("Rect") || _name.EndsWith("ScrollRect")) {
                        compObj = go.GetComponent<ScrollRect>();
                    }
                    break;
                case "Down":
                case "Dropdown":
                    compObj = go.GetComponent<Dropdown>();
                    if (compObj == null) {
                        compObj = go.GetComponent<TMP_Dropdown>();
                    }
                    break;
                case "Toggle":
                    compObj = go.GetComponent<UnityEngine.UI.Toggle>();
                    if (compObj == null) {
                        compObj = go.GetComponent<UnityEngine.UIElements.Toggle>();
                    }
                    break;
                case "Slider":
                    compObj = go.GetComponent<UnityEngine.UI.Slider>();
                    break;
                case "Particle":
                    //compObj = go.GetComponent<UIParticle>();
                    break;
                case "Group":
                    compObj = go.GetComponent<ToggleGroup>();
                    break;
                case "Mask":
                    compObj = go.GetComponent<Mask>();
                    if (compObj == null) {
                        compObj = go.GetComponent<RectMask2D>();
                    }
                    if (compObj == null) {
                        compObj = go.GetComponent<MaskField>();
                    }
                    break;
                case "Shadow":
                    compObj = go.GetComponent<Shadow>();
                    break;
                case "Outline":
                    compObj = go.GetComponent<Outline>();
                    break;
            }
            if (compObj == null) {
                compObj = onGetCompType?.Invoke(typeStr, go);
            }
            return compObj != null;
        }

        return go1;
    }

    public class AutoButtonExplainWindow : EditorWindow
    {
        public static void Open(Action onSaveData)
        {
            var view = (AutoButtonExplainWindow)EditorWindow.GetWindow(typeof(AutoButtonExplainWindow), false, $"自动匹配添加UI说明", true);
            view.position = new Rect(10, 10, 1100, 1100);
            view._Init();
            view.Show();
        }

        Texture[] texArr;

        Rect viewRect;
        Rect contentRect;
        Vector2 scroll;

        void _Init()
        {
            int width = 0;
            int height = 0;
            // TODO

            var x = 0;
            var y = 0;
            viewRect = new Rect(x, y, width + 10, 1000);
            contentRect = new Rect(x, y, width + 10, height + 50);
        }

        void OnGUI()
        {
            int height = 0;
            scroll = GUI.BeginScrollView(viewRect, scroll, contentRect);
            for (int i = 0; i < texArr.Length; i++) {
                var tex = texArr[i];
                var rect = new Rect(0, height, tex.width, tex.height);
                height += tex.height + 5;
                DrawTextureWithTexCoords(rect, tex, rect, Color.white, 1);
            }

            GUI.EndScrollView();
        }
    }

    public static Rect DrawTextureWithTexCoords(Rect viewRect0, Texture tex, Rect spriteRect, Color color, float hightRatio = 1)
    {
        if (tex == null) {
            return viewRect0;
        }
        float texWidth = tex.width;
        float texHeight = tex.height;
        Rect viewRect = viewRect0;
        float viewRatio = viewRect.width / viewRect.height;
        float spriteRatio = spriteRect.width / spriteRect.height;
        if (viewRatio > spriteRatio) {
            viewRect.width = spriteRatio * viewRect.height;
        } else {
            viewRect.height = viewRect.width / spriteRatio;
        }
        if (Math.Abs(hightRatio - 1) > 0.001f) {
            var height = viewRect.height;
            viewRect.height *= hightRatio;
            viewRect.y += (height - viewRect.height) * 0.5f;
        }

        //------------调整放缩比例------------------
        spriteRect.x = spriteRect.x / texWidth;
        //屏幕坐标系原点: 左上角
        //图片坐标系原点: 左下角
        //图片的Y轴与屏幕的Y转方向相反，这里需要颠倒一下(都以左上角为坐标原点)
        //sourceRect.y = 1.0f - (sourceRect.y + sourceRect.height) / th;       
        spriteRect.y = spriteRect.y / texHeight;
        spriteRect.width = spriteRect.width / texWidth;
        spriteRect.height = spriteRect.height / texHeight;
        //------------------------------------------   
        var lastColor = GUI.color;
        GUI.color = color;
        GUI.DrawTextureWithTexCoords(viewRect, tex, spriteRect, true);
        GUI.color = lastColor;
        return viewRect;
    }
}
