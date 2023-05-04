using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleSatte { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public GameObject allyPrefab;
    public GameObject enemyPrefab;

    public Transform allyBattleZone;
    public Transform enemyBattleZone;

    Unit allyUnit;
    Unit enemyUnit;

    public BattleSatte state;


    void Start()
    {
        state = BattleSatte.START;
        SetUpBattle();
    }

    // INSTANCIAMOS TODOS LOS ALIADOS Y ENEMIGOS
    void SetUpBattle()
    {
        GameObject allyGO = Instantiate(allyPrefab, allyBattleZone);
        allyUnit = allyGO.GetComponent<Unit>();

        GameObject enemyGO =  Instantiate(enemyPrefab, enemyBattleZone);
        enemyUnit = enemyGO.GetComponent<Unit>();
    }
}
