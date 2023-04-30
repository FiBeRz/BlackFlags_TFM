using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopButtonScript : MonoBehaviour
{
    [SerializeField] private int value = 50;

    void Start()
    {
        this.GetComponentInChildren<TextMeshProUGUI>().SetText(value + "$");
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
