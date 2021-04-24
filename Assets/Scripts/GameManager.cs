using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> cows;
    public List<GameObject> connections;
    public List<GameObject> households;

    public int cowsCount;

    public int cash;

    public bool gameStart;
    public bool gamePause;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
