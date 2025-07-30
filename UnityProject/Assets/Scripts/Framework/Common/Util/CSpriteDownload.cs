using System;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class CSpriteDownload
{
    public static void SetRemoteOrLocalImage(string configPath, ref WebTexture.WebTextureResult result, bool useThumbnail = false, Action<Sprite> fallBack = null, Vector4 border = new Vector4())
    {
        if (string.IsNullOrEmpty(configPath)) {
            //本地资源逻辑
            fallBack?.Invoke(null);
            return;
        }
        if (result == null) {
            result = new WebTexture.WebTextureResult();
        }
        var tween = result.tween;
        WebTexture wt = result.webTexture;
        if (configPath.Contains("remote:")) {
            // if (configPath == result.imagePath)
            // {
            // 	return;
            // }
            //如果配置里不加后缀默认用png
            string extension = Path.GetExtension(configPath);
            if (string.IsNullOrEmpty(extension)) {
                configPath = configPath + ".png";
            }
            //动更图逻辑
            var imgPath = configPath.Split(':');
            if (imgPath.Length == 2) {
                string bgName = imgPath[1];
                if (wt == null) {
                    wt = new WebTexture(fallBack);
                }

                string imageUrl = bgName;
                WebTexture.Status status = wt.SetTexture(imageUrl, null, null, border);
                if (useThumbnail && status == WebTexture.Status.Web) {
                    string thumbnail = bgName.Replace(".jpg", "_thumbnail");
                    thumbnail = thumbnail.Replace(".png", "_thumbnail");
                    SetTextureToImageSpriteAsync($"Textures/Thumbnails/{thumbnail}", fallBack, border);
                }
            }
        } else {
            result?.Dispose();
            result = null;
            //本地资源逻辑
            fallBack?.Invoke(null);
            return;
        }

        result.imagePath = configPath;
        result.tween = tween;
        result.webTexture = wt;
    }

    public static void Download(string imageUrl, Action<Sprite> fallBack = null, Vector4 border = new Vector4())
    {
        var wt = new WebTexture(fallBack);
        WebTexture.Status status = wt.SetTexture(imageUrl, null, null, border);
    }

    // 回调里不能使用ref参数，所以只好传image进来
    public static void SetTextureToImageSpriteAsync(string texPath, Action<Sprite> image, Vector4 border = new Vector4())
    {
        var req = ResourceFacade.instance.LoadObjectAsync<Texture>(texPath);
        // 老版框架可能返回null req
        if (req == null) {
            Debug.LogError($"asset not found:{texPath}");
            image?.Invoke(null);
            return;
        }
        req.callback = request => {
            Texture2D texture = request.asset as Texture2D;
            if (texture != null) {
                Sprite msprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 100, 0, SpriteMeshType.FullRect, border);
                image?.Invoke(msprite);
            } else {
                image?.Invoke(null);
            }
            request.Dispose();
        };
    }

    public class WebTexture
    {
        //sprite缓存保存时间
        private const int SPRITE_CACAHE_SAVE_TIME = 1800;

        public enum Status { None, Local, Web }

        private class WebTexSpriteInfo
        {
            public long lastUpdateTimestamp;
            public Sprite webResSprite;
        }

        public class WebTextureResult
        {
            public WebTexture webTexture = null;
            public Tween tween = null;
            public string imagePath = null;

            public WebTextureResult()
            {
            }

            public void ResetImgPath()
            {
                imagePath = null;
            }

            public void Dispose()
            {
                webTexture?.Dispose();
                webTexture = null;
                tween?.Kill();
                tween = null;
                imagePath = null;
            }
        }

        private Status _status;

        private Action<Sprite> _textureComp;

        private string _currentUriString;
        private string _localUriString;

        private static Dictionary<string, WebTextureHttpRequest> _requestMap = new Dictionary<string, WebTextureHttpRequest>();

        public static string defaultTexFolder = null;

        public static string defaultTexName = null;

        private Sprite _webSprite;

        public Action callBack { get; set; }

        public WebTexture(Action<Sprite> imgCpt)
        {
            _status = Status.None;
            _textureComp = imgCpt;
        }

        public static void Clear()
        {
            Dictionary<string, WebTextureHttpRequest>.Enumerator iter = _requestMap.GetEnumerator();
            while (iter.MoveNext()) {
                iter.Current.Value.Dispose();
            }
            _requestMap.Clear();
        }

        public void Reset()
        {
            if (!string.IsNullOrEmpty(_localUriString)) {
                //不能直接卸载_textureComp上的图，因为循环列表可能将对应的图给替换调
                // if(_textureComp && _textureComp.sprite)
                // 	UIUtil.UnloadTexture(_textureComp.sprite.texture);
                _localUriString = null;
            }

            if (_status == Status.Web) {
                DisposeRequest();
            }

            _status = Status.None;
        }

        public void Dispose()
        {
            Reset();
            _textureComp = null;
            callBack = null;
        }

        public void SetTexture(string folder, string texName)
        {
            string localUri = folder + "/" + texName;
            if (_localUriString == localUri) {
                return;
            }

            Reset();

            _localUriString = localUri;

            var texPath = "UITexture/" + folder + "/" + texName;
            SetTextureToImageSpriteAsync(texPath, _textureComp);

            _status = Status.Local;
        }

        public Status SetTexture(string uri, string defaultFolder = null, string defaultTexName = null, Vector4 border = new Vector4())
        {
            if (null == uri) {
                return Status.None;
            }

            if (!string.IsNullOrEmpty(_currentUriString) && _currentUriString.Equals(uri)) {
                return Status.None;
            }
            Reset();

            _localUriString = defaultFolder + "/" + defaultTexName;

            return DoSetTexture(uri, false, border);
        }

        public void SetTexture(string uriString, bool isForceUpdate)
        {
            if (null == uriString) {
                return;
            }

            _localUriString = uriString;

            if (!string.IsNullOrEmpty(_currentUriString) && _currentUriString.Equals(uriString) && !isForceUpdate) {
                return;
            }
            Reset();

            DoSetTexture(uriString, isForceUpdate);
        }

        public void SetTexture(Texture2D texture)
        {
            if (texture == null) {
                return;
            }
            Reset();
            Sprite msprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            _textureComp.Invoke(msprite);
        }

        public void SetImgCpt(Action<Sprite> img)
        {
            _textureComp = img;
        }

        public bool IsUrlEquals(string uriString)
        {
            return !string.IsNullOrEmpty(_currentUriString) && _currentUriString.Equals(uriString);
        }

        Status DoSetTexture(string uriString, bool isForceUpdate = false, Vector4 border = new Vector4())
        {
            if (isForceUpdate && !uriString.Contains("?")) {
                //防止使用cdn缓存
                uriString = $"{uriString}?timestamp={GetCurTimestamp()}";
            }
            _currentUriString = uriString;
            WebTextureHttpRequest request;
            if (!_requestMap.TryGetValue(uriString, out request)) {
                if (!isForceUpdate) {
                    var itr = _requestMap.GetEnumerator();
                    while (itr.MoveNext()) {
                        string uri = itr.Current.Key;
                        string originUri = uriString;
                        if (originUri.Contains("?")) {
                            var uriArr = originUri.Split('?');
                            originUri = uriArr[0];
                        }
                        if (uri.Contains(originUri)) {
                            request = itr.Current.Value;
                            break;
                        }
                    }
                    itr.Dispose();
                }
                if (request == null) {
                    request = new WebTextureHttpRequest(uriString);
                    _requestMap.Add(uriString, request);
                }
            }

            ++request.referanceCount;
            request.boder = border;
            switch (request.status) {
                case WebTextureHttpRequest.Status.None:
                    request.successCallback += OnLoadWebTextureSuccess;
                    request.Send();
                    break;
                case WebTextureHttpRequest.Status.Requesting:
                    request.successCallback += OnLoadWebTextureSuccess;
                    break;
                case WebTextureHttpRequest.Status.Finish:
                    OnLoadWebTextureSuccess(request);
                    break;
            }

            _status = Status.Web;
            return _status;
        }

        void DisposeRequest()
        {
            if (!string.IsNullOrEmpty(_currentUriString)) {
                WebTextureHttpRequest request;
                if (_requestMap.TryGetValue(_currentUriString, out request)) {
                    request.successCallback -= OnLoadWebTextureSuccess;
                    request.referanceCount--;
                    // _textureComp.sprite = null;
                }
                _currentUriString = null;
            }
        }

        void OnLoadWebTextureSuccess(WebTextureHttpRequest request)
        {
            if (!string.IsNullOrEmpty(_localUriString)) {
                _localUriString = null;
            }
            Texture2D texture = request.texture2D;
            if (texture != null) {
                Sprite msprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 100, 0, SpriteMeshType.FullRect, request.boder);
                _webSprite = msprite;
                _textureComp.Invoke(_webSprite);
            }
            callBack?.Invoke();
            callBack = null;
            request.successCallback -= OnLoadWebTextureSuccess;
        }

        long GetCurTimestamp()
        {
            return (long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }

    class WebTextureHttpRequest
    {
        public enum Status { None, Requesting, Finish, }

        public WebTextureHttpRequest(string uri)
        {
            this.uri = uri;
            _referanceCount = 0;
            status = Status.None;
            _retryCount = 3;
        }

        public Action<WebTextureHttpRequest> successCallback;
        public string uri { get; private set; }
        public Status status { get; private set; }
        public Texture2D texture2D { get; private set; }
        public Vector4 boder { get; set; }
        const float DELAY_TIME = 30f;
        UnityWebRequest _innerRequest;
        UnityWebRequestAsyncOperation _innerRequestAsyncOp;
        vp_Timer.Handle _handler;
        int _retryCount;

        int _referanceCount;
        public int referanceCount {
            get { return _referanceCount; }
            set {
                _referanceCount = value;
                if (_referanceCount > 0) {
                    if (null != _handler) {
                        _handler.Cancel();
                        _handler = null;
                    }
                } else if (_referanceCount == 0) {
                    _handler = new vp_Timer.Handle();
                    vp_Timer.In(DELAY_TIME, Dispose, _handler);
                } else {
                    Logger.Error("Reference Count Error " + uri);
                }
            }
        }

        public void Send()
        {
            _innerRequest = UnityWebRequestTexture.GetTexture(uri);
            UnityWebRequestAsyncOperation asyncOperation = _innerRequest.SendWebRequest();
            asyncOperation.completed += OnRequestFinish;

            status = Status.Requesting;
        }

        public void OnRequestFinish(AsyncOperation op)
        {
            op.completed -= OnRequestFinish;
            var top = op as UnityWebRequestAsyncOperation;
            if (top == null) {
                return;
            }
            UnityWebRequest request = top.webRequest;
            if (request != _innerRequest) {
                return;
            }
            _innerRequest = null;
            if (!request.isNetworkError && !request.isHttpError) {
                texture2D = ((DownloadHandlerTexture)request.downloadHandler).texture;
                texture2D.name = uri;
            } else {
                //TODO 再次请求
                Logger.Warning(request.error);
                if (_retryCount > 0) {
                    --_retryCount;
                    Send();
                    return;
                }
            }

            if (null != texture2D) {
                status = Status.Finish;
            } else {
                status = Status.None;
            }

            if (Status.Finish == status) {
                if (null != successCallback) {
                    successCallback(this);
                }
            }
        }

        public void Dispose()
        {
            if (_innerRequestAsyncOp != null) {
                _innerRequestAsyncOp.completed -= OnRequestFinish;
                _innerRequestAsyncOp = null;
            }

            if (_innerRequest != null) {
                _innerRequest.Abort();
                _innerRequest = null;
            }

            status = Status.None;

            if (_handler != null) {
                _handler.Cancel();
                _handler = null;
            }

            if (null != texture2D) {
                ResourceFacade.instance.Unload(texture2D);
                texture2D = null;
            }

            _retryCount = 3;
        }
    }
}
