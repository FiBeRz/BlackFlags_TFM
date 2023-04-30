using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    [SerializeField] private Card card;

    [SerializeField] public int id;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private Image artworkImage;
    [SerializeField] private Image cardBack;

    void Start() 
    {
        card = CardDataBase.CardList[id];
        nameText.text = card.name;
        descriptionText.text = card.description;
        artworkImage.sprite = card.artworkImage;
    }

    public void Init(Card card) {
        this.card = card;
        this.id = card.id;
        this.nameText.text = card.name;
        this.descriptionText.text = card.description;
        this.artworkImage.sprite = card.artworkImage;
    }

    public void ShowCardBack(bool isActive) {
        if (isActive)
            cardBack.gameObject.SetActive(true);
        else
            cardBack.gameObject.SetActive(false);
    }
}
