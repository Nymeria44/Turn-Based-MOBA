using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUnit : MonoBehaviour
{
    public UnitInfo unitInfo;
    
    // Start is called before the first frame update
    void Start()
    {
        UnitMovement.StartMovement(unitInfo);
        transform.position = Hex.GetXYZPosition(unitInfo.Q, unitInfo.R);
    }

    // Update is called once per frame
    void Update()
    {
        UnitMovement.UpdateMovement(unitInfo);
        transform.position = Hex.GetXYZPosition(unitInfo.Q, unitInfo.R);
    }
}

