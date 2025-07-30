using System;
using System.IO;
using UnityEngine;

public class PathUtils
{
    
    // PackagePath2AssetPath
    public static string P2A(string packagePath, string component)
    {
        return $"Assets/Game/{component}/{packagePath}";
    }
    
    
    // http://192.168.17.3:8000/comp_loading/iOS/catalog_2021.11.18.11.18.10.json -> http://192.168.17.3:8000/comp_loading/
    public static string GetCatalogUrlPrefix(string url)
    {
        var subUrl = url.Substring(0, url.LastIndexOf("/"));
        var prefix = url.Substring(0, subUrl.LastIndexOf("/") + 1);
        return prefix;
    }
    
    // $comp_loading$game_scenes_all_62cd40948eca1b94df727bb1e34b7cbe -> comp_loading
    public static string GetCatalogComponentName(string url)
    {
        var subUrl = url.Substring(0, url.LastIndexOf("$"));
        var name = subUrl.Substring(subUrl.LastIndexOf("$") + 1);
        return name;
    }   
    // 获取移动平台可写路径 - 同cocos游戏同级
    public static string GetMobileWritablePath(string gameName)
    {
#if UNITY_ANDROID
        // 默认可写路径: /storage/emulated/0/Android/data/com.wodi.who/files/UnityCache/Shared
        // 期望所在路径: /storage/emulated/0/Android/data/com.wodi.who/files/Wanba/download/unity/${GameName}
        var currentPath = Caching.currentCacheForWriting.path;
        var begIndex = currentPath.IndexOf("files");
        var prefixPath = currentPath.Substring(0, begIndex + 5);
        return $"{prefixPath}/Wanba/download/unity/{gameName}";
#elif UNITY_IOS
        // 默认可写路径: /Library/UnityCache/Shared
        // 期望所在路径: /Documents/unity/games/${GameName}
        var currentPath = Caching.currentCacheForWriting.path;
        var begIndex = currentPath.IndexOf("Library") > 0 ? currentPath.IndexOf("Library") : currentPath.IndexOf("Documents");
        if (begIndex > 0)
        {
            var prefixPath = currentPath.Substring(0, begIndex);
            return $"{prefixPath}Documents/unity/games/{gameName}";
        }
        else
        {
            Debug.LogError($"Failed to match search path(Library or Documents): {currentPath}");
            return currentPath;
        }
#else
        return Caching.currentCacheForWriting.path;
#endif
    }

    /// </summary>
    /// <param name="url">url链接</param>
    /// <returns></returns>
    public static System.Collections.Specialized.NameValueCollection ParseUrl(string url)
    {
        string baseUrl = "";
        if (string.IsNullOrEmpty(url))
            return null;
        System.Collections.Specialized.NameValueCollection nvc = new System.Collections.Specialized.NameValueCollection();

        try
        {
            int questionMarkIndex = url.IndexOf('?');

            if (questionMarkIndex == -1)
                baseUrl = url;
            else
                baseUrl = url.Substring(0, questionMarkIndex);
            if (questionMarkIndex == url.Length - 1)
                return null;
            string ps = url.Substring(questionMarkIndex + 1);

            // 开始分析参数对   
            System.Text.RegularExpressions.Regex re = new System.Text.RegularExpressions.Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", System.Text.RegularExpressions.RegexOptions.Compiled);
            System.Text.RegularExpressions.MatchCollection mc = re.Matches(ps);

            foreach (System.Text.RegularExpressions.Match m in mc)
            {
                nvc.Add(m.Result("$2").ToLower(), m.Result("$3"));
            }
            
            String findMark = ":";
            questionMarkIndex = baseUrl.IndexOf('@');
            if (questionMarkIndex == -1)
            {
                questionMarkIndex = baseUrl.IndexOf(findMark);
                if (questionMarkIndex == baseUrl.Length - 1)
                    return null;
                nvc.Add("event", baseUrl.Substring(questionMarkIndex + 3));
            }
            else
            {
                if (questionMarkIndex == baseUrl.Length - 1)
                    return null;
                nvc.Add("event", baseUrl.Substring(questionMarkIndex + 1));
            }
           
           
        }
        catch { }
        return nvc;

    }
}