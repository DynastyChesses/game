using System;
using System.Collections.Generic;
using FixMath.NET;
using UnityEngine;

public enum DeadRules
{
    [Alias("失败")]
    Loser = 0,
    [Alias("复活")]
    Resurrection = 1,
}

// public enum VictoryRules
// {
//     [Alias("最高分")]
//     HighScore = 0,
//     [Alias("到达终点")]
//     Winner = 1,
//     [Alias("存活")]
//     Survive = 2,
// }
public enum GameOverChecker
{
    [Alias("胜利者人数")]
    WinnerChecker = 0,
    [Alias("淘汰者人数")]
    LoserChecker = 1,
    [Alias("计时器")]
    TimeChecker = 2,
}
public enum LevelModelTypes
{
    [Alias("竞速")]
    Racing = 0,
    [Alias("生存")]
    Survive = 1,
    [Alias("积分")]
    Score = 2,
    [Alias("足球")]
    Football = 3,
}


public class LevelRulesConfig : MonoBehaviour
{
    public string LevelName;
    public string LevelDesc;
    public string LevelTargetDesc;
    public LevelModelTypes LevelModel;
    public BEPUutilities.Vector3 Gravity = new BEPUutilities.Vector3(0,-9.81m*2,0);
    public Fix64 PlayerMoveSpeed = 7;
    public Fix64 PlayerAirSpeed = 7;
    public Fix64 PlayerJumpSpeed = 7;
    public DeadRules DeadRules;
    // public VictoryRules VictoryRules;
    public List<OverCheckerData> OverCheckerDataList = new List<OverCheckerData>();
}


[Serializable]
public class OverCheckerData
{
    public GameOverChecker OverChecker;
    public int Value;
}