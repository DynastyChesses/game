using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class MapLoader : MonoBehaviour
{
    [Header("CSV配置")]
    public string csvFileName = "MapTest"; 

    [Header("Addressable标签")]
    public string spriteAtlasLabel = "UIAtla"; 

    private AsyncOperationHandle<IList<Sprite>> atlasLoadHandle;

    void Start()
    {
        StartCoroutine(LoadMapRoutine());
    }

    IEnumerator LoadMapRoutine()
    {
        // 异步加载图集
        atlasLoadHandle = Addressables.LoadAssetsAsync<Sprite>(spriteAtlasLabel, null, Addressables.MergeMode.Union);

        yield return atlasLoadHandle;

        if (atlasLoadHandle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.LogError("图集加载失败: " + spriteAtlasLabel);
            yield break;
        }

        // 加载CSV文件
        string csvPath = Path.Combine(Application.streamingAssetsPath, csvFileName);
        string csvData;

#if UNITY_ANDROID && !UNITY_EDITOR
        // Android平台特殊处理
        UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(csvPath);
        yield return www.SendWebRequest();
        csvData = www.downloadHandler.text;
#else
        csvData = File.ReadAllText(csvPath);
#endif

        // 解析并生成地图
        yield return StartCoroutine(ParseAndGenerateMap(csvData));
    }

    IEnumerator ParseAndGenerateMap(string csvData)
    {
        // 获取已加载的图集精灵
        var spriteList = atlasLoadHandle.Result as System.Collections.Generic.IList<Sprite>;
        if (spriteList == null || spriteList.Count == 0)
        {
            Debug.LogError("没有加载到任何精灵");
            yield break;
        }

        // 创建父对象用于组织地图元素
        GameObject mapParent = new GameObject("GeneratedMap");
        mapParent.transform.position = Vector3.zero;

        string[] lines = csvData.Split(new[] { '\r', '\n' }, System.StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < lines.Length; i++) // 跳过标题行
        {
            string[] cols = ParseCSVLine(lines[i]);
            if (cols.Length < 4) continue;

            // 解析CSV行数据
            int spriteIndex = int.Parse(cols[0]);
            float posX = float.Parse(cols[1]);
            float posY = float.Parse(cols[2]);
            int sortingOrder = int.Parse(cols[3]);

            // 确保精灵索引有效
            if (spriteIndex < 0 || spriteIndex >= spriteList.Count)
            {
                Debug.LogWarning($"无效的精灵索引: {spriteIndex}");
                continue;
            }

            // 创建精灵游戏对象
            GameObject tileObj = new GameObject($"Tile_{i}");
            tileObj.transform.SetParent(mapParent.transform);
            tileObj.transform.position = new Vector3(posX, posY, 0);

            // 添加并配置SpriteRenderer
            SpriteRenderer renderer = tileObj.AddComponent<SpriteRenderer>();
            renderer.sprite = spriteList[spriteIndex];
            renderer.sortingOrder = sortingOrder;

            // 每生成100个tile等待一帧（防止卡顿）
            if (i % 100 == 0)
                yield return null;
        }

        Debug.Log($"地图生成完成");
    }

    // CSV解析方法
    string[] ParseCSVLine(string line)
    {
        System.Text.RegularExpressions.MatchCollection matches = 
            System.Text.RegularExpressions.Regex.Matches(line, 
            "(?:^|,)(\"(?:[^\"]+|\"\")*\"|[^,]*)");
        
        string[] values = new string[matches.Count];
        for (int i = 0; i < matches.Count; i++)
        {
            values[i] = matches[i].Value.TrimStart(',').Trim('\"');
        }
        return values;
    }

    void OnDestroy()
    {
        // 释放Addressables资源
        if (atlasLoadHandle.IsValid())
        {
            Addressables.Release(atlasLoadHandle);
        }
    }
}