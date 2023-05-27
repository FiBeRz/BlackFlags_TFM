using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlapJackButtonScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI shortTutorialText;
    [SerializeField] GameObject tutorialExpanded;

    public void saySomething()
    {
        int stringIndex = Random.Range(0, MainConstants.ShortTutorialMap.Length);
        shortTutorialText.SetText(MainConstants.ShortTutorialMap[stringIndex]);
        tutorialExpanded.SetActive(true);
    }

    public void disableExpandedText()
    {
        tutorialExpanded.SetActive(false);
    }
}
