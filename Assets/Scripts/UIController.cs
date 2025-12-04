using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public Slider healthSlider;
    public TMP_Text AmmoText;
    public Image healthFillImage;
    public Gradient healthGradient;

    public GameObject pauseScreen;


    public Image blackScreen;
    public float fadeSpeed = 1.5f;

    public Image fadeImage;
    public float fadeOutDelay = 5.0f;
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHealthUI(PlayerHealthController.instance.currentHealth);
        // Ensure the image starts transparent
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
        Debug.Log("UIController Start: Starting FadeInAndOut coroutine");
        // For testing purposes, start the fade-in and fade-out coroutine
        StartCoroutine(FadeInAndOut());

    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.ending)
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
        }
        else
        {
            blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
        }
    }
    public void UpdateHealthUI(int currentHealth)
    {
        healthSlider.value = currentHealth;
        healthFillImage.color = healthGradient.Evaluate((float)currentHealth / healthSlider.maxValue);
        //healthText.text = "Health: " + currentHealth + "/" + healthSlider.maxValue;
    }

    public IEnumerator FadeInAndOut()
    {
        Debug.Log("FadeInAndOut coroutine started");

        // Fade in
        while (fadeImage.color.a < 1f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 1f, fadeSpeed * Time.deltaTime));
            Debug.Log("Fading in: " + fadeImage.color.a);
            yield return null;
        }

        // Wait for the specified delay
        yield return new WaitForSeconds(fadeOutDelay);

        // Fade out
        while (fadeImage.color.a > 0f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 0f, fadeSpeed * Time.deltaTime));
            Debug.Log("Fading out: " + fadeImage.color.a);
            yield return null;
        }

        Debug.Log("FadeInAndOut coroutine completed");
    }

}