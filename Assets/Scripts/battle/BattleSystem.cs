using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }


public class BattleSystem : MonoBehaviour
{
    public GameObject CardDataBase;
    public GameObject HUDController;

    private Deck deck;
    private HUDController HUD;

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

    public List<Unit> allAlly;

    private int nWarriors = 0;
    private int nShooters = 0;
    private int nWizards = 0;
    private int nAlly = 0;

    // PORCENTAJES
    public float buffAttackRatio = 0.1F;
    public float buffDefenseRatio = 0.2F;

    public float ataqueCargadoRatio = 1.0F;

    public int shipDamage = 50;

    // FLAGS PARA ACCIONES DE CARTAS
    private bool discard = false;
    private bool defend = false;
    private bool ataqueCargado = false;
    private int multicard = 0;


    // Start is called before the first frame update
    void Start()
    {
        deck = CardDataBase.GetComponent<Deck>();
        HUD = HUDController.GetComponent<HUDController>();

        state = BattleState.START;
        
        StartCoroutine("SetupBattle");
        //Desactivacion del mapa que invoco battle system, por lo cual tambien se remueve el fade
       

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            state = BattleState.WON;
            Debug.Log("Victoria");
            StartCoroutine("ReturnToMap");
        }

    }
    [SerializeField] Image fade;

    public void SpawnEntities()
    {
        Vector3 position = allyStation.position;
        // POR AHORA HAY UN EQUIPO PREDEFINIDO DE 3 WARRIOR, 2 SHOOTERS Y 1 WIZARD

        int i;
        for (i = 0; i < 3; i++)
        {
            GameObject allyGO = Instantiate(allyWarriorPrefab, new Vector3(position.x + 0f, position.y, position.z + (i * 2)), allyStation.rotation, allyStation);
            allyWarriors.Add(allyGO.GetComponent<Unit>());
            allAlly.Add(allyGO.GetComponent<Unit>());
        }
        nWarriors = i;
        for (i = 0; i < 2; i++)
        {
            GameObject allyGO = Instantiate(allyShooterPrefab, new Vector3(position.x + 2f, position.y, position.z + (i * 2)), allyStation.rotation, allyStation);
            allyShooters.Add(allyGO.GetComponent<Unit>());
            allAlly.Add(allyGO.GetComponent<Unit>());
        }
        nShooters = i;
        for (i = 0; i < 1; i++)
        {
            GameObject allyGO = Instantiate(allyWizardPrefab, new Vector3(position.x + 4f, position.y, position.z + (i * 2)), allyStation.rotation, allyStation);
            allyWizards.Add(allyGO.GetComponent<Unit>());
            allAlly.Add(allyGO.GetComponent<Unit>());
        }
        nWizards = i;

        nAlly = nWizards + nShooters + nWarriors;

        GameObject enemyGO = Instantiate(enemyPrefab, enemyStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

    }

    GameObject worldmap;
    IEnumerator SetupBattle()
    {
        SpawnEntities();

        //Como esto no lo maneja game manager uso un fade asignado
       
        if (fade)
        {
            float a = 1;
            fade.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0.3f);

            while (a > 0)
            {
                a -= Time.deltaTime * 0.75f;
                fade.color = new Color(0, 0, 0, a);
                yield return null;
            }


            worldmap = GameObject.FindGameObjectWithTag("Holder");
            if (worldmap)
            {
                worldmap.SetActive(false);
            }
        }

        StartCoroutine(deck.DrawFirstCards());


        state = BattleState.PLAYERTURN;
        PlayerTurn();

    }



    IEnumerator EnemyTurn() 
    {
        isDraggable = false;
        HUD.HideHand();
        HUD.ChangeIcon(false);

        yield return new WaitForSeconds(3f);

        int nTargets = nAlly;
        if (defend && nWarriors > 0)
        {
            nTargets = nWarriors;
        }

        //Poner animación de ataque del enemigo
        Animator animator = enemyUnit.gameObject.GetComponentInChildren<Animator>();
        StartCoroutine(attackAnimation(animator));

        for (int i = 0; i < allAlly.Count; ++i)
        {
            Unit currentUnit = allAlly[i];
            if (defend)
            {
                if (currentUnit.unitClass != UnitClass.Warrior) continue;
            }

            //Poner animación de golpe en cada unidad
            Animator animatorAlly = currentUnit.gameObject.GetComponentInChildren<Animator>();
            StartCoroutine(hitAllyAnimation(animatorAlly, currentUnit, nTargets));
        }
        defend = false;

        if (nAlly == 0)
        {
            state = BattleState.LOST;
        }
        else 
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    IEnumerator attackAnimation(Animator animator)
    {
        if (animator)
        {
            animator.SetBool("Attack", true);
        }
        yield return new WaitForSeconds(1f);
        if (animator)
        {
            animator.SetBool("Attack", false);
        }
    }

    IEnumerator hitEnemyAnimation(Animator animator, int damage, float mlt)
    {
        yield return new WaitForSeconds(1f);
        if (animator)
        {
            animator.SetBool("Hit", true);
        }
        yield return new WaitForSeconds(1f);
        if (animator)
        {
            animator.SetBool("Hit", false);
        }

        bool isDead = enemyUnit.TakeDamage((int)(damage * mlt));
        Debug.Log(enemyUnit.currentHP);
        if (isDead)
        {
            state = BattleState.WON;
            Debug.Log("Victoria");
            StartCoroutine("ReturnToMap");
        }
    }

    IEnumerator hitAllyAnimation(Animator animator, Unit currentUnit, int nTargets)
    {
        yield return new WaitForSeconds(1f);
        if (animator)
        {
            animator.SetBool("Hit", true);
        }
        yield return new WaitForSeconds(1f);
        if (animator)
        {
            animator.SetBool("Hit", false);
        }

        bool isDead = currentUnit.TakeDamage(enemyUnit.damage / nTargets);
        if (isDead)
        {
            nAlly--;
            allAlly.Remove(currentUnit);
            if (currentUnit.unitClass == UnitClass.Warrior)
            {
                allyWarriors.Remove(currentUnit);
                nWarriors--;
            }
            else if (currentUnit.unitClass == UnitClass.Shooter)
            {
                allyShooters.Remove(currentUnit);
                nShooters--;
            }
            else
            {
                allyWizards.Remove(currentUnit);
                nWizards--;
            }
            Destroy(currentUnit.gameObject);
        }
    }

    void PlayerTurn() 
    {
        HUD.ShowHand();
        HUD.ChangeIcon(true);

        isDraggable = true;
        if (multicard != 1)
        {
            deck.DrawCard();

            if (ataqueCargado)
            {
                //yield return new WaitForSeconds(1f);
                this.attack(1, ataqueCargadoRatio);
                ataqueCargado = false;
            }
        }
    }

    public void cardAction(int id)
    {
        if (discard)
        {
            discard = false;
            deck.DrawCard();
            deck.DrawCard();

            if (multicard == 1)
            {
                return;
            }

            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
            return;
        }
            
        if (multicard == 1)
        {
            multicard = 0;
        }



        if (multicard == 2)
        {
            multicard = 1;
        }

        bool isDead = false;
        switch (id){
            case 0:
                this.attack(3);
                break;
            case 1://ATAQUE RAPIDO
                this.attack(1, 1f);
                break;
            case 2://DESCARTAR
                discard = true;
                break;
            case 3://ATAQUE CARGADO
                ataqueCargado = true;
                break;
            case 4://ATAQUE NORMAL
                this.attack(0);
                break;
            case 5://DEFENSA
                defend = true;
                break;
            case 6://ROBAR
                deck.DrawCard();
                break;
            case 7://AUMENTO ATAQUE
                this.buffAlly(0);
                break;
            case 8://AUMENTO DEFENSA
                this.buffAlly(1);
                break;
            case 9://MAREA
                multicard = 2;
                break;
            default:
                break;
        }
        if (multicard == 1)
        {
            return;
        }

        if (isDead)
        {
            state = BattleState.WON;
        }
        else
        {
            if (!discard)
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
            
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
                //Poner animacion de atacar en warrior
                Animator animator = warrior.gameObject.GetComponentInChildren<Animator>();
                StartCoroutine(attackAnimation(animator));

                damage += warrior.damage;
            }
        }
        else if (clase == 1) //Shooters
        {
            //unitsIndex = 3;
            foreach (Unit shooter in allyShooters)
            {
                Animator animator = shooter.gameObject.GetComponentInChildren<Animator>();
                StartCoroutine(attackAnimation(animator));

                damage += shooter.damage;
            }
        }
        else {
            damage = shipDamage;
        }

        //Poner animación de golpeo en enemigo
        Animator enemyAlly = enemyUnit.gameObject.GetComponentInChildren<Animator>();
        StartCoroutine(hitEnemyAnimation(enemyAlly, damage, mlt));

        /*bool isDead = enemyUnit.TakeDamage((int)(damage * mlt));
        Debug.Log(enemyUnit.currentHP);

        if (isDead)
        {
            state = BattleState.WON;
            Debug.Log("Victoria");
            StartCoroutine("ReturnToMap");
        }*/

    }

    public void buffAlly(int type)
    {
        if (type == 0)
        {
            foreach (Unit unit in allAlly)
            {
                unit.buffAttack(buffAttackRatio);
            }
        }
        else if (type == 1)
        {
            foreach (Unit unit in allAlly)
            {
                unit.buffDefense(buffDefenseRatio);
            }
        }
    }

    IEnumerator ReturnToMap()
    {
        float a = 0;

        while (a <= 1)
        {
            a += Time.deltaTime * 0.75f;
            fade.color = new Color(0, 0, 0, a);
            yield return null;
        }
        a = 1;
        fade.color = new Color(0, 0, 0, a);

       
        if (worldmap)
        {
            worldmap.SetActive(true);

            SceneManager.UnloadSceneAsync(MainConstants.INDEX_SCENE_BATTLE);
        }
        
        yield return null;
    }

}
