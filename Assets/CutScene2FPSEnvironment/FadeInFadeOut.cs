using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInFadeOut : MonoBehaviour
{
    public static FadeInFadeOut instance;

    public Image fadeImage; // The image you want to fade in and out
    public float fadeSpeed = 2.0f;
    public float fadeOutDelay = 5.0f; // Time to wait before fading out

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // Ensure the image starts transparent
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 0f);
    }

    public void StartFadeInAndOut()
    {
        StartCoroutine(FadeInAndOut());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeInAndOut()
    {
        // Fade in
        while (fadeImage.color.a < 1f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 1f, fadeSpeed * Time.deltaTime));
            yield return null;
        }

        // Wait for the specified delay
        yield return new WaitForSeconds(fadeOutDelay);

        // Fade out
        while (fadeImage.color.a > 0f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 0f, fadeSpeed * Time.deltaTime));
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        // Fade out immediately without delay
        while (fadeImage.color.a > 0f)
        {
            fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, Mathf.MoveTowards(fadeImage.color.a, 0f, fadeSpeed * Time.deltaTime));
            yield return null;
        }
    }
}
