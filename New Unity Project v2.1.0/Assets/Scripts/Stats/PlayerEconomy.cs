using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        // ++++++++ Testing Only ++++++++++
        if (Input.GetKeyUp(KeyCode.T))
        {
            TakeDamage(10);
        }
        // +++++++++ Testing Only +++++++++++
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.getValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {

    }
}
