using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] private GameObject menuPausa;
    private bool juegoPausado=false;

    void Start()
    {
        menuPausa.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(juegoPausado)
            {
                Reanudar();
            }else
            {
                Pausa();
            }
        }
    }

    public void Pausa()
    {
        juegoPausado=true;
        Time.timeScale=0f;
        menuPausa.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado=false;
        Time.timeScale=1f;
        menuPausa.SetActive(false);
    }

    public void Reiniciar()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("Main Stage");
    }

    public void MainMenu()
    {
        Debug.Log("Main Menu");
        AudioManager.Instance.PlayMusic("Menu Theme");
        SceneManager.LoadScene("MainMenu");
    }
}
