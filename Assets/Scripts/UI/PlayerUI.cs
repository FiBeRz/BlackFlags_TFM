using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCText, tutorialText;
    [SerializeField] private Image NPCTextBox;
    [SerializeField] private Image fade;
    [SerializeField] private Image reputationIcon;
    [SerializeField] private Image expandedReputationIcon;
    [SerializeField] private Sprite defaultSprite, goodSprite, bestSprite, badSprite, worstSprite;
    [SerializeField] private GameObject shopUI, shopImage, tutorialUI, notification;
    [SerializeField] private TextMeshProUGUI moneyText;

    void Start()
    {
        if (NPCText)
        {
            NPCText.gameObject.SetActive(false);
        }
        if (NPCTextBox)
        {
            NPCTextBox.gameObject.SetActive(false);
        }
        if (expandedReputationIcon)
        {
            expandedReputationIcon.gameObject.SetActive(false);
        }
        if (shopUI)
        {
            shopUI.SetActive(false);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("RemoveFade");
    }

    IEnumerator RemoveFade()
    {
        float a = 1;
        fade.color = new Color(0, 0, 0, a);
        yield return new WaitForSeconds(0.2f);
        while (a > 0)
        {
            a -= Time.deltaTime * 0.75f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }
        a = 0;


        //Debug.Log("Evento de fadescreen");

        fade.color = new Color(0, 0, 0, 0);
        yield return null;
    }

    private void changeText()
    {
        if (NPCText && NPCTextBox)
        {
            if (!(GameManager.Instance.isInTutorial()) && (GameManager.Instance.isText()))
            {
                notification.SetActive(false);
                NPCText.SetText(GameManager.Instance.getTextMessage());
                NPCText.gameObject.SetActive(true);
                NPCTextBox.gameObject.SetActive(true);
            }
            else
            {
                NPCText.gameObject.SetActive(false);
                NPCTextBox.gameObject.SetActive(false);
            }
        }

        if (GameManager.Instance.isInTutorial())
        {
            tutorialText.SetText(GameManager.Instance.getTutorialMessage());
        }
    }

    public void changeReputationImage(int reputationImage)
    {
        if (reputationIcon)
        {
            if (reputationImage == MainConstants.DEFAULT_REPUTATION)
                reputationIcon.sprite = defaultSprite;
            else if (reputationImage == MainConstants.GOOD_REPUTATION)
                reputationIcon.sprite = goodSprite;
            else if (reputationImage == MainConstants.BEST_REPUTATION)
                reputationIcon.sprite = bestSprite;
            else if (reputationImage == MainConstants.BAD_REPUTATION)
                reputationIcon.sprite = badSprite;
            else
                reputationIcon.sprite = worstSprite;
        }
    }

    public void calculateReputationImage()
    {
        int reputationImage = MainConstants.DEFAULT_REPUTATION;
        if (GameManager.Instance.getReputation() >= 50)
        {
            reputationImage = MainConstants.GOOD_REPUTATION;
            if (GameManager.Instance.getReputation() >= 100)
            {
                reputationImage = MainConstants.BEST_REPUTATION;
            }
        }
        else if (GameManager.Instance.getReputation() <= -50)
        {
            reputationImage = MainConstants.BAD_REPUTATION;
            if (GameManager.Instance.getReputation() <= -100)
            {
                reputationImage = MainConstants.WORST_REPUTATION;
            }
        }

        changeReputationImage(reputationImage);
    }

    private void showReputation()
    {
        if (GameManager.Instance.getInReputation())
        {
            expandedReputationIcon.gameObject.SetActive(true);
        }
        else
        {
            expandedReputationIcon.gameObject.SetActive(false);
        }
    }

    private void isInShop()
    {
        if ((GameManager.Instance.isInShop()) && (GameManager.Instance.isText()))
        {
            shopUI.SetActive(true);
            shopImage.SetActive(true);

            if (GameManager.Instance.getReputation() <= -100)
            {
                shopImage.SetActive(false);
            }
        }
        else
        {
            shopUI.SetActive(false);
        }
    }

    private void isInTutorial()
    {
        if ((GameManager.Instance.isInTutorial()) && (GameManager.Instance.isText()))
        {
            notification.SetActive(false);
            tutorialUI.SetActive(true);
        }
        else
        {
            tutorialUI.SetActive(false);
        }
    }

    private void updateMoney()
    {
        moneyText.SetText(GameManager.Instance.getMoney() + "$");
    }

    private void setTutorial()
    {
        if (!GameManager.Instance.isFirstTimeIsland())
        {
            GameManager.Instance.skipTutorial();
        }
    }

    private void checkNotification()
    {
        if (GameManager.Instance.isNotificated())
        {
            notification.SetActive(true);
        }
        else
        {
            notification.SetActive(false);
        }
    }

    private void Update()
    {
        checkNotification();
        setTutorial();
        updateMoney();
        calculateReputationImage();
        changeText();
        isInShop();
        isInTutorial();
        showReputation();
    }
}
