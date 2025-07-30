using System.Text;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AdvancedScriptViewSkin))]
public class AdvancedScriptViewSkinEditor :ScriptViewSkinEditor
{
	private SerializedProperty _singleIntPropList;
	private SerializedProperty _singleFloatPropList;
	private SerializedProperty _singleBoolPropList;
	private SerializedProperty _singleStringPropList;
    private SerializedProperty _singleColorPropList;

	protected override void InitializeProps()
	{
		base.InitializeProps();
		this._singleIntPropList = this.serializedObject.FindProperty("singleIntPropList"); // Find the List in our script and create a refrence of it
		this._singleFloatPropList = this.serializedObject.FindProperty("singleFloatPropList"); // Find the List in our script and create a refrence of it
		this._singleBoolPropList = this.serializedObject.FindProperty("singleBoolPropList"); // Find the List in our script and create a refrence of it
		this._singleStringPropList = this.serializedObject.FindProperty("singleStringPropList"); // Find the List in our script and create a refrence of it
        this._singleColorPropList = this.serializedObject.FindProperty("singleColorPropList");
    }

	protected override StringBuilder AppendHelpBoxMsg()
	{
		var str = base.AppendHelpBoxMsg();
		str.Append(@"SingleIntProp looks like that   public int prop;              
								SingleFloatProp looks like that   public float prop;              
								SingleBoolProp looks like that   public bool prop;              
								SingleStringProp looks like that   public string prop;
                                SingleColorProp looks like that   public UnityEngine.Color prop;");
		return str;
	}

	protected override void DrawAddButtons()
	{
		base.DrawAddButtons();
		if (GUILayout.Button("Add New Single Int Property"))
		{
			this._singleIntPropList.InsertArrayElementAtIndex(this._singleIntPropList.arraySize);
			SerializedProperty propRef = this._singleIntPropList.GetArrayElementAtIndex(this._singleIntPropList.arraySize - 1);
			propRef.FindPropertyRelative("generateScript").boolValue = true;
			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			nameRef.stringValue = null;
		}

		if (GUILayout.Button("Add New Single Float Property"))
		{
			this._singleFloatPropList.InsertArrayElementAtIndex(this._singleFloatPropList.arraySize);
			SerializedProperty propRef = this._singleFloatPropList.GetArrayElementAtIndex(this._singleFloatPropList.arraySize - 1);
			propRef.FindPropertyRelative("generateScript").boolValue = true;
			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			nameRef.stringValue = null;
		}

		if (GUILayout.Button("Add New Single Bool Property"))
		{
			this._singleBoolPropList.InsertArrayElementAtIndex(this._singleBoolPropList.arraySize);
			SerializedProperty propRef = this._singleBoolPropList.GetArrayElementAtIndex(this._singleBoolPropList.arraySize - 1);
			propRef.FindPropertyRelative("generateScript").boolValue = true;
			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			nameRef.stringValue = null;
		}

		if (GUILayout.Button("Add New Single String Property"))
		{
			this._singleStringPropList.InsertArrayElementAtIndex(this._singleStringPropList.arraySize);
			SerializedProperty propRef = this._singleStringPropList.GetArrayElementAtIndex(this._singleStringPropList.arraySize - 1);
			propRef.FindPropertyRelative("generateScript").boolValue = true;
			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			nameRef.stringValue = null;
		}

        if (GUILayout.Button("Add New Single Color Property"))
        {
            this._singleColorPropList.InsertArrayElementAtIndex(this._singleColorPropList.arraySize);
            SerializedProperty propRef = this._singleColorPropList.GetArrayElementAtIndex(this._singleColorPropList.arraySize - 1);
            propRef.FindPropertyRelative("generateScript").boolValue = true;
            SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
            nameRef.stringValue = null;
        }
    }

	protected override void DrawPropertyAreas()
	{
		base.DrawPropertyAreas();

		EditorGUILayout.Space();

		EditorGUILayout.LabelField("--Single Int Prop Field------------------------------------------------------------------------------------------------------------------------------");

		EditorGUILayout.Space();



		//Display our list to the inspector window

		for (int i = 0; i < this._singleIntPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleIntPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			SerializedProperty valRef = propRef.FindPropertyRelative("propVal");
			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");



			//2 : Full custom GUI Layout <-- Choose me I can be fully customized with GUI options.
			EditorGUILayout.BeginHorizontal();
			nameRef.stringValue = EditorGUILayout.TextField("", string.IsNullOrEmpty(nameRef.stringValue) ? "singleIntProp" + i : nameRef.stringValue, GUILayout.Width(150));
			
			valRef.intValue = EditorGUILayout.IntField("", valRef.intValue, GUILayout.Width(150));
			bool delthis = false;
			if (GUILayout.Button("X", GUILayout.Width(18), GUILayout.Height(18)))
			{
				this._singleIntPropList.DeleteArrayElementAtIndex(i);
				delthis = true;
			}

			if (!delthis)
			{
				if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(18)))
				{
					this._singleIntPropList.InsertArrayElementAtIndex(i + 1);
					this._singleIntPropList.GetArrayElementAtIndex(this._singleIntPropList.arraySize - 1).FindPropertyRelative("generateScript").boolValue = true;
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

		EditorGUILayout.LabelField("--Single Float Prop Field------------------------------------------------------------------------------------------------------------------------------");

		EditorGUILayout.Space();



		//Display our list to the inspector window

		for (int i = 0; i < this._singleFloatPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleFloatPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			SerializedProperty valRef = propRef.FindPropertyRelative("propVal");
			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");



			//2 : Full custom GUI Layout <-- Choose me I can be fully customized with GUI options.
			EditorGUILayout.BeginHorizontal();
			nameRef.stringValue = EditorGUILayout.TextField("", string.IsNullOrEmpty(nameRef.stringValue) ? "singleFloatProp" + i : nameRef.stringValue, GUILayout.Width(150));

			valRef.floatValue = EditorGUILayout.FloatField("", valRef.floatValue, GUILayout.Width(150));
			bool delthis = false;
			if (GUILayout.Button("X", GUILayout.Width(18), GUILayout.Height(18)))
			{
				this._singleFloatPropList.DeleteArrayElementAtIndex(i);
				delthis = true;
			}

			if (!delthis)
			{
				if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(18)))
				{
					this._singleFloatPropList.InsertArrayElementAtIndex(i + 1);
					this._singleFloatPropList.GetArrayElementAtIndex(this._singleFloatPropList.arraySize - 1).FindPropertyRelative("generateScript").boolValue = true;
				}

				generateScriptRef.boolValue = GUILayout.Toggle(generateScriptRef.boolValue, "", GUILayout.Width(20),
					GUILayout.Height(18));
			}
			EditorGUILayout.EndHorizontal();

		}

		EditorGUILayout.Space();

		EditorGUILayout.LabelField("--Single Bool Prop Field------------------------------------------------------------------------------------------------------------------------------");

		EditorGUILayout.Space();



		//Display our list to the inspector window

		for (int i = 0; i < this._singleBoolPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleBoolPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			SerializedProperty valRef = propRef.FindPropertyRelative("propVal");
			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");



			//2 : Full custom GUI Layout <-- Choose me I can be fully customized with GUI options.
			EditorGUILayout.BeginHorizontal();
			nameRef.stringValue = EditorGUILayout.TextField("", string.IsNullOrEmpty(nameRef.stringValue) ? "singleBoolProp" + i : nameRef.stringValue, GUILayout.Width(150));

			valRef.boolValue = EditorGUILayout.Toggle(valRef.boolValue, "", GUILayout.Width(150));
			bool delthis = false;
			if (GUILayout.Button("X", GUILayout.Width(18), GUILayout.Height(18)))
			{
				this._singleBoolPropList.DeleteArrayElementAtIndex(i);
				delthis = true;
			}

			if (!delthis)
			{
				if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(18)))
				{
					this._singleBoolPropList.InsertArrayElementAtIndex(i + 1);
					this._singleBoolPropList.GetArrayElementAtIndex(this._singleBoolPropList.arraySize - 1).FindPropertyRelative("generateScript").boolValue = true;
				}

				generateScriptRef.boolValue = GUILayout.Toggle(generateScriptRef.boolValue, "", GUILayout.Width(20),
					GUILayout.Height(18));
			}
			EditorGUILayout.EndHorizontal();

		}

		EditorGUILayout.Space();

		EditorGUILayout.LabelField("--Single String Prop Field------------------------------------------------------------------------------------------------------------------------------");

		EditorGUILayout.Space();



		//Display our list to the inspector window

		for (int i = 0; i < this._singleStringPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleStringPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
			SerializedProperty valRef = propRef.FindPropertyRelative("propVal");
			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");



			//2 : Full custom GUI Layout <-- Choose me I can be fully customized with GUI options.
			EditorGUILayout.BeginHorizontal();
			nameRef.stringValue = EditorGUILayout.TextField("", string.IsNullOrEmpty(nameRef.stringValue) ? "singleStringProp" + i : nameRef.stringValue, GUILayout.Width(150));

			valRef.stringValue = EditorGUILayout.TextField("", valRef.stringValue, GUILayout.Width(150));
			bool delthis = false;
			if (GUILayout.Button("X", GUILayout.Width(18), GUILayout.Height(18)))
			{
				this._singleStringPropList.DeleteArrayElementAtIndex(i);
				delthis = true;
			}

			if (!delthis)
			{
				if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(18)))
				{
					this._singleStringPropList.InsertArrayElementAtIndex(i + 1);
					this._singleStringPropList.GetArrayElementAtIndex(this._singleStringPropList.arraySize - 1).FindPropertyRelative("generateScript").boolValue = true;
				}

				generateScriptRef.boolValue = GUILayout.Toggle(generateScriptRef.boolValue, "", GUILayout.Width(20),
					GUILayout.Height(18));
			}
			EditorGUILayout.EndHorizontal();

		}

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("--Single Color Prop Field------------------------------------------------------------------------------------------------------------------------------");

        EditorGUILayout.Space();

        for (int i = 0; i < this._singleColorPropList.arraySize; ++i)
        {
            SerializedProperty propRef = this._singleColorPropList.GetArrayElementAtIndex(i);

            SerializedProperty nameRef = propRef.FindPropertyRelative("propName");
            SerializedProperty valRef = propRef.FindPropertyRelative("propVal");
            SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");



            //2 : Full custom GUI Layout <-- Choose me I can be fully customized with GUI options.
            EditorGUILayout.BeginHorizontal();
            nameRef.stringValue = EditorGUILayout.TextField("", string.IsNullOrEmpty(nameRef.stringValue) ? "singleStringProp" + i : nameRef.stringValue, GUILayout.Width(150));

            valRef.colorValue = EditorGUILayout.ColorField(valRef.colorValue, GUILayout.Width(150));
            bool delthis = false;
            if (GUILayout.Button("X", GUILayout.Width(18), GUILayout.Height(18)))
            {
                this._singleColorPropList.DeleteArrayElementAtIndex(i);
                delthis = true;
            }

            if (!delthis)
            {
                if (GUILayout.Button("+", GUILayout.Width(20), GUILayout.Height(18)))
                {
                    this._singleColorPropList.InsertArrayElementAtIndex(i + 1);
                    this._singleColorPropList.GetArrayElementAtIndex(this._singleColorPropList.arraySize - 1).FindPropertyRelative("generateScript").boolValue = true;
                }

                generateScriptRef.boolValue = GUILayout.Toggle(generateScriptRef.boolValue, "", GUILayout.Width(20),
                    GUILayout.Height(18));
            }
            EditorGUILayout.EndHorizontal();

        }
    }

	protected override void GeneratePropFields(StringBuilder sb)
	{
		base.GeneratePropFields(sb);
		for (int i = 0; i < this._singleIntPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleIntPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine("public int " + nameRef.stringValue + ";");
		}

		for (int i = 0; i < this._singleFloatPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleFloatPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine("public float " + nameRef.stringValue + ";");
		}

		for (int i = 0; i < this._singleBoolPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleBoolPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine("public bool " + nameRef.stringValue + ";");
		}

		for (int i = 0; i < this._singleStringPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleStringPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine("public string " + nameRef.stringValue + ";");
		}

        for (int i = 0; i < this._singleColorPropList.arraySize; ++i)
        {
            SerializedProperty propRef = this._singleColorPropList.GetArrayElementAtIndex(i);

            SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

            SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
            if (generateScriptRef.boolValue)
                sb.AppendLine("public UnityEngine.Color " + nameRef.stringValue + ";");
        }
    }

	protected override void GenerateConstructor(StringBuilder sb)
	{
		base.GenerateConstructor(sb);
		sb.AppendLine("AdvancedScriptViewSkin advViewSkin = _viewSkin as AdvancedScriptViewSkin;");
		for (int i = 0; i < this._singleIntPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleIntPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine("this." + nameRef.stringValue + " = advViewSkin.GetSingleIntProperty(\"" + nameRef.stringValue + "\");");
		}

		for (int i = 0; i < this._singleFloatPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleFloatPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine("this." + nameRef.stringValue + " = advViewSkin.GetSingleFloatProperty(\"" + nameRef.stringValue + "\");");
		}

		for (int i = 0; i < this._singleBoolPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleIntPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine("this." + nameRef.stringValue + " = advViewSkin.GetSingleBoolProperty(\"" + nameRef.stringValue + "\");");
		}

		for (int i = 0; i < this._singleStringPropList.arraySize; ++i)
		{
			SerializedProperty propRef = this._singleStringPropList.GetArrayElementAtIndex(i);

			SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

			SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
			if (generateScriptRef.boolValue)
				sb.AppendLine("this." + nameRef.stringValue + " = advViewSkin.GetSingleStringProperty(\"" + nameRef.stringValue + "\");");
		}

        for (int i = 0; i < this._singleColorPropList.arraySize; ++i)
        {
            SerializedProperty propRef = this._singleColorPropList.GetArrayElementAtIndex(i);

            SerializedProperty nameRef = propRef.FindPropertyRelative("propName");

            SerializedProperty generateScriptRef = propRef.FindPropertyRelative("generateScript");
            if (generateScriptRef.boolValue)
                sb.AppendLine("this." + nameRef.stringValue + " = advViewSkin.GetSingleColorProperty(\"" + nameRef.stringValue + "\");");
        }
    }
}