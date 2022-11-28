using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player;



    public float health = 50f;
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
        
   
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //mechanika respawnu


    }


    public Image[] lives;
    public int livesRemaining;
    public void LoseLife()
    {
        livesRemaining--;
        lives[livesRemaining].enabled = false;
        if(livesRemaining==0)
        {
            Debug.Log("You Lost");
        }
    }
    




}
