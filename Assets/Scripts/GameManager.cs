using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cows;
    public List<GameObject> connections;
    public List<GameObject> households;

    public bool gameStart;
    public bool gamePause;

    [SerializeField] private IntVariable score;
    [SerializeField] private IntVariable cash;
    [SerializeField] private IntVariable cowsCount;
    [SerializeField] private IntVariable householdsCount;
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
            int cashAdjustment = householdsCount.Value * 10 - cowsCount.Value * 5;
            cash.Value += cashAdjustment;
            score.Value = cashAdjustment * 1000;
        }
    } 
}
