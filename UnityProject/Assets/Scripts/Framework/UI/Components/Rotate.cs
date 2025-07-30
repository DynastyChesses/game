using UnityEngine;

public class Rotate : MonoBehaviour 
{
	public Vector3 axis;
	public float rate;

	public bool useWorldSpace = false;

	private Transform _cachedTransform;

	private Space _space;

	void Start()
	{
		_cachedTransform = this.transform;
		_space = useWorldSpace ? Space.World : Space.Self;
	}

	void Update () 
	{
		float deltaTime = Time.deltaTime;
		if (deltaTime < 0f)
		{
			deltaTime = 0.033f;
		}
		_cachedTransform.Rotate(axis * deltaTime * rate, _space);
	}
}