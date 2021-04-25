using TMPro;
using UnityEngine;

public class BalanceCounter : MonoBehaviour
{
    public void UpdateCount(int balance)
    {
        string text = $"{balance}";
        string sign = balance > 0 ? "+" : "-";
        TextMeshProUGUI ugui = GetComponent<TextMeshProUGUI>();
        TextMeshPro gameUI = GetComponent<TextMeshPro>();
        if (ugui)
        {
           
            GetComponent<TextMeshProUGUI>().text = $"({sign} {Mathf.Abs(balance)})";
            GetComponent<TextMeshProUGUI>().color = BalanceColor(balance);
        }
        if (gameUI)
        {
            GetComponent<TextMeshPro>().text = $"({sign} {Mathf.Abs(balance)})";    
            GetComponent<TextMeshPro>().color = BalanceColor(balance);    
        }
    }

    public Color BalanceColor(int balance)
    {
        return balance > 0 ? Color.green : Color.red;
    }
}
