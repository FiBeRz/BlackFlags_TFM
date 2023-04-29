using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapUI : MonoBehaviour
{
    [SerializeField] private Image reputationIcon;
    [SerializeField] private Sprite defaultSprite, goodSprite, bestSprite, badSprite, worstSprite;
    [SerializeField] private GameObject eventInformation, mapInformation;

    void Start()
    {
        eventInformation.SetActive(false);
        mapInformation.SetActive(true);
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
    }
}
