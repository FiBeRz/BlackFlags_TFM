using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReputationMarkScript : MonoBehaviour
{
    [SerializeField] private float minValue = -110, maxValue = 155;
    private float minReputation = -100, maxReputation = 100;

    void Update()
    {
        updatePosition();
    }

    private void updatePosition()
    {
        int reputationValue = GameManager.Instance.getReputation();
        float reputationPercentage = (reputationValue - minReputation) / (maxReputation - minReputation);
        float xValue = reputationPercentage * (maxValue - minValue) + minValue;

        if (xValue > maxValue)
            xValue = maxValue;
        else if (xValue < minValue)
            xValue = minValue;


        this.GetComponent<RectTransform>().anchoredPosition = new Vector2(xValue, this.GetComponent<RectTransform>().anchoredPosition.y);
    }
}
