using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointInitialize : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] checkpoints; // Array of all checkpoints in the sequence

    void Start()
    {
        // Hide all checkpoints initially except the first one
        for (int i = 1; i < checkpoints.Length; i++)
        {
            checkpoints[i].SetActive(false);
        }
    }
}