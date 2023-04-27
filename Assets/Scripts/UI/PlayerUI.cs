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
        NPCText.gameObject.SetActive(false);
        NPCTextBox.gameObject.SetActive(false);
    }

    public void showNPCText(string dialogueText)
    {
        NPCText.SetText(dialogueText);
        NPCText.gameObject.SetActive(true);
        NPCTextBox.gameObject.SetActive(true);
    }

    public void hideNPCText()
    {
        NPCText.gameObject.SetActive(false);
        NPCTextBox.gameObject.SetActive(false);
    }

    public void changeReputationImage(int reputationImage)
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
