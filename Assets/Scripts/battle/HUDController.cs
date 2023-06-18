using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public GameObject Hand;
    private Transform posHand;
    public GameObject HiddenPlace;
    private Transform posHidden;

    private Vector3 original;

    private float speed = 2f;

    private bool hideHand = false;

    public GameObject preFabDamagePopUp;
    public GameObject EnemyIcon;
    public GameObject AllyIcon;

    private Image enemyBackground;
    private Image enemyIcon;
    private Image allyBackground;
    private Image allyIcon;

    void Start()
    {
        posHand = Hand.transform;
        original = posHand.position;
        posHidden = HiddenPlace.transform;

        enemyBackground = EnemyIcon.GetComponent<Image>();
        enemyIcon = EnemyIcon.transform.GetChild(0).GetComponent<Image>();

        allyBackground = AllyIcon.GetComponent<Image>();
        allyIcon = AllyIcon.transform.GetChild(0).GetComponent<Image>();
    }

    void Update()
    {
        if (hideHand)
        {
            posHand.position = Vector3.Lerp(posHand.position, posHidden.position,  speed * Time.deltaTime);
        }
        else 
        {
            posHand.position = Vector3.Lerp(posHand.position, original, speed * Time.deltaTime);
        }
    }

    public DamagePopUp ShowDamage(Vector3 position, int damage)
    {
        GameObject damagePopUpTransform = Instantiate(preFabDamagePopUp, position + new Vector3(-1,1,0), Quaternion.identity);

        DamagePopUp damagePopUp = damagePopUpTransform.GetComponent<DamagePopUp>();
        damagePopUp.Setup(damage);

        return damagePopUp;
    }

    // bool @turno, true si aliado false si enemigo
    public void ChangeIcon(bool turno)
    {
        if (turno) 
        {
            var tempColor = enemyBackground.color;
            tempColor.a = 0.5f;
            enemyBackground.color = tempColor;

            tempColor = enemyIcon.color;
            tempColor.a = 0.5f;
            enemyIcon.color = tempColor;

            tempColor = allyBackground.color;
            tempColor.a = 1f;
            allyBackground.color = tempColor;

            tempColor = allyIcon.color;
            tempColor.a = 1f;
            allyIcon.color = tempColor;

        }
        else 
        {
            var tempColor = enemyBackground.color;
            tempColor.a = 1f;
            enemyBackground.color = tempColor;

            tempColor = enemyIcon.color;
            tempColor.a = 1f;
            enemyIcon.color = tempColor;

            tempColor = allyBackground.color;
            tempColor.a = 0.5f;
            allyBackground.color = tempColor;

            tempColor = allyIcon.color;
            tempColor.a = 0.5f;
            allyIcon.color = tempColor;
        }

    }

    public void HideHand() 
    {
        hideHand = true;
    }

    public void ShowHand() 
    {
        hideHand = false;
    }

}
