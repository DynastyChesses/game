using System.Diagnostics;
using UnityEngine.Profiling;


public class ScriptProfiler
{
    [Conditional("ENABLE_PROFILER")]
    public static void BeginSample(string str)
    {
        Profiler.BeginSample(str);
    }

    [Conditional("ENABLE_PROFILER")]
    public static void EndSample()
    {
        Profiler.EndSample();
    }

}
