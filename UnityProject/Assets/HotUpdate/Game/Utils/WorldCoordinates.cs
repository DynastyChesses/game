using System.Collections;
using System.Collections.Generic;

public enum GridDirection
{
    SW,
    W,
    NW,
    N,
    NE,
    E,
    SE,
    S,
    NONE,
}

public struct WorldCoordinates
{
    public int x;
    public int y;
    //
    // 是否相邻
    public static bool IsAdjacent(WorldCoordinates a, WorldCoordinates b) => new bool();
    // 距离
    public static float Distance(WorldCoordinates a, WorldCoordinates b) => new float();
    public static WorldCoordinates operator +(WorldCoordinates a, WorldCoordinates b) => new WorldCoordinates();
    public static WorldCoordinates operator -(WorldCoordinates a, WorldCoordinates b) => new WorldCoordinates();
    public static WorldCoordinates operator /(WorldCoordinates a, int divisor) => new WorldCoordinates();
    public static bool operator ==(WorldCoordinates a, WorldCoordinates b) => new bool();
    public static bool operator !=(WorldCoordinates a, WorldCoordinates b) => new bool();
    public bool IsValid(int width, int height) => new bool();
    public int ToIndex(int width) => new int();
    public static int ToIndex(int x, int y, int width) => new int();
    public static WorldCoordinates FromIndex(int index, int width) => new WorldCoordinates();
    public static GridDirection GetDirectionFromDistanceVector(WorldCoordinates distanceVector) => new GridDirection();
    public static GridDirection GetDirection(WorldCoordinates from, WorldCoordinates to) => new GridDirection();
    public static GridDirection ToDirection(WorldCoordinates coordinates) => new GridDirection();
    public int SqrMagnitude
    {
        get => new int();
    }
    public float Magnitude
    {
       get => new float();
    }
    public static List<WorldCoordinates> GetArea(
        WorldCoordinates center,
        int radius,
        bool allowDiagonal = true,
        bool includeCenter = true)
    {
        return (List<WorldCoordinates>) null;
    }
    
    public static void GetAreaPreallocated(
        List<WorldCoordinates> area,
        WorldCoordinates center,
        int radius,
        bool allowDiagonal = true,
        bool includeCenter = true)
    {
    }
}

public class WorldCoordinatesUtils : Singleton<WorldCoordinatesUtils>
{
    public override void Dispose()
    {
        // TODO
    }
    
    
}
