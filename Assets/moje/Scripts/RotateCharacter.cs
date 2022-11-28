using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCharacter : MonoBehaviour
{
        [SerializeField] private GameObject character;
    private Quaternion temp;

    void setPlayerRotationY(int y)
    {
        temp = character.transform.rotation;
        character.transform.rotation = Quaternion.Euler(0, y, 0);
    }
    void setPlayerRotation()
    {
        character.transform.rotation = temp;
    }

  
}
