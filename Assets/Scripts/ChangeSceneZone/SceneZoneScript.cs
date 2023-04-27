using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneZoneScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.showMapText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            GameManager.Instance.hideMapText();
        }
    }
}
