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
        CardList.Add(new Card(1, "Fuego!", "Los <b>Artilleros</b> atacan con su potencia de fuego", Resources.Load<Sprite>("Sprites/gun")));
        CardList.Add(new Card(2, "Debilitar", "Reduce la defensa de los enemigos", Resources.Load<Sprite>("Sprites/deBuffDefense")));
        CardList.Add(new Card(3, "Mal de Ojo", "Activa <b>Cañonazo</b> y los <b>Artilleros</b> realizarán un potente ataque al comienzo del siguiente turno", 
                                Resources.Load<Sprite>("Sprites/bigGun")));

        // Tank Cards
        CardList.Add(new Card(4, "Duelo", "Los <b>Bucaneros</b> atacan con sus sables", Resources.Load<Sprite>("Sprites/sword")));
        CardList.Add(new Card(5, "Protección", "El siguiente turno solo los <b>Bucaneros</b> recibirán daño", Resources.Load<Sprite>("Sprites/shield")));
        CardList.Add(new Card(6, "A toda vela!", "Activa <b>Cañonazo</b> y roba una carta", Resources.Load<Sprite>("Sprites/draw")));

        // Wizard Cards
        CardList.Add(new Card(7, "Amplificación", "Los <b>Escorbúticos</b> aumentan el poder de los aliados", Resources.Load<Sprite>("Sprites/buffAttack")));
        CardList.Add(new Card(8, "Refuerzo", "Los <b>Escorbúticos</b> aumentan la defensa de los aliados", Resources.Load<Sprite>("Sprites/buffDefense")));
        CardList.Add(new Card(9, "Marea", "Activa <b>Cañonazo</b> y al siguiente turno permite jugar dos cartas", Resources.Load<Sprite>("Sprites/water")));
    }
}
