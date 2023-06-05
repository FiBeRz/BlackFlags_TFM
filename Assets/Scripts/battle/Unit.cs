using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitClass { Warrior, Shooter, Wizard };

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int defense;

    public UnitClass unitClass;

    private HUDController HUDController;


    [SerializeField] private HealthBar _healthBar;

    void Awake() 
    {
        HUDController = GameObject.Find("HUDController").GetComponent<HUDController>();

    }

    public void buffAttack(float ratio) 
    {
        this.damage += (int)(this.damage * ratio);
    }

    public void buffDefense(float ratio)
    {
        this.defense += (int)(this.defense * ratio);
    }

    // LO SUYO SERIA QUE LAS UNIDADES TUVIESEN UN ID, Y AL MORIR DEVOLVIESE LA FUNCION EL ID DE LA UNIDAD PARA TRABAJAR MEJOR
    // POR AHORA NO HACE FALTA PERO ESTÁ APUNTADO
    public bool TakeDamage(int dmg)
    {
        int currentDMG = dmg - defense;

        if( currentDMG < 0) currentDMG = 0;

        currentHP -= currentDMG;

        _healthBar.UpdateHealthBar(maxHP, currentHP);
        HUDController.ShowDamage(this.transform.position,currentDMG);

        if (currentHP <= 0)
            return true;
        else
            return false;

    }
}
