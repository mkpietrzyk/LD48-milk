using TMPro;
using UnityEngine;

public class CashCounter : MonoBehaviour
{
    public void UpdateCount(int count)
    {
        string text = $"Cash {count:D6}";
        GetComponent<TextMeshPro>().text = text;
    }
}
