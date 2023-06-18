using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FlapJackButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource flapjackSoundEffect;
    [SerializeField] TextMeshProUGUI shortTutorialText;
    [SerializeField] GameObject tutorialExpanded;

    public void saySomething()
    {
        flapjackSoundEffect.Play();

        int stringIndex = Random.Range(0, MainConstants.ShortTutorialMap.Length);
        shortTutorialText.SetText(MainConstants.ShortTutorialMap[stringIndex]);
        tutorialExpanded.SetActive(true);
    }

    public void disableExpandedText()
    {
        tutorialExpanded.SetActive(false);
    }
}
