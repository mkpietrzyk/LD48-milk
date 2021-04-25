using TMPro;
using UnityEngine;

public class CowsCounter : MonoBehaviour
{
    public void UpdateCount(int count)
    {
        string text = $"Cows {count}";
        GetComponent<TextMeshPro>().text = text;
    }
}
