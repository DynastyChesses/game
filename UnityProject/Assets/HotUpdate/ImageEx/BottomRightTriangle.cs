using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class BottomRightTriangle : Image
{
    protected override void OnPopulateMesh(VertexHelper vh)
    {
        var angle = 13f;
        
        Vector4 rt = GetDrawingDimensions();

        // 容器尺寸
        float containerWidth = rt.z - rt.x;
        

        // 通过角度计算底边长度
        float radian = angle * Mathf.Deg2Rad;
        float rightLength = containerWidth * Mathf.Tan(radian);

        
        

        // 顶点坐标（从右下角开始绘制）
        Vector3 bottomRight = new Vector3(rt.z, rt.y); // 固定右下角
        Vector3 topRight = new Vector3(rt.z, rt.y+rightLength); // 右上角
        Vector3 bottomLeft = new Vector3(rt.x, rt.y); // 动态左下角

        // 构建三角形
        vh.Clear();
        vh.AddVert(bottomLeft, color, Vector2.zero); // 0
        vh.AddVert(topRight, color, Vector2.zero);     // 1
        vh.AddVert(bottomRight, color, Vector2.zero);  // 2
        vh.AddTriangle(0, 1, 2);
    }

    private Vector4 GetDrawingDimensions()
    {
        Rect r = GetPixelAdjustedRect();
        return new Vector4(r.x, r.y, r.x + r.width, r.y + r.height);
    }
#if UNITY_EDITOR
    protected override void OnValidate()
    {
        base.OnValidate();
    }
#endif
}