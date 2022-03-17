using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && Key.keyCount == 1)
        {
            Key.keyCount--; 
            Destroy(gameObject);
        }
    }
}
