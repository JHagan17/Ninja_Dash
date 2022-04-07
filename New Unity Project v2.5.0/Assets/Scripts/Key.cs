using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int keyValue = 1;
    public static int keyCount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            keyCount += 1;
            Destroy(gameObject);
            print("Player has key!");
        }
    }
}
