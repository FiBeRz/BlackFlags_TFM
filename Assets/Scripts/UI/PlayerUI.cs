using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCText;
    [SerializeField] private Image NPCTextBox;
    [SerializeField] private Image reputationIcon;
    [SerializeField] private Sprite defaultSprite, goodSprite, bestSprite, badSprite, worstSprite;

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
    }

    private void changeText()
    {
        if (NPCText && NPCTextBox)
        {
            if (GameManager.Instance.getTextMessage() != "")
            {
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

    private void Update()
    {
        calculateReputationImage();
        changeText();
    }
}
