using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    HexGrid unitPosition = new HexGrid(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3Int[] movementRangeArray = MovementRange(1, new Vector3Int(unitPosition.Q, unitPosition.R, unitPosition.S));

        // Moving piece to centre of a clicked on tile.
        if(Input.GetButtonDown("Fire1"))
        {
            Vector3Int selectedTile = Userinput.MousePosToQRS();
            for (int i = 0; i < 7; i++)
            {
                if (movementRangeArray[i] == selectedTile)
                {
                    Vector3 Hexworldpos = Userinput.MousePosToXYZ();
                    transform.position = Hexworldpos;
                    unitPosition.Q = selectedTile.x;
                    unitPosition.R = selectedTile.y;
                    unitPosition.S = selectedTile.z;
                }
            }
        }
         
    }
    /// <summary>
    /// Passess a Vector3 array of tiles in range of x number of steps
    /// </summary>
    /// <param name="numSteps">How many steps can be taken</param>
    /// <param name="center">The center tile in cube coord</param>
    /// <returns></returns>
    public static Vector3Int[] MovementRange(int numSteps, Vector3Int center)
    {
        //Determining the number of tile in range for array declartion
        int numberOfTiles = 2;
        int x = 0;
        for (int j = 0; j < numSteps; j ++)
        {
            x += 6;
            numberOfTiles += x;
        }
        
        Vector3Int[] MoveRange = new Vector3Int[numberOfTiles];
        int i = 0;
        for (int q = - numSteps; q <= numSteps; q++)
        {
            for (int r = -numSteps; r <= numSteps; r++)
            {
                for (int s = -numSteps; s <= numSteps; s++)
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
}
