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

    public UnitClass unitClass;

    
    // LO SUYO SERIA QUE LAS UNIDADES TUVIESEN UN ID, Y AL MORIR DEVOLVIESE LA FUNCION EL ID DE LA UNIDAD PARA TRABAJAR MEJOR
    // POR AHORA NO HACE FALTA PERO ESTÁ APUNTADO
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;

    }
}
