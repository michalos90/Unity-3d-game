using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    // Start is called before the first frame update
    private static GameMaster instance;
    public Vector3 lastCheckPointPos;
    
    void Awake()
    {
    if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    else
        {
            Destroy(gameObject);                
        }
    }
 
   



    }






