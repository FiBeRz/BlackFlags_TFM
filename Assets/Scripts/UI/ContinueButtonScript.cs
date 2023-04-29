using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject eventInformation, mapInformation;

    public void continueEvent()
    {
        mapInformation.SetActive(true);
        eventInformation.SetActive(false);

        if (GameManager.Instance.inBattleEvent())
        {
            GameManager.Instance.launchBattleEvent();
        }
        else if (GameManager.Instance.inBossEvent())
        {
            GameManager.Instance.launchBossEvent();
        }
    }

    public void acceptEvent()
    {
        mapInformation.SetActive(true);
        eventInformation.SetActive(false);

        if (GameManager.Instance.inRescueEvent())
        {
            GameManager.Instance.launchRescueEvent();
        }
        else if (GameManager.Instance.inObjectEvent())
        {
            GameManager.Instance.addObject();
        }
    }

    public void rejectEvent()
    {
        mapInformation.SetActive(true);
        eventInformation.SetActive(false);

        if (GameManager.Instance.inRescueEvent())
        {
            GameManager.Instance.rejectRescueScene();
        }
        else if (GameManager.Instance.inObjectEvent())
        {
            GameManager.Instance.rejectObject();
        }
    }
}
