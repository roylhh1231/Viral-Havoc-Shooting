using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed, lifeTime;
    public Rigidbody RB;

    public GameObject ImpactEffect;
    public int damage = 10;
    //public bool damageEnemy, damagePlayer;

    public bool attackPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = transform.forward * moveSpeed; //make the ball move forward

        lifeTime -= Time.deltaTime;//count down the down

        if(lifeTime <= 0)
        {
            Destroy(gameObject);//Destroy the object as soon as it becomes 0 (zero)
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        /*
        if(other.gameObject.tag == "Enemy" && damageEnemy)
        {
            other.gameObject.GetComponent<EnemyHealthController>().damageEnemy(damage); //call this method to damage enemy
        }

        if (other.gameObject.tag == "Player" && damagePlayer)
        {
            PlayerHealthController.instance.DamagePlayer(damage);
            //Debug.Log("You Got hit");
        }

        if (other.gameObject.tag == "HeadShot" && damageEnemy)
        {
            Debug.Log("Hit");
            other.transform.parent.GetComponent<EnemyHealthController>().damageEnemy(damage * 2);
        }
        */

        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if(damageable != null) //if it is connected
        {
            damageable.TakeDamage(damage, attackPlayer);
        }

        float offset = 0.7f;

        Vector3 newPosition = transform.position - transform.forward * offset;//make it move backward a bit based on offset

        Instantiate(ImpactEffect, newPosition, transform.rotation); //spawn the ImpactEffect at his position & rotation
    

        Destroy(gameObject);//destroy when it touches something

        // new
        if (other.tag == "Enemy")
        {
            other.GetComponent<Enemy2>().TakeDamage(damage);
        }

        if (other.tag == "Boss")
        {
            other.GetComponent<BossController>().TakeDamage(damage);
        }

        if (other.tag == "Player")
        {
            Debug.Log("Bullet hit the player");
            PlayerHealthController.instance.TakeDamage(damage, attackPlayer);
        }
    }


}
