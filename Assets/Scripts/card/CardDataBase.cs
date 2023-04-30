using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> CardList = new List<Card>();

    void Awake() {
        // Ship Cards
        CardList.Add(new Card(0, "Cannons", "Dispara los cañones del barco", Resources.Load<Sprite>("Sprites/cannon")));

        // Ship Shooter
        CardList.Add(new Card(1, "Ataque rapido", "Ataca con tu potencia de fuego", Resources.Load<Sprite>("Sprites/gun")));
        CardList.Add(new Card(2, "Descartar", "Descarta una carta para robar dos", Resources.Load<Sprite>("Sprites/shuffle")));
        CardList.Add(new Card(3, "Ataque cargado", "Realiza un 175% del daño al principio del siguiente turno", Resources.Load<Sprite>("Sprites/bigBullet")));

        // Tank Cards
        CardList.Add(new Card(4, "Ataque", "Ataca a los enemigos", Resources.Load<Sprite>("Sprites/sword")));
        CardList.Add(new Card(5, "Defensa", "Absorve un x % del daño", Resources.Load<Sprite>("Sprites/shield")));
        CardList.Add(new Card(6, "Robar", "Roba una carta del mazo", Resources.Load<Sprite>("Sprites/jew")));

        // Wizard Cards
        CardList.Add(new Card(7, "Aumento de ataque", "Aumenta el poder de los aliados", Resources.Load<Sprite>("Sprites/redArrowUp")));
        CardList.Add(new Card(8, "Aumento de defensa", "Aumenta la defensa de los aliados", Resources.Load<Sprite>("Sprites/blueArrowUp")));
        CardList.Add(new Card(9, "Marea", "Aumenta el número de cartas que puedes jugar el siguiente turno", Resources.Load<Sprite>("Sprites/water")));
    }
}
