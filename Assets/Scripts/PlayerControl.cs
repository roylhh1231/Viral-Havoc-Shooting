using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed, mouseSensitivity, gravityModifier, jumpPower, runSpeed;
    private bool canDoubleJump;
    public CharacterController charCon;

    private Vector3 moveInput;
    public Transform camTrans;

    Animator anim;

    public static PlayerControl instance;

    public GameObject muzzleFlash;

    private Vector3 cameraOffset; // To store the initial offset of the camera
    private float verticalRotation = 0f; // To store the camera's vertical rotation
    private float horizontalRotation = 0f; // To store the camera's horizontal rotation

    public void Awake()
    {
        instance = this;
    }

    void Start()
    {
        canDoubleJump = false;
        anim = GetComponent<Animator>();
        cameraOffset = camTrans.position - transform.position; // Initialize the camera offset
    }

    // Update is called once per frame
    void Update()
    {
        float yStore = moveInput.y; // Store the initial moveInput.y 

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical"); // Apply the vertical input based on the z-axis
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal"); // Apply the horizontal input based on the x-axis

        moveInput = vertMove + horiMove; // Combine both inputs
        moveInput.Normalize(); // Normalize the input to handle diagonal movement speed

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveInput = moveInput * runSpeed; // Apply sprint speed
        }
        else
        {
            moveInput = moveInput * moveSpeed; // Apply normal speed
        }

        moveInput = moveInput * moveSpeed; // Apply the movement speed

        // Apply gravity
        moveInput.y = yStore; // Continue the movement based on the initial moveInput.y value
        moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

        if (charCon.isGrounded)
        {
            moveInput.y = -1f; // Normalize the value when touching the ground
            moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                moveInput.y = jumpPower;
                canDoubleJump = true; // Enable double jump
            }
        }
        else
        {
            if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
            {
                moveInput.y = jumpPower;
                canDoubleJump = false; // Disable double jump
            }
        }

        charCon.Move(moveInput * Time.deltaTime); // Move the character

        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")); // Get mouse input

        // Rotate the character based on mouse input (yaw rotation)
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x * mouseSensitivity, transform.rotation.eulerAngles.z);

        // Update the camera's vertical rotation (pitch rotation)
        verticalRotation -= mouseInput.y * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -60f, 60f); // Clamp the vertical rotation

        // Update the camera's horizontal rotation (yaw rotation)
        horizontalRotation += mouseInput.x * mouseSensitivity;

        // Apply the camera rotation
        camTrans.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0f);
        camTrans.position = transform.position + cameraOffset; // Update the camera's position to follow the character

        anim.SetFloat("MoveSpeed", moveInput.magnitude); // Update animation speed
    }
}
