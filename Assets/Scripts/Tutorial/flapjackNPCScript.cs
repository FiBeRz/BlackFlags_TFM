using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flapjackNPCScript : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;

    void Update()
    {
        if (GameManager.Instance.getTutorialGroup() == 2)
        {
            //Move to shop
            this.transform.position = waypoints[0].transform.position;
        }
        else if (GameManager.Instance.getTutorialGroup() == 3)
        {
            //Move to pier
            this.transform.position = waypoints[1].transform.position;
            this.transform.rotation = waypoints[1].transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.showTutorialText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.hideTutorialText();
        }
    }
}
