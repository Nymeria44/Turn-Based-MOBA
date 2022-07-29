using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CurrentPosition = new Vector3(0, 1, 0);
        
        transform.position = CurrentPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Moving piece to centre of a clicked on tile.
        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 Hexworldpos = Userinput.MousePosToXYZ();
            transform.position = Hexworldpos;
        }
    }

    /// <summary>
    /// Current position of the unity
    /// </summary>
    public Vector3 CurrentPosition { get; set; }


    public UnitMovement(Vector3 currentposition)
    {
        
    }

}
