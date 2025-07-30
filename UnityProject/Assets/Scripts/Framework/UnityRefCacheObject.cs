public class UnityRefCacheObject :RefCacheObject
{
	public UnityRefCacheObject(float life) : base(life)
	{
		
	}	

	public delegate void DestroyDelegate(UnityEngine.Object obj);

	public int id;

	public DestroyDelegate onDestroy;
}
