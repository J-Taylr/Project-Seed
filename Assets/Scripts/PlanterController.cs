using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterController : MonoBehaviour
{
    public TreeAnims treeAnims;
    public EnemySpawner enemySpawner;
    public ProgressBar progressBar;
    [SerializeField] GameObject plantText;
    

    bool inCollider = false;
    public float treeMax = 1;
    bool treePlanted = false;
    public int treeHealth = 100;
    public float growSpeed;
    public float treeSize;

    [Header("Tree Anims")]
    [SerializeField] GameObject treeSeed;

    private void Start()
    {
        treeHealth = 100;
    }

    private void Update()
    {
        TextAppear();
        PlantTree();
       
    }



    public void PlantTree()
    {
        if (inCollider && Input.GetKeyDown(KeyCode.E) && !treePlanted)
        {
            print("planted a tree!");
            treePlanted = true;
            StartCoroutine(TreeGrower(0, 1, 60));
            enemySpawner.StartWave();
            treeSeed.SetActive(true);
        }
    }


    public void TakeDamage()
    {
        treeHealth--;
        //print("ouch! tree health at " + treeHealth);
    }

  
    IEnumerator TreeGrower(float v_start, float v_end, float duration)
    {
        treeSize = 0;
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            treeSize = Mathf.Lerp(v_start, v_end, elapsed / duration);
            elapsed += Time.deltaTime;
            progressBar.IncrementProgress(treeSize);
            yield return null;
        }
        treeSize = v_end;
    }

    public void TextAppear()
    {
        if (inCollider == true)
        {
            plantText.SetActive(true);
        }
        else { plantText.SetActive(false); }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inCollider = true;
        }
        else { inCollider = false; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inCollider = false;
        }
    }
}
