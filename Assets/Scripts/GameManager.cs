using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int totalReputationValue = 0;

    //Island HUB
    private string textMessage = "";
    private bool inSceneZone = false;
    private bool inReputation = false;

    //Map
    private bool isRescueEvent = false;
    private bool isObjectEvent = false;
    private bool isBattleEvent = false;
    private bool isBossEvent = false;

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

    public void prepareRescueScene()
    {
        isRescueEvent = true;
    }

    public void rejectRescueScene()
    {
        isRescueEvent = false;
        addReputation(-15);
    }

    public void launchRescueEvent()
    {
        isRescueEvent = false;

        //Change to Battle-Rescue scene
        Debug.Log("Evento de rescate");
    }

    public bool inRescueEvent()
    {
        return isRescueEvent;
    }

    public void prepareBattleScene()
    {
        isBattleEvent = true;
    }

    public void launchBattleEvent()
    {
        isBattleEvent = false;

        //Change to Battle scene
        Debug.Log("Evento de combate");
    }

    public bool inBattleEvent()
    {
        return isBattleEvent;
    }

    public void prepareBossScene()
    {
        isBossEvent = true;
    }

    public void launchBossEvent()
    {
        isBossEvent = false;

        //Change to Battle-Boss scene
        Debug.Log("Evento de Boss");
    }

    public bool inBossEvent()
    {
        return isBossEvent;
    }

    public void prepareObject()
    {
        isObjectEvent = true;
    }

    public bool inObjectEvent()
    {
        return isObjectEvent;
    }

    public void rejectObject()
    {
        isRescueEvent = false;
    }

    public void addObject()
    {
        isObjectEvent = false;

        //Add object indicator to object list
        Debug.Log("Objeto añadido");
    }
}
