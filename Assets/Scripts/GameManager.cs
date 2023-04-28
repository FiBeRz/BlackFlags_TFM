using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int totalReputationValue = 0;

    private string textMessage = "";
    private bool inSceneZone = false;
    private bool inReputation = false;

    public void showNPCText()
    {
        int stringNumber = Random.Range(0, MainConstants.NPCDialogue.Length);
        textMessage = MainConstants.NPCDialogue[stringNumber];
    }

    public void hideNPCText()
    {
        textMessage = "";
    }

    public void showNPCShopText()
    {
        int stringNumber = Random.Range(0, MainConstants.NPCShopDialogue.Length);
        textMessage = MainConstants.NPCShopDialogue[stringNumber];
    }

    public void hideNPCShopText()
    {
        textMessage = "";
    }

    public void showMapText()
    {
        textMessage = MainConstants.NOTIFICATION_MAP;
        inSceneZone = true;
    }

    public void hideMapText()
    {
        textMessage = "";
    }

    public bool isInSceneZone()
    {
        return inSceneZone;
    }

    public void addReputation(int reputationPoints)
    {
        totalReputationValue += reputationPoints;
    }

    public int getReputation()
    {
        return totalReputationValue;
    }

    public void setReputation(int reputationValue)
    {
        totalReputationValue = reputationValue;
    }

    public string getTextMessage()
    {
        return textMessage;
    }

    public void showReputation()
    {
        inReputation = !inReputation;
    }

    public bool getInReputation()
    {
        return inReputation;
    }

    public void changeToMapScene()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(MainConstants.INDEX_SCENE_MAP);
    }
}
