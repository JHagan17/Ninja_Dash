using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public int ShurikenValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.AddShurikens(ShurikenValue);
            Destroy(gameObject);
        }
    }
}
