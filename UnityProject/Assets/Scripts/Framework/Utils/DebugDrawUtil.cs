using UnityEngine;
using System.Collections;

public class DebugDrawUtil
{
    public static void DrawCircle(Vector3 center, float radius, Color color)
    {
        Gizmos.color = color;
        // 绘制圆环
        Vector3 beginPoint = center;
        Vector3 firstPoint = center;
        float m_Radius = radius;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += 0.1f)
        {
            float x = m_Radius * Mathf.Cos(theta) + center.x;
            float z = m_Radius * Mathf.Sin(theta) + center.z;
            Vector3 endPoint = new Vector3(x, 0, z);
            if (theta == 0)
            {
                firstPoint = endPoint;
            }
            else
            {
                Gizmos.DrawLine(beginPoint, endPoint);
            }
            beginPoint = endPoint;
        }
        
        // 绘制最后一条线段
        Gizmos.DrawLine(firstPoint, beginPoint);
    }

	public static void DrawRect(Vector3 center, float sizeX, float sizeZ, Color color)
	{
		Gizmos.color = color;
		// 绘制圆环
		Vector3 beginPoint = center;
		Vector3 endPoint = center;

		beginPoint.x -= sizeX * .5f;
		beginPoint.y = 0;
		beginPoint.z -= sizeZ * .5f;
		endPoint.x += sizeX * .5f;
		endPoint.y = 0;
		endPoint.z -= sizeZ * .5f;

		Gizmos.DrawLine(beginPoint, endPoint);

		beginPoint = endPoint;
		endPoint.z += sizeZ;

		Gizmos.DrawLine(beginPoint, endPoint);

		beginPoint = endPoint;
		endPoint.x -= sizeX;

		Gizmos.DrawLine(beginPoint, endPoint);

		beginPoint = endPoint;
		endPoint.z -= sizeZ;

		Gizmos.DrawLine(beginPoint, endPoint);
	}
}
