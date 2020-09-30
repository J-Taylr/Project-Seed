using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyController : MonoBehaviour
{
    public PlayerController playerController;
    public AIDestinationSetter aiSetter;
    public PlanterController planterController;
    public Rigidbody2D rb;
    public AIPath aiPath;

    [Header("General")]
    public bool isWalker;
    private bool isAttacking;
    public int enemyHealth = 1;

    [Header("Attack")]
    public float attackRadius = 5;
    public float attackSpeed = 1;

    [Header("Knockback")]
    public float knockbackStrength = 50;
    public float knockbackTime = 0.3f;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        aiPath = GetComponent<AIPath>();
    }

    private void Update()
    {
        if (!isAttacking)
        {
            CheckTargetDistance();
        }
    }

    public void CheckTargetDistance()
    {
        if (isWalker)
        {

            float attackDistance = Vector2.Distance(transform.position, aiSetter.target.position);

            if (attackDistance < attackRadius)
            {
                isAttacking = true;
                StartCoroutine(WalkerAttack());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Weapon"))
        {
            DamageEnemy();


            StartCoroutine(AIPathDelay());
            Vector2 knockbackDirection = gameObject.transform.position - playerController.transform.position;
            rb.AddForce(knockbackDirection.normalized * knockbackStrength, ForceMode2D.Impulse); // knockback for enemy
   
        }

    }

    IEnumerator AIPathDelay()
    {
        aiPath.enabled = false;
        yield return new WaitForSeconds(knockbackTime);
        aiPath.enabled = true;
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
            Destroy(this.gameObject, 0.3f);
        }
    }
    
    

   


    IEnumerator WalkerAttack()
    {
            print("attacking planter");
        while (true)
        {
            planterController.TakeDamage();
            yield return new WaitForSeconds(attackSpeed);
        }
    }

}
