using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cows;
    public List<GameObject> connections;
    public List<GameObject> households;

    public bool gameStart;
    public bool gamePause;

    [SerializeField] private IntVariable balance;
    [SerializeField] private IntVariable cash;
    [SerializeField] private IntVariable cowsCount;
    [SerializeField] private FloatVariable connectionDistance;
    [SerializeField] private IntVariable householdsCount;
    [SerializeField] private GameObject household;
    [SerializeField] private GameObject tree;
    

    public enum MenuState
    {
        Pause,
        End,
        Main,
        Settings,
        Tutorial
    }

    public MenuState menuState;

    void Start()
    {
        StartCoroutine(UpdateScore());
        SpawnObjects(household);
        SpawnObjects(tree);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator UpdateScore()
    {
        while (!gamePause)
        {
            yield return new WaitForSeconds(5);
            int cowsHappiness = cowsCount.Value + (int) (cowsCount.Value * 0.2f);
            int currentBalance = householdsCount.Value * 10 + cowsCount.Value * cowsHappiness - cowsCount.Value * 5 - (int) connectionDistance.Value;
            balance.Value = currentBalance;
            cash.Value += currentBalance;
        }
    }

    public void SpawnObjects(GameObject go)
    {
        float yPos = 0;

        if (go.CompareTag("household"))
        {
            yPos = 0.5f;
        }

        if (go.CompareTag("tree"))
        {
            yPos = 1.3f;
        }
        
        Vector3 min = new Vector3(0, 0, -30);
        Vector3 max = new Vector3(130, 0, 30);

        for (int i = 0; i <= 50; i++)
        {
            float randomX = Random.Range(min.x, max.x);
            float randomZ = Random.Range(min.z, max.z);
            Vector3 randomPosition = new Vector3(randomX, yPos, randomZ);
            Instantiate(go, randomPosition, Quaternion.identity);
        }
    }
}