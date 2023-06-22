using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopNPCScript : MonoBehaviour
{
    [SerializeField] Transform transformCuerpo;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //Show text
            GameManager.Instance.targetHablador = transformCuerpo;
            GameManager.Instance.notify();
            GameManager.Instance.showNPCShopText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            //Hide text
            GameManager.Instance.endNotify();
            GameManager.Instance.targetHablador = null;
            GameManager.Instance.hideNPCShopText();
        }
    }
}
