using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy2 : MonoBehaviour
{
    public int HP = 100;
    public Slider healthBar;
    public Animator animator;
    public float destroyDelay = 5f;
    public GameObject Key;


    void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            GetComponent<Collider>().enabled = false;
            //AudioManager.instance.Play("Monster Death");

            //play death animation
            animator.SetTrigger("die");

            StartCoroutine(DestroyAfterDelay());
        }
        else
        {
            //AudioManager.instance.Play("Monster Death");

            //play get hit animation
            animator.SetTrigger("damage");
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
        // Instantiate the Key at an upward offset from this GameObject's position
        Vector3 spawnPosition = transform.position + new Vector3(0, 1.5f, 0); // Adjust the 1.5f to control how high above the enemy the key appears
        Instantiate(Key, spawnPosition, Quaternion.identity);

        
    }
}
