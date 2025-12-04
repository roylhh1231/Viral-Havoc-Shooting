using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    public string mainMenuScene;


    // Reference to the AudioManager
   // private AudioManagerBgmSound audioManager;
    public int SelectSFXIndex = 15; // Index of the select sound effect in the AudioManager


    // Start is called before the first frame update
    void Start()
    {
        // Attempt to find the AudioManager instance
        if (AudioManagerBgmSound.instance != null)
        {
            AudioManagerBgmSound.instance.PlaySFX(SelectSFXIndex);
        }
        else
        {
            Debug.Log("AudioManager instance found.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Resume()
    {
        // Play select sound
        if (AudioManagerBgmSound.instance != null)
        {
            AudioManagerBgmSound.instance.PlaySFX(SelectSFXIndex);
        }
        GameManager.instance.PauseUnpause();
    }

    public void Mainmenu()
    {
        // Play select sound
        if (AudioManagerBgmSound.instance != null)
        {
            AudioManagerBgmSound.instance.PlaySFX(SelectSFXIndex);
        }
        SceneManager.LoadScene(mainMenuScene);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        // Play select sound
        if (AudioManagerBgmSound.instance != null)
        {
            AudioManagerBgmSound.instance.PlaySFX(SelectSFXIndex);
        }
        Application.Quit();
    }
}