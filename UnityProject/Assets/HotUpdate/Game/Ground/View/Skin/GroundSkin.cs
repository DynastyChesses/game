
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GroundSkin :BaseGamePopupView
{
	//auto generate propertyDef Start, Don't Delete it!
	public RectTransform groundTr;
	public RectTransform RootTr;
	public RectTransform HillTr;
	public RectTransform ResTr;
	public RectTransform CityTr;
	public RectTransform UnitTr;
	//auto generate propertyDef End, Don't Delete it!





	public Dictionary<int, GroundTiled> ground = new Dictionary<int, GroundTiled>();
	
	// 获取
	public GroundTiled getTiled(GameObject o)
	{
		for (int i = 0; i < ground.Count; i++)
		{
			if (o == ground[i].gameObject)
			{
				return ground[i];
			}
		}

		return null;
	}

	public GroundSkin(GameObject viewObj) : base(viewObj)
	{
		
		//auto generate propertySet Start, Don't Delete it!
		this.groundTr = _viewSkin.GetSingleProperty("groundTr", 0) as RectTransform;
		this.RootTr = _viewSkin.GetSingleProperty("RootTr", 1) as RectTransform;
		this.HillTr = _viewSkin.GetSingleProperty("HillTr", 2) as RectTransform;
		this.ResTr = _viewSkin.GetSingleProperty("ResTr", 3) as RectTransform;
		this.CityTr = _viewSkin.GetSingleProperty("CityTr", 4) as RectTransform;
		this.UnitTr = _viewSkin.GetSingleProperty("UnitTr", 5) as RectTransform;
		//auto generate propertySet End, Don't Delete it!




		


	}

	public override void Dispose()
    {
		//auto generate propertyDis Start, Don't Delete it!
		//auto generate propertyDis End, Don't Delete it!








		base.Dispose();
    }

    // __ANIMATE__
}
