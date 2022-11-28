using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float damage = 10f;
    [SerializeField] private GameObject impactEffect;
    [SerializeField] private float range  = 5f;
    [SerializeField] private Animator animator;
    [SerializeField] private float fireRate  = 0.6f;
    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject gun;

    //  [SerializeField] private ParticleSystem muzzleFlash;
    private float nextTimeToFire = 0f;
    void Update()
    {
    if(Input.GetKeyDown(KeyCode.L) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time +1f / fireRate;
            animator.SetTrigger("Shoot");
           
        }
    }
  void Shoot()
    {
     
        RaycastHit hit;
        
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy target =hit.transform.GetComponent<Enemy>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }       
            GameObject impactGO =Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
    void GunOn()
    {
        gun.SetActive(true);
    }
    void GunOff()
    {
        gun.SetActive(false);

    }
}

  
