using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController2D controller; //to find grounding etc
    public GameObject sword;
    [SerializeField] Animator animator;

    [Header("General")]
    public int playerHealth = 3;


    [Header("Movement")]                                            
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    float attackSpeed = 0.5f;
    bool jump = false;
    bool crouch = false;
    bool move = false;
    // Update is called once per frame
    void Update()
    {
        Attack();
        UpdateAnims();



        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.D)))
        {
            move = true;
        }
        else { move = false; }
      
    }


    public void PlayerTakeDamage()
    {
        if (playerHealth > 0) 
        { 
            playerHealth--;
        }
        else if (playerHealth <= 0)
        {
            print("player is dead");
            //kill player
        }
        
       
    }

    private void UpdateAnims()
    {
        if (move)
        {
            animator.SetBool("isWalking", true);
        } 
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(Swingsword());
        }
    }


    IEnumerator Swingsword()
    {
        sword.SetActive(true);
        yield return new WaitForSeconds(attackSpeed);
        sword.SetActive(false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}