using UnityEngine;

//This  for all items that the player can interact with such as enemies,
//items etc. It is meant to be used as a base class. 


public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interactionTransform;

    

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireSphere(transform.position, radius);
        
    }
}
