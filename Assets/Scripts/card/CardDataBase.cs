using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> CardList = new List<Card>();

    void Awake() {
        // Cartas Iniciales
        CardList.Add(new Card(0, "Cañonazo", "Dispara los cañones del barco", Resources.Load<Sprite>("Sprites/cannon")));
        CardList.Add(new Card(1, "Fuego!", "Los <b><color=green>Artilleros</color></b> atacan con su potencia de fuego", Resources.Load<Sprite>("Sprites/gun")));
        CardList.Add(new Card(4, "Duelo", "Los <b><color=blue>Bucaneros</color></b> atacan con sus sables", Resources.Load<Sprite>("Sprites/sword")));
        CardList.Add(new Card(9, "Marea", "Activa <b>Cañonazo</b> y al siguiente turno permite jugar dos cartas", Resources.Load<Sprite>("Sprites/water")));
        CardList.Add(new Card(7, "Amplificación", "Los <b><color=purple>Escorbúticos</color></b> aumentan el poder de los aliados", Resources.Load<Sprite>("Sprites/buffAttack")));

        //Cartas bloqueadas
        if (GameManager.Instance.getCard2())
        {
            CardList.Add(new Card(2, "Debilitar", "Los <b><color=purple>Escorbúticos</color></b> reducen la defensa de los enemigos", Resources.Load<Sprite>("Sprites/deBuffDefense")));
        }
        if (GameManager.Instance.getCard3())
        {
            CardList.Add(new Card(3, "Mal de Ojo", "Activa <b>Cañonazo</b> y los <b><color=green>Artilleros</color></b> realizarán un potente ataque al comienzo del siguiente turno",
                    Resources.Load<Sprite>("Sprites/bigGun")));
        }
        if (GameManager.Instance.getCard5())
        {
            CardList.Add(new Card(5, "Protección", "El siguiente turno solo los <b><color=blue>Bucaneros</color></b> recibirán daño", Resources.Load<Sprite>("Sprites/shield")));
        }
        if (GameManager.Instance.getCard6())
        {
            CardList.Add(new Card(6, "A toda vela!", "Activa <b>Cañonazo</b> y roba una carta", Resources.Load<Sprite>("Sprites/draw")));
        }
        if (GameManager.Instance.getCard8())
        {
            CardList.Add(new Card(8, "Refuerzo", "Los <b><color=purple>Escorbúticos</color></b> aumentan la defensa de los aliados", Resources.Load<Sprite>("Sprites/buffDefense")));
        }
    }
}
