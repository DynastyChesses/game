using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using BestHTTP.JSON.LitJson;
using DG.Tweening;
using UnityEngine;
using Debug = UnityEngine.Debug;
using Random = UnityEngine.Random;

// 定义百川智能需求
// 角色定义
public class CharacterProfile
{
    // public string character_name;
    // public string character_info;
    // public string user_name;
    // public string user_info;
    public string character_id;
}

// 每一条通信消息
public class MessageItem
{
    public string role { get; set; }
    public string content { get; set; }
}

// 百川的请求
public class BCRequestData
{
    public string model { get; set; }
    public CharacterProfile character_profile { get; set; }
    public List<MessageItem> messages { get; set; }
    public bool stream { get; set; }
    //
    public float temperature = 0.4f;
    //
    
}

public class BaseGameUtils: Singleton<BaseGameUtils>
{
    
    private CancellationTokenSource _cts;
    private CancellationToken _ct;

    public void QueryStream(List<MessageItem> context)
    {
        _cts = new CancellationTokenSource();
        _ct = _cts.Token;
        System.Threading.Tasks.Task.Run(async () =>
        {
            if (!_ct.IsCancellationRequested)
            {
                await _HttpClientConnect(1, context, _cts);
            }
        });
    }
    
    // 处理异步任务
    private async System.Threading.Tasks.Task _HttpClientConnect(int num, List<MessageItem> context, CancellationTokenSource source)
    {
        HttpClient client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", $"XXXXXX");

        var data = new BCRequestData();
        data.model = "Baichuan-NPC-Turbo";
        data.character_profile = new CharacterProfile();
        data.character_profile.character_id = "XXXX";
        data.messages = context;
        data.stream = true;
        data.temperature = 0.3f;
        string json = JsonMapper.ToJson(data);
        var postData = new StringContent(json, Encoding.UTF8, "application/json");
        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.baichuan-ai.com/v1/chat/completions") { Content = postData };

        // 发送 POST 请求
        var response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
        
        if (response.IsSuccessStatusCode)
        {
            using (var streamReader = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.UTF8))
            {
                while (!streamReader.EndOfStream)
                {
                    try
                    {
                        var line = await streamReader.ReadLineAsync();
                        if (line.Length > 0)
                        {
                            // 转码，解决中文乱码问题
                            Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
                            string result = reg.Replace(line, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
                            // 接受
                            ApplicationFacade.instance.SendNotification("RECV_MSG", result);
                        }
                    }

                    catch (System.Exception ex)
                    {
                        Debug.LogError(ex);
                    }
                }
                // 当前结束
                ApplicationFacade.instance.SendNotification("RECV_END");
                source.Cancel();
                source.Dispose();
            }
        }
        else
        {
            // isStreamFinish = false;
            Debug.Log("请求失败：" + response.StatusCode);
        }
    }
    
    
    public void KnuthDurstenfeldShuffle<T>(ref List<T> list)
    {
        //随机交换
        int currentIndex;
        T tempValue;      
        for (int i = list.Count - 1; i >= 0; i--)
        {
            currentIndex = Random.Range(0, i+1);
            tempValue = list[currentIndex];
            list[currentIndex] = list[i];
            list[i] = tempValue;
        }
    }
    
    

    public static void ValueTo(float tm, Action<float> update, Action cb)
    {
        float progress1 = 0;
        var tween = DOTween.To(() => progress1, x => progress1 = x, 1, tm).OnUpdate(() =>
        {
            update.Invoke(progress1);
        }).OnComplete(() =>
        {
            cb.Invoke();
        });
    }
    
    // Game Center
    

    public override void Dispose()
    {
        // TODO
    }
}