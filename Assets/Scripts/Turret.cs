using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;

    public float rangeToTargetPlayer, timeBetweenShots = .5f;
    private float shotCounter;
    public float rotateSpeed = 45f;

    public Transform gun, firePoint1, firePoint2, firePoint3;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter = timeBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, PlayerController.instance.transform.position) < rangeToTargetPlayer)
        {
            //gun.LookAt(PlayerController.instance.transform.position + new Vector3(0f, 0.3f, 0f));
            gun.LookAt(PlayerController.instance.transform.position + new Vector3(0f, 0.3f, 0f));
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                Instantiate(bullet, firePoint1.position, firePoint1.rotation);
                Instantiate(bullet, firePoint2.position, firePoint2.rotation);
                Instantiate(bullet, firePoint3.position, firePoint3.rotation);
                shotCounter = timeBetweenShots;
            }
        }
        else
        {
            shotCounter = timeBetweenShots;

            //gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.Euler(0f, gun.rotation.eulerAngles.y + 10f, 0f), rotateSpeed * Time.deltaTime);
            gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.Euler(0f, gun.rotation.eulerAngles.y + 10f, 0f), rotateSpeed * Time.deltaTime);
        }
    }


}