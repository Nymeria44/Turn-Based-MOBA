using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : MonoBehaviour
{
    public UnitInfo unitInfo;
    public Material lightMaterial;
    public Material darkMaterial;

    // Start is called before the first frame update
    void Start()
    {
        SetTeamColour(unitInfo.team);
        
        //Setting position on game board based on team
        UnitMovement.StartMovement(unitInfo);
        transform.position = Hex.GetXYZPosition(unitInfo.Q, unitInfo.R);
    }

    // Update is called once per frame
    void Update()
    {
        //Movement commands
        UnitMovement.UpdateMovement(unitInfo);
        transform.position = Hex.GetXYZPosition(unitInfo.Q, unitInfo.R);
    }

    private void SetTeamColour (int team)
    {
        if (team == 1)
        {
            GetComponent<MeshRenderer>().material = lightMaterial;
        }        
        
        if (team == 2)
        {
            GetComponent<MeshRenderer>().material = darkMaterial;
        }
        else
        {
            Debug.Log("team was not selected");
        }
    }
}

