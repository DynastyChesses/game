// 当前游戏所有数据

// 游戏模式

using System;
using System.Collections.Generic;
using MiracleWar;
using UnityEngine;

public enum GameMode
{
    Single = 1,
    MutiPlayer = 2
}
public class GameProxy : TBaseProxy<GameProxy>
{
    // 游戏模式
    public GameMode gameMode = GameMode.Single;
    // 当前局ID
    public int gameId = -1;
    //
    public MapInfo currentMapInfo = null;
    // 当前玩家数量
    public int currentPlayerCount = 0;
    // 所有玩家
    public game_user[] Users = null;
    
    // 当前的随机种子
    public int Seed
    {
        get
        {
            return currentMapInfo.Seed;
        }
    }
    
    //
    public int TotalTile
    {
        get
        {
            return currentMapInfo.Width * currentMapInfo.Height;
        }
    }
    
    // 随机算法
    public int Rand(int min, int max, int pos)
    {
        if (max < min)
        {
            throw new Exception("max not less min");
        }
        int n = Seed * (pos + 756);
        if (max - min == 0)
        {
            return max;
        }
        int c = Math.Abs(n % (max - min));
        return min + c;
    }
    
    public GameProxy() :base(ProxyNames.Game)
    {
        
    }
}