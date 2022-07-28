using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// Code run by unity in generating game board
/// </summary>
public class GameBoard : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        //Creating gameGrid
        int gameGridRad = 16;
        for (int q = -gameGridRad; q <= gameGridRad; q++)
        {
            for (int r = -gameGridRad; r <= gameGridRad; r++)
            {
                for (int s = -gameGridRad; s <= gameGridRad; s++)
                {
                    if ((q + r + s) == 0)
                    {
                        HexGrid newTile = new (q, r, s);
                        HexGrid.TileDictonary.Add(new Vector3(q, r, s), newTile);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        foreach (KeyValuePair<Vector3, HexGrid> entry in HexGrid.TileDictonary)
        {

            DrawHexagon(entry.Value.Q, entry.Value.R);
            Handles.Label(Hex.GetXYZPosition(entry.Value.Q, entry.Value.R), $"{entry.Value.Q},{entry.Value.R}");
        }
    }

    /*******************************************
    * FUNCTIONS
    *******************************************/
    /// <summary>
    /// Draws a hexagon using Gizmos.Drawline
    /// </summary>
    /// <param name="q">cubecoord at center of hex</param>
    /// <param name="r">cubecoord at center of hex</param>
    void DrawHexagon(int q, int r)
    {
        for (int i = 0; i < 6; i++)
        {
            Vector3 corner1 = Hex.FindCorner(Hex.GetXYZPosition(q, r), Hex.size, i);
            Vector3 corner2 = Hex.FindCorner(Hex.GetXYZPosition(q, r), Hex.size, i + 1);
            Gizmos.DrawLine(corner1, corner2);
        }
    }
}