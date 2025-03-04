using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(NextScene);
    }

    public void NextScene()
    {
        Debug.Log("Cambio de escena");
        // GameManager.Instance.ChangeScene("nombre de la escena");
    }
}
