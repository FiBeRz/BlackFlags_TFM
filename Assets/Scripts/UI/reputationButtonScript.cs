using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reputationButtonScript : MonoBehaviour
{
    [SerializeField] private AudioSource reputationSoundEffect;
    [SerializeField] private Image expandedReputationIcon;
    [SerializeField] private Sprite closeSprite, openSprite;
    private bool isExpanded = false;

    private void Start()
    {
        expandedReputationIcon.gameObject.SetActive(false);
    }

    public void expandReputation()
    {
        reputationSoundEffect.Play();
        if (isExpanded)
        {
            expandedReputationIcon.gameObject.SetActive(false);
            this.GetComponent<Image>().sprite = openSprite;
        }
        else
        {
            expandedReputationIcon.gameObject.SetActive(true);
            this.GetComponent<Image>().sprite = closeSprite;
        }

        isExpanded = !isExpanded;

        if (this.GetComponent<Button>())
        {
            this.GetComponent<Button>().Select();
        }
    }
}
