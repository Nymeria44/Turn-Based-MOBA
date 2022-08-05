using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public int Speed = 2;

    private void Start()
    {
        transform.position = new Vector3(0, 15, -69);
    }

    void Update()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float zAxisValue = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        transform.position = new Vector3(transform.position.x + xAxisValue, transform.position.y, transform.position.z + zAxisValue);
    }
    
}
