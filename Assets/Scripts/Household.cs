using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Household : MonoBehaviour
{
    public string connectedFrom;
    public string connectedTo;
    public string uniqueID;
    public StringVariable selectedObjectID;
    public GameObject connectionLine;
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
        gameObject.tag = "selected";
        selectedObjectID.SetValue(uniqueID);
        Instantiate(connectionLine, transform.position, Quaternion.identity);
    }
}
