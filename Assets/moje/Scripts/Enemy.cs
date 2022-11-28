using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage = 20f;
    [SerializeField] private float velocity = -1f;
    [SerializeField] private Animator animator;
    [SerializeField] private float walkSpeed =30f;        
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform grundCheckPosition;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private BoxCollider boxCollider;
    private bool dmg=false;
    [SerializeField] private bool mustTurn;
    [SerializeField] private bool mustPatrol;
    [SerializeField] private bool flip = true;
    [SerializeField] private bool move =true;
    [SerializeField] private float health = 50f;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        //animacja zgonu
        Destroy(gameObject);
    }
    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        } 
    }
    private void FixedUpdate()
    {
        if(mustPatrol)
        {
            if (move)
            {
                mustTurn = !Physics.CheckSphere(grundCheckPosition.position, 0.1f, groundLayer);//sprawdzenie powierzchni czy tam ona jest
            }
        }
    }
    void Patrol()
    {
        if (mustTurn)
        {
           Flip();
        }
        rb.velocity = new Vector3(walkSpeed * Time.fixedDeltaTime, rb.velocity.y*velocity);// mechanika chodzenia 
    }
    void Flip()//technika odwrócenia postaci 
    {
        if (flip) 
        {
            mustPatrol = false;
            enemy.transform.Rotate(0, 180, 0);
            walkSpeed *= -1;
            mustPatrol = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            move = false;
            animator.SetTrigger("MeleeAttack");
            PlayerStats target = collision.transform.GetComponent<PlayerStats>();
            if (target != null)
            {
                if (dmg)
                {
                    Debug.Log("W1e hit a  " + collision.gameObject.name);

                    target.TakeDamage(damage);
                    

               }
            }
        }

        else
        {
            Flip();

        }
    }
    void dmgOn()
    {
        dmg = true;
    }
    void dmgOff()
    {
        dmg = false;
    }
    void flipOff()
    {
        flip = false;
    }
    void flipOn()
    {
        flip = true;
    }
    void moveOn()
    {
        move=true ;
    }

}
