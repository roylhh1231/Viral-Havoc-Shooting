using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro; // Add this using directive

public class HUDManager : MonoBehaviour
{

    public static HUDManager instance;
    public TMP_Text scoreText; // Change Text to TextMeshProUGUI

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keeps the HUDManager between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        RefreshHUD();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RefreshHUD()
    {
        if (GameManager.instance != null && scoreText != null)
        {
            
            scoreText.text = GameManager.instance.counter + "/5";
        }
    }

}