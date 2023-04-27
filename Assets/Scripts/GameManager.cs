using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Canvas UICanvas;
    [SerializeField] private int totalReputationValue = 0;

    public void showNPCText()
    {
        if (UICanvas.GetComponent<PlayerUI>())
        {
            int stringNumber = Random.Range(0, MainConstants.NPCDialogue.Length);
            UICanvas.GetComponent<PlayerUI>().showNPCText(MainConstants.NPCDialogue[stringNumber]);
        }
    }

    public void hideNPCText()
    {
        if (UICanvas.GetComponent<PlayerUI>())
        {
            UICanvas.GetComponent<PlayerUI>().hideNPCText();
        }
    }

    public void showNPCShopText()
    {
        if (UICanvas.GetComponent<PlayerUI>())
        {
            int stringNumber = Random.Range(0, MainConstants.NPCShopDialogue.Length);
            UICanvas.GetComponent<PlayerUI>().showNPCText(MainConstants.NPCShopDialogue[stringNumber]);
        }
    }

    public void hideNPCShopText()
    {
        if (UICanvas.GetComponent<PlayerUI>())
        {
            UICanvas.GetComponent<PlayerUI>().hideNPCText();
        }
    }

    public void addReputation(int reputationPoints)
    {
        totalReputationValue += reputationPoints;
        changeReputationImage();
    }

    public int getReputation()
    {
        return totalReputationValue;
    }

    public void setReputation(int reputationValue)
    {
        totalReputationValue = reputationValue;
    }

    public void changeReputationImage()
    {
        int reputationImage = MainConstants.DEFAULT_REPUTATION;
        if (totalReputationValue >= 50)
        {
            reputationImage = MainConstants.GOOD_REPUTATION;
            if (totalReputationValue >= 100)
            {
                reputationImage = MainConstants.BEST_REPUTATION;
            }
        }
        else if (totalReputationValue <= -50)
        {
            reputationImage = MainConstants.BAD_REPUTATION;
            if (totalReputationValue <= -100)
            {
                reputationImage = MainConstants.WORST_REPUTATION;
            }
        }

        if (UICanvas.GetComponent<PlayerUI>())
        {
            UICanvas.GetComponent<PlayerUI>().changeReputationImage(reputationImage);
        }
    }

    private void Update()
    {
        changeReputationImage();
    }
}
