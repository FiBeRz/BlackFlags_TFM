using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI NPCText;
    [SerializeField] private Image NPCTextBox;

    void Start()
    {
        NPCText.gameObject.SetActive(false);
        NPCTextBox.gameObject.SetActive(false);
    }

    public void showNPCText(string dialogueText)
    {
        NPCText.SetText(dialogueText);
        NPCText.gameObject.SetActive(true);
        NPCTextBox.gameObject.SetActive(true);
    }

    public void hideNPCText()
    {
        NPCText.gameObject.SetActive(false);
        NPCTextBox.gameObject.SetActive(false);
    }
}
