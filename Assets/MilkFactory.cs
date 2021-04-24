using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class MilkFactory : MonoBehaviour
{
    public StringVariable selectedObjectID;
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
        Debug.Log("click");
        Debug.Log(transform.position);
        selectedObjectID.SetValue("factory");
        gameObject.tag = "selected";
    }
}
