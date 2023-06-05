using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reputationButtonScript : MonoBehaviour
{
    [SerializeField] private Image expandedReputationIcon;
    private bool isExpanded = false;

    private void Start()
    {
        expandedReputationIcon.gameObject.SetActive(false);
    }

    public void expandReputation()
    {
        if (isExpanded)
        {
            expandedReputationIcon.gameObject.SetActive(false);
        }
        else
        {
            expandedReputationIcon.gameObject.SetActive(true);
        }

        isExpanded = !isExpanded;

        if (this.GetComponent<Button>())
        {
            this.GetComponent<Button>().Select();
        }
    }
}
