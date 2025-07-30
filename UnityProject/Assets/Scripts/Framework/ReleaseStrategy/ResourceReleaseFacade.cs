// -----------------------------------------------------------------------------
//
//  Author : 	Duke Zhou
//  Data : 		2016/8/19
//
// -----------------------------------------------------------------------------
//
using System;

public interface IReleaseStrategy
{
    ResourceReleaseFacade.ResourceToken Recycle(IResourceUnit unit, Action<IResourceUnit, ResourceReleaseFacade.ResourceToken> disposeCallback);
    IResourceUnit Acquire(ResourceReleaseFacade.ResourceToken token);
    void Tick();
    void Reset();
}

public class ResourceReleaseFacade
{
    private static ResourceReleaseFacade _instance;
    public static ResourceReleaseFacade instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new ResourceReleaseFacade(new TimeThresholdStrategy());
            }
            return _instance;
        }
    }

    private IReleaseStrategy _strategy;

    public ResourceReleaseFacade(IReleaseStrategy strategy)
    {
        _strategy = strategy;
    }

    public void Reset()
    {
        _strategy.Reset();
    }

    public ResourceToken Recycle(IResourceUnit unit, Action<IResourceUnit, ResourceToken> disposeCallback)
    {
        return _strategy.Recycle(unit, disposeCallback);
    }

    public IResourceUnit Acquire(ResourceToken token)
    {
        return _strategy.Acquire(token);
    }

    public static void Tick(ref UpdateTimeInfo info)
    {
        instance._strategy.Tick();
    }

    public class ResourceToken
    {
        public string id;

        public ResourceToken(string id = "")
        {
            this.id = id;
        }
    }
}