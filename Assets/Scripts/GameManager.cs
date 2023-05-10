using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int totalReputationValue = 0;
    [SerializeField] private int totalMoney = 300;

    //Island HUB
    private string textMessage = "";
    private bool inSceneZone = false;
    private bool inReputation = false;
    private bool inShop = false;

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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        inShop = true;
    }

    public void changeShopBuyText()
    {
        int stringNumber = Random.Range(0, MainConstants.NPCShopBuy.Length);
        textMessage = MainConstants.NPCShopBuy[stringNumber];
    }

    public void changeShopNoMoneyText()
    {
        int stringNumber = Random.Range(0, MainConstants.NPCShopNoMoney.Length);
        textMessage = MainConstants.NPCShopNoMoney[stringNumber];
    }

    public void hideNPCShopText()
    {
        textMessage = "";

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inShop = false;
    }

    public bool isInShop()
    {
        return inShop;
    }

    public void showMapText()
    {
        textMessage = MainConstants.NOTIFICATION_MAP;
        inSceneZone = true;
    }

    public void hideMapText()
    {
        textMessage = "";
        inSceneZone = false;
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

    public int getMoney()
    {
        return totalMoney;
    }

    public void addMoney(int money)
    {
        totalMoney += money;
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

    [SerializeField] Image fade;


    public void changeToMapScene(int mapID = 0)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine("ChangeToMapScene");
    }

    IEnumerator ChangeToMapScene()
    {
       
        fade = GameObject.FindGameObjectWithTag("Fadeout").GetComponent<Image>();
        float a = 0;
        fade.color = new Color(0, 0, 0, a);


        while (a < 1)
        {
            a += Time.deltaTime * 0.75f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }
        a = 1;
        SceneManager.LoadScene(MainConstants.INDEX_SCENE_MAP);

        Debug.Log("Evento de mapa");
        yield return new WaitForSeconds(0.2f);
        fade.color = new Color(0, 0, 0, 0);
    }

    public void launchBattleEvent(int battleID = 0)
    {
        StartCoroutine("LaunchBattleEvent");
    }

    IEnumerator LaunchBattleEvent()
    {
        isBattleEvent = false;
        fade = GameObject.FindGameObjectWithTag("Fadeout").GetComponent<Image>();
        float a = 0;
        fade.color = new Color(0, 0, 0, a);
    

        while (a < 1)
        {
            a += Time.deltaTime * 0.75f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }
        a = 1;
        SceneManager.LoadScene(MainConstants.INDEX_SCENE_BATTLE, LoadSceneMode.Additive);
        
        Debug.Log("Evento de combate");
        yield return new WaitForSeconds(0.2f);
        fade.color = new Color(0, 0, 0, 0);
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
