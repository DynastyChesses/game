﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditorInternal;


namespace SuperScrollView
{

    [CustomEditor(typeof(LoopGridView))]
    public class LoopGridViewEditor : UnityEditor.Editor
    {

        SerializedProperty mGridFixedType;
        SerializedProperty mGridFixedRowOrColumn;
        SerializedProperty mItemSnapEnable;
        SerializedProperty mArrangeType;
        SerializedProperty mItemPrefabDataList;
        SerializedProperty mItemSnapPivot;
        SerializedProperty mViewPortSnapPivot;
        SerializedProperty mPadding;
        SerializedProperty mItemSize;
        SerializedProperty mItemPadding;
        SerializedProperty mItemRecycleDistance;

        GUIContent mItemSnapEnableContent = new GUIContent("ItemSnapEnable");
        GUIContent mArrangeTypeGuiContent = new GUIContent("ArrangeType");
        GUIContent mItemPrefabListContent = new GUIContent("ItemPrefabList");
        GUIContent mItemSnapPivotContent = new GUIContent("ItemSnapPivot");
        GUIContent mViewPortSnapPivotContent = new GUIContent("ViewPortSnapPivot");
        GUIContent mGridFixedTypeContent = new GUIContent("GridFixedType");
        GUIContent mPaddingContent = new GUIContent("Padding");
        GUIContent mItemSizeContent = new GUIContent("ItemSize");
        GUIContent mItemPaddingContent = new GUIContent("ItemPadding");
        GUIContent mGridFixedRowContent = new GUIContent("RowCount");
        GUIContent mGridFixedColumnContent = new GUIContent("ColumnCount");
        GUIContent mItemRecycleDistanceContent = new GUIContent("RecycleDistance");
        int mPreviewCount;
        bool mExpandItemPrefabList;

        protected virtual void OnEnable()
        {
            mGridFixedType = serializedObject.FindProperty("mGridFixedType");
            mItemSnapEnable = serializedObject.FindProperty("mItemSnapEnable");
            mArrangeType = serializedObject.FindProperty("mArrangeType");
            mItemPrefabDataList = serializedObject.FindProperty("mItemPrefabDataList");
            mItemSnapPivot = serializedObject.FindProperty("mItemSnapPivot");
            mViewPortSnapPivot = serializedObject.FindProperty("mViewPortSnapPivot");
            mGridFixedRowOrColumn = serializedObject.FindProperty("mFixedRowOrColumnCount");
            mItemPadding = serializedObject.FindProperty("mItemPadding");
            mPadding = serializedObject.FindProperty("mPadding");
            mItemSize = serializedObject.FindProperty("mItemSize");
            mItemRecycleDistance = serializedObject.FindProperty("mItemRecycleDistance");
            mPreviewCount = 25;
            mExpandItemPrefabList = true;
        }


        void ShowItemPrefabDataList(LoopGridView listView)
        {
            // EditorGUILayout.PropertyField(mItemPrefabDataList, mItemPrefabListContent);
            // if (mItemPrefabDataList.isExpanded == false)
            // {
            //     return;
            // }
            
            // 精简UI
            mExpandItemPrefabList = EditorGUILayout.Toggle($"ItemPrefab列表, 个数:{mItemPrefabDataList.arraySize}。展开?", mExpandItemPrefabList);
            if (mExpandItemPrefabList == false)
                return;

            EditorGUI.indentLevel += 1;
            if (GUILayout.Button("Add New"))
            {
                mItemPrefabDataList.InsertArrayElementAtIndex(mItemPrefabDataList.arraySize);
                if(mItemPrefabDataList.arraySize > 0)
                {
                    SerializedProperty itemData = mItemPrefabDataList.GetArrayElementAtIndex(mItemPrefabDataList.arraySize - 1);
                    SerializedProperty mItemPrefab = itemData.FindPropertyRelative("mItemPrefab");
                    mItemPrefab.objectReferenceValue = null;
                }
            }
            int removeIndex = -1;
            // EditorGUILayout.PropertyField(mItemPrefabDataList.FindPropertyRelative("Array.size"));
            for (int i = 0; i < mItemPrefabDataList.arraySize; i++)
            {
                SerializedProperty itemData = mItemPrefabDataList.GetArrayElementAtIndex(i);
                SerializedProperty mInitCreateCount = itemData.FindPropertyRelative("mInitCreateCount");
                SerializedProperty mItemPrefab = itemData.FindPropertyRelative("mItemPrefab");
                EditorGUILayout.BeginHorizontal();
                // EditorGUILayout.PropertyField(itemData);
                GUILayout.Label($"元素{i}");
                if (GUILayout.Button("Remove"))
                {
                    removeIndex = i;
                }
                EditorGUILayout.EndHorizontal();
                // if (itemData.isExpanded == false)
                // {
                //     continue;
                // }
                mItemPrefab.objectReferenceValue = EditorGUILayout.ObjectField("ItemPrefab", mItemPrefab.objectReferenceValue, typeof(GameObject), true);             
                mInitCreateCount.intValue = EditorGUILayout.IntField("InitCreateCount", mInitCreateCount.intValue);
                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }
            if (removeIndex >= 0)
            {
                mItemPrefabDataList.DeleteArrayElementAtIndex(removeIndex);
            }
            EditorGUI.indentLevel -= 1;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            LoopGridView tListView = serializedObject.targetObject as LoopGridView;
            if (tListView == null)
            {
                return;
            }
            ShowItemPrefabDataList(tListView);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(mGridFixedType, mGridFixedTypeContent);
            if(mGridFixedType.enumValueIndex == (int)GridFixedType.ColumnCountFixed)
            {
                EditorGUILayout.PropertyField(mGridFixedRowOrColumn, mGridFixedColumnContent);
            }
            else
            {
                EditorGUILayout.PropertyField(mGridFixedRowOrColumn, mGridFixedRowContent);
            }
            mGridFixedRowOrColumn.intValue = Mathf.Max(mGridFixedRowOrColumn.intValue, 0);
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(mPadding, mPaddingContent,true);
            EditorGUILayout.PropertyField(mItemSize, mItemSizeContent);
            EditorGUILayout.PropertyField(mItemPadding, mItemPaddingContent);
            EditorGUILayout.PropertyField(mItemRecycleDistance, mItemRecycleDistanceContent);

            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(mItemSnapEnable, mItemSnapEnableContent);
            if(mItemSnapEnable.boolValue == true)
            {
                EditorGUILayout.PropertyField(mItemSnapPivot, mItemSnapPivotContent);
                EditorGUILayout.PropertyField(mViewPortSnapPivot, mViewPortSnapPivotContent);
            }
            EditorGUILayout.Space();
            EditorGUILayout.PropertyField(mArrangeType, mArrangeTypeGuiContent);

            serializedObject.ApplyModifiedProperties();
            
            GUILayout.Space(20);
            GUILayout.Label("--------预览-------");
            mPreviewCount = EditorGUILayout.IntField("预览总数", mPreviewCount);
            mPreviewCount = Mathf.Clamp(mPreviewCount, 0, 100);
            if (GUILayout.Button("重新创建预览"))
            {
                tListView.RecreatePreviewItems(mPreviewCount);
            }
            if (GUILayout.Button("移除预览"))
            {
                tListView.RecreatePreviewItems(0);

            }
        }
    }
}
