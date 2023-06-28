using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject eventInformation, mapInformation, shopUI;
    [SerializeField] private AudioSource buttonSoundEffect;

    public void continueEvent()
    {
        StartCoroutine("continueSubroutine");

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
        StartCoroutine("continueSubroutine");

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
        StartCoroutine("continueSubroutine");

        if (GameManager.Instance.inRescueEvent())
        {
            GameManager.Instance.rejectRescueScene();
        }
        else if (GameManager.Instance.inObjectEvent())
        {
            GameManager.Instance.rejectObject();
        }
    }

    IEnumerator continueSubroutine()
    {
        buttonSoundEffect.Play();
        yield return new WaitForSeconds(0.1f);

        mapInformation.SetActive(true);
        eventInformation.SetActive(false);
        if (shopUI)
        {
            shopUI.SetActive(false);
        }
    }

    public void acceptTaxes()
    {
        int money = GameManager.Instance.getMoney();
        int totalTaxes = 10 * money / 100;
        GameManager.Instance.addMoney(-1 * totalTaxes);
        GameManager.Instance.addReputation(10);
        StartCoroutine(waitReputation());
    }

    public void rejectTaxes()
    {
        GameManager.Instance.addReputation(-20);
        StartCoroutine(waitReputation());
    }

    IEnumerator waitReputation()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.changeToIslandScene();
    }
}
