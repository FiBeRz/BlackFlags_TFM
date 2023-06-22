using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject mNPCPrefab;
    [SerializeField] private GameObject fNPCPrefab;
    [SerializeField] private GameObject[] waypointRoute;

    //Time between generations
    [SerializeField] private int minTime = 5;
    [SerializeField] private int maxTime = 10;

    private bool generate = true;
    private GameObject NPC;

    
    void Update()
    {
        if (generate)
        {
            
            if (Random.Range(0,2) == 0)
            {
                Debug.Log("GenerandMo");
                NPC = Instantiate(mNPCPrefab, spawnPoint);
            }
            else
            {
                Debug.Log("GenerandoF");
                NPC = Instantiate(fNPCPrefab, spawnPoint);
            }
            
            generate = false;

            if (NPC.GetComponent<npcScript>())
            {
                NPC.GetComponent<npcScript>().setWaypoints(waypointRoute);
            }

            int timeToWait = Random.Range(minTime, maxTime + 1);
            StartCoroutine(waiting(timeToWait));
        }
    }

    private IEnumerator waiting(int timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        generate = true;
    }
}
