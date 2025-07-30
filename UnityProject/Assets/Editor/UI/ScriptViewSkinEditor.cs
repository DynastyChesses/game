using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Object = UnityEngine.Object;
using System.Linq;
using TMPro;
using UnityEngine.UI;

[CustomEditor(typeof(ScriptViewSkin))]
public partial class ScriptViewSkinEditor :UnityEditor.Editor
{
	private SerializedProperty _singlePropList;
	private SerializedProperty _multiplePropList;
	protected SerializedProperty _exportId;
	protected SerializedProperty _exportPath;
	protected SerializedProperty _exportType;

	protected ScriptViewSkin asset;

	private List<Type> _sPropTypeList = new List<Type>();
	private List<Type> _mPropTypes = new List<Type>();

    private List<List<string>> _addPropertyList = new List<List<string>>();
    private Dictionary<string, string> _addContainDictionary = new Dictionary<string, string>()
    {
        {"ItemSpriteDisplySkin", "ItemSpriteDisply"},
    };

	private const string TabSymbol = "	";
	private const string TabSymbolTow = "		";
	private string searchKeyword = string.Empty;
	void OnEnable()
	{
        asset = target as ScriptViewSkin;
		InitializeProps();
	}

	protected virtual void InitializeProps()
	{
		this._singlePropList = this.serializedObject.FindProperty("singlePropList"); // Find the List in our script and create a refrence of it
		this._multiplePropList = this.serializedObject.FindProperty("multiplePropList");
		this._exportId = this.serializedObject.FindProperty("exportId");
		this._exportPath = this.serializedObject.FindProperty("exportPath");
		this._exportType = this.serializedObject.FindProperty("exportType");
	}

	protected virtual string GetTemplateFilePath()
	{
		var thisScriptPath = $"{Application.dataPath}/Templates/";
		var thisScriptDir = Path.GetDirectoryName(thisScriptPath);
		var res = Path.Combine(thisScriptDir, "ScriptViewTemplate.txt");
		return res;
	}

	protected virtual StringBuilder AppendHelpBoxMsg()
	{
		var str = new StringBuilder();
		str.Append(@"SingleProp looks like that   public PropType prop;               
								MultipleProp looks like that   public List<PropType> prop;              
								");
		return str;
	}

	protected virtual void DrawAddButtons()
	{
		if (GUILayout.Button("Add New Single Property"))
		{
			this._singlePropList.InsertArrayElementAtIndex(this._singlePropList.arraySize);
			SerializedProperty propRef = this._singlePropList.GetArrayElementAtIndex(this._singlePropList.arraySize - 1);
			propRef.FindPropertyRelative("generateScript").boolValue = true;
			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			nameRef.stringValue = null;
		}

		if (GUILayout.Button("Add New Multiple Property"))
		{
			this._multiplePropList.InsertArrayElementAtIndex(this._multiplePropList.arraySize);
			SerializedProperty propRef = this._multiplePropList.GetArrayElementAtIndex(this._multiplePropList.arraySize - 1);
			propRef.FindPropertyRelative("generateScript").boolValue = true;
			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			nameRef.stringValue = null;
		}
	}

	private static List<Component> _cachedComponents = new List<Component>();

	protected virtual void DrawPropertyAreas()
	{
		EditorGUILayout.Space();
		
		EditorGUILayout.LabelField("-- 模糊搜索 ------------------------------------------------------------------------------------------------------------------------------");
		EditorGUILayout.BeginHorizontal();
		string tempKeyword = EditorGUILayout.TextField(searchKeyword);
		if (tempKeyword != searchKeyword)
		{
			searchKeyword = tempKeyword;
		}
		EditorGUILayout.EndHorizontal();
		EditorGUILayout.Space();

		
		EditorGUILayout.LabelField("--Single Prop Field------------------------------------------------------------------------------------------------------------------------------");

		EditorGUILayout.Space();



		//Display our list to the inspector window

		_sPropTypeList.Clear();

		for (int i = 0; i < this._singlePropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singlePropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			SerializedProperty valRef = propRef.FindPropertyRelative("propVal");
			if (searchKeyword.Trim() != "" && (!nameRef.stringValue.Contains(searchKeyword.Trim()) && !valRef.objectReferenceValue.name.Contains(searchKeyword.Trim())))
			{
				continue;
			}
			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");



			//2 : Full custom GUI Layout <-- Choose me I can be fully customized with GUI options.
			EditorGUILayout.BeginHorizontal();
			nameRef.stringValue = EditorGUILayout.TextField("", string.IsNullOrEmpty(nameRef.stringValue) ? "singleProp" + i : nameRef.stringValue, GUILayout.Width(150));
			Type selectType = null;
			Type[] types = null;
			string[] typeNames = null;
			if (valRef.objectReferenceValue == null)
			{
				selectType = typeof(Object);
			}
			else if (valRef.objectReferenceValue is GameObject)
			{
				var gameObj = valRef.objectReferenceValue as GameObject;
				_cachedComponents.Clear();
				gameObj.GetComponents<Component>(_cachedComponents);
				for (int j = 0; j < _cachedComponents.Count;)
				{
					if (!_cachedComponents[j])
					{
						// Debug.LogWarning($"{gameObj.name} found missing component");
						_cachedComponents.RemoveAt(j);
					}
					else
					{
						++j;
					}
				}

				var cCount = _cachedComponents.Count;
				typeNames = new string[cCount + 1];
				types = new Type[cCount + 1];
				typeNames[0] = typeof(GameObject).Name;
				types[0] = typeof(GameObject);
				for (int j = 0; j < cCount; ++j)
				{
					types[j + 1] = _cachedComponents[j].GetType();
					typeNames[j + 1] = types[j + 1].Name;
				}
				int selIndex = EditorGUILayout.Popup("", 0, typeNames, GUILayout.Width(100));
				selectType = types[selIndex];
				if (selIndex != 0)
				{
					valRef.objectReferenceValue = gameObj.GetComponent(selectType);
				}
			}
			else if (valRef.objectReferenceValue is Component)
			{
				var comp = valRef.objectReferenceValue as Component;
				var gameObj = comp.gameObject;
				_cachedComponents.Clear();
				gameObj.GetComponents<Component>(_cachedComponents);
				for (int j = 0; j < _cachedComponents.Count;)
				{
					if (!_cachedComponents[j])
					{
						// Debug.LogWarning($"{gameObj.name} found missing component");
						_cachedComponents.RemoveAt(j);
					}
					else
					{
						++j;
					}
				}

				var cCount = _cachedComponents.Count;
				typeNames = new string[cCount + 1];
				types = new Type[cCount + 1];
				typeNames[0] = typeof(GameObject).Name;
				types[0] = typeof(GameObject);
				int selIndex = 0;
				for (int j = 0; j < cCount; ++j)
				{
					if (_cachedComponents[j] == comp)
					{
						selIndex = j + 1;
					}
					types[j + 1] = _cachedComponents[j].GetType();
					typeNames[j + 1] = types[j + 1].Name;
				}
				int lastIndex = selIndex;
				selIndex = EditorGUILayout.Popup("", selIndex, typeNames, GUILayout.Width(100));
				selectType = types[selIndex];
				if (selIndex != lastIndex)
				{
					valRef.objectReferenceValue = selIndex == 0 ? (Object)gameObj : (Object)gameObj.GetComponent(selectType);
				}
			}
			else
			{
				selectType = valRef.objectReferenceValue.GetType();
			}
			_sPropTypeList.Add(selectType);
			valRef.objectReferenceValue = EditorGUILayout.ObjectField("", valRef.objectReferenceValue, selectType, true, GUILayout.Width(150));
			bool delthis = false;
			if (GUILayout.Button("X", GUILayout.Width(18), GUILayout.Height(18)))
			{
				this._singlePropList.DeleteArrayElementAtIndex(i);
				_sPropTypeList.RemoveAt(i);
				delthis = true;
			}

			if (!delthis)
			{
				if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(18)))
				{
					this._singlePropList.InsertArrayElementAtIndex(i + 1);
					this._singlePropList.GetArrayElementAtIndex(this._singlePropList.arraySize - 1).FindPropertyRelative("generateScript").boolValue = true;
				}

				generateScriptRef.boolValue = GUILayout.Toggle(generateScriptRef.boolValue, "", GUILayout.Width(20),
					GUILayout.Height(18));
			}
			EditorGUILayout.EndHorizontal();

			//Remove this index from the List
			//			EditorGUILayout.LabelField("Remove an index from the List<> with a button");

			// Array fields with remove at index
		}

		EditorGUILayout.Space();

		EditorGUILayout.LabelField("--Multiple Prop Field------------------------------------------------------------------------------------------------------------------------------");

		EditorGUILayout.Space();

		_mPropTypes.Clear();

		for (int i = 0; i < this._multiplePropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._multiplePropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			SerializedProperty valRef = propRef.FindPropertyRelative("propVal");
			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");


			EditorGUILayout.BeginHorizontal();
			nameRef.stringValue = EditorGUILayout.TextField("", string.IsNullOrEmpty(nameRef.stringValue) ? "multipleProp" + i : nameRef.stringValue, GUILayout.Width(150));
			Object loopObj = GetOneObject(valRef);
			Type selectType = null;
			Type[] types = null;
			string[] typeNames = null;
			if (loopObj == null)
			{
				selectType = typeof(Object);
			}
			else if (loopObj is GameObject)
			{
				var gameObj = loopObj as GameObject;
				var components = gameObj.GetComponents<Component>();
				typeNames = new string[components.Length + 1];
				types = new Type[components.Length + 1];
				typeNames[0] = typeof(GameObject).Name;
				types[0] = typeof(GameObject);
				for (int j = 0; j < components.Length; ++j)
				{
					types[j + 1] = components[j].GetType();
					typeNames[j + 1] = types[j + 1].Name;
				}
				int selIndex = EditorGUILayout.Popup("", 0, typeNames, GUILayout.Width(100));
				selectType = types[selIndex];
				if (selIndex != 0)
				{
					for (int a = 0; a < valRef.arraySize; a++)
					{
						SerializedProperty child = valRef.GetArrayElementAtIndex(a);
						if (child != null && child.objectReferenceValue != null)
						{
							child.objectReferenceValue = (child.objectReferenceValue as GameObject).GetComponent(selectType);
						}

					}
				}
			}
			else if (loopObj is Component)
			{
				var comp = loopObj as Component;
				var gameObj = comp.gameObject;
				var components = gameObj.GetComponents<Component>();
				typeNames = new string[components.Length + 1];
				types = new Type[components.Length + 1];
				typeNames[0] = typeof(GameObject).Name;
				types[0] = typeof(GameObject);
				int selIndex = 0;
				for (int j = 0; j < components.Length; ++j)
				{
					if (components[j] == comp)
					{
						selIndex = j + 1;
					}
					types[j + 1] = components[j].GetType();
					typeNames[j + 1] = types[j + 1].Name;
				}
				int lastIndex = selIndex;
				selIndex = EditorGUILayout.Popup("", selIndex, typeNames, GUILayout.Width(100));
				selectType = types[selIndex];
				if (selIndex != lastIndex)
				{
					for (int a = 0; a < valRef.arraySize; a++)
					{
						SerializedProperty child = valRef.GetArrayElementAtIndex(a);
						if (child != null && child.objectReferenceValue != null)
						{
							child.objectReferenceValue = selIndex == 0 ?
							(Object)((child.objectReferenceValue as Component).gameObject) : (child.objectReferenceValue as Component).GetComponent(selectType);
						}
					}
				}
			}
			else
			{
				selectType = loopObj.GetType();
			}

			_mPropTypes.Add(selectType);
			bool delete = GUILayout.Button("X", GUILayout.Width(18), GUILayout.Height(18));
			generateScriptRef.boolValue = GUILayout.Toggle(generateScriptRef.boolValue, "", GUILayout.Width(20), GUILayout.Height(18));

			EditorGUILayout.EndHorizontal();

			for (int a = 0; a < valRef.arraySize; a++)
			{
				EditorGUILayout.BeginHorizontal();

				valRef.GetArrayElementAtIndex(a).objectReferenceValue = EditorGUILayout.ObjectField("", valRef.GetArrayElementAtIndex(a).objectReferenceValue, selectType, true);
				if (GUILayout.Button("-", GUILayout.MaxWidth(15), GUILayout.MaxHeight(15)))
				{
					valRef.DeleteArrayElementAtIndex(a);
				}
				EditorGUILayout.EndHorizontal();
			}

			if (GUILayout.Button("Add", GUILayout.MaxWidth(50), GUILayout.MaxHeight(18)))
			{
				valRef.InsertArrayElementAtIndex(valRef.arraySize);
				this._multiplePropList.GetArrayElementAtIndex(this._multiplePropList.arraySize - 1).FindPropertyRelative("generateScript").boolValue = true;
			}

			EditorGUILayout.Space();

			//Remove this index from the List
			if (delete)
			{
				this._multiplePropList.DeleteArrayElementAtIndex(i);
				_mPropTypes.RemoveAt(i);
			}
			EditorGUILayout.Space();
		}
	}

	protected virtual void GeneratePropFields(StringBuilder sb)
	{
        _addPropertyList.Clear();

        for (int i = 0; i < this._singlePropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singlePropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
		    if (generateScriptRef.boolValue)
		    {
		        sb.AppendLine(TabSymbol + "public " + _sPropTypeList[i].Name + " " + nameRef.stringValue + ";");

                SerializedProperty propGameObject = propRef.FindPropertyRelative("propVal");
		        GameObject go = propGameObject.objectReferenceValue as GameObject;

		        if (go)
		        {
                    ScriptViewSkin skin = go.GetComponent<ScriptViewSkin>();

                    if (skin != null && _addContainDictionary.ContainsKey(skin.exportId))
                    {
                        _addPropertyList.Add(new List<string>() { nameRef.stringValue, _addContainDictionary[skin.exportId], nameRef.stringValue + "Display"});

                        sb.AppendLine(TabSymbol + "public " + _addContainDictionary[skin.exportId] + " " + nameRef.stringValue + "Display" + ";");
                    }
                }
		    }
		}

		for (int i = 0; i < this._multiplePropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._multiplePropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");

			if (generateScriptRef.boolValue)
				sb.AppendLine(TabSymbol + "public SkinUObjectList<" + _mPropTypes[i].Name + "> " + nameRef.stringValue + ";");
		}
	}

	protected virtual void GenerateConstructor(StringBuilder sb)
	{
		for (int i = 0; i < this._singlePropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singlePropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine(TabSymbolTow + "this." + nameRef.stringValue + " = _viewSkin.GetSingleProperty(\"" + nameRef.stringValue + "\", " + i + ") as " +
							_sPropTypeList[i].Name + ";");
		}

	    for (int i = 0; i < this._addPropertyList.Count; i++)
	    {
	        sb.AppendLine(TabSymbolTow + "this." + _addPropertyList[i][2] + " = new " + _addPropertyList[i][1] + "(this." + _addPropertyList[i][0] + ");");
	    }

		for (int i = 0; i < this._multiplePropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._multiplePropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine(TabSymbolTow + "this." + nameRef.stringValue + " = new SkinUObjectList<" + _mPropTypes[i].Name + ">(_viewSkin, \"" + nameRef.stringValue + "\", " + i + ");");
		}
	}

//     protected virtual void GenerateDispose(StringBuilder sb)
//     {
//         var typesSet = new HashSet<string>(GetItemRendererHostTypes());
//         for (int i = 0; i < this._singlePropList.arraySize; ++i)
//         {
//             SerializedProperty propRef = this._singlePropList.GetArrayElementAtIndex(i);

//             SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

//             SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");

//             if (generateScriptRef.boolValue && typesSet.Contains(_sPropTypeList[i].Name))
//             {
//                 sb.AppendLine(TabSymbolTow + nameRef.stringValue + ".Dispose();");
//             }
//         }

//         for (int i = 0; i < this._addPropertyList.Count; i++)
//         {
//             sb.AppendLine(TabSymbolTow + "this." + _addPropertyList[i][2] + ".Dispose();");
//         }

//         for (int i = 0; i < this._multiplePropList.arraySize; ++i)
//         {
//             SerializedProperty propRef = this._multiplePropList.GetArrayElementAtIndex(i);

//             SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

//             SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
// 	        if (generateScriptRef.boolValue && _mPropTypes.Count > i && _mPropTypes[i] != null &&
// 	            typesSet.Contains(_mPropTypes[i].Name))
// 	        {
// 		        sb.AppendLine(TabSymbolTow + string.Format("foreach (var item in {0})", nameRef.stringValue));
// 		        sb.AppendLine(TabSymbolTow + TabSymbol +"item.Dispose();");
// //		        sb.AppendLine(TabSymbolTow + nameRef.stringValue + string.Format("{0}.Dispose();", i));
// 	        }
//         }
//     }

//     private IEnumerable<string> GetItemRendererHostTypes()
//     {
//         var types = Assembly.GetAssembly(typeof(IItemRendererHost)).GetTypes();

//         var set = new HashSet<string>();
//         foreach (var type in types)
//         {
//             foreach (var @interface in type.GetInterfaces())
//             {
//                 if (@interface == typeof (IItemRendererHost))
//                 {
//                     set.Add(type.Name);
//                 }
//             }
//         }

//         return set;
//     }

    private void DrawGenerationArea()
	{
		if (searchKeyword.Equals(""))
		{
			if (GUILayout.Button("GenerateUIScript"))
			{
				if (string.IsNullOrEmpty(_exportId.stringValue))
				{
					Debug.LogError("No Script Name!");
					//Apply the changes to our list
					this.serializedObject.ApplyModifiedProperties();
					return;
				}
				string path = _exportPath.stringValue;
				if (path.StartsWith("/"))
				{
					path = path.Remove(0, 1);
				}
				string saveRootPath = Application.dataPath.Replace("/Assets", "/");
				string fullPath = path;
				if (string.IsNullOrEmpty(path))
				{
					path = EditorUtility.SaveFilePanel("export cs file", _exportId.stringValue + ".cs", "cs",
																"Please enter a file name to export the script to");

					fullPath = path;
					path = fullPath.Replace(saveRootPath,"");
				}
				else
				{
					string fixPath = path.Replace(saveRootPath,"");
					fullPath = saveRootPath + fixPath;
				}
				_exportPath.stringValue = path;
				if (path.Length == 0)
				{
					//Apply the changes to our list
					this.serializedObject.ApplyModifiedProperties();
					return;
				}

				StringBuilder sb = new StringBuilder();
				const string defStartComment = "//auto generate propertyDef Start, Don't Delete it!";
				const string defEndComment = "//auto generate propertyDef End, Don't Delete it!";
				const string setStartComment = "//auto generate propertySet Start, Don't Delete it!";
	            const string setEndComment = "//auto generate propertySet End, Don't Delete it!";
	            const string disStartComment = "//auto generate propertyDis Start, Don't Delete it!";
	            const string disEndComment = "//auto generate propertyDis End, Don't Delete it!";
				bool partialReplace = false;
			    bool autoGenerateDispose = false;
				string template = null;
				if (File.Exists(fullPath))
				{
					partialReplace = true;
					string fileContent = File.ReadAllText(fullPath, Encoding.UTF8);
	                if (!(fileContent.Contains(defStartComment) &&
	                      fileContent.Contains(defEndComment) &&
	                      fileContent.Contains(setStartComment) &&
	                      fileContent.Contains(setEndComment)))
					{
						if (EditorUtility.DisplayDialog("警告", "目标文件中未发现自动生成注释，继续可能覆盖文件，是否继续", "是", "否"))
						{
							partialReplace = false;
						}
						else
						{
							//Apply the changes to our list
							this.serializedObject.ApplyModifiedProperties();
							return;
						}
					}
					else
					{
						template = fileContent;
					}

				    if(fileContent.Contains(disStartComment) &&
				        fileContent.Contains(disEndComment))
				    {
				        autoGenerateDispose = true;
	                    //Debug.Log("自动生成Dispose函数");
				    }
				    else
				    {
				         autoGenerateDispose = false;
	                    //Debug.Log("未生成Dispose函数");
				    }
				}


				if (!partialReplace)
				{
					template = File.ReadAllText(GetTemplateFilePath(), Encoding.UTF8);
					ScriptViewSkin.ExportType exportType =
						(ScriptViewSkin.ExportType) Enum.GetValues(typeof (ScriptViewSkin.ExportType)).GetValue(_exportType.enumValueIndex);
					template = template.Replace("${className}", this._exportId.stringValue);
					template = template.Replace("${propSetFuncName}",
						exportType != ScriptViewSkin.ExportType.ItemRenderer ? this._exportId.stringValue : "override void Replace");
					string baseClsName;
					string baseCall = " : base(viewObj)";
				    string replaceBase = "";
					switch (exportType)
					{
						case ScriptViewSkin.ExportType.Popup:
							baseClsName = "BaseGamePopupView";
							break;
						case ScriptViewSkin.ExportType.ItemRenderer:
							baseClsName = "BaseScriptItemRendererView";
							baseCall = "";
					        replaceBase = "base.Replace(viewObj);";
	                        break;
						case ScriptViewSkin.ExportType.Normal:
						default:
							baseClsName = "BaseScriptView";
	                        break;
					}
					template = template.Replace("${baseClass}", baseClsName);
					template = template.Replace("${baseCall}", baseCall);
					template = template.Replace("${propertySetFirstPart}", replaceBase);
	            }
				else
				{
					sb.AppendLine(defStartComment);
				}

				GeneratePropFields(sb);

				if (!partialReplace)
				{
					sb.Remove(sb.Length - 1, 1);
					template = template.Replace("${propertyDef}", sb.ToString());
				}
				else
				{
					sb.AppendLine(TabSymbol + defEndComment);
					int defStartIndex = template.IndexOf(defStartComment);
					int defEndIndex = template.IndexOf(defEndComment);
					template = template.Remove(defStartIndex, defEndIndex - defStartIndex);
					template = template.Replace(defEndComment, sb.ToString());
				}

				sb.Length = 0;

				if (partialReplace)
				{
					sb.AppendLine(setStartComment);
				}

				GenerateConstructor(sb);

				if (!partialReplace)
				{
					sb.Remove(sb.Length - 1, 1);
					template = template.Replace("${propertySet}", sb.ToString());
				}
				else
				{
					sb.AppendLine(TabSymbolTow + setEndComment);
					int setStartIndex = template.IndexOf(setStartComment);
					int setEndIndex = template.IndexOf(setEndComment);
					template = template.Remove(setStartIndex, setEndIndex - setStartIndex);
					template = template.Replace(setEndComment, sb.ToString());
				}

	            sb.Length = 0;


	            if (partialReplace)
	            {
	                sb.AppendLine(disStartComment);
	            }

	            // GenerateDispose(sb);

			    if (!partialReplace)
			    {
					if (sb.Length > 0)
					{
			    		sb.Remove(sb.Length - 1, 1);
					}
	                template = template.Replace("${propertyDis}", sb.ToString());
			    }
	            else if(autoGenerateDispose)
	            {
	                sb.AppendLine(TabSymbolTow + disEndComment);
	                int disStartIndex = template.IndexOf(disStartComment);
	                int disEndIndex = template.IndexOf(disEndComment);
	                template = template.Remove(disStartIndex, disEndIndex - disStartIndex);
	                template = template.Replace(disEndComment, sb.ToString());
	            }

				File.WriteAllText(fullPath, template, Encoding.UTF8);
				EditorUtility.DisplayDialog("message", "Export Skin Completed", "ok");
				AssetDatabase.ImportAsset(fullPath.Replace(saveRootPath, ""));
			}
		}
	}

	public override void OnInspectorGUI()
	{
		this.serializedObject.Update();

		//Choose how to display the list<> Example purposes only
		EditorGUILayout.Space();
		EditorGUILayout.Space();

		//Or add a new item to the List<> with a button

		//		ScriptViewSkin.SkinProperty newSkinProp = null;

		_exportId.stringValue = EditorGUILayout.TextField("Skin ID", _exportId.stringValue);

		EditorGUILayout.BeginHorizontal();
		_exportPath.stringValue = EditorGUILayout.TextField("Skin Path", _exportPath.stringValue);
		if (GUILayout.Button("Open file"))
		{
			string path = _exportPath.stringValue;
			string saveRootPath = Application.dataPath.Replace("/Assets", "/");
			string relativePath = path.Replace(saveRootPath, "");
			string fullPath = saveRootPath + relativePath;

			if (!File.Exists(fullPath))
			{
				string folder = "";
				if (EditorPrefs.HasKey("lastSkinFolder"))
				{
					folder = EditorPrefs.GetString("lastSkinFolder") + "/";
					folder = saveRootPath + folder;
				}
				
				fullPath = EditorUtility.SaveFilePanel("Open .cs file",folder,_exportId.stringValue + ".cs","cs");
				if (!string.IsNullOrEmpty(fullPath))
				{
					string savePath = Path.GetDirectoryName(fullPath);
					string saveRelativePath = savePath.Replace(saveRootPath, "");
					
					EditorPrefs.SetString("lastSkinFolder", Path.GetDirectoryName(saveRelativePath));
				}
			}

			relativePath = fullPath.Replace(saveRootPath, "");
			
			_exportPath.stringValue = relativePath;
			if (File.Exists(fullPath))
			{
				UnityEditorInternal.InternalEditorUtility.OpenFileAtLineExternal(fullPath, 1);
			}
		}
		EditorGUILayout.EndHorizontal();


		EditorGUILayout.Space();
		EditorGUILayout.Space();

		_exportType.enumValueIndex = (int)(ScriptViewSkin.ExportType)EditorGUILayout.EnumPopup("Skin Type:", (ScriptViewSkin.ExportType)Enum.GetValues(typeof(ScriptViewSkin.ExportType)).GetValue(_exportType.enumValueIndex));
		EditorGUILayout.Space();
		EditorGUILayout.Space();

		EditorGUILayout.HelpBox(AppendHelpBoxMsg().ToString(), MessageType.Info);

		DrawAddButtons();

		DrawPropertyAreas();

        DrawAutoButton();
        
		DrawGenerationArea();

		AdditionFunction();
		this.serializedObject.ApplyModifiedProperties();

	}

	private Object GetOneObject(SerializedProperty prop)
	{
		if (prop.arraySize > 0)
		{
			for (int i = 0; i < prop.arraySize; ++i)
			{
				SerializedProperty child = prop.GetArrayElementAtIndex(i);
				if (child != null && child.objectReferenceValue != null)
				{
					return child.objectReferenceValue as Object;
				}
			}
		}
		return null;
	}

	protected virtual void AdditionFunction()
	{
		ScriptViewSkin t = target as ScriptViewSkin;
		if (t == null)
		{
			return;
		}
		//		ScriptPopupViewSkin otherT = t.GetComponent<ScriptPopupViewSkin>();
		//		if (otherT != null && GUILayout.Button("Copy Value From Script Popup View"))
		//		{
		//			CopyFromOtherTypeView(otherT.singlePropList, otherT.multiplePropList, otherT.exportId, otherT.exportType);
		//		}
		Component otherComp = t.GetComponent(_exportId.stringValue);
		if (otherComp != null && GUILayout.Button("Copy Value From Other Monobehavior"))
		{
			CopyFromOtherComponent(otherComp);
		}
	}

	protected void CopyFromOtherComponent(Component otherComp)
	{
		Type type = otherComp.GetType();
		FieldInfo[] fields = type.GetFields(System.Reflection.BindingFlags.Public | BindingFlags.Instance);
		List<ScriptViewSkin.SkinSingleProperty> propList = new List<ScriptViewSkin.SkinSingleProperty>();
		List<ScriptViewSkin.SkinMultipleProperty> mPropList = new List<ScriptViewSkin.SkinMultipleProperty>();
		foreach (var field in fields)
		{
			object value = field.GetValue(otherComp);
			if (value is GameObject || value is MonoBehaviour)
			{
				var prop = new ScriptViewSkin.SkinSingleProperty();
				prop.propName = field.Name;
				prop.propVal = value as Object;

				propList.Add(prop);
			}
			else if (value is IList)
			{
				var prop = new ScriptViewSkin.SkinMultipleProperty();
				prop.propName = field.Name;
				prop.propVal = new Object[(value as IList).Count];
				int counter = 0;
				foreach (var val in (value as IList))
				{
					if (val is Object)
					{
						prop.propVal[counter] = val as Object;
						++counter;
					}
				}
				mPropList.Add(prop);
			}
		}
		CopyFromOtherTypeView(propList, mPropList, _exportId.stringValue, ScriptViewSkin.ExportType.Normal);
	}

	protected void CopyFromOtherTypeView(List<ScriptViewSkin.SkinSingleProperty> otherSinglePropList, List<ScriptViewSkin.SkinMultipleProperty> otherMultiplePropList, string otherExportId, ScriptViewSkin.ExportType otherExportType)
	{
		if (otherSinglePropList != null)
		{
			if (_singlePropList.arraySize < otherSinglePropList.Count)
			{
				for (int i = otherSinglePropList.Count - _singlePropList.arraySize; i > 0; --i)
				{
					_singlePropList.InsertArrayElementAtIndex(_singlePropList.arraySize);
				}
			}
			else
			{
				_singlePropList.arraySize = otherSinglePropList.Count;
			}

			for (int i = 0; i < _singlePropList.arraySize; ++i)
			{
				SerializedProperty propRef = this._singlePropList.GetArrayElementAtIndex(i);

				SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
				SerializedProperty valRef = propRef.FindPropertyRelative("propVal");

				nameRef.stringValue = otherSinglePropList[i].propName;
				valRef.objectReferenceValue = otherSinglePropList[i].propVal;
			}

		}
		else
		{
			_singlePropList.arraySize = 0;
		}

		if (otherMultiplePropList != null)
		{
			if (_multiplePropList.arraySize < otherMultiplePropList.Count)
			{
				for (int i = otherMultiplePropList.Count - _multiplePropList.arraySize; i > 0; --i)
				{
					_multiplePropList.InsertArrayElementAtIndex(_multiplePropList.arraySize);
				}
			}
			else
			{
				_multiplePropList.arraySize = otherMultiplePropList.Count;
			}

			for (int i = 0; i < _multiplePropList.arraySize; ++i)
			{
				SerializedProperty propRef = this._multiplePropList.GetArrayElementAtIndex(i);

				SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
				SerializedProperty valRef = propRef.FindPropertyRelative("propVal");

				nameRef.stringValue = otherMultiplePropList[i].propName;

				var a = otherMultiplePropList[i].propVal;
				if (a != null)
				{

					if (valRef.arraySize < a.Length)
					{
						for (int j = a.Length - valRef.arraySize; j > 0; --j)
						{
							valRef.InsertArrayElementAtIndex(valRef.arraySize);
						}
					}
					else
					{
						valRef.arraySize = a.Length;
					}

					for (int j = 0; j < valRef.arraySize; ++j)
					{
						valRef.GetArrayElementAtIndex(j).objectReferenceValue = a[j] as Object;
					}
				}
				else
				{
					valRef.arraySize = 0;
				}
			}



		}
		else
		{
			_multiplePropList.arraySize = 0;
		}

		_exportId.stringValue = otherExportId;
		_exportType.enumValueIndex = Array.IndexOf(Enum.GetValues(typeof(ScriptViewSkin.ExportType)), otherExportType);
	}
	
	//越靠后优先级越高 比GameObject优先级小的就不需要列出来了
	private static Type[] _typePriority = new[]
	{
		typeof(GameObject),
		typeof(Image),
		typeof(Slider),
		typeof(ScrollRect),
		typeof(UGUIButtonEx),
		typeof(TextMeshProUGUI),
		typeof(TMP_InputField)
	};

	static Object RecommendComponent(Transform t,string name)
	{
		bool skipLogic = name.Equals("returnBtn") || name.Equals("ReturnBtn");
		if (skipLogic)
		{
			return t.gameObject;
		}
		var components = t.GetComponents<Component>();
		int count = components.Length;
		int mapCount = _typePriority.Length;
		int property = 0;
		Object recommend = t.gameObject;
		for (int i = 0; i < count; i++)
		{
			for (int j = 0; j < mapCount; j++)
			{
				if (components[i].GetType() == _typePriority[j] && j > property)
				{
					property = j;
					recommend = components[i];
				}
			}
		}
		return recommend;
	}

}
