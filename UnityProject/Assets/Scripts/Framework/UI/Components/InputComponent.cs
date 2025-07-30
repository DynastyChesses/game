// using System;
// using UnityEngine;
// using System.Collections;
//
// public class InputComponent : MonoBehaviour
// {
//     private System.Action<int> _onValueChange;
//     public event System.Action<int> onValueChange
//     {
//         add     {_onValueChange += value;}
//         remove  {_onValueChange -= value;}
//     }
//
//     public int value
//     {
//         get
//         {
//             return int.Parse(numInput.value);
//         }
//     }
//
//     private bool _interactive;
//     public bool interactive
//     {
//         get
//         {
//             return _interactive;
//         }
//         set
//         {
//             _interactive = value;
//             if (null != numInput)
//             {
//                 _numInputCollider = _numInputCollider ?? numInput.GetComponent<BoxCollider>();
//                 _numInputCollider.enabled = _interactive;
//             }
//             if (null != addButton)
//             {
//                 addButton.interactive = _interactive;
//             }
//
//             if (null != subButton)
//             {
//                 subButton.interactive = _interactive;
//             }
//         }
//     }
//
//     public bool setAddBtnInteractiveInternal { get; set; }
//     public bool setSubBtnInteractiveInternal { get; set; }
//
//     public UIInput numInput;
//     public UILabel maxLabel;
//     public ScaledLabelSpriteComponent subButton;
//     public ScaledLabelSpriteComponent addButton;
//     public ScaledLabelSpriteComponent maxButton;
//     private BoxCollider _numInputCollider;
//
//     private int _nowNum;
//     private int _minNum = 0;
//     private int _maxNum;
//
//     void Start()
//     {
//         if(subButton != null)
//             EventTriggerListener.Get(subButton.gameObject).onClick += OnSubButton;
//         if(addButton != null)
//             EventTriggerListener.Get(addButton.gameObject).onClick += OnAddButton;
//         if(maxButton != null)
//             EventTriggerListener.Get(maxButton.gameObject).onClick += OnMaxButton;
//
//         if(numInput != null)
//         {
// #if UNITY_EDITOR
//             EventDelegate.Add(numInput.onChange, OnInputChange);
// #else
// 			EventDelegate.Add(numInput.onSubmit, OnInputChange);
// #endif	
// //            numInput.onValidate += OnInputValidate;
//             numInput.validation = UIInput.Validation.Integer;
//         }
//     }
//
//     public void SetMinNum(int minNum)
//     {
//         this._minNum = minNum;
//     }
//
//     public void SetMaxNum(int maxNum)
//     {
//         SetMaxNum(maxNum, Color.white);
//     }
//
//     public void SetMaxNum(int maxNum, Color textColor)
//     {
//         this._maxNum = maxNum;
//         if (this.maxLabel != null)
//         {
//             this.maxLabel.color = maxNum > 0 ? textColor : Color.red;
//             this.maxLabel.text = maxNum.ToString();
//         }
//     }
//
//     public void SetVaule(int num, bool refreshInput = true, bool refreshSlider = true, bool notify = true)
//     {
//         num = Mathf.Clamp(num, _minNum, _maxNum);
//         bool hasChange = (num != _nowNum);
//         _nowNum = num;
//
//
//         if(refreshInput)
//             RefreshInput();
//         if(_onValueChange != null && hasChange && notify)
//             _onValueChange.Invoke(_nowNum);
//         
//         if (setSubBtnInteractiveInternal && null != subButton)
//         {
//             subButton.interactive = _nowNum > _minNum;
//         }
//
//         if (setAddBtnInteractiveInternal && null != addButton)
//         {
//             addButton.interactive = _nowNum < _maxNum;
//         }
//     }
//
//     void RefreshInput()
//     {
//         if (null != numInput)
//         {
//             numInput.value = _nowNum.ToString();
//         }
//     }
//
//     void OnSubButton(GameObject go)
//     {
//         SetVaule(_nowNum-1);
//     }
//
//     void OnAddButton(GameObject go)
//     {
//         SetVaule(_nowNum+1);
//     }
//     
//     void OnMaxButton(GameObject go)
//     {
//         SetVaule(_maxNum);
//     }
//
//     void OnInputChange()
//     {
//         if(numInput.isSelected)
//         {
//             string newString = numInput.value;
//             if(newString.Length > 7)
//             {
//                 numInput.value = newString.Substring(0, newString.Length - 1);
//                 return;
//             }
//             string formatedString = newString;
//             if(string.IsNullOrEmpty(newString))
//                 formatedString = "0";
//             int newNum = int.Parse(formatedString);
//             newNum = Mathf.Clamp(newNum, _minNum, _maxNum);
//             formatedString = newNum.ToString();
//             if(!formatedString.Equals(newString))
//             {
//                 numInput.value = formatedString;
//             }
//             SetVaule(newNum, false, true);
//         }
//     }
//
// //    char OnInputValidate(string text, int charIndex, char addedChar)
// //    {
// //        if(string.IsNullOrEmpty(text))
// //            return addedChar;
// //        int newNum = int.Parse(text);
// //        if(newNum > _maxNum)
// //            return new char();
// //        return addedChar;
// //    }
// }
