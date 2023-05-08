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

    public void Init(Card card) {
        this.card = card;
        this.id = card.id;
        this.nameText.text = card.name;
        this.descriptionText.text = card.description;
        this.artworkImage.sprite = card.artworkImage;
    }
}
