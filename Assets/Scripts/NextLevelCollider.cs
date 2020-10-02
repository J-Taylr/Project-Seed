using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelCollider : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //print(collision + " collided");
            gameManager.LoadNextLevel();
        }
    }
}
