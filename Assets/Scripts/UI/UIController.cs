using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loseUI;

    public void DisplayGameOverUI()
    {
        loseUI.SetActive(true);
        winUI.SetActive(false);
    }

    public void DisplayWinUI()
    {
        winUI.SetActive(true);
        loseUI.SetActive(false);
    }
}
