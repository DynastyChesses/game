using System;
using System.Collections;
using System.Collections.Generic;
using BestHTTP;
using UnityEngine;

public class HttpManager : Singleton<HttpManager>
{

    public void Get(string url, Action<int, string> cb)
    {
        HTTPRequest request = new HTTPRequest(new Uri(url), HTTPMethods.Get, false, true, (originalRequest, response) =>
        {
            cb.Invoke(response.StatusCode, response.Message);
        });
        request.Send();
    }

    public void Post(string url, Dictionary<string, string> param, Action<int, string> cb)
    {
        HTTPRequest request = new HTTPRequest(new Uri(url), HTTPMethods.Post, false, true, (originalRequest, response) =>
        {
            cb.Invoke(response.StatusCode, response.Message);
        });
        foreach (var item in param)
        {
            request.AddField(item.Key, item.Value);
        }

        request.Send();
    }
    
    public override void Dispose()
    {
        // TODO
    }
}
