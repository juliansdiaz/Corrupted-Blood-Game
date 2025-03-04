using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    public bool isMute;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }

        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        myMixer.SetFloat("Music Volume", MathF.Log10(volume) * 20);

        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX Volume", MathF.Log10(volume) * 20);

        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }

    public void MuteAll()
    {
        isMute = !isMute; // Alterna entre silencio y sonido
        if (isMute)
        {
            myMixer.SetFloat("Master Volume", -80f); // Silencia todo el audio
            Debug.Log("No hay sonido");
        }
        else
        {
            myMixer.SetFloat("Master Volume", 0f); // Restaura el volumen
            Debug.Log("Sí hay sonido");
        }
    }
}
