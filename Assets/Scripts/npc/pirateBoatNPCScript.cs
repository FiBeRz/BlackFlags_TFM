using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateBoatNPCScript : MonoBehaviour
{
    [SerializeField] Transform transformCuerpo;
    Quaternion rotacionInicial;

    private void Start()
    {
        rotacionInicial = transformCuerpo.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.notify();
            GameManager.Instance.boatText();
            GameManager.Instance.targetHablador = transformCuerpo;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transformCuerpo.rotation = rotacionInicial;
            GameManager.Instance.endNotify();
            GameManager.Instance.endText();
            GameManager.Instance.hideBoatText();
            GameManager.Instance.targetHablador = null;
        }
    }
}
