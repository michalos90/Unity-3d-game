using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider swordColider;
    [SerializeField] private float damage=50f;
    [SerializeField] private bool dmg =false;
    [SerializeField] private GameObject sword;
    [SerializeField] private float attackRate = 0.6f;

    private float nextTimeToAttack = 0f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K) && Time.time >= nextTimeToAttack)
        {
            nextTimeToAttack = Time.time + 1f / attackRate;
            dmg = true;
            animator.SetTrigger("MeleeAttack");
        }
    }
    void ColiderOn()
    {
        swordColider.gameObject.SetActive(true);
    }
    void ColiderOff()
    {
        dmg = false;
        swordColider.gameObject.SetActive(false);
    }
    void SwordOn()
    {
        sword.SetActive(true);
    }
    void SwordOff()
    {
        sword.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Enemy")
        {
            Enemy target = collision.transform.GetComponent<Enemy>();
            if (target != null)
            {
                if (dmg)
                {
                    Debug.Log("We hit a  " + collision.gameObject.name);

                    target.TakeDamage(damage);
                    ColiderOff();
                }
                
            }
          
        }      
        if(collision.gameObject.tag=="Chest")
        {
            CrashCrate crashCrate = collision.transform.GetComponent<CrashCrate>();
            if(crashCrate!=null)
            {
                crashCrate.DestroyChest();
            }

        }
        
    }
}


