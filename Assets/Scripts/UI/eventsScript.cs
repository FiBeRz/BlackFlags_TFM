using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class eventsScript : MonoBehaviour
{
    [SerializeField] private Button[] childrenButtons;
    [SerializeField] private Button[] branchButtons; 
    [SerializeField] private int eventType;
    [SerializeField] private GameObject eventInformation, mapInformation, shopUI;
    [SerializeField] private TextMeshProUGUI textName, textEvent;
    [SerializeField] private Image eventImage, boat, boatWaypoint;
    [SerializeField] private Sprite eventSprite;
    [SerializeField] private Button continueButton, acceptButton, rejectButton;

    //Sound effect
    [SerializeField] private AudioSource pressEventSoundEffect;
    [SerializeField] private AudioSource pointEventSoundEffect;

    public void eventPoint()
    {
        if (this.GetComponent<Button>().interactable)
        {
            pointEventSoundEffect.Play();
        }
    }

    public void eventClick()
    {
        //Move boat
        GameManager.Instance.setBoatPosition(boatWaypoint.GetComponent<RectTransform>().anchoredPosition);
        //boat.GetComponent<RectTransform>().position = boatWaypoint.GetComponent<RectTransform>().position;

        //Change sprite to visited
        if (this.GetComponent<Button>())
        {
            this.GetComponent<Button>().interactable = false;
            var ss = this.GetComponent<Button>().spriteState;
            ss.disabledSprite = ss.selectedSprite;
            this.GetComponent<Button>().spriteState = ss;
        }

        //Enable children buttons
        for (int i=0; i<childrenButtons.Length; i++)
        {
            if (childrenButtons[i].IsActive())
            {
                childrenButtons[i].interactable = true;
            }
        }

        //Disable branch buttons
        for (int i = 0; i < branchButtons.Length; i++)
        {
            branchButtons[i].interactable = false;
        }

        StartCoroutine("eventSubroutine");
        launchEvent();
    }

    IEnumerator eventSubroutine()
    {
        pressEventSoundEffect.Play();
        yield return new WaitForSeconds(0.1f);

        mapInformation.SetActive(false);
        eventInformation.SetActive(true);
    }

    private void launchEvent()
    {
        eventImage.sprite = eventSprite;
        continueButton.gameObject.SetActive(false);
        acceptButton.gameObject.SetActive(false);
        rejectButton.gameObject.SetActive(false);

        if (eventType == MainConstants.EVENT_UNKNOWN)
        {
            executeUnknownEvent();
        }
        else if (eventType == MainConstants.EVENT_BLESS)
        {
            executeBlessEvent();
        }
        else if (eventType == MainConstants.EVENT_CHEST)
        {
            executeChestEvent();
        }
        else if (eventType == MainConstants.EVENT_OASIS)
        {
            executeOasisEvent();
        }
        else if (eventType == MainConstants.EVENT_SHARK)
        {
            executeSharkEvent();
        }
        else if (eventType == MainConstants.EVENT_RESCUE)
        {
            executeRescueEvent();
        }
        else if (eventType == MainConstants.EVENT_BATTLE)
        {
            executeBattleEvent();
        }
        else if (eventType == MainConstants.EVENT_BOSS)
        {
            executeBossEvent();
        }
        else if (eventType == MainConstants.EVENT_BLACKMARKET)
        {
            executeBlackMarketEvent();
        }
        else if (eventType == MainConstants.EVENT_SHORTCUT)
        {
            executeShortcutEvent();
        }
    }

    private void executeUnknownEvent()
    {
        textName.SetText(MainConstants.NAME_UNKNOWN);
        textEvent.SetText(MainConstants.EXPLANATION_UNKNOWN);
        continueButton.gameObject.SetActive(true);
    }

    private void executeBlessEvent()
    {
        textName.SetText(MainConstants.NAME_BLESS);
        textEvent.SetText(MainConstants.EXPLANATION_BLESS);
        acceptButton.gameObject.SetActive(true);
        rejectButton.gameObject.SetActive(true);

        GameManager.Instance.prepareObject();
    }

    private void executeChestEvent()
    {
        GameManager.Instance.addMoney(MainConstants.MONEY_CHEST);
        textName.SetText(MainConstants.NAME_CHEST);
        textEvent.SetText(MainConstants.EXPLANATION_CHEST);
        continueButton.gameObject.SetActive(true);
    }

    private void executeOasisEvent()
    {
        textName.SetText(MainConstants.NAME_OASIS);
        textEvent.SetText(MainConstants.EXPLANATION_OASIS);
        continueButton.gameObject.SetActive(true);
    }

    private void executeSharkEvent()
    {
        textName.SetText(MainConstants.NAME_SHARK);
        textEvent.SetText(MainConstants.EXPLANATION_SHARK);
        continueButton.gameObject.SetActive(true);
    }

    private void executeRescueEvent()
    {
        textName.SetText(MainConstants.NAME_RESCUE);
        textEvent.SetText(MainConstants.EXPLANATION_RESCUE);
        acceptButton.gameObject.SetActive(true);
        rejectButton.gameObject.SetActive(true);

        GameManager.Instance.prepareRescueScene();
    }

    private void executeBattleEvent()
    {
        textName.SetText(MainConstants.NAME_BATTLE);
        textEvent.SetText(MainConstants.EXPLANATION_BATTLE);
        continueButton.gameObject.SetActive(true);

        GameManager.Instance.prepareBattleScene();
    }

    private void executeBossEvent()
    {
        textName.SetText(MainConstants.NAME_BOSS);
        textEvent.SetText(MainConstants.EXPLANATION_BOSS);
        continueButton.gameObject.SetActive(true);

        GameManager.Instance.prepareBossScene();
    }

    private void executeBlackMarketEvent()
    {
        textName.SetText(MainConstants.NAME_BLACKMARKET);
        if (shopUI)
        {
            textEvent.SetText("");
            shopUI.SetActive(true);
        }
        continueButton.gameObject.SetActive(true);
    }

    private void executeShortcutEvent()
    {
        textName.SetText(MainConstants.NAME_SHORTCUT);
        textEvent.SetText(MainConstants.EXPLANATION_SHORTCUT);
        continueButton.gameObject.SetActive(true);
    }
}
