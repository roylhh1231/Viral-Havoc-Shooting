using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int HP = 100;
    public Slider healthBar;
    public Animator animator;
    public float destroyDelay = 5f;

    void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0)
        {
            GetComponent<Collider>().enabled = false;

            //play death animation
            animator.SetTrigger("die");
            //AudioManagerNEW.instance.Play("Monster Death");

            StartCoroutine(DestroyAfterDelay());
        }
        else
        {
            
            //play get hit animation
            animator.SetTrigger("damage");

            //AudioManagerNEW.instance.Play("Monster Death");
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
    }
}
