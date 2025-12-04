using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionScene2 : MonoBehaviour
{
    public string mainMenuScene;
    public Slider bgmSlider;
    public Slider sfxSlider;
    private AudioManagerBgmSound audioManager;

    void Start()
    {
        audioManager = AudioManagerBgmSound.instance;

        if (bgmSlider != null)
        {
            bgmSlider.onValueChanged.AddListener(audioManager.SetBGMVolume);
            bgmSlider.value = audioManager.GetBGMVolume();
        }
        else
        {
            Debug.LogError("BGMSlider not assigned.");
        }

        if (sfxSlider != null)
        {
            sfxSlider.onValueChanged.AddListener(audioManager.SetSFXVolume);
            sfxSlider.value = audioManager.GetSFXVolume();
        }
        else
        {
            Debug.LogError("SFXSlider not assigned.");
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

   /* public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }*/
}