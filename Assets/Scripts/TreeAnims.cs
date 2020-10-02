using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAnims : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

   public void PlantSeed()
    {
        animator.SetTrigger("PlantSeed");
    }
}
