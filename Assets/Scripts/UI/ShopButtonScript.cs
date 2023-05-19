using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonScript : MonoBehaviour
{
    [SerializeField] private int value = 50;
    private int initialValue;

    void Start()
    {
        initialValue = value;
        changeText();
    }

    void Update()
    {
        checkValue();
    }

    private void checkValue()
    {
        if (GameManager.Instance.getReputation() >= 100)
        {
            if(value != (MainConstants.DISCOUNT_PERCENT * initialValue/100))
            {
                value = MainConstants.DISCOUNT_PERCENT * initialValue/100;
                changeText();
                changeTextColor(MainConstants.COLOR_GREEN);
            }
        }
        else if (GameManager.Instance.getReputation() <= -50)
        {
            if (value != (MainConstants.RECHARGE_PERCENT * initialValue / 100))
            {
                value = MainConstants.RECHARGE_PERCENT * initialValue / 100;
                changeText();
                changeTextColor(MainConstants.COLOR_RED);
            }
        }
        else
        {
            value = initialValue;
            changeText();
            changeTextColor(MainConstants.COLOR_BLACK);
        }
    }

    private void changeText()
    {
        this.GetComponentInChildren<TextMeshProUGUI>().SetText(value + "$");
    }

    private void changeTextColor(int color)
    {
        if (color == MainConstants.COLOR_GREEN)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().color = Color.green;
        }
        else if (color == MainConstants.COLOR_RED)
        {
            this.GetComponentInChildren<TextMeshProUGUI>().color = Color.red;
        }
        else
        {
            this.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
        }
    }

    public void purchase()
    {
        if (GameManager.Instance.getMoney() >= value)
        {
            GameManager.Instance.addMoney(-1 * value);
            //this.GetComponent<Button>().interactable = false;
            GameManager.Instance.changeShopBuyText();
        }
        else
        {
            GameManager.Instance.changeShopNoMoneyText();
        }
    }
}
