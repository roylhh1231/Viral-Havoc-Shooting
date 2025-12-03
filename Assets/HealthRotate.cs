using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRotate : MonoBehaviour
{
    // Rotation speed
    public float rotationSpeed = 50f;
    // Floating speed and height
    public float floatSpeed = 2f;
    public float floatHeight = 0.5f;
    // Initial position
    private Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Save the initial position
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its Y axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        // Float the object up and down
        float newY = initialPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
