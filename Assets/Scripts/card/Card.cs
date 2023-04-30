using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

//[CreateAssetMenu(fileName = "New Card",  menuName = "Card")]
public class Card
{
    public int id;
    public string name;
    public string description;

    public Sprite artworkImage;

    public Card(int id, string cardName, string description, Sprite artworkImage) {
        this.id = id;
        this.name = cardName;
        this.description = description;
        this.artworkImage = artworkImage;
    }
}
