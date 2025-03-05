using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemsManager : MonoBehaviour
{
    public TextMeshProUGUI itemsText;
    public int itemCount = 5;
    public void AllItemsCollected()
    {
        if(itemCount == 0)
        {
            GameManager.Instance.GameOverWin();
        }
    }
}
