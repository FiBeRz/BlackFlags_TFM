using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueTutorialButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource flapjackSoundEffect;
    [SerializeField] private int textIndex = 0;
    [SerializeField] private GameObject caption, reputation;

    public void continueEvent()
    {
        textIndex++;
        flapjackSoundEffect.Play();
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
}
