
using UnityEngine;

public partial class GameObjectPool
{
    public static void InspectorGUI()
    {
        _instance?.InspectorGUIImpl();
    }

    private void InspectorGUIImpl()
    {
        for (int i = 0; i < _queuePool.liveCount;++i)
        {
            GQueue queue = _queuePool.GetLiveQueueAt(i);

            if (queue.lastIdleTime > 0)
            {
                var now = RealTimer.elapsedSeconds;
                var recycleTime = queue.lastIdleTime + DEATH_TIME;
                GUILayout.Label($"{queue.name}, {queue.Count} / {queue.totalAllocNum}, {now:F2} / {recycleTime:F2}");
            }
            else
            {
                GUILayout.Label($"{queue.name}, {queue.Count} / {queue.totalAllocNum}");
            }
        }
    }
}
