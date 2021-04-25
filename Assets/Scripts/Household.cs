using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
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
    public IntVariable householdCount;
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

        if (String.IsNullOrEmpty(connectedTo) && !String.IsNullOrEmpty(connectedFrom))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            gameObject.GetComponentInChildren<TextMeshPro>().text = "";
        }
        
        if (!String.IsNullOrEmpty(connectedTo) && !String.IsNullOrEmpty(connectedFrom))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            gameObject.GetComponentInChildren<TextMeshPro>().text = "";
        }
        
    }

    private void OnMouseDown()
    {
        if (String.IsNullOrEmpty(connectedTo) && !String.IsNullOrEmpty(connectedFrom))
        {
            gameObject.tag = "selected";
            selectedObjectID.SetValue(uniqueID);
            Instantiate(connectionLine, transform.position, Quaternion.identity);
        }
    }

    private void OnMouseUp()
    {
        gameObject.tag = "household";
    }

    private void OnMouseOver()
    {
        if (String.IsNullOrEmpty(connectedTo))
        {
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            gameObject.GetComponentInChildren<TextMeshPro>().text = $"{householdCount.Value * 20} €";
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            gameObject.GetComponentInChildren<TextMeshPro>().text = "";
        }
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.grey;
        gameObject.GetComponentInChildren<TextMeshPro>().text = "";
    }
}
