using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static int shurikens;
    static shurikenUI ShurikenUI;

    public static int playerHitpoints = 90;
    
    
    #region Singleton
    
    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
        
        //ShurikenUI = FindObjectOfType<shurikenUI>();
        shurikens = 0;
        //ShurikenUI.UpdateShurikens();

    }
    #endregion

    public GameObject player;

    public Inventory inventory;



    void Update()
    {
        CalculateDamage();
        Debug.Log(playerHitpoints);
    }

    public static void AddShurikens(int shurikenValue)
    {
        shurikens += shurikenValue;

        ShurikenUI.UpdateShurikens();
    }

    private void OnTriggerEnter(Collider collider)
    {
        var item = collider.GetComponent<ItemsManager>();

        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "EnemyAttack")
        {
            StartCoroutine(BufferedDamage());
            playerHitpoints -= EnemyController.enemyDamage;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void CalculateDamage()
    {
        if (playerHitpoints <= 0)
        {
            Die();
        }
    }

    IEnumerator BufferedDamage()
    {
        yield return new WaitForSecondsRealtime(3);
    }

    //private void OnApplicationQuit()
    //{
    //    inventory.Container.Clear();
    //}
}
