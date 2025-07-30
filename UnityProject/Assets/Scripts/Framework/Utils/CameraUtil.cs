using UnityEngine;
using DG.Tweening;

public class CameraUtil : MonoBehaviour 
{ 
	public enum DragMode
	{
		None,
		Drag,
		Scroll
	}
	private static Plane GROUND_PLANE = new Plane(Vector3.up, Vector3.zero);
	private static Plane XYGROUND_PLANE = new Plane(Vector3.forward, Vector3.zero);
	
    public static Vector3 GetWorldPos(Camera camera, Vector2 screenPos, float distance)
    {
	    if (camera == null)
	    {
		    return Vector3.zero;
	    }
        Ray ray = camera.ScreenPointToRay( screenPos );
        return ray.GetPoint(distance);
    }

    public static Vector3 GetWorldPos(Camera camera, Vector2 screenPos, bool useXYPlane = false)
	{
		if (camera == null)
		{
			return Vector3.zero;
		}
		Plane plane = useXYPlane ? XYGROUND_PLANE : GROUND_PLANE;
		Ray ray = camera.ScreenPointToRay( screenPos );

		float t;

		plane.Raycast (ray, out t);
		return ray.GetPoint( t );
	}
	
	public static Vector3 GetScreenPos(Camera camera, Camera uiCamera, Vector3 worldPos)
	{
		if (camera == null)
		{
			return Vector3.zero;
		}
		Vector3 pos = camera.WorldToViewportPoint(worldPos);
		pos.z = 0;
		return uiCamera.ViewportToWorldPoint(pos);
	} 

    public static Vector3 GetScreenPosEx(Camera camera, Camera uiCamera, Vector3 worldPos, out bool isReverse)
    {
	    if (camera == null)
	    {
		    isReverse = false;
		    return Vector3.zero;
	    }
        Vector3 pos = camera.WorldToViewportPoint(worldPos);
        if(pos.z <= 0)
        {
            isReverse = true;
        }
        else
        {
            isReverse = false;
        }
        pos.z = 0;
        return uiCamera.ViewportToWorldPoint(pos);
    }

	public static void ShakeScreen(Camera camera, float time, float amountX = 1f, float amountY = 1f, float amountZ = 1f, float delay = 0f)
	{
		if (camera != null)
		{
			camera.DOShakePosition(time, new Vector3(amountX, amountY, amountZ)).SetDelay(delay);
		}
	}
}
