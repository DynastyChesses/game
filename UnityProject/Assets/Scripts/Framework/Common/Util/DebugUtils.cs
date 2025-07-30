

using System.Diagnostics;

public static class DebugUtils
{
    [Conditional( "DEBUG" )]
    public static void ValueIsTrue( bool value, string msg = "" )
    {
        if ( !value )
            Logger.Error( $"DEBUG Error: {msg}" );
    }


    #region 调试日志

    [Conditional("DEBUG_CHARACTER_AVATAR_TRANSFORM")]
    public static void DebugCharacterAvatarTransform(string info)
    {
        DebugInfo($"CharacterAvatar Transform:{info}");
    }
    
    // 调查问卷调试信息
    [Conditional("DEBUG_QUESTION_INFO")]
    public static void DebugQuestionInfo(string info)
    {
        DebugInfo($"DEBUG Question:{info}");
    }
        
    [Conditional("DEBUG_MAP_TRANSLATE_INFO")]
    public static void DebugMapTranslateInfo(string s)
    {
        DebugInfo($"DEBUG MAP TRANSLATE:{s}");
    }
    
    [Conditional("TERRITORY_DEFENSE_DEBUG")]
    public static void DebugTerritoryDefenseInfo(string s)
    {
        DebugInfo($"DEBUG MAP TRANSLATE:{s}");
    }
    
    [Conditional("FIREPOT_IDLE_REWARD_DEBUG")]
    public static void DebugFirePotIdleRewardDefenseInfo(string s)
    {
        DebugInfo($"DEBUG FIREPOT IDLE:{s}");
    }
    
    [Conditional("UNITY_EDITOR")]
    public static void DebugInfo(string tag)
    {
        Logger.Error($"{RealTimer.elapsedMilliseconds} : {tag}");
    }
    #endregion
}