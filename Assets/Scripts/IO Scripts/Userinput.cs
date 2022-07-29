using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Userinput : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns>Returns the QRS position of the hexagon clicked on</returns>
    public static Vector3Int MousePosToQRS ()
    {
        //Getting mouse position and converting to ray
        Vector3 mousePos = Input.mousePosition;
        Ray mouseClickRay = Camera.main.ScreenPointToRay(mousePos);
        
        Plane planeGrid = new Plane(Vector3.up, 0);
        if (!planeGrid.Raycast(mouseClickRay, out float distanceGridFromRay))
        {
            
        }
        
        Vector3 worldPos = mouseClickRay.origin + mouseClickRay.direction * distanceGridFromRay;
        return Hex.GetQRSPosition(worldPos.x, worldPos.z);
    }

    public static Vector3 MousePosToXYZ()
    {
        Vector3Int QRSPos = MousePosToQRS();
        return Hex.GetXYZPosition(QRSPos.x, QRSPos.y);
    }
}
