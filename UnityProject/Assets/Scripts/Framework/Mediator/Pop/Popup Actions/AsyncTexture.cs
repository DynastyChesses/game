using System;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class AsyncTexture
{
	private RawImage _texture;

	public RawImage texture
	{
		get { return _texture; }
	}

    private bool _pixelPerfect;

    public bool pixelPerfect
    {
        get
        {
            return _pixelPerfect;
        }
        set
        {
            _pixelPerfect = value;
        }
    }

	//TODO 置灰
    //private bool _disabled;

    //public bool disabled
    //{
    //    get
    //    {
    //        return _disabled;
    //    }
    //    set
    //    {
    //        _disabled = value;
    //        if (_texture != null)
    //        {
    //            _texture.disabled = _disabled;
    //        }
    //    }
    //}

    private GameObject _indicator;

    public GameObject indicator
    {
        get
        {
            return _indicator;
        }
        set
        {
            _indicator = value;
        }
    }

	private Action<IAsyncResourceRequest> _loadCallback;
	public event Action onLoadTextureComplete;

    // ILRuntime改造-添加无参构造函数
    public AsyncTexture()
    {

    }
    public AsyncTexture(RawImage texture, string fallbackPath = null, bool setPixelPerfect = false, GameObject indicator = null, bool disabled = false)
	{
		_texture = texture;
		_texture.texture = null;
		_fallbackPath = fallbackPath;
        _pixelPerfect = setPixelPerfect;
        _indicator = indicator;
		//TODO 置灰
	    //_disabled = disabled;
        SetIndicatorPosition();
		_loadCallback = new Action<IAsyncResourceRequest>(OnLoadTextureComplete);
	}

	private string _fallbackPath = null;

	public string fallbackPath
	{
		get { return _fallbackPath; }
	}

	private string _path = null;
	private IAsyncResourceRequest _request;

	public string path
	{
		get { return _path; }

		set
		{
			if (_path != value)
			{
				_path = value;
				if (_texture != null)
				{
					if (string.IsNullOrEmpty (_path))
					{
						Object asset = AssetGetter (_texture);
						if (asset != null)
						{
							ResourceFacade.instance.Unload (asset);
							AssetSetter (_texture, null);
						} 
						if (_request != null)
						{
							_request.Dispose ();
							_request = null;

						}
						if (null != _indicator)
						{
							_indicator.SetActive(false);
						}
					}
					else
					{
						if (_request != null)
						{
							_request.Dispose ();
							_request = null;
						}
						_request = GetRequest(_path);

                        if (_indicator != null)
                        {
                            _indicator.SetActive(true);
                        }

						if (_request != null)
						{
							_request.callback = _loadCallback;
						}
						else if (!string.IsNullOrEmpty(_fallbackPath))
						{
							_request = GetRequest(_fallbackPath);
							if (_request != null)
							{
								_request.callback = _loadCallback;
							}
						}

						if (_request == null)
						{
							Object asset = AssetGetter (_texture);
							if (asset != null)
							{
								ResourceFacade.instance.Unload (asset);
								AssetSetter (_texture, null);
							}
						}
					}
				}
			}
		}
	}

	protected virtual Object AssetGetter(RawImage texture)
	{
		return texture != null ? texture.texture : null;
	}

	protected virtual void AssetSetter(RawImage texture, Object asset)
	{
		if (texture != null)
		{
			texture.texture = asset as Texture;
		}
	}

	protected virtual IAsyncResourceRequest GetRequest(string path)
	{
		return ResourceFacade.instance.LoadObjectAsync<Texture>(path);
	}

	private void OnLoadTextureComplete(IAsyncResourceRequest request)
	{
		Object asset = AssetGetter (_texture);
		if (asset != null)
		{
			ResourceFacade.instance.Unload (asset);
			AssetSetter (_texture, null);
		}
		if (_request.asset != null)
		{
			AssetSetter(_texture, _request.asset);
			if (_texture != null)
			{
			    if (_pixelPerfect)
			    {
			        _texture.SetNativeSize();
			    }

				//TODO 置灰
                //_texture.disabled = _disabled;
            }
		}
		else
		{
			_path = null;
		}

        if (_indicator != null)
        {
            _indicator.SetActive(false);
        }

		_request.Dispose();
		_request = null;
		if (onLoadTextureComplete != null)
		{
			onLoadTextureComplete();
		}
	}

	public void Dispose()
	{
		_path = null;
		Object asset = AssetGetter(_texture);
		if (asset != null)
		{
			ResourceFacade.instance.Unload(asset);
			AssetSetter(_texture, null);
		}
		if (_request != null)
		{
			_request.Dispose();
			_request = null;

		}
		_texture = null;
	}

    private void SetIndicatorPosition()
    {
        if (_indicator == null) return;
        _indicator.transform.SetParent(_texture.transform); 
        _indicator.transform.localPosition = Vector3.zero;
        _indicator.SetActive(false);
    }
}
