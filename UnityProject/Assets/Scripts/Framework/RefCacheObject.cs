
public class RefCacheObject
{
	public string objName;

	public object obj;

	public UnityObjectType type;

	public float remainingLife;

	public int referCount;

	public RefCacheObject(float life)
	{
		this._life = life;
	}

	private float _life;
	public float life 
	{
		get
		{
			return _life;
		}
	}
}

