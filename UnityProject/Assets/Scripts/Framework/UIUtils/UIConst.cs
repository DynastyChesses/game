using System.Runtime.CompilerServices;
using UnityEngine;

public class UIConst
{
    // public static Vector3 UI_LAYER_INVISIBLE_POSITION = new Vector3(8000, 8000, 5100);
    //
    // public static Vector3 UI_LAYER_VISIBLE_POSITION = new Vector3(0, 0, 5100);

    public static Vector3 INVISIBLE_POSITION = new Vector3(8000, 8000, 0);

    public static Vector3 VISIBLE_POSITION = new Vector3(0, 0, 0);

    public static Color SELF_COLOR = new Color32(2, 255, 159, 255);

    public static Color FRIEND_COLOR = new Color32(2, 173, 255, 255);

    public static Color ENEMY_COLOR = new Color32(255, 22, 96, 255);
    
    //游戏设计尺寸分辨率
    public static Vector2Int DESIGN_SOLUTION = new Vector2Int(750, 1334);
}

public class Layers 
{
    public const int DEFAULT = 0;
    public const int TRANSPARENT_FX = 1;
    public const int IGNORE_RAYCAST = 2;
    public const int WATER = 4;
    public const int UI = 5;
    public const int POST_PROCESSING = 8;
    public const int UI3D = 9;
    public const int RenderTexture = 12;
    public const int FLASH_WHITE = 16;
    public const int DONT_SHOW = 31;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int CullMask(int layer)
    {
        return 1 << layer;
    }
}

public class PopupLayers
{
    public const int DEFAULT_LAYER = 0;
    public const int TOP_LAYER = 1;
    public const int UI_ROOT_LAYER = 2;
}