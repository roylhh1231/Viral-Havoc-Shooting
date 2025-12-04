using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buformorph : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public float destroyDelay = 50f;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            GetComponent<Collider>().enabled = false;
            AudioManagerNEW.instance.Play("Monster Death");

            //play death animation
            animator.SetTrigger("die");

            StartCoroutine(DestroyAfterDelay());
        }
        else
        {
            AudioManagerNEW.instance.Play("Monster Death");

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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
