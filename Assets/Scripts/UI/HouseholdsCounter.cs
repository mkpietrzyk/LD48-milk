using System;
using TMPro;
using UnityEngine;

public class HouseholdsCounter : MonoBehaviour
{
    public void UpdateCount(int count)
    {
        string text = $"Households {count}";
        GetComponent<TextMeshPro>().text = text;
    }
}
