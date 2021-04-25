using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject milkBase;
    public GameObject lastConnection;
    public Vector3 newPosition;

    private void Start()
    {
        newPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            MoveTo(milkBase);
        }
        
        if (Input.GetMouseButton(1))
        {
            float xinput = Input.GetAxisRaw("Mouse X");
            float zinput = Input.GetAxisRaw("Mouse Y");

            var position = transform.position;
            float x = position.x;
            float z = position.z;
            float y = position.y;
 
            newPosition = new Vector3(x + xinput, y, z + zinput);            
        }
 
        transform.position = Vector3.Lerp(transform.position, newPosition, 5f * Time.deltaTime);
    }

    private void MoveTo(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 offsetCoordinates = new Vector3(targetPosition.x - 13, 10f, targetPosition.z - 13);
        transform.position = offsetCoordinates;
    }
}
