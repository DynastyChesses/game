using System;
public interface IUpdateFacade
{
    int AddTimeLimitUpdatorMethod(float interval, Action<object> updateHandler, object param = null);

    int AddFrameLimitUpdatorMethod(int interval, Action<object> updateHandler, object param = null);

    int CallOnceMethod(int delayFrames, Action<object> updateHandler, object param = null);

    int CallOnceMethod(float delayTimes, Action<object> updateHandler, object param = null);

    void RemoveLimitUpdatorMethod(int id);

    bool IsValid(int id);

    void SetActive(int id, bool active);
}