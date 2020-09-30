using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public PlanterController planterController;


    [Header("Spawners")]
    public GameObject airSpawner;
    public GameObject leftSpawner;
    public GameObject rightSpawner;

    [Header("Spawnees")]
    public GameObject walker;
    public GameObject flyer;

    private int spawnCount = 0;
    public int spawnCountMax = 10;
    private float spawnDelay; 
    public float spawnDMin = 1;
    public float spawnDMax = 6;


    void Start()
    {
        
        spawnDelay = Random.Range(spawnDMin, spawnDMax);
    }


    public void StartWave()
    {
       // print("starting wave");
        StartCoroutine(WaveBegin());
    }

    IEnumerator WaveBegin()
    {


        while (planterController.treeSize < 1)
        {
            spawnDelay = Random.Range(spawnDMin, spawnDMax);
            float groundspawner = Random.Range(1, 4);

            if (groundspawner <= 2) //changes which side ground enemies spawn on 
            {
             Instantiate(walker, leftSpawner.transform.position, Quaternion.identity);
                spawnCount++;
                //print("spawned walker left");

            }
            else
            {
                Instantiate(walker, rightSpawner.transform.position, Quaternion.identity);
                spawnCount++;
                // print("spawned walker right");
            }

            Instantiate(flyer, airSpawner.transform.position, Quaternion.identity);
            spawnCount++;
            //print("spawned flyer");

            //print("delay " + spawnDelay);
            yield return new WaitForSeconds(spawnDelay);
        }

    }







}
