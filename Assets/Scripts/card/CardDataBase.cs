using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> CardList = new List<Card>();

    void Awake() {
        // Ship Cards
        CardList.Add(new Card(0, "Cañonazo", "Dispara los cañones del barco", Resources.Load<Sprite>("Sprites/cannon")));

        // Ship Shooter
        CardList.Add(new Card(1, "Fuego!", "Ataca con tu potencia de fuego", Resources.Load<Sprite>("Sprites/gun")));
        CardList.Add(new Card(2, "Trueque", "Descarta una carta para robar dos", Resources.Load<Sprite>("Sprites/shuffle")));
        CardList.Add(new Card(3, "Mal de Ojo", "Realiza un 175% del daño al principio del siguiente turno", Resources.Load<Sprite>("Sprites/bigGun")));

        // Tank Cards
        CardList.Add(new Card(4, "Duelo", "Ataca a los enemigos", Resources.Load<Sprite>("Sprites/sword")));
        CardList.Add(new Card(5, "Protección", "Absorbe un x % del daño", Resources.Load<Sprite>("Sprites/shield")));
        CardList.Add(new Card(6, "A toda vela!", "Roba una carta del mazo y dispara los cañones", Resources.Load<Sprite>("Sprites/draw")));

        // Wizard Cards
        CardList.Add(new Card(7, "Amplificación", "Aumenta el poder de los aliados", Resources.Load<Sprite>("Sprites/buffAttack")));
        CardList.Add(new Card(8, "Refuerzo", "Aumenta la defensa de los aliados", Resources.Load<Sprite>("Sprites/buffDefense")));
        CardList.Add(new Card(9, "Marea", "El siguiente turno puedes jugar dos cartas", Resources.Load<Sprite>("Sprites/water")));
    }
}
