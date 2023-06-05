using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    public GameObject Hand;
    private Transform posHand;
    public GameObject HiddenPlace;
    private Transform posHidden;

    private Vector3 original;

    private float speed = 2f;

    private bool hideHand = false;

    void Start()
    {
        posHand = Hand.transform;
        original = posHand.position;
        posHidden = HiddenPlace.transform;
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

    public GameObject preFabDamagePopUp;

    public void HideHand() 
    {
        hideHand = true;
    }

    public void ShowHand() 
    {
        hideHand = false;
    }

}
