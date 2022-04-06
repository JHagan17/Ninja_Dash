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

    public int health = 100;

    public static int enemyDamage = 30;
    private int hitsNeeded;

    //Patrolling
    //public Vector3 walkPoint;
    //bool walkPointSet;
    //public float walkPointRange;

    public GameObject rightFist;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject.FindGameObjectWithTag("Player");
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                CalculateDamage();
                FaceTarget(); 
            }
        }
    }

    public void ActivateFist()
    {
        rightFist.GetComponent<Collider>().enabled = true;
    }
    
    public void DeactivateFist()
    {
        rightFist.GetComponent<Collider>().enabled = false;
    }

    

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    //private void Awake ()
    //{
    //    player = GameObject.Find("Player").transform;
    //    agent = GetComponent<NavMeshAgent>();
    //}

    public void TakeDamage(int damage)
    {
        damage = 20;

        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    public void TakePlayerHitpoints()
    {
        PlayerManager.playerHitpoints -= enemyDamage;
    }

    public void CalculateDamage()
    {
        float timer = 0.0f;
        float waitTime = 3.0f;
        float displayTime;

        timer += Time.deltaTime;
        displayTime = timer * 100;

        if (timer > waitTime)
        {
            TakePlayerHitpoints();
            timer = timer - waitTime;
        }

        hitsNeeded = PlayerManager.playerHitpoints / enemyDamage;

        //for (int i = 0; i < hitsNeeded; i++)
        //{
            
            
        //    //print("Player has been hit!");
        //}

        Debug.Log(timer);
    }


}
