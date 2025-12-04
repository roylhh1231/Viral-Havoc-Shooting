using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string NextLevel;

    // public string OptionScene;

    public GameObject Option;
    public string mainMenuScene;
    public string increaseVolumeButtonName = "IncreaseVolume";
    public string decreaseVolumeButtonName = "DecreaseVolume";
    private float volume = 1.0f;
    private const float volumeStep = 0.1f;
    private const float maxVolume = 1.0f;
    private const float minVolume = 0.0f;


    // Reference to the AudioManager
    private AudioManagerBgmSound audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // Ensure Option is only controlled if it's in the main menu scene
        if (SceneManager.GetActiveScene().name == mainMenuScene)
        {
            Option.SetActive(false);
        }

        // Attempt to find the AudioManager instance
        audioManager = AudioManagerBgmSound.instance;
        if (audioManager == null)
        {
            Debug.LogError("AudioManager instance not found. Please ensure AudioManager is properly set up in the scene.");
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

    public void PlayGame()
    {
        if (audioManager != null)
        {
            audioManager.PlaySFX(15); // Play the Select sound effect
        }
        SceneManager.LoadScene(NextLevel);
    }

    public void QuitGame()
    {
        if (audioManager != null)
        {
            audioManager.PlaySFX(15); // Play the Select sound effect
        }
        Application.Quit();
        Debug.Log("Quitting the game");
    }

    public void OpenOptionScene()
    {
        if (audioManager != null)
        {
            audioManager.PlaySFX(15); // Play the Select sound effect
        }
        Option.SetActive(true);
    }

    public void CloseOption ()
    {
        if (audioManager != null)
        {
            audioManager.PlaySFX(15); // Play the Select sound effect
        }
        Option.SetActive(false);
    }

    public void IncreaseVolume()
    {
        volume = Mathf.Clamp(volume + volumeStep, minVolume, maxVolume);
        AudioListener.volume = volume;
    }

    public void DecreaseVolume()
    {
        volume = Mathf.Clamp(volume - volumeStep, minVolume, maxVolume);
        AudioListener.volume = volume;
    }
}
