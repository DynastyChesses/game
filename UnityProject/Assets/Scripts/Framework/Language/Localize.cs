using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Localize
{
    private static string[] LANG = new string []
    {
        "zh_cn",    // 0
        "en",       // 1
    };

#if UNITY_EDITOR
    public static int currLang = 1;
#else
    public static int currLang = 1;
#endif
    private static Dictionary<string, string> _data;
    public static bool loaded => _data != null;

    public static string Get( string key )
    {
        if( _data == null ) return "";
        if( string.IsNullOrEmpty( key ) )
        {
            Debug.LogError( $"<Localize> Key为空，请查看调用堆栈进行检查！" );
            return "";
        }
        
        if( !_data.TryGetValue( key, out string outText ) )
        {
            Debug.LogError( $"<Localize> 不存在的Key：{key}" );
            return key;
        }

        return outText;
    }
    
    public static string Get( string key, string arg1 )
    {
        if( _data == null ) return "";
        if( string.IsNullOrEmpty( key ) )
        {
            Debug.LogError( $"<Localize> Key为空，请查看调用堆栈进行检查！" );
            return "";
        }
        
        if( !_data.TryGetValue( key, out string outText ) )
        {
            Debug.LogError( $"<Localize> 不存在的Key：{key}" );
            return key;
        }

        try
        {
            outText = string.Format( outText, arg1 );
        }
        catch ( Exception e )
        {
            Debug.LogError( $"<Localize> Key：{key} 参数数量对不上，请检查！" );
            throw;
        }

        return outText;
    }
    
    public static string Get( string key, string arg1, string arg2 )
    {
        if( _data == null ) return "";
        if( string.IsNullOrEmpty( key ) )
        {
            Debug.LogError( $"<Localize> Key为空，请查看调用堆栈进行检查！" );
            return "";
        }
        
        if( !_data.TryGetValue( key, out string outText ) )
        {
            Debug.LogError( $"<Localize> 不存在的Key：{key}" );
            return key;
        }

        try
        {
            outText = string.Format( outText, arg1, arg2 );
        }
        catch ( Exception e )
        {
            Debug.LogError( $"<Localize> Key：{key} 参数数量对不上，请检查！" );
            throw;
        }

        return outText;
    }
    
    public static string Get( string key, string arg1, string arg2, string arg3 )
    {
        if( _data == null ) return "";
        if( string.IsNullOrEmpty( key ) )
        {
            Debug.LogError( $"<Localize> Key为空，请查看调用堆栈进行检查！" );
            return "";
        }
        
        if( !_data.TryGetValue( key, out string outText ) )
        {
            Debug.LogError( $"<Localize> 不存在的Key：{key}" );
            return key;
        }

        try
        {
            outText = string.Format( outText, arg1, arg2, arg3 );
        }
        catch ( Exception e )
        {
            Debug.LogError( $"<Localize> Key：{key} 参数数量对不上，请检查！" );
            throw;
        }

        return outText;
    }
    
    public static string Get( string key, string arg1, string arg2, string arg3, string arg4 )
    {
        if( _data == null ) return "";
        if( string.IsNullOrEmpty( key ) )
        {
            Debug.LogError( $"<Localize> Key为空，请查看调用堆栈进行检查！" );
            return "";
        }
        
        if( !_data.TryGetValue( key, out string outText ) )
        {
            Debug.LogError( $"<Localize> 不存在的Key：{key}" );
            return key;
        }

        try
        {
            outText = string.Format( outText, arg1, arg2, arg3, arg4 );
        }
        catch ( Exception e )
        {
            Debug.LogError( $"<Localize> Key：{key} 参数数量对不上，请检查！" );
            throw;
        }

        return outText;
    }

    public static string Get( string key, params string[] arg )
    {
        if( _data == null ) return "";
        if( string.IsNullOrEmpty( key ) )
        {
            Debug.LogError( $"<Localize> Key为空，请查看调用堆栈进行检查！" );
            return "";
        }
        
        if( !_data.TryGetValue( key, out string outText ) )
        {
            Debug.LogError( $"<Localize> 不存在的Key：{key}" );
            return key;
        }
        if( arg.Length == 0 )
        {
            return outText;
        }

        try
        {
            outText = string.Format( outText, arg );
        }
        catch ( Exception e )
        {
            Debug.LogError( $"<Localize> Key：{key} 参数数量对不上，请检查！" );
            throw;
        }

        return outText;
    }
}