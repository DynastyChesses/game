using System.Collections.Generic;

public interface IBatchRenderContext
{
    bool active
    {
        get;
    }
    bool supportGPUInstance
    {
        get;
    }

    void OnGPUInstanceRender();

    void OnNormalRender();
}

public class GameBatchRenderManager
{
    private static GameBatchRenderManager _instance = new GameBatchRenderManager();

    public static GameBatchRenderManager instance
    {
        get
        {
            return _instance;
        }
    }
    private int _updator;

    public GameBatchRenderManager()
    {
    }

    public void Start()
    {
        if (!EquineScheduler.IsValid(_updator))
        {
            _updator = EquineScheduler.AddFrameLimitUpdator(1, OnUpdate);
        }
    }
    
    private List<IBatchRenderContext> _renderBatches = new List<IBatchRenderContext>();
    public void PostRender(IBatchRenderContext batch)
	{
        _renderBatches.Add(batch);
	}

    public void Clear()
    {
        _renderBatches.Clear();
    }

    public void Dispose()
    {
        EquineScheduler.RemoveLimitUpdator(ref _updator);
    }
    
    private void OnUpdate(int updator, object obj, UpdateTimeInfo info)
    {
        OnRender();
    }
    
	private void OnRender()
	{
        int count = _renderBatches.Count;
        for (int i = 0; i < count; ++i)
        {
            IBatchRenderContext batch = _renderBatches[i];
            if (!batch.active)
            {
                continue;
            }
            if (batch.supportGPUInstance)
            {
                batch.OnGPUInstanceRender();
            }
            else
            {
                batch.OnNormalRender();
            }
        }
	}
}
