using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    //Tripulación pirata
    [SerializeField] private int pirateWarriors = 2;
    [SerializeField] private int pirateShooters = 1;
    [SerializeField] private int pirateWizards = 1;

    //Desbloqueo cartas
    [SerializeField] private bool card2 = false;
    [SerializeField] private bool card3 = false;
    [SerializeField] private bool card5 = false;
    [SerializeField] private bool card6 = false;
    [SerializeField] private bool card8= false;

    //Reputation Popup
    [SerializeField] private GameObject prefabReputationPopUp;

    //Sound Effects
    [SerializeField] private AudioSource flapjackSoundEffect;
    [SerializeField] private AudioSource enterShopSoundEffect;
    [SerializeField] private AudioSource talkingSoundEffect;
    [SerializeField] private AudioSource objectSoundEffect;
    [SerializeField] private AudioSource runStartSoundEffect;
    [SerializeField] private AudioSource goodReputationSoundEffect;
    [SerializeField] private AudioSource badReputationSoundEffect;

    //Variables
    [SerializeField] private int totalReputationValue = 0;
    [SerializeField] private int totalMoney = 300;
    [SerializeField] private bool audioSilenciado = false;
    [SerializeField] private float maxVolumen = 1;

    //Island HUB
    private string textMessage = "";
    private bool inReputation = false;
    private bool inShop = false;
    private bool notification = false;
    private bool haveText = false;
    [SerializeField] public GameObject jugadorReferencia = null;
    [SerializeField] public Transform targetHablador;

    //Map
    private bool isRescueEvent = false;
    private bool isObjectEvent = false;
    private bool isBattleEvent = false;
    private bool isBossEvent = false;
    private bool endOfRun = false;
    private Vector2 boatMapPosition;
    private bool moveBoat = false;

    //Change Scenes
    [SerializeField] Image fade;
    private bool changeToCombat = false;
    private bool reactivateInterface = false;

    //Tutorial info
    [SerializeField] private bool firstTimeIsland = true;
    private string tutorialIslandText = "";
    private int tutorialIslandIndex = 0, tutorialIslandGroup = 1;
    private bool inTutorial = false;

    [SerializeField] private bool firstTimeMap = true;
    private string tutorialMapText = MainConstants.TutorialMap[0];

    [SerializeField] private bool firstTimeBattle = true;

    //Get Map and Boat info
    [SerializeField] public bool hasMap = false, hasBoat = false, hasMission = false;
    public bool pirateTalk = false, boatPirate = false, pierPirate = false, mapPirate = false;
    public int boatPirateIndex = 0, pierPirateIndex = 0, mapPirateIndex = 0;
    private bool inChangeToMap = false;
    private bool notificationMap = false, notificationBoat = false;

    public void FijarVolumen()
    {
        if (audioSilenciado)
        {
            AudioListener.volume = 0;
           
        }
        else
        {
            AudioListener.volume = maxVolumen;
           
        }
    }

    // Update is called once per frame

    public bool GetAudioEstatus()
    {

        return audioSilenciado;
    }

    public bool CambiarEstatus()
    {
        audioSilenciado = !audioSilenciado;

        FijarVolumen();

        return audioSilenciado;
    }

    public bool isFirstTimeIsland()
    {
        return firstTimeIsland;
    }

    public void skipTutorial()
    {
        tutorialIslandGroup = 3;
        tutorialIslandIndex = MainConstants.TutorialIsland3.Length-1;
    }

    public void showTutorialText()
    {
        inTutorial = true;
        changeTutorialText();
    }

    public void changeTutorialIndex()
    {
        tutorialIslandIndex++;
        flapjackSoundEffect.Play();
        changeTutorialText();
    }

    public void changeTutorialText()
    {
        if (tutorialIslandGroup == 1)
        {
            if (tutorialIslandIndex >= MainConstants.TutorialIsland1.Length)
            {
                tutorialIslandIndex = 0;
                tutorialIslandGroup = 2;
              //  StartCoroutine("fadeEffect");
            }
            else
            {
                tutorialIslandText = MainConstants.TutorialIsland1[tutorialIslandIndex];
            }
        }
        else if (tutorialIslandGroup == 2)
        {
            if (tutorialIslandIndex >= MainConstants.TutorialIsland2.Length)
            {
                tutorialIslandIndex = 0;
                tutorialIslandGroup = 3;
              //  StartCoroutine(fadeEffect());
            }
            else
            {
                tutorialIslandText = MainConstants.TutorialIsland2[tutorialIslandIndex];
            }
        }
        else
        {
            if (tutorialIslandIndex >= MainConstants.TutorialIsland3.Length)
            {
                firstTimeIsland = false;
                endText();
                tutorialIslandIndex = MainConstants.TutorialIsland3.Length-1;
            }
            tutorialIslandText = MainConstants.TutorialIsland3[tutorialIslandIndex];
        }
    }

    public int getTutorialGroup()
    {
        return tutorialIslandGroup;
    }

    public int getTutorialIndex()
    {
        return tutorialIslandIndex;
    }

    public void hideTutorialText()
    {
        inTutorial = false;
        tutorialIslandText = "";
    }


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
        inShop = false;
    }

    public bool isInShop()
    {
        return inShop;
    }

    public bool isInTutorial()
    {
        return inTutorial;
    }

    public void addReputation(int reputationPoints)
    {
        popUpReputation(reputationPoints);

        if (reputationPoints > 0)
        {
            goodReputationSoundEffect.Play();
        }
        else if (reputationPoints < 0)
        {
            badReputationSoundEffect.Play();
        }

        totalReputationValue += reputationPoints;
    }

    public void popUpReputation(int reputationPoints)
    {
        GameObject reputationPopUpTransform = Instantiate(prefabReputationPopUp);

        if (reputationPopUpTransform.GetComponent<reputationPopUp>())
        {
            reputationPopUpTransform.GetComponent<reputationPopUp>().Setup(reputationPoints);
        }
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

    public string getTutorialMessage()
    {
        return tutorialIslandText;
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
        addReputation(15);

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
        pirateTalk = false;
        pierPirate = false;
        notification = false;
        haveText = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        runStartSoundEffect.Play();
        StartCoroutine("ChangeToMapScene");
    }

    public void setupMap()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator fadeEffect()
    {
        fade = GameObject.FindGameObjectWithTag("Fadeout").GetComponent<Image>();
        float a = 1;
        fade.color = new Color(0, 0, 0, a);


        while (a > 0)
        {
            a -= Time.deltaTime * 0.75f;
            if (fade)
            {
                fade.color = new Color(0, 0, 0, a);
            }
            yield return null;
        }
        a = 0;

        yield return new WaitForSeconds(0.2f);
        if (fade)
        {
            fade.color = new Color(0, 0, 0, 0);
        }
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

        //Sumar piratas tripulantes
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            pirateWarriors++;
        }
        else if(random == 1)
        {
            pirateShooters++;
        }
        else
        {
            pirateWizards++;
        }
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
        isObjectEvent = false;
    }

    public void addObject()
    {
        isObjectEvent = false;

        Debug.Log("Objeto añadido");
        addReputation(-15);
    }

    public bool isInChangeToCombat()
    {
        return changeToCombat;
    }

    public void returnFromCombat()
    {
        changeToCombat = false;
    }

    public void unlockCard()
    {
        if (!card8)
        {
            card8 = true;
        }
        else if (!card6)
        {
            card6 = true;
        }
        else if (!card5)
        {
            card5 = true;
        }
        else if (!card3)
        {
            card3 = true;
        }
        else
        {
            card2 = true;
        }
    }

    public bool getCard2()
    {
        return card2;
    }

    public bool getCard3()
    {
        return card3;
    }

    public bool getCard5()
    {
        return card5;
    }

    public bool getCard6()
    {
        return card6;
    }

    public bool getCard8()
    {
        return card8;
    }

    public bool isInReactivateInterface()
    {
        return reactivateInterface;
    }

    public void returnFromReactivate()
    {
        reactivateInterface = false;
    }

    public bool isFirstTimeInMap()
    {
        return firstTimeMap;
    }

    public void endMapTutorial()
    {
        firstTimeMap = false;
    }

    public void changeTutorialMapText(string newText)
    {
        tutorialMapText = newText;
    }

    public string getTutorialText()
    {
        return tutorialMapText;
    }

    public void notify()
    {
        notification = true;
    }

    public void endNotify()
    {
        notification = false;
    }

    public bool isNotificated()
    {
        return notification;
    }

    public void setPlayer(GameObject player)
    {
        jugadorReferencia = player;
    }

    public void setText()
    {
        haveText = true;
        inReputation = false;
        if (targetHablador != null)
        {
            targetHablador.eulerAngles = new Vector3(targetHablador.eulerAngles.x, jugadorReferencia.transform.eulerAngles.y + 180, targetHablador.eulerAngles.z);
        }

        jugadorReferencia.GetComponent<Animator>().SetFloat("Speed", 0);

        if (inShop || inTutorial)
        { 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            if (inShop)
            {
                Debug.Log("SPress");
                enterShopSoundEffect.Play();
            }
            else
            {
                Debug.Log("SEPress");
                flapjackSoundEffect.Play();
            }
        }
        else
        {
            Debug.Log("NPPress");
            talkingSoundEffect.Play();
        }
    }

    public void endText()
    {
        haveText = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (notificationBoat)
        {
            notificationBoat = false;
        }

        if (notificationMap)
        {
            notificationMap = false;
        }
    }

    public void changeText()
    {
        if (!haveText)
        {
            setText();
        }
        else
        {
            endText();
        }
    }

    public void enterTutorialText()
    {
        setText();
    }

    public bool isText()
    {
        return haveText;
    }

    public void boatText()
    {
        pirateTalk = true;
        boatPirate = true;

        textMessage = MainConstants.NPCPirateBoat[boatPirateIndex];
    }

    public void hideBoatText()
    {
        textMessage = "";
        pirateTalk = false;
        boatPirate = false;
    }

    public void pirateMapText()
    {
        pirateTalk = true;
        mapPirate = true;

        textMessage = MainConstants.NPCPirateMap[mapPirateIndex];
    }

    public void hidePirateMapText()
    {
        textMessage = "";
        pirateTalk = false;
        mapPirate = false;
    }

    public void piratePierText()
    {
        pirateTalk = true;
        pierPirate = true;

        if (hasMap && !hasBoat)
        {
            textMessage = MainConstants.NPCPiratePierSearch[0];
        }
        else if (!hasMap && hasBoat)
        {
            textMessage = MainConstants.NPCPiratePierSearch[1];
        }
        else if (hasMap && hasBoat)
        {
            textMessage = MainConstants.NPCPiratePierFinal[0];
            if (!inChangeToMap)
            {
                inChangeToMap = true;
            }
        }
        else
        {
            textMessage = MainConstants.NPCPiratePierIntro[pierPirateIndex];
        }
    }

    public void hidePiratePierText()
    {
        textMessage = "";
        pirateTalk = false;
        pierPirate = false;
    }

    public bool isInPirateTalk()
    {
        return pirateTalk;
    }

    public void enterPirateText()
    {
        setText();
    }

    public bool isInMission()
    {
        return hasMission;
    }

    public bool playerHasMap()
    {
        return hasMap;
    }

    public bool playerHasBoat()
    {
        return hasBoat;
    }

    public void changePirateIndex()
    {
        if (mapPirate)
        {
            if (hasMission)
            {
                mapPirateIndex++;
                if (!hasMap)
                {
                    hasMap = true;
                    objectSoundEffect.Play();
                    notificationMap = true;
                }

                if (mapPirateIndex >= MainConstants.NPCPirateMap.Length)
                {
                    notificationMap = false;
                    endText();
                    mapPirateIndex = MainConstants.NPCPirateMap.Length - 1;
                }

                else
                {
                    talkingSoundEffect.Play();
                    pirateMapText();
                }
            } 
            else
            {
                endText();
            }
        }
        else if (boatPirate)
        {
            if (hasMission)
            {
                boatPirateIndex++;
                if (!hasBoat)
                {
                    hasBoat = true;
                    objectSoundEffect.Play();
                    notificationBoat = true;
                }

                if (boatPirateIndex >= MainConstants.NPCPirateBoat.Length)
                {
                    notificationBoat = false;
                    endText();
                    boatPirateIndex = MainConstants.NPCPirateBoat.Length - 1;
                }
                else
                {
                    talkingSoundEffect.Play();
                    boatText();
                }
            }
            else
            {
                endText();
            }
        }
        else if (pierPirate)
        {
            pierPirateIndex++;

            if (inChangeToMap)
            {
                changeToMapScene();
            }
            else if (pierPirateIndex >= MainConstants.NPCPiratePierIntro.Length)
            {
                pierPirateIndex = MainConstants.NPCPiratePierIntro.Length-1;
                if (!hasMission)
                {
                    hasMission = true;
                    objectSoundEffect.Play();
                }
                boatPirateIndex = 1;
                mapPirateIndex = 1;
                endText();
            }
            else
            {
                talkingSoundEffect.Play();
                piratePierText();
            }
        }
    }

    public bool isNotificatedMap()
    {
        return notificationMap;
    }

    public bool isNotificatedBoat()
    {
        return notificationBoat;
    }

    public void setBoatPosition(Vector2 newPosition)
    {
        boatMapPosition = newPosition;
        moveBoat = true;
    }

    public Vector2 getBoatPosition()
    {
        return boatMapPosition;
    }

    public void stopBoat()
    {
        moveBoat = false;
    }

    public bool isMovingBoat()
    {
        return moveBoat;
    }

    public bool isFirstTimeBattle()
    {
        return firstTimeBattle;
    }

    public void endBattleTutorial()
    {
        firstTimeBattle = false;
    }

    public int getWarriors()
    {
        return pirateWarriors;
    }

    public int getShooters()
    {
        return pirateShooters;
    }

    public int getWizards()
    {
        return pirateWizards;
    }
}
