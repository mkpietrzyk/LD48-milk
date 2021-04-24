using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Household : MonoBehaviour
{
    public int connectedFrom;
    public int connectedTo;
    public string uniqueID;
    public StringVariable selectedObjectID;
    private void OnEnable()
    {
        uniqueID = Guid.NewGuid().ToString();
        
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selectedObjectID.Value != uniqueID)
        {
            gameObject.tag = "household";
        }
        
    }

    private void OnMouseDown()
    {
        Debug.Log("click");
        Debug.Log(transform.position);
        selectedObjectID.SetValue(uniqueID);
        gameObject.tag = "selected";
    }
}
