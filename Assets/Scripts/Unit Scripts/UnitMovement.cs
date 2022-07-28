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
        if(Input.GetButtonDown("Fire1"))
        {
            Vector3 mousePos = Input.mousePosition;
            Ray Neater = Camera.main.ScreenPointToRay(mousePos);
            Plane planeGrid = new Plane(Vector3.up, 0);
            if (!planeGrid.Raycast(Neater, out float distanceFloat))
            {
                return;
            }
            Vector3 worldPos = Neater.origin + Neater.direction * distanceFloat;
            Vector3Int gameBoardPos = Hex.GetQRSPosition(worldPos.x, worldPos.z);
            Vector3 Hexworldpos = Hex.GetXYZPosition(gameBoardPos.x, gameBoardPos.z);
            Debug.Log($"worldpos: {worldPos}, gameboardpos {gameBoardPos}, Hexworldpos {Hexworldpos}");
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
