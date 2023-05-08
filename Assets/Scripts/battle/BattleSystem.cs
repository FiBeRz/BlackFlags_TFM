using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }


public class BattleSystem : MonoBehaviour
{

    public GameObject CardDataBase;
    private Deck deck;

    public GameObject allyWarriorPrefab;
    public GameObject allyShooterPrefab;
    public GameObject allyWizardPrefab;
    public GameObject enemyPrefab;

    public Transform allyStation;
    public Transform enemyStation;

    public Unit enemyUnit;

    public BattleState state;
    public bool isDraggable = false;


    // LISTA DE ALIADOS POR CLASE
    public List<Unit> allyWarriors;
    public List<Unit> allyShooters;
    public List<Unit> allyWizards;

    private int nWarriors = 0;
    private int nShooters = 0;
    private int nWizards = 0;


    // Start is called before the first frame update
    void Start()
    {
        deck = CardDataBase.GetComponent<Deck>();

        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        Vector3 position = allyStation.position;
        // POR AHORA HAY UN EQUIPO PREDEFINIDO DE 3 WARRIOR, 2 SHOOTERS Y 1 WIZARD

        int i;
        for (i = 0; i < 3; i++)
        {
            GameObject allyGO = Instantiate(allyWarriorPrefab, new Vector3(position.x + 0f, position.y, position.z + (i*2)), allyStation.rotation, allyStation);
            allyWarriors.Add(allyGO.GetComponent<Unit>());
        }
        nWarriors = i;
        for (i = 0; i < 2; i++)
        {
            GameObject allyGO = Instantiate(allyShooterPrefab, new Vector3(position.x + 2f, position.y, position.z + (i*2)), allyStation.rotation, allyStation);
            allyShooters.Add(allyGO.GetComponent<Unit>());
        }
        nShooters = i;
        for (i = 0; i < 1; i++)
        {
            GameObject allyGO = Instantiate(allyWizardPrefab, new Vector3(position.x + 4f, position.y, position.z + (i*2)), allyStation.rotation, allyStation);
            allyWizards.Add(allyGO.GetComponent<Unit>());
        }
        nWizards = i;


        GameObject enemyGO = Instantiate(enemyPrefab, enemyStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

     
        StartCoroutine(deck.DrawFirstCards());


        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator EnemyTurn() 
    {
        isDraggable = false;

        yield return new WaitForSeconds(1f);

        Unit currentTarget;

        if (nWarriors > 0)
        {
            currentTarget = allyWarriors[0];

            bool isDead = currentTarget.TakeDamage(enemyUnit.damage);

            if (isDead)
            {
                nWarriors--;
                allyWarriors.Remove(currentTarget);
                Destroy(currentTarget.gameObject);
            }
        }
        else if (nShooters > 0)
        {
            currentTarget = allyShooters[0];

            bool isDead = currentTarget.TakeDamage(enemyUnit.damage);

            if (isDead)
            {
                nShooters--;
                allyShooters.Remove(currentTarget);
                Destroy(currentTarget.gameObject);
            }
        }
        else 
        {
            currentTarget = allyWizards[0];

            bool isDead = currentTarget.TakeDamage(enemyUnit.damage);

            if (isDead)
            {
                nWizards--;
                allyWizards.Remove(currentTarget);
                Destroy(currentTarget.gameObject);
            }
        }

        if (nShooters + nWarriors + nWizards == 0)
        {
            state = BattleState.LOST;
        }
        else 
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

       
    }

    void PlayerTurn() 
    {
        isDraggable = true;
        deck.DrawCard();
    }


    public void cardAction(int id)
    {
        bool isDead = false;
        switch (id){
            case 1://ATAQUE RAPIDO
                this.attack(1, 1f);
                break;
            case 3://ATAQUE CARGADO
                this.attack(1, 2f);
                break;
            case 4://ATAQUE NORMAL
                this.attack(0,1f);
                break;
            default:
                break;
        }

        if (isDead)
        {
            state = BattleState.WON;
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
           
    }


    private void attack(int clase, float mlt = 1)
    {
        int damage = 0;
        Debug.Log(enemyUnit.currentHP);
        if (clase == 0) //Warriors
        {
            foreach (Unit warrior in allyWarriors)
            {
                damage += warrior.damage;
            }
        }
        else if (clase == 1) //Shooters
        {
            foreach (Unit shooter in allyShooters)
            {
                damage += shooter.damage;
            }
        }
        else //Wizards
        {
            foreach (Unit wizard in allyWizards)
            {
                damage += wizard.damage;
            }
        }
        bool isDead = enemyUnit.TakeDamage((int)(damage * mlt));
        Debug.Log(enemyUnit.currentHP);

        if (isDead)
        {
            state = BattleState.WON;
            Debug.Log("Victoria");
        }

    }

}
