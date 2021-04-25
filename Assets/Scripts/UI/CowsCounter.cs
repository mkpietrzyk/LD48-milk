using TMPro;
using UnityEngine;

public class CowsCounter : MonoBehaviour
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
