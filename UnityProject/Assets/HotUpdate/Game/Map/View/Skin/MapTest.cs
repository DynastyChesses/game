using System;
using System.Collections.Generic;
using UnityEngine;
public class MapTestVO
{
    // 长
    public int width = 0;
    // 宽
    public int height = 0;
    // 数据矩阵
    public List<List<int>> datas = new List<List<int>>();

}
public class MapTest : BaseScriptItemRendererView
{
    public MapTest() => prefabPath = "MapTestIR";

    private MapTestVO _data;
    public override object data
    {
        get => _data;
        set
        {
            // 支持直接传入TextAsset或MapTestVO
            if (value is TextAsset csvFile)
            {
                _data = new MapTestVO();
            }
            else
            {
                _data = value as MapTestVO;
            }
            Refresh();
        }
    }

    public override void Refresh()
    {
        base.Refresh();
        ClearExistingTiles();
        Render();
    }

    private void ClearExistingTiles()
    {
        foreach (Transform child in rectTransform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void Render()
    {
        if (_data?.datas == null) return;

        for (int y = 0; y < _data.datas.Count; y++)
        {
            List<int> row = _data.datas[y];
            for (int x = 0; x < row.Count; x++)
            {
                CreateTile(x, y, row[x]);
            }
        }
    }

    private void CreateTile(int x, int y, int tileType)
    {
        Ground_TiledVO tileData = new Ground_TiledVO()
        {
            x = x,
            y = y,
            //tileType = tileType,
            order = y // 使用y坐标作为渲染顺序
        };

        CommonItemRenderer tile = new CommonItemRenderer(rectTransform);
        tile.data = tileData;
        PositionTile(tile.rectTransform, x, y);
    }

    private void PositionTile(RectTransform tileTransform, int x, int y)
    {
        // 假设每个地块大小为100x100像素
        tileTransform.anchoredPosition = new Vector2(x * 100, -y * 100);
    }

    //auto generate propertyDef Start, Don't Delete it!
    //auto generate propertyDef End, Don't Delete it!



    public override void Replace(GameObject viewObj)
    {
        base.Replace(viewObj);
        //auto generate propertySet Start, Don't Delete it!
        //auto generate propertySet End, Don't Delete it!

    }

    public override void Dispose()
    {
        //auto generate propertyDis Start, Don't Delete it!
        //auto generate propertyDis End, Don't Delete it!

        base.Dispose();
    }
}