using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour, IInteractable
{
    private Camera _mainCam;
    [SerializeField] public GameObject UIPanel;
    [SerializeField] public TextMeshProUGUI _prompText;

    private void Start()
    {
        _mainCam = Camera.main;
        UIPanel.SetActive(false);
    }

    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(worldPosition: transform.position + rotation * Vector3.forward, worldUp: rotation * Vector3.up);
    }

    public bool IsDisplayed = false;

    public string InterationPrompt => throw new System.NotImplementedException();

    public void Setup(string prompText)
    {
        _prompText.text = prompText;
        UIPanel.SetActive(true);
        IsDisplayed = true;
    }

    public void Close()
    {
        UIPanel.SetActive(false);
        IsDisplayed = false;
    }

    public bool Interact(Interactor interactor)
    {
        throw new System.NotImplementedException();
    }
}