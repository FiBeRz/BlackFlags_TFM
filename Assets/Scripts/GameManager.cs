using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Canvas UICanvas;

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
}
