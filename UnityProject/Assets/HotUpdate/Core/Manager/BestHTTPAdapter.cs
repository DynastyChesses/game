using BestHTTP;

public class BestHTTPAdapter
{
    private static bool _configured = false;

    public static void Configure()
    {
        if (!_configured)
        {
            _configured = true;
            HTTPManager.RootCacheFolderProvider = () => StorageManager.persistentDataPath;
            HTTPManager.MaxConnectionPerServer = 4;
            HTTPManager.Setup();
            HTTPManager.Logger.Output = new BestHTTPLogOutput();
            EquineMonoDispatcher.onUpdate += UpdateProxy;
            EquineMonoDispatcher.onApplicationPause += OnApplicationPauseProxy;
            EquineMonoDispatcher.onApplicationQuit += OnApplicationQuitProxy;
        }
    }

    private static void UpdateProxy(ref UpdateTimeInfo info)
    {
        ScriptProfiler.BeginSample("BestHTTPAdapter.UpdateProxy");
        HTTPUpdateDelegator.Instance.Update();
        ScriptProfiler.EndSample();
    }
    
    private static void OnApplicationPauseProxy(bool paused)
    {
        HTTPUpdateDelegator.Instance.OnApplicationPause(paused);
    }

    private static void OnApplicationQuitProxy()
    {
        HTTPUpdateDelegator.Instance.OnApplicationQuit();
    }
}