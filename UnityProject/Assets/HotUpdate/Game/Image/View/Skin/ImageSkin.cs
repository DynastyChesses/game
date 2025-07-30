
using System.Collections.Generic;
using UnityEngine;

public class ImageSkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public UGUIButtonEx baseBtn;
	public GameObject groundTile;
	//auto generate propertyDef End, Don't Delete it!



	public List<GameObject> allObject = new List<GameObject>();


	public ImageSkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.baseBtn = _viewSkin.GetSingleProperty("baseBtn", 0) as UGUIButtonEx;
		this.groundTile = _viewSkin.GetSingleProperty("groundTile", 1) as GameObject;
		//auto generate propertySet End, Don't Delete it!


		
		this.baseBtn.onClick.AddListener(TestButton);
		

	}

	public void TestButton()
	{
		Debug.LogError("TestButton");
		// 随机生成
		var o = GameObject.Instantiate(this.groundTile);
		allObject.Add(o);
		o.transform.SetParent(UIManager.instance.sceneLayer, false); 
		o.transform.localScale = Vector3.one;
		o.transform.position = Vector3.one;
	}

	public override void Dispose()
    {
		//auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!





		base.Dispose();
    }

    
}
