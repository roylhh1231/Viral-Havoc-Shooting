using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 1.0f;

    private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //calcualte the vertical movement using sine function
        float yOffset = Mathf.Sin(Time.time * speed) * distance;

        //update the object's position
        transform.position = startPosition + new Vector3(0, yOffset, 0);
    }
}
