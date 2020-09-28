using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerController playerController;


    [Header("General")]
    public int enemyHealth = 1;

 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DamagePlayer();
        }
        if (collision.CompareTag("Weapon"))
        {
            DamageEnemy();
        }

    }

    public void DamageEnemy()
    {
        if (enemyHealth > 0)
        {
            enemyHealth--;
            print("enemy takes damage");
        }
        else if (enemyHealth <= 0)
        {
            print(gameObject.name + " is dead");
            //kill enemy
        }
    }

    public void DamagePlayer()
    {
        playerController.PlayerTakeDamage();
    }
}
