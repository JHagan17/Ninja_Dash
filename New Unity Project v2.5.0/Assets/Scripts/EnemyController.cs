using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public Transform player;
    Transform target;
    NavMeshAgent agent;
    public float stoppingDistance;

    public int health = 20;

    public static int enemyDamage = 30;

    public static int bulletDamage = Bullet.damage;
    
    //Patrolling
    //public Vector3 walkPoint;
    //bool walkPointSet;
    //public float walkPointRange;

    //public GameObject rightFist;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectWithTag("Player");
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        stoppingDistance = agent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            float distance = Vector3.Distance(transform.position, target.position);

            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);

                if (distance <= stoppingDistance)
                {
                    FaceTarget();
                }

            }
        }
    }

    

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected ()
    {
        //lookRadius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);        
        
        //stoppingDistance
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stoppingDistance);
    }

    public void TakeDamage(int bulletDamage)
    {
        health -= bulletDamage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        
    }

    public void OnTriggerEnter(Collider other)
    { 
        if (other.gameObject.tag == "Shuriken")
        {
            TakeDamage(bulletDamage);
        }
    }

    //public void Attack()
    //{   
    //    PlayerManager.playerHitpoints -= enemyDamage; 
    //}    

    //IEnumerator BufferedAttack()
    //{
        

    //    Attack();

    //    yield return new WaitForSecondsRealtime(5);
    //}    
    
    //IEnumerator BufferedAttack()
    //{
    //    int playerHitpoints = PlayerManager.playerHitpoints;
    //    hitsNeeded = playerHitpoints / enemyDamage;

    //    for(hits = 0; hits < hitsNeeded; hits++)
    //    {
    //        yield return new WaitForSecondsRealtime(3);
            
    //        hits++;
    //    }
    //}

}
