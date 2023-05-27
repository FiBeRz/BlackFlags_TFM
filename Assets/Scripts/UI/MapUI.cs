using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MapUI : MonoBehaviour
{
    [SerializeField] private Image reputationIcon, fade;
    [SerializeField] private Sprite defaultSprite, goodSprite, bestSprite, badSprite, worstSprite;
    [SerializeField] private GameObject eventInformation, mapInformation, fadeoutPanel, taxesInformation, blackMarketEvent, shortcutEvent, tutorialInformation;
    [SerializeField] private TextMeshProUGUI moneyText, shopMoneyText, tutorialText;
    [SerializeField] private TextMeshProUGUI[] eventPercentageTexts;
    [SerializeField] private Button startEventBattle, startEventUnknown;
    private GameObject eventSystem;
    private bool startRun = false;

    void Start()
    {
        eventInformation.SetActive(false);
        taxesInformation.SetActive(false);
        checkTutorial();
        mapInformation.SetActive(true);
        eventSystem = GameObject.Find("EventSystem");
        moneyText.SetText(GameManager.Instance.getMoney() + "$");
        shopMoneyText.SetText(GameManager.Instance.getMoney() + "$");

        if (GameManager.Instance.getReputation() >= 50)
        {
            shortcutEvent.SetActive(true);
            blackMarketEvent.SetActive(false);
        }
        else if (GameManager.Instance.getReputation() <= -50)
        {
            blackMarketEvent.SetActive(true);
            shortcutEvent.SetActive(false);
        }
        else
        {
            blackMarketEvent.SetActive(false);
            shortcutEvent.SetActive(false);
        }
    }

    private void OnEnable()
    {
        StartCoroutine("RemoveFade");
    }

    IEnumerator RemoveFade()
    {    
        if (fade)
        {
            float a = 1;
            fade.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0.2f);
            while (a > 0)
            {
                a -= Time.deltaTime * 0.75f;
                fade.color = new Color(0, 0, 0, a);
                yield return null;
            }
            a = 0;


            //Debug.Log("Evento de fadescreen");

            fade.color = new Color(0, 0, 0, 0);
        }
        yield return null;
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

    private void checkChangeToCombat()
    {
        if (GameManager.Instance.isInChangeToCombat())
        {
            eventSystem.SetActive(false);
            GameManager.Instance.returnFromCombat();
        }
    }

    private void checkReactivateInterface()
    {
        if (GameManager.Instance.isInReactivateInterface())
        {
            eventSystem.SetActive(true);
            GameManager.Instance.returnFromReactivate();
        }
    }

    private void checkEndOfRun()
    {
        if (GameManager.Instance.isEndOfRun())
        {
            taxesInformation.SetActive(true);
        }
    }

    private void calculateMoney()
    {
        moneyText.SetText(GameManager.Instance.getMoney() + "$");
        shopMoneyText.SetText(GameManager.Instance.getMoney() + "$");
    }

    private void calculateEventPercentage()
    {
        int unknownValue, oasisValue, rescueValue, sharkValue, chestValue, battleValue, blessValue, bossValue, marketValue, shortcutValue;

        //Good reputation
        if (GameManager.Instance.getReputation() >= 50 && GameManager.Instance.getReputation() < 100)
        {
            unknownValue = MainConstants.GOOD_UNKNOWN;
            oasisValue = MainConstants.GOOD_OASIS;
            rescueValue = MainConstants.GOOD_RESCUE;
            sharkValue = MainConstants.GOOD_SHARK;
            chestValue = MainConstants.GOOD_CHEST;
            battleValue = MainConstants.GOOD_BATTLE;
            blessValue = MainConstants.GOOD_BLESS;
            bossValue = MainConstants.GOOD_BOSS;
            marketValue = MainConstants.GOOD_BLACKMARKET;
            shortcutValue = MainConstants.GOOD_SHORTCUT;
        }
        //Best reputation
        else if (GameManager.Instance.getReputation() >= 100)
        {
            unknownValue = MainConstants.BEST_UNKNOWN;
            oasisValue = MainConstants.BEST_OASIS;
            rescueValue = MainConstants.BEST_RESCUE;
            sharkValue = MainConstants.BEST_SHARK;
            chestValue = MainConstants.BEST_CHEST;
            battleValue = MainConstants.BEST_BATTLE;
            blessValue = MainConstants.BEST_BLESS;
            bossValue = MainConstants.BEST_BOSS;
            marketValue = MainConstants.BEST_BLACKMARKET;
            shortcutValue = MainConstants.BEST_SHORTCUT;
        }
        //Bad reputation
        else if (GameManager.Instance.getReputation() <= -50 && GameManager.Instance.getReputation() > -100)
        {
            unknownValue = MainConstants.BAD_UNKNOWN;
            oasisValue = MainConstants.BAD_OASIS;
            rescueValue = MainConstants.BAD_RESCUE;
            sharkValue = MainConstants.BAD_SHARK;
            chestValue = MainConstants.BAD_CHEST;
            battleValue = MainConstants.BAD_BATTLE;
            blessValue = MainConstants.BAD_BLESS;
            bossValue = MainConstants.BAD_BOSS;
            marketValue = MainConstants.BAD_BLACKMARKET;
            shortcutValue = MainConstants.BAD_SHORTCUT;
        }
        //Worst reputation
        else if (GameManager.Instance.getReputation() <= -100)
        {
            unknownValue = MainConstants.WORST_UNKNOWN;
            oasisValue = MainConstants.WORST_OASIS;
            rescueValue = MainConstants.WORST_RESCUE;
            sharkValue = MainConstants.WORST_SHARK;
            chestValue = MainConstants.WORST_CHEST;
            battleValue = MainConstants.WORST_BATTLE;
            blessValue = MainConstants.WORST_BLESS;
            bossValue = MainConstants.WORST_BOSS;
            marketValue = MainConstants.WORST_BLACKMARKET;
            shortcutValue = MainConstants.WORST_SHORTCUT;
        }
        //Neutral reputation
        else
        {
            unknownValue = MainConstants.NEUTRAL_UNKNOWN;
            oasisValue = MainConstants.NEUTRAL_OASIS;
            rescueValue = MainConstants.NEUTRAL_RESCUE;
            sharkValue = MainConstants.NEUTRAL_SHARK;
            chestValue = MainConstants.NEUTRAL_CHEST;
            battleValue = MainConstants.NEUTRAL_BATTLE;
            blessValue = MainConstants.NEUTRAL_BLESS;
            bossValue = MainConstants.NEUTRAL_BOSS;
            marketValue = MainConstants.NEUTRAL_BLACKMARKET;
            shortcutValue = MainConstants.NEUTRAL_SHORTCUT;
        }

        eventPercentageTexts[MainConstants.EVENT_UNKNOWN].SetText(unknownValue + "%");
        eventPercentageTexts[MainConstants.EVENT_OASIS].SetText(oasisValue + "%");
        eventPercentageTexts[MainConstants.EVENT_RESCUE].SetText(rescueValue + "%");
        eventPercentageTexts[MainConstants.EVENT_SHARK].SetText(sharkValue + "%");
        eventPercentageTexts[MainConstants.EVENT_CHEST].SetText(chestValue + "%");
        eventPercentageTexts[MainConstants.EVENT_BATTLE].SetText(battleValue + "%");
        eventPercentageTexts[MainConstants.EVENT_BLESS].SetText(blessValue + "%");
        eventPercentageTexts[MainConstants.EVENT_BOSS].SetText(bossValue + "%");
        eventPercentageTexts[MainConstants.EVENT_BLACKMARKET].SetText(marketValue + "%");
        eventPercentageTexts[MainConstants.EVENT_SHORTCUT].SetText(shortcutValue + "%");
    }

    private void checkTutorial()
    {
        if (GameManager.Instance.isFirstTimeInMap())
        {
            tutorialInformation.SetActive(true);
        }
        else
        {
            tutorialInformation.SetActive(false);
        }
    }

    private void checkTextTutorial()
    {
        if (GameManager.Instance.isFirstTimeInMap())
        {
            tutorialText.SetText(GameManager.Instance.getTutorialText());
        }
        else
        {
            tutorialInformation.SetActive(false);
            if (!startRun)
            {
                startEventBattle.interactable = true;
                startEventUnknown.interactable = true;
                startRun = true;
            }
        }
    }

    private void Update()
    {
        calculateReputationImage();
        calculateEventPercentage();
        calculateMoney();
        checkChangeToCombat();
        checkReactivateInterface();
        checkEndOfRun();
        checkTextTutorial();
    }
}
