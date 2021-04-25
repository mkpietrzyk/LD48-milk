using UnityAtoms.BaseAtoms;
using UnityEngine;

public class CowShop : MonoBehaviour
{
    public IntVariable cash;
    public IntVariable cowCount;
    public GameObject stand;
    public GameObject cow;
    public GameObject cows;

    public void OnMouseOver()
    {
        stand.GetComponent<Renderer>().material.color = Color.cyan;
    }

    private void OnMouseExit()
    {
        stand.GetComponent<Renderer>().material.color = Color.grey;
    }

    private void OnMouseDown()
    {
        bool isValidBalance = cash.Value > 100;

        if (isValidBalance)
        {
            BuyCow();
            cash.Value -= 100;
        }
        else
        {
        }
    }

    private void BuyCow()
    {
        Vector3 min = new Vector3(-11.5f, 0.6f, 2.5f);
        Vector3 max = new Vector3(-4.5f, 0.6f, 11.5f);
        
        float randomX = Random.Range(min.x, max.x);
        float randomZ = Random.Range(min.z, max.z);
        Vector3 randomPosition = new Vector3(randomX, min.y, randomZ);
        cowCount.Value += 1;
        Instantiate(cow, randomPosition, Quaternion.identity, cows.transform);
    }
}