using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class ConnectionsCounter : MonoBehaviour
{
    public FloatVariable connectionsDistance;
    
    public void UpdateCount(int count)
    {
        string text = $"{count:D2} = {connectionsDistance.Value:F1} km";
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
