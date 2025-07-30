

using System;
using System.Collections.Generic;
using UnityEngine;

public class MapVO
{
    // 长
    public int width = 0;
    // 宽
    public int height = 0;
    // 数据矩阵
    public List<List<int>> datas = new List<List<int>>();
// 新增CSV解析功能
    public MapVO(TextAsset csv = null)
    {
        if (csv == null) return;
        
        // 解析CSV
        string[] rows = csv.text.Split(new[] { "\r\n", "\n" }, 
            StringSplitOptions.RemoveEmptyEntries);
        height = rows.Length;
        
        foreach (string row in rows)
        {
            List<int> rowData = new List<int>();
            string[] cols = row.Split(',');
            
            foreach (string col in cols)
            {
                if (int.TryParse(col.Trim(), out int value))
                {
                    rowData.Add(value);
                }
                else
                {
                    rowData.Add(0); 
                }
            }
            
            datas.Add(rowData);
            width = Mathf.Max(width, rowData.Count); 
        }
    }
}

public class Map : BaseScriptItemRendererView
{
    
    public Map()
    {
        prefabPath = "Map";
    }
    
    private MapVO _data;

    public override object data
    {
        get
        {
            return _data;
        }
        set
        {
            _data = value as MapVO;
            Refresh();
        }
    }

    public override void Refresh()
    {
        base.Refresh();
        if (_data == null)
            return;
        Render();
    }

    public void Render()
    {
        // 生成过程
        for (int i = 0; i < _data.height; i++)
        {
            for (int j = 0; j < _data.width; j++)
            {
                // 创建地块数据
                Ground_TiledVO tileVO = new Ground_TiledVO();
                tileVO.order = 0;
                tileVO.x = j;
                tileVO.y = i;
                // TODO
                CommonItemRenderer tileRender = new CommonItemRenderer(this.gameObject.transform);
                tileRender.data = tileVO;
            } 
        }
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

// 数据类
