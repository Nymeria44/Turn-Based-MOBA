using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Hexagon maths and variables
/// </summary>
public class Hex : MonoBehaviour
{
    /*******************************************
     * VARIABLES AND GLOBAL VALUES
     *******************************************/
    /// <summary>
    /// Distance from the centre of a hex to a corner
    /// </summary>
    public static float size = 2;
    /// <summary>
    /// Width of a hexagon
    /// </summary>
    public static float width = size * 2;
    /// <summary>
    /// Height of a hexagon
    /// </summary>
    public static float height = Mathf.Sqrt(3) * size;
    /// <summary>
    /// horizontal distance between two hex centres
    /// </summary>
    public static float horizontalSpacing = width * 3 / 4;
    /// <summary>
    /// vertical distance between two hex centres
    /// </summary>
    public static float verticalSpacing = height;
    /// <summary>
    /// Array of vectors for calculating neibouring tiles
    /// </summary>
    static readonly Vector3Int[] FindNeighbourArray = { 
        new Vector3Int (1, 0, -1), 
        new Vector3Int (1, -1, 0), 
        new Vector3Int (0, -1, 1), 
        new Vector3Int (-1, 0, 1), 
        new Vector3Int (-1, 1, 0), 
        new Vector3Int (0, 1, -1) };


    /*******************************************
     * FUNCTIONS
     *******************************************/
    /// <summary>
    /// Converts from GridCoord to UnityCoord
    /// </summary>
    /// <param name="q"></param>
    /// <param name="r"></param>
    /// <returns></returns>
    public static Vector3 GetXYZPosition(int q, int r)
    {
        Vector3 posXYZ;
        posXYZ.x = size * (3 / 2f * q);
        posXYZ.z = size * (Mathf.Sqrt(3) / 2 * q + Mathf.Sqrt(3) * r);
        posXYZ.y = 0;
        return posXYZ;
    }
    /// <summary>
    /// Converts from UnityCoord to GridCoord
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static Vector3Int GetQRSPosition(float x, float y)
    {
        Vector3 QRSNonRounded;
        QRSNonRounded.x = (2f / 3 * x) / size;
        QRSNonRounded.y = (-1f / 3 * x + Mathf.Sqrt(3) / 3 * y) / size;
        //QRSNonRounded.y = (Mathf.Sqrt(3) / 3 * x + (-1f / 3) * y) / size;
        //QRSNonRounded.x = (2/3f * y) / size;
        QRSNonRounded.z = (-QRSNonRounded.x - QRSNonRounded.y);
        return CubeRound(QRSNonRounded);
    }
    /// <summary>
    /// Rounds CubeCoords
    /// </summary>
    /// <param name="unroundedCube"></param>
    /// <returns></returns>
    public static Vector3Int CubeRound (Vector3 unroundedCube)
    {
        Vector3Int roundedCube = new Vector3Int();
        roundedCube.x = Mathf.RoundToInt(unroundedCube.x);
        roundedCube.y = Mathf.RoundToInt(unroundedCube.y);
        roundedCube.z = Mathf.RoundToInt(unroundedCube.z);
        return roundedCube;
    }
    /// <summary>
    /// Finds a vertice of a hexagon
    /// </summary>
    /// <param name="center"></param>
    /// <param name="size"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public static Vector3 FindCorner(Vector3 center, float size, int i)
    {
        int angleDeg = 60 * i;
        float angleRad = (Mathf.PI / 180) * angleDeg;

        return new Vector3(center.x + size * Mathf.Cos(angleRad), center.y, center.z + size * Mathf.Sin(angleRad));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3Int CoordsAdd(Vector3Int a, Vector3Int b)
    {
        return new Vector3Int(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    /// <summary>
    /// Substracts the (q,s,r) of b from a
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3Int CoordsSubstract(Vector3Int a, Vector3Int b)
    {
        return new Vector3Int(a.x - b.x, a.y - b.y, a.z - b.z);
    }
    /// <summary>
    /// Multiples coordinates (q,r,s) by an int b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Vector3Int CoordsScale(Vector3Int a, int b)
    {
        return new Vector3Int(a.x * b, a.y * b, a.z * b);
    }
    /// <summary>
    /// Finds the absolute distance between a and b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static float CoordsDistance(Vector3Int a, Vector3Int b)
    {
        Vector3Int vector = CoordsSubstract(a, b);
        return (Mathf.Abs(vector.x) + Mathf.Abs(vector.y) + Mathf.Abs(vector.z) / 2);
    }

    /// <summary>
    /// Finds (q,r,s) position of all neighbouring tiles.
    /// </summary>
    /// <param name="currentTile"></param>
    /// <returns>returns an array of vector3Int</returns>
    public static Vector3Int[] FindNeighbours (Vector3Int currentTile)
    {
        Vector3Int[] NeighbourTiles = new Vector3Int[6];
        for (int i = 0; i <= 6; i++)
        {
            NeighbourTiles[i] = CoordsAdd(currentTile, FindNeighbourArray[i]);
        }

        return NeighbourTiles;
    }
    /// <summary>
    /// Linear interpolation of floats for line drawing
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    private static float FloatLerp(float a, float b, float t)
    {
        return a + (b - a) * t;
    }
    /// <summary>
    /// Linear interpolation of cube coord for line drawing
    /// </summary>
    /// <param name="a">cube coords unrounded</param>
    /// <param name="b">cube coords unrounded</param>
    /// <param name="t"></param>
    /// <returns></returns>
    private static Vector3 CubeLerp(Vector3 a, Vector3 b, float t)
    {
        Vector3 CubeLerped = new Vector3();
        CubeLerped.x = FloatLerp(a.x, b.x, t);
        CubeLerped.y = FloatLerp(a.y, b.y, t);
        CubeLerped.z = FloatLerp(a.z, b.z, t);
        return CubeLerped;
    }
    /// <summary>
    /// Draws a line between two hexagons
    /// </summary>
    public static Vector3Int[] DrawLine (Vector3Int a, Vector3Int b)
    {
        int N = Mathf.RoundToInt(CoordsDistance(a, b));
        Vector3Int[] lineBetweenAB = new Vector3Int[Mathf.RoundToInt(N)];
        for (int i = 0; i <= N; i++)
        {
            lineBetweenAB[i] = CubeRound(CubeLerp(a, b, 1.0f * N * i));
        }
        return lineBetweenAB;
    }
}



/// <summary>
/// Responsible for the dictionary of the gameboard
/// </summary>
public class HexGrid
{
    /// <summary>
    /// Dictionary which stores the game grid
    /// </summary>
    public static Dictionary<Vector3, HexGrid> TileDictonary = new Dictionary<Vector3, HexGrid>();
    
    
    public int Q { get; set; }
    public int R { get; set; }
    public int S { get; set; }

    public HexGrid(int q, int r, int s)
    {
        this.Q = q;
        this.R = r;
        this.R = s;
    }
}