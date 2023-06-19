using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueTutorialButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource flapjackSoundEffect;
    [SerializeField] private int textIndex = 0;
    [SerializeField] private GameObject caption, reputation;
    [SerializeField] private bool inBattle;
    [SerializeField] private GameObject battleTutorial;

    private void Start()
    {
        if (inBattle && !GameManager.Instance.isFirstTimeBattle() && battleTutorial)
        {
            battleTutorial.SetActive(false);
        }
    }

    public void continueEvent()
    {
        flapjackSoundEffect.Play();

        if (!inBattle)
        {
            textIndex++;
            if (textIndex < MainConstants.TutorialMap.Length)
            {
                GameManager.Instance.changeTutorialMapText(MainConstants.TutorialMap[textIndex]);
                if (textIndex == 2)
                {
                    caption.SetActive(true);
                }
                else if (textIndex == 3)
                {
                    caption.SetActive(false);
                    reputation.SetActive(true);
                }
                else
                {
                    reputation.SetActive(false);
                }

            }
            else
            {
                GameManager.Instance.endMapTutorial();
            }
        }
        else
        {
            if (battleTutorial)
            {
                StartCoroutine(endBattleTutorial());
            }
        }
    }

    IEnumerator endBattleTutorial()
    {
        yield return new WaitForSeconds(0.2f);
        battleTutorial.SetActive(false);
        GameManager.Instance.endBattleTutorial();
    }
}
