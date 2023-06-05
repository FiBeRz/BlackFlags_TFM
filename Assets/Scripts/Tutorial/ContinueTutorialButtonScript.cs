using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueTutorialButtonScript : MonoBehaviour
{
    [SerializeField] private int textIndex = 0;

    public void continueEvent()
    {
        textIndex++;
        if (textIndex < MainConstants.TutorialMap.Length)
        {
            GameManager.Instance.changeTutorialMapText(MainConstants.TutorialMap[textIndex]);
        }
        else
        {
            GameManager.Instance.endMapTutorial();
        }
    }
}
