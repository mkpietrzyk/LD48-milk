using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private IntVariable balance;
    [SerializeField] private IntVariable cash;
    [SerializeField] private IntVariable cowsCount;
    [SerializeField] private FloatVariable connectionDistance;
    [SerializeField] private IntVariable householdsCount;
    [SerializeField] private GameObject household;
    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject houseContainer;
    [SerializeField] private GameObject treeContainer;
    
    
    public BoolVariable gameStarted;
    public BoolVariable gamePaused;
    public BoolVariable gameEnded;
    public StringVariable uiState;
    public SetStringVariableValue setUIVisibility;

    void Start()
    {
        uiState.Value = uiState.InitialValue;
        cowsCount.Value = 2;
        cash.Value = 100;
        balance.Value = 0;
        householdsCount.Value = 0;
        connectionDistance.Value = 0;
        StartCoroutine(UpdateScore());
        SpawnObjects(household, 50);
        SpawnObjects(tree, 150);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamePaused.Value && gameStarted.Value && Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

        if (gamePaused.Value && Input.GetKeyDown(KeyCode.Escape))
        {
            ResumeGame();
        }
    }

    private IEnumerator UpdateScore()
    {
        while (gameStarted.Value)
        {
            yield return new WaitForSeconds(5);
            int cowsHappiness = (int) (cowsCount.Value * 0.2f);
            int cowsUnhapiness = (int) (householdsCount.Value / cowsCount.Value) * 10;
            int currentBalance = householdsCount.Value * 20 + cowsCount.Value * cowsHappiness - cowsCount.Value * 5 - (int) connectionDistance.Value - cowsUnhapiness;
            balance.Value = currentBalance;
            cash.Value += currentBalance;
        }
    }

    public void SpawnObjects(GameObject go, int amount)
    {
        float yPos = 0;
        GameObject parent = null;

        if (go.CompareTag("household"))
        {
            yPos = 0.5f;
            parent = houseContainer;
        }

        if (go.CompareTag("tree"))
        {
            yPos = 1.3f;
            parent = treeContainer;
        }
        
        Vector3 min = new Vector3(0, 0, -30);
        Vector3 max = new Vector3(130, 0, 30);

        for (int i = 0; i <= amount; i++)
        {
            float randomX = Random.Range(min.x, max.x);
            float randomZ = Random.Range(min.z, max.z);
            Vector3 randomPosition = new Vector3(randomX, yPos, randomZ);
            Instantiate(go, randomPosition, Quaternion.identity, parent.transform);
        }
    }
    
    public void StartGame()
    {
        gameStarted.Value = true;
        uiState.Value = "PlayerUI";
    }

    public void PauseGame()
    {
        gamePaused.Value = true;
        Time.timeScale = 0;
        uiState.Value = "PauseMenu";
    }

    public void ResumeGame()
    {
        gamePaused.Value = false;
        Time.timeScale = 1;
        uiState.Value = "PlayerUI";
    }

    public void ReturnToMenu()
    {
        gameStarted.Value = false;
        uiState.Value = "MainMenu";
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}