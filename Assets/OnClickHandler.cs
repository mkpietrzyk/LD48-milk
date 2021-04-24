using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickHandler : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            // Casts the ray and get the first game object hit
            Physics.Raycast(ray, out hit);
            Debug.Log("This hit at " + hit.transform.position );
        }
    }
}
