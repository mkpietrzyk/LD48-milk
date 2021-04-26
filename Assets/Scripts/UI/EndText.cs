using TMPro;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class EndText : MonoBehaviour
{
    public IntVariable cash;

    public void UpdateText(string stuff)
    {
        string text = cash.Value < 0
            ? "Oh no, we lost all the cows :( Better luck next time!"
            : "Moo Moo! You have connected all houses! Now we all got the milk :3";
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