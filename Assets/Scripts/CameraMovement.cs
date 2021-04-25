using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject milkBase;
    public GameObject connections;
    public Vector3 newPosition;
    public Vector3 min;
    public Vector3 max;

    private void Start()
    {
        newPosition = transform.position;
        min = new Vector3(-17f, 10f, -31f);
        max = new Vector3(120f, 10f, 16.50f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Vector3 milkFactoryPosition = MoveTo(milkBase);
            transform.position = milkFactoryPosition;
        }
        
        if(Input.GetKeyDown(KeyCode.N))
        {
            GameObject lastConnection = connections.transform.GetChild(transform.childCount - 1).gameObject;
            Vector3 milkFactoryPosition = MoveTo(lastConnection);
            transform.position = milkFactoryPosition;
        }

        if (Input.GetKey(KeyCode.W))
        {
            float xSpeed = 5f;
            float zSpeed = 5f;
            
            var position = transform.position;
            float x = position.x;
            float z = position.z;
            float y = position.y;
            
            newPosition = new Vector3(x + xSpeed, y, z + zSpeed);
            if (IsInBoundaries(newPosition))
            {
                transform.position = Vector3.Lerp(position, newPosition, 5f * Time.deltaTime);    
            }
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            float xSpeed = 5f;
            float zSpeed = 5f;
            
            var position = transform.position;
            float x = position.x;
            float z = position.z;
            float y = position.y;
            
            newPosition = new Vector3(x - xSpeed, y, z - zSpeed);
            if (IsInBoundaries(newPosition))
            {
                transform.position = Vector3.Lerp(position, newPosition, 5f * Time.deltaTime);    
            }
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            float xSpeed = 5f;
            float zSpeed = 5f;
            
            var position = transform.position;
            float x = position.x;
            float z = position.z;
            float y = position.y;
            
            newPosition = new Vector3(x - xSpeed, y, z + zSpeed);
            if (IsInBoundaries(newPosition))
            {
                transform.position = Vector3.Lerp(position, newPosition, 5f * Time.deltaTime);    
            }
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            float xSpeed = 5f;
            float zSpeed = 5f;
            
            var position = transform.position;
            float x = position.x;
            float z = position.z;
            float y = position.y;
            
            newPosition = new Vector3(x + xSpeed, y, z - zSpeed);
            if (IsInBoundaries(newPosition))
            {
                transform.position = Vector3.Lerp(position, newPosition, 5f * Time.deltaTime);    
            }
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
            transform.position = Vector3.Lerp(position, newPosition, 5f * Time.deltaTime);
        }
    }

    private Vector3 MoveTo(GameObject target)
    {
        Vector3 targetPosition = target.transform.position;
        Vector3 offsetCoordinates = new Vector3(targetPosition.x - 16, 10f, targetPosition.z - 12);
        return offsetCoordinates;
    }

    public bool IsInBoundaries(Vector3 position)
    {
        bool biggerX = position.x < max.x;
        bool lowerX = position.x > min.x;
        bool lowerZ = position.z < max.z;
        bool biggerZ = position.z > min.z;

        return biggerX && lowerX && lowerZ && biggerZ;
    }
}
