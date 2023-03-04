using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFall : MonoBehaviour
{
    public GameObject box;
    public Transform spawnManager;
    private bool spawnAgain = true;    
    
    
    void Update()
    {
        if(spawnAgain)
        {
            StartCoroutine("SpawnBox");
        }
    }

    IEnumerator SpawnBox()
    {
        spawnAgain = false;

        Instantiate(box, new Vector3(spawnManager.position.x, spawnManager.position.y, 0), Quaternion.identity);

        yield return new WaitForSeconds(5f);

        spawnAgain = true;
    }
}
