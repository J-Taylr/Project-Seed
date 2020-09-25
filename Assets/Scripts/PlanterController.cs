using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanterController : MonoBehaviour
{
    [SerializeField] GameObject plantText;
    bool inCollider = false;
    public int treeMax = 100;
    bool treePlanted = false;

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
            StartCoroutine(TreeGrower());
        }
    }

    public IEnumerator TreeGrower()
    {
        int treeSize = 0;
        while (treeSize < treeMax)
        {
            treeSize++;
            print("tree size " + treeSize);
            yield return new WaitForSeconds(1);
        }

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
