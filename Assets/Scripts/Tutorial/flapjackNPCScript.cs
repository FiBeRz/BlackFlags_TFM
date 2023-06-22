using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flapjackNPCScript : MonoBehaviour
{
    Quaternion rotacionInicial;
    [SerializeField] Transform transformCuerpo;
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] float velocidad = 1;
    int etapa = 0;
    void Update()
    {
        if (GameManager.Instance.getTutorialGroup() == 2 && etapa == 0)
        {
            //Move to shop
            etapa = 1;
            StartCoroutine("MoverLoro");
            GetComponent<BoxCollider>().enabled = false;
        }
        else if (GameManager.Instance.getTutorialGroup() == 3 && etapa == 1)
        {
            //Move to pier
            etapa = 2;
            StartCoroutine("MoverLoro");
            GetComponent<BoxCollider>().enabled = false;
            // this.transform.position = waypoints[1].transform.position;
            // this.transform.rotation = waypoints[1].transform.rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {

            GameManager.Instance.targetHablador = transformCuerpo;
            GameManager.Instance.notify();
            GameManager.Instance.showTutorialText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            transformCuerpo.rotation = rotacionInicial;
            GameManager.Instance.targetHablador = null;
            GameManager.Instance.endNotify();
            GameManager.Instance.endText();
            GameManager.Instance.hideTutorialText();
        }
    }


    private IEnumerator MoverLoro()
    {
        GameManager.Instance.endNotify();
        GameManager.Instance.endText();
        GameManager.Instance.hideTutorialText();

        int id = 0;
        if (GameManager.Instance.getTutorialGroup() == 3)
            id = 1;


        while (transform.position != waypoints[id].transform.position)
        {
            transform.LookAt(waypoints[id].transform);
           transform.position = Vector3.MoveTowards(transform.position, waypoints[id].transform.position, velocidad * Time.deltaTime);
            yield return null;
        }
        transform.rotation = waypoints[id].transform.rotation;
        GameManager.Instance.targetHablador = null;
        GetComponent<BoxCollider>().enabled = true;

    }
}
