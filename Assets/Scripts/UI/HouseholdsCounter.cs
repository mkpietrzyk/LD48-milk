using System;
using TMPro;
using UnityEngine;

public class HouseholdsCounter : MonoBehaviour
{
    public void UpdateCount(int count)
    {
        string text = $"{count:D2}";
        TextMeshProUGUI ugui = GetComponent<TextMeshProUGUI>();
        TextMeshPro gameUI = GetComponent<TextMeshPro>();
        if (ugui)
        {
            GetComponent<TextMeshProUGUI>().text = text;
            
        }
        if (gameUI)
        {
            GetComponent<TextMeshPro>().text = text;    
        }
    }
}
