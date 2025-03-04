using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Main Stage");
    }
}
