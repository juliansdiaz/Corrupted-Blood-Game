using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesManager : MonoBehaviour
{
   public int lives = 3;

    void Update()
    {
        OutofLives();
    }

    public void OutofLives()
    {
        if(lives == 0)
        {
            Debug.Log("No more lives, player dead");
            Destroy(gameObject);
        }
    }
}
