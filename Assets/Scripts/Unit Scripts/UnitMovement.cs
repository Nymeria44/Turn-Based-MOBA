using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    UnitMovementInfo Unitinfo = new UnitMovementInfo();

    // Start is called before the first frame update
    void Start()
    {
        //Hardcoding unit movespeed and position for Alpha testing
        Unitinfo.movespeed = 5;
        Unitinfo.Q = 0;
        Unitinfo.R = 0;
        Unitinfo.S = 0;
        transform.position = Hex.GetXYZPosition(Unitinfo.Q, Unitinfo.R);
    }

    // Update is called once per frame
    void Update()
    {
        // Moving piece to centre of a clicked tile if in ms range.
        if (Input.GetButtonDown("Fire1"))
        {
            //Finding tiles in range of unit and number of them (arraysize)
            Vector3Int[] movementRangeArray = MovementRange(Unitinfo.movespeed, Unitinfo.QRSVec());
            int arraysize = NumberOfTilesInRange(Unitinfo.movespeed);

            //Checking if selected tile is in range of movespeed
            Vector3Int selectedTile = Userinput.MousePosToQRS();
            for (int i = 0; i < arraysize; i++)
            {
                if (movementRangeArray[i] == selectedTile)
                {
                    Vector3 Hexworldpos = Userinput.MousePosToXYZ();
                    transform.position = Hexworldpos;
                    Unitinfo.Q = selectedTile.x;
                    Unitinfo.R = selectedTile.y;
                    Unitinfo.S = selectedTile.z;
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
    public static Vector3Int[] MovementRange(int moveSpeed, Vector3Int center)
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

/// <summary>
/// Information about a Unit for movement
/// </summary>
public class UnitMovementInfo
{
    /// <summary>
    /// Q position of unit
    /// </summary>
    public int Q;
    /// <summary>
    /// R position of unit
    /// </summary>
    public int R;
    /// <summary>
    /// S position of unit
    /// </summary>
    public int S;
    /// <summary>
    /// Creates a cube coor vector
    /// </summary>
    /// <returns></returns>
    public Vector3Int QRSVec()
    {
        Vector3Int qrsVec = new Vector3Int();
        qrsVec.x = Q;
        qrsVec.y = R;
        qrsVec.z = S;
        return qrsVec;

    }
    /// <summary>
    /// Number of tiles a unit can move
    /// </summary>
    public int movespeed;
}