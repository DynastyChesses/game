using System;
using System.Text;
using TMPro;

public static class TextUtil
{
    private static TMP_SpriteAsset _tmpSpriteAsset = null;
    private static IAsyncResourceRequest _tmpSpriteAssetReq = null;

    public static TMP_SpriteAsset tmpSpriteAsset => _tmpSpriteAsset;

    public static void TMPSpriteAssetWarmUp(Action<TMP_SpriteAsset> warmCb)
    {
        if (_tmpSpriteAsset == null)
        {
            _tmpSpriteAssetReq?.Dispose();
            _tmpSpriteAssetReq = ResourceFacade.instance.LoadObjectAsync<TMP_SpriteAsset>("Atlas/TMPSprite/TMPTokenIcon");
            _tmpSpriteAssetReq.callback = request =>
            {
                if (request == null || request.asset == null)
                {
                    return;
                }
                TMP_SpriteAsset material = request.asset as TMP_SpriteAsset;
                _tmpSpriteAsset = ResourceFacade.Instantiate(material) as TMP_SpriteAsset;
                warmCb?.Invoke(_tmpSpriteAsset);
                _tmpSpriteAssetReq?.Dispose();
                _tmpSpriteAssetReq = null;
            };
        }
    }
    
    private static StringBuilder __stringBuilder = null;

    private static StringBuilder stringBuilder
    {
        get
        {
            if (__stringBuilder == null)
            {
                __stringBuilder = new StringBuilder(512);
            }

            return __stringBuilder;
        }
    }
}