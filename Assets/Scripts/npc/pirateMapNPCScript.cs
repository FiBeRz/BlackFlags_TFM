using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateMapNPCScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.notify();
            GameManager.Instance.pirateMapText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.endNotify();
            GameManager.Instance.endText();
            GameManager.Instance.hidePirateMapText();
        }
    }
}
