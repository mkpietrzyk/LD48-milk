using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class MilkFactory : MonoBehaviour
{
    public StringVariable selectedObjectID;
    public GameObject connectionLine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObjectID.Value != "factory")
        {
            gameObject.tag = "factory";
        }
    }
    
    private void OnMouseDown()
    { 
        gameObject.tag = "selected";
        selectedObjectID.SetValue("factory");
        Instantiate(connectionLine, transform.position, Quaternion.identity);
    }
}
