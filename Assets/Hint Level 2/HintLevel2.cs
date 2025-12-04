using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class HintLevel2 : MonoBehaviour
{
    public static HintLevel2 instance;

    public GameObject note1;
    public GameObject note2;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        note1.SetActive(false);
        note2.SetActive(false);
    }

    public void OpenNote1()
    {
        note1.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseNote1()
    {
        note1.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenNote2()
    {
        note2.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseNote2()
    {
        note2.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

}

