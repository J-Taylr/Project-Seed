using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;

    public bool levelComplete = false;



    public void WinLevel()
    {
        levelComplete = true;
    }

    public void LoadNextLevel()
    {
        if (levelComplete)
        {
            print("next level! ");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0; //loops back to first scene
            }
            SceneManager.LoadScene(nextSceneIndex);
        } 
    }

    public void Respawn()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex - 1;
       
        SceneManager.LoadScene(nextSceneIndex);
    }
    
}
