using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed, mouseSensitivity, gravityModifier, jumpPower, runSpeed = 12;
    private bool canDoubleJump;
    public CharacterController charCon;

    private Vector3 moveInput;
    private float lastGroundedHeight; // Add this line
    private bool isFalling; // Add this line

    public Transform camTrans;

    Animator anim;

    public Transform firePoint;
    public static PlayerController instance;

    public GameObject muzzleFlash;

    public Gun activeGun;

    public List<Gun> allGuns = new List<Gun>();
    public int currentGun;

    public AudioSource footFast, footSlow;

    private float bounceAmount;
    private bool bounce;

    public float maxViewAngle = 60f;
    // Define indices for gun audio clips
    public int pistolAudioIndex = 9;
    public int repeaterAudioIndex = 10;
    public int snipperAudioIndex = 11;
    public int GrappingAudioIndex = 12;
    public int SwitchSFX = 4; // Index of the checkpoint sound effect in the AudioManager


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);

        canDoubleJump = false;
        anim = GetComponent<Animator>();
        UIController.instance.AmmoText.text = "" + activeGun.currentAmmo;
    }

    void Update()
    {
        if (!UIController.instance.pauseScreen.activeInHierarchy && !GameManager.instance.ending)
        {
            float yStore = moveInput.y;

            Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
            Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");

            moveInput = vertMove + horiMove;
            moveInput.Normalize();

            if (Input.GetKey(KeyCode.LeftShift))
            {
                moveInput = moveInput * runSpeed;
            }
            else
            {
                moveInput = moveInput * moveSpeed;
            }

            moveInput.y = yStore;

            moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

            if (charCon.isGrounded)
            {
                if (isFalling)
                {
                    isFalling = false;
                    float fallDistance = lastGroundedHeight - transform.position.y;
                    if (fallDistance >= 15f)
                    {
                        PlayerHealthController.instance.TakeDamage(10, false);
                    }
                }

                canDoubleJump = true;
                anim = GetComponent<Animator>();
                if (anim == null)
                {
                    Debug.LogError("Animator component not found");
                }

                moveInput.y = -1f;
                moveInput.y += Physics.gravity.y * gravityModifier * Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    moveInput.y = jumpPower;
                    canDoubleJump = true;
                }
            }
            else
            {
                if (!isFalling)
                {
                    lastGroundedHeight = transform.position.y;
                    isFalling = true;
                }

                if (canDoubleJump && Input.GetKeyDown(KeyCode.Space))
                {
                    moveInput.y = jumpPower;
                    canDoubleJump = false;
                }
            }

            if (bounce)
            {
                bounce = false;
                moveInput.y = bounceAmount;
                canDoubleJump = true;
            }

            charCon.Move(moveInput * Time.deltaTime);

            Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

            camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));

            if (camTrans.rotation.eulerAngles.x > maxViewAngle && camTrans.rotation.eulerAngles.x < 180f)
            {
                camTrans.rotation = Quaternion.Euler(maxViewAngle, camTrans.rotation.eulerAngles.y, camTrans.rotation.eulerAngles.z);
            }
            else if (camTrans.rotation.eulerAngles.x > 180f && camTrans.rotation.eulerAngles.x < 360f - maxViewAngle)
            {
                camTrans.rotation = Quaternion.Euler(-maxViewAngle, camTrans.rotation.eulerAngles.y, camTrans.rotation.eulerAngles.z);
            }

            if (anim != null)
            {
                anim.SetFloat("moveSpeed", moveInput.magnitude);
            }

            if (Input.GetMouseButtonDown(0) && activeGun.fireCounter <= 0)
            {
                RaycastHit hit;
                if (Physics.Raycast(camTrans.position, camTrans.forward, out hit, 500f))
                {
                    firePoint.LookAt(hit.point);
                }
                else
                {
                    firePoint.LookAt(camTrans.position + (camTrans.forward * 30f));
                }

                FireShot();
            }

            if (Input.GetMouseButton(0) && activeGun.canAutoFire)
            {
                if (activeGun.fireCounter <= 0)
                {
                    FireShot();
                }
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (AudioManagerBgmSound.instance != null)
                {
                    AudioManagerBgmSound.instance.PlaySFX(SwitchSFX);
                }
                SwitchGun();
            }
        }
    }

    public void Bounce(float bounceForce)
    {
        bounceAmount = bounceForce;
        bounce = true;
    }

    public void FireShot()
    {
        if (activeGun.currentAmmo > 0)
        {
            activeGun.currentAmmo--;

            Instantiate(activeGun.bullet, firePoint.position, firePoint.rotation);

            activeGun.fireCounter = activeGun.fireRate;

            if (UIController.instance != null)
            {
                UIController.instance.AmmoText.text = "" + activeGun.currentAmmo;
            }

            muzzleFlash.SetActive(true);
            Invoke("SetMuzzleFalse", 0.1f);

            // Play gun-specific audio
            if (AudioManagerBgmSound.instance != null)
            {
                if (activeGun.name.Contains("Snipper"))
                {
                    AudioManagerBgmSound.instance.PlaySFX(snipperAudioIndex);
                }
                else if (activeGun.name.Contains("Pistol"))
                {
                    AudioManagerBgmSound.instance.PlaySFX(pistolAudioIndex);
                }
                else if (activeGun.name.Contains("Repeater"))
                {
                    AudioManagerBgmSound.instance.PlaySFX(repeaterAudioIndex);
                }
                // Add more conditions for other gun types if needed
            }
        }
    }

    public void SwitchGun()
    {
        activeGun.gameObject.SetActive(false);

        currentGun++;

        if (currentGun >= allGuns.Count)
        {
            currentGun = 0;
        }

        activeGun = allGuns[currentGun];
        activeGun.gameObject.SetActive(true);

        UIController.instance.AmmoText.text = "" + activeGun.currentAmmo;
    }

    public void SetMuzzleFalse()
    {
        muzzleFlash.SetActive(false);
    }

    public void AddGun(Gun newGun)
    {
        if (!allGuns.Contains(newGun))
        {
            allGuns.Add(newGun);
            Debug.Log("New gun added: " + newGun.name);
            if (activeGun == null)
            {
                activeGun = newGun;
                newGun.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Gun already in inventory: " + newGun.name);
        }
    }

    public void RemoveGun(GameObject gunToRemove)
    {
        Gun gun = gunToRemove.GetComponent<Gun>();
        if (gun != null && allGuns.Contains(gun))
        {
            allGuns.Remove(gun);
            Destroy(gunToRemove);

            if (currentGun >= allGuns.Count)
            {
                currentGun = 0;
            }
            if (allGuns.Count > 0)
            {
                activeGun = allGuns[currentGun];
                activeGun.gameObject.SetActive(true);
            }
            else
            {
                activeGun = null;
            }

            if (UIController.instance != null && activeGun != null)
            {
                UIController.instance.AmmoText.text = "" + activeGun.currentAmmo;
            }
        }
    }
}
