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
    private bool endOfRun = false;

    //Change Scenes
    [SerializeField] Image fade;
    private bool changeToCombat = false;
    private bool reactivateInterface = false;


    public void showNPCText()
    {
        //Neutral reputation
        int stringNumber = Random.Range(0, MainConstants.NPCDialogue.Length);
        textMessage = MainConstants.NPCDialogue[stringNumber];

        //Good reputation
        if (totalReputationValue >= 50)
        {
            int stringGood = Random.Range(0, MainConstants.NPCDialogueGood.Length);
            if (totalReputationValue < 100)
            {
                if (Random.Range(0, 3) == 0)                                                //33% change message from default to good
                {
                    textMessage = MainConstants.NPCDialogueGood[stringGood];
                }
            }
            else
            {
                textMessage = MainConstants.NPCDialogueGood[stringGood];
                //Best reputation
                int stringBest = Random.Range(0, MainConstants.NPCDialogueBest.Length);
                if (Random.Range(0, 2) == 0)                                                //50% change message from good to best
                {
                    textMessage = MainConstants.NPCDialogueBest[stringBest];
                }
            }
        }

        //Bad reputation
        if (totalReputationValue <= -50)
        {
            int stringBad = Random.Range(0, MainConstants.NPCDialogueBad.Length);
            if (totalReputationValue > -100)
            {
                if (Random.Range(0, 3) == 0)                                                //33% change message from default to bad
                {
                    textMessage = MainConstants.NPCDialogueBad[stringBad];
                }
            }
            else
            {
                textMessage = MainConstants.NPCDialogueBad[stringBad];
                //Worst reputation
                int stringWorst = Random.Range(0, MainConstants.NPCDialogueWorst.Length);
                if (Random.Range(0, 2) == 0)                                                //50% change message from bad to worst
                {
                    textMessage = MainConstants.NPCDialogueWorst[stringWorst];
                }
            }
        }
    }

    public void hideNPCText()
    {
        textMessage = "";
    }

    public void showNPCShopText()
    {
        if ((totalReputationValue > -100) && (totalReputationValue < 100))
        {
            int stringNumber = Random.Range(0, MainConstants.NPCShopDialogue.Length);
            textMessage = MainConstants.NPCShopDialogue[stringNumber];
        }
        else if (totalReputationValue >= 100)
        {
            int stringNumber = Random.Range(0, MainConstants.NPCShopGood.Length);
            textMessage = MainConstants.NPCShopGood[stringNumber];
        }
        else
        {
            int stringNumber = Random.Range(0, MainConstants.NPCShopBad.Length);
            textMessage = MainConstants.NPCShopBad[stringNumber];
        }

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

    public void changeToMapScene(int mapID = 0)
    {
        hideMapText();
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
            if (fade)
            {
                fade.color = new Color(0, 0, 0, a);
            }
            yield return null;
        }
        a = 1;
        endOfRun = false;
        SceneManager.LoadScene(MainConstants.INDEX_SCENE_MAP);

        Debug.Log("Evento de mapa");
        yield return new WaitForSeconds(0.2f);
        if (fade)
        {
            fade.color = new Color(0, 0, 0, 0);
        }
    }

    public void changeToIslandScene()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(MainConstants.INDEX_SCENE_ISLAND);
    }

    public void launchBattleEvent(int battleID = 0)
    {
        changeToCombat = true;
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
        reactivateInterface = true;
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
        returnFromBoss();
    }

    public bool inBossEvent()
    {
        return isBossEvent;
    }

    public void returnFromBoss()
    {
        endOfRun = true;
    }

    public bool isEndOfRun()
    {
        return endOfRun;
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

    public bool isInChangeToCombat()
    {
        return changeToCombat;
    }

    public void returnFromCombat()
    {
        changeToCombat = false;
    }

    public bool isInReactivateInterface()
    {
        return reactivateInterface;
    }

    public void returnFromReactivate()
    {
        reactivateInterface = false;
    }
}
