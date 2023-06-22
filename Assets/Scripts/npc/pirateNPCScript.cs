using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateNPCScript : MonoBehaviour
{
    [SerializeField] Transform transformCuerpo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.notify();
            GameManager.Instance.targetHablador = transformCuerpo;
            GameManager.Instance.piratePierText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.endNotify();
            GameManager.Instance.endText();
            GameManager.Instance.hidePiratePierText();
            GameManager.Instance.targetHablador = null;
        }
    }
}
