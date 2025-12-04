using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public string NextScene;
    public float timeBetweenShowing = 1f;
    public GameObject ExitButton;//textContent,
    public Image blackImage;
    public float fade = 2f;

    void Start()
    {
        // Debug checks to ensure variables are assigned
        /*if (textContent == null)
        {
            Debug.LogError("textContent is not assigned in the Inspector.");
        }*/
        if (ExitButton == null)
        {
            Debug.LogError("returnButton is not assigned in the Inspector.");
        }
        if (blackImage == null)
        {
            Debug.LogError("blackImage is not assigned in the Inspector.");
        }

        StartCoroutine(ShowObjects());
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (blackImage != null)
        {
            blackImage.color = new Color(blackImage.color.r, blackImage.color.g, blackImage.color.b, Mathf.MoveTowards(blackImage.color.a, 0f, fade * Time.deltaTime));
        }
    }

    public void MainMenu()
    {
        Debug.Log("Transitioning to Main Menu scene.");
        SceneManager.LoadScene(NextScene);
    }

    public IEnumerator ShowObjects()
    {
        // yield return new WaitForSeconds(timeBetweenShowing);
        /* if (textContent != null)
         {
             textContent.SetActive(true);
         }*/
        yield return new WaitForSeconds(timeBetweenShowing);
        if (ExitButton != null)
        {
            ExitButton.SetActive(true);
        }
    }
}