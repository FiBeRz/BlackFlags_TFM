using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class captionScript : MonoBehaviour
{
    [SerializeField] private Image expandedCaptionIcon;
    [SerializeField] private Sprite button, buttonPressed;
    private bool isExpanded = false;

    private void Start()
    {
        expandedCaptionIcon.gameObject.SetActive(false);
    }

    public void expandCaption()
    {
        if (isExpanded)
        {
            expandedCaptionIcon.gameObject.SetActive(false);
            this.GetComponent<Button>().image.sprite = button;
        }
        else
        {
            expandedCaptionIcon.gameObject.SetActive(true);
            this.GetComponent<Button>().image.sprite = buttonPressed;
        }

        isExpanded = !isExpanded;
    }
}
