using System;
using TMPro;
using UnityEngine;

public class HouseholdsCounter : MonoBehaviour
{
    public void UpdateCount(int count)
    {
        string text = $"Households: {count:D3}";
        GetComponent<TextMeshPro>().text = text;
    }
}
