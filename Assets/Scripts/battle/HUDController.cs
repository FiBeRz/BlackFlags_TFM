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
    public GameObject preFabAtkPopUp;
    public GameObject preFabDefPopUp;
    public GameObject preFabMessagePopUp;
    public GameObject preFabProtectionPopUp;
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

    public StatsPopUp ShowDamage(Vector3 position, int damage)
    {
        GameObject damagePopUpTransform = Instantiate(preFabDamagePopUp, position + new Vector3(-1,1,0), Quaternion.identity);

        StatsPopUp damagePopUp = damagePopUpTransform.GetComponent<StatsPopUp>();
        damagePopUp.Setup(damage);

        return damagePopUp;
    }

    public StatsPopUp ShowStatsBuff(Vector3 position, float buff, int type)
    {
        var text = "";

        switch (type){
            case 0:
                GameObject defBuffPopUpTransform = Instantiate(preFabDefPopUp, position + new Vector3(-1,1,0), Quaternion.identity);
                StatsPopUp defBuffPopUp = defBuffPopUpTransform.GetComponent<StatsPopUp>();
                if (buff > 0)
                {
                    text = "↑DEF";
                }
                else
                {
                    text = "↓DEF";
                }
                
                defBuffPopUp.ShowBuff(text);

                return defBuffPopUp;
            case 1:
                GameObject atkBuffPopUpTransform = Instantiate(preFabAtkPopUp, position + new Vector3(-1,1,0), Quaternion.identity);
                StatsPopUp atkBuffPopUp = atkBuffPopUpTransform.GetComponent<StatsPopUp>();
                text = "↑ATK";

                atkBuffPopUp.ShowBuff(text);

                return atkBuffPopUp;
            case 2:
                GameObject protectionPopUpTransform = Instantiate(preFabProtectionPopUp, position + new Vector3(-1,1,0), Quaternion.identity);
                StatsPopUp protectionPopUp = protectionPopUpTransform.GetComponent<StatsPopUp>();
                text = "⌂BLK";

                protectionPopUp.ShowBuff(text);

                return protectionPopUp;
            default:
                return null;
        }
    }

    public MessagePopUp ShowMessage(Vector3 position, string message)
    {

        GameObject atkMessPopUpTransform = Instantiate(preFabMessagePopUp, position + new Vector3(-1, 1, 0), Quaternion.identity);
        MessagePopUp atkMessPopUp = atkMessPopUpTransform.GetComponent<MessagePopUp>();

        atkMessPopUp.ShowMessage(message);

        return atkMessPopUp;
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
