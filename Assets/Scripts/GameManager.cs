using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {get; private set;}
    UIController uIController;

    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        uIController = FindAnyObjectByType<UIController>();
    }

    public void GameOverWin()
    {
        Time.timeScale = 0;
        uIController.DisplayWinUI();
    }

    public void GameOverLose()
    {
        Time.timeScale = 0;
        uIController.DisplayGameOverUI();
    }
}
