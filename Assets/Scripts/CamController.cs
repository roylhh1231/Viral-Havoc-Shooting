using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()//will be call after all normal update called
    {
        transform.position = target.position;
        transform.rotation = target.rotation;

    }
}


