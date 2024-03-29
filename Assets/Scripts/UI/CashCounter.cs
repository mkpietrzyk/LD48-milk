using TMPro;
using UnityEngine;

public class CashCounter : MonoBehaviour
{
    public void UpdateCount(int count)
    {
        string text = $"{count:D6}";
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
