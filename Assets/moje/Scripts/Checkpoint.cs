using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform respawnPoint;
    private GameMaster gm;


    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }
    public void Spawn()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
      
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            gm.lastCheckPointPos = transform.position;
        }
    }


}
