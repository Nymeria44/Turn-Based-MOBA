using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public static void StartMovement(UnitInfo unitInfo)
    {
        //Hardcoding unit moveSpeed and position for Alpha testing
        unitInfo.moveSpeed = 5;
        if (unitInfo.team == 1)
        {
            unitInfo.Q = 0;
            unitInfo.R = 16;
            unitInfo.S = -16;
        }
        if (unitInfo.team == 2)
        {
            unitInfo.Q = 0;
            unitInfo.R = -16;
            unitInfo.S = 16;
        }
        else 
        {
            Debug.Log ("Unit's team was not set");
        }
    }

    // Update is called once per frame
    public static void UpdateMovement(UnitInfo unitInfo)
    {
        // Moving piece to centre of a clicked tile if in ms range.
        if (Input.GetButtonDown("Fire1"))
        {
            //Finding tiles in range of unit and number of them (arraysize)
            Vector3Int[] movementRangeArray = MovementRange(unitInfo.moveSpeed, unitInfo.QRSVec());
            int arraysize = NumberOfTilesInRange(unitInfo.moveSpeed);

            //Checking if selected tile is in range of moveSpeed
            Vector3Int selectedTile = Userinput.MousePosToQRS();
            for (int i = 0; i < arraysize; i++)
            {
                if (movementRangeArray[i] == selectedTile)
                {
                    Vector3 Hexworldpos = Userinput.MousePosToXYZ();
                    unitInfo.Q = selectedTile.x;
                    unitInfo.R = selectedTile.y;
                    unitInfo.S = selectedTile.z;
                }
            }
        }
    }

    /// <summary>
    /// Passess a Vector3 array of tiles in range of x number of steps
    /// </summary>
    /// <param name="moveSpeed">How many steps can be taken</param>
    /// <param name="center">The center tile in cube coord</param>
    /// <returns></returns>
    public static Vector3Int[] MovementRange(int moveSpeed , Vector3Int center)
    {

        int numberOfTiles = NumberOfTilesInRange(moveSpeed);

        Vector3Int[] MoveRange = new Vector3Int[numberOfTiles];
        int i = 0;
        for (int q = - moveSpeed; q <= moveSpeed; q++)
        {
            for (int r = -moveSpeed; r <= moveSpeed; r++)
            {
                for (int s = -moveSpeed; s <= moveSpeed; s++)
                {
                    if (q + r + s == 0)
                    {
                        MoveRange[i] = (Hex.CoordsAdd(center, new Vector3Int(q, r, s)));
                        i++;
                    }
                }

            }
        }
        return MoveRange;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="moveSpeed"></param>
    /// <returns></returns>
    private static int NumberOfTilesInRange (int moveSpeed)
    {
        int numberOfTiles = 1;
        int x = 0;
        for (int j = 0; j < moveSpeed; j++)
        {
            x += 6;
            numberOfTiles += x;
        }
        return numberOfTiles;
    }
}