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
    [SerializeField] private GameObject eventInformation, mapInformation, fadeoutPanel;
    private GameObject eventSystem;

    void Start()
    {
        eventInformation.SetActive(false);
        mapInformation.SetActive(true);
        eventSystem = GameObject.Find("EventSystem");
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

    private void Update()
    {
        calculateReputationImage();
        checkChangeToCombat();
        checkReactivateInterface();
    }
}
