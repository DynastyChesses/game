using System;
using UnityEngine;
using UnityEngine.Rendering;
using System;
using System.Collections.Generic;
using System.IO;

public class BlurFrameBuffer : IResourceUnit
{
    public string id => UIManager.BLUR_FRAME_BUFFER_RID;
    
    private RenderTexture _frameTexture;
    private RenderTexture _frameTextureCache;
    
    private Material _material;

    private bool _readyToCapture;
    private int _readyToCaptureFrameID;
    private bool _captured;
    private bool _capturedCache = false;

    private Action _blurBackComplete;
    private Canvas _excludeCanvas;
    private IPopupView _excludeView;
    
    public RenderTexture frameTexture => _frameTexture;
    public RenderTexture frameTextureCache => _frameTextureCache;

    public BlurFrameBuffer()
    {
        _frameTexture = null;
        _material = null;

        _readyToCapture = false;
        _captured = false;
        _frameTextureCache = null;
        _blurBackComplete = null;
    }

    public void Load()
    {
        if (_readyToCapture)
            return;

        var width = UIManager.instance.uiCamera.pixelWidth;
        var height = UIManager.instance.uiCamera.pixelHeight;
        {
            var desc = new RenderTextureDescriptor();
            desc.width = width;
            desc.height = height;
            desc.colorFormat = RenderTextureFormat.ARGB32;
            desc.depthBufferBits = 0;
            desc.sRGB = true;
            desc.useMipMap = false;
            desc.autoGenerateMips = false;
            desc.volumeDepth = 1;
            desc.msaaSamples = 1;
            desc.dimension = TextureDimension.Tex2D;
            _frameTexture = RenderTexture.GetTemporary(desc);
        }
        
        if (_frameTexture == null)
            return;
        
        InitMaterial();
    }

    private delegate void InitMaterialCallback();
    private IAsyncResourceRequest _materialReq = null;
    private void InitMaterial(InitMaterialCallback callback = null)
    {
        _materialReq?.Dispose();
        _materialReq = ResourceFacade.instance.LoadObjectAsync<Material>("Assets/Arts/Mat/BlurBack", "");
        _materialReq.callback = request =>
        {
            if (request == null || request.asset == null)
            {
                return;
            }
            Material material = request.asset as Material;
            _material = ResourceFacade.Instantiate(material) as Material;
            _readyToCapture = true;
            _materialReq?.Dispose();
            _materialReq = null;
            
            callback?.Invoke();
        };
    }

    public void Dispose()
    {
        if (_frameTexture != null)
        {
            RenderTexture.ReleaseTemporary(_frameTexture);
            _frameTexture = null;
        }

        if (_material != null)
        {
            ResourceFacade.Destroy(_material);
            _material = null;
        }

        _materialReq?.Dispose();
        _materialReq = null;
        _readyToCapture = false;
        _captured = false;
        ClearCache();
        _blurBackComplete = null;
        
        CameraCaptureBridge.RemoveCaptureAction(UIManager.instance.uiCamera, CaptureAction);
        RenderPipelineManager.endFrameRendering -= RenderPipelineManagerOnendFrameRendering;
    }

    public void AddCallback(Action func)
    {
        _blurBackComplete += func;
    }
    
    public void RemoveCallback(Action func)
    {
        _blurBackComplete -= func;
        _excludeCanvas = null;
        _excludeView = null;
    }
    
    public void ClearCallback()
    {
        _blurBackComplete = null;
    }
    public void ClearCache()
    {
        if (_frameTextureCache != null)
        {
            RenderTexture.ReleaseTemporary(_frameTextureCache);
            _frameTextureCache = null;
        }
        _capturedCache = false;
    }
    
    public void BlurBack(IPopupView handleView)
    {
        if (_readyToCapture == false)
        {
            InitMaterial(() =>
            {
                BlurBack(handleView);
            });
            return;
        }
        _excludeView = handleView;
        
        if (_excludeView != null)
        {
            PopupFacade.instance.SetViewShow(_excludeView,false);
        }
        _captured = false;
        
        _readyToCaptureFrameID = Time.frameCount;
        // 
        if (UIManager.instance.clickEff != null)
        {
            // 隐藏 
            UIManager.instance.clickEff.gameObject.SetActive(false);
        }
        
        //
        CameraCaptureBridge.RemoveCaptureAction(UIManager.instance.uiCamera, CaptureAction);
        ScriptProfiler.BeginSample("CameraCaptureBridge.AddCaptureAction!!");
        CameraCaptureBridge.AddCaptureAction(UIManager.instance.uiCamera, CaptureAction);
        ScriptProfiler.EndSample();
        RenderPipelineManager.endFrameRendering += RenderPipelineManagerOnendFrameRendering;
    }

    private void RenderPipelineManagerOnendFrameRendering(ScriptableRenderContext arg1, Camera[] arg2)
    {
        if (_captured)
        {
            // Logger.Debug($"BlurFrameBuffer.RenderPipelineManagerOnendFrameRendering remove capture action {Time.frameCount}");
    
            CameraCaptureBridge.RemoveCaptureAction(UIManager.instance.uiCamera, CaptureAction);
            RenderPipelineManager.endFrameRendering -= RenderPipelineManagerOnendFrameRendering;
    
            _blurBackComplete?.Invoke();
            _blurBackComplete = null;
        }
    }
    
    public bool SaveRenderTextureAsPng(RenderTexture renderT, string filePath)  
    {  
        if (renderT == null)  
        {  
            Debug.LogError("RenderTexture is null!");  
            return false;  
        }  
  
        int width = renderT.width;  
        int height = renderT.height;  
  
        // 创建Texture2D对象  
        Texture2D texture2D = new Texture2D(width, height, TextureFormat.ARGB32, false);  
  
        // 设置活动渲染纹理并读取像素  
        RenderTexture.active = renderT;  
        texture2D.ReadPixels(new Rect(0, 0, width, height), 0, 0);  
        texture2D.Apply();  
  
        // 编码为PNG并写入文件  
        byte[] pngData = texture2D.EncodeToPNG();  
        try  
        {  
            File.WriteAllBytes(filePath, pngData);  
            Debug.LogError("Texture saved as PNG to " + filePath);  
            return true;  
        }  
        catch (System.Exception e)  
        {  
            Debug.LogError("Failed to save texture as PNG: " + e.Message);  
            return false;  
        }  
        finally  
        {  
            // 清理资源  
            RenderTexture.active = null;  
            Texture2D.DestroyImmediate(texture2D);  
        }  
    } 

    private void CaptureAction(RenderTargetIdentifier arg1, CommandBuffer arg2)
    {
        ScriptProfiler.BeginSample("CaptureAction!!");
        if (_readyToCapture == false)
        {
            InitMaterial(() =>
            {
                CaptureAction(arg1, arg2);
            });
            return;
        }
        if (_captured)
        {
            return;
        }
        
        // due to HidePopup delay
        // if (!(Time.frameCount >= _readyToCaptureFrameID + 1))
        //     return;
        
        // Debug.LogError($"BlurFrameBuffer.CaptureAction blur frame buffer {Time.frameCount}");
        _captured = true;
        
        int DownSampleNum = 2;
        float BlurSpreadSize = 2.0f;
        float BlurIterations = 2;
        
        var srcWidth = _frameTexture.width;
        var srcHeight = _frameTexture.height;
        var srcFormat = _frameTexture.format;
        
        float widthMod = 1.0f / (1.0f * (1 << (int) DownSampleNum));
        _material.SetFloat("_DownSampleValue", BlurSpreadSize * widthMod);
        int renderWidth = srcWidth >> (int) DownSampleNum;
        int renderHeight = srcHeight >> (int) DownSampleNum;
        
        RenderTexture renderBuffer = RenderTexture.GetTemporary(renderWidth, renderHeight, 0, srcFormat);
        arg2.Blit(arg1, _frameTexture);
        arg2.Blit(_frameTexture, renderBuffer, _material, 0);

        for (int i = 0; i < BlurIterations; i++)
        {
            float iterationOffs = (i * 1.0f);
            _material.SetFloat("_DownSampleValue", BlurSpreadSize * widthMod + iterationOffs);
        
            RenderTexture tempBuffer = RenderTexture.GetTemporary(renderWidth, renderHeight, 0, srcFormat);
            arg2.Blit(renderBuffer, tempBuffer, _material, 1);
            RenderTexture.ReleaseTemporary(renderBuffer);
            renderBuffer = tempBuffer;
        
            tempBuffer = RenderTexture.GetTemporary(renderWidth, renderHeight, 0, srcFormat);
            arg2.Blit(renderBuffer, tempBuffer, _material, 2);
        
            RenderTexture.ReleaseTemporary(renderBuffer);
            renderBuffer = tempBuffer;
        }
        
        arg2.Blit(renderBuffer, _frameTexture, _material, 3);
        RenderTexture.ReleaseTemporary(renderBuffer);
        
        if (!_capturedCache)
        {
            CaptureForCache(arg1, arg2);
        }
        if (_excludeCanvas != null)
        {
            _excludeCanvas.enabled = true;
            _excludeCanvas.overrideSorting = true;
        }
        if (_excludeView != null)
        {
            PopupFacade.instance.SetViewShow(_excludeView,true);
        }
        ScriptProfiler.EndSample();
    }
    
    private void CaptureForCache(RenderTargetIdentifier arg1, CommandBuffer arg2)
    {
        if (_frameTextureCache == null)
        {
            var desc = new RenderTextureDescriptor();
            desc.width = _frameTexture.width;
            desc.height = _frameTexture.height;
            desc.colorFormat = RenderTextureFormat.ARGB32;
            desc.depthBufferBits = 0;
            desc.sRGB = true;
            desc.useMipMap = false;
            desc.autoGenerateMips = false;
            desc.volumeDepth = 1;
            desc.msaaSamples = 1;
            desc.dimension = TextureDimension.Tex2D;
            _frameTextureCache = RenderTexture.GetTemporary(desc);
        }
        arg2.Blit(_frameTexture, _frameTextureCache,_material);
        _capturedCache = true;
    }
}