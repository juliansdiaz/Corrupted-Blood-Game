using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LivesManager : MonoBehaviour
{
   public int lives = 3;
   public TextMeshProUGUI livesText;

    void Update()
    {
        OutofLives();
    }

    public void OutofLives()
    {
        if(lives == 0)
        {
            
            gameObject.SetActive(false);
            GameManager.Instance.GameOverLose();
        }
    }
}
