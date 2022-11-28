using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    [SerializeField] private Transform character;
    [SerializeField] private float xOffset;
    [SerializeField] private float yOffset;
    [SerializeField] private float zOffset;



    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(character.transform.position.x-xOffset, character.position.y-yOffset, zOffset);
    }
 
}
