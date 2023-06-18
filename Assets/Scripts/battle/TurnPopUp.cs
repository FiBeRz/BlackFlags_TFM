using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnPopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;

    private float disappearTimer;

    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        textColor = textMesh.color;
    }

    public void Setup(string mensage)
    {
        textMesh.SetText(mensage);
        disappearTimer = 1f;
    }

    private void Update() 
    {
        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0)
        {
            //float disappearSpeed = 3f;
           // textColor.a -= disappearSpeed * Time.deltaTime;
           // textMesh.color = textColor;

            if (textColor.a < 0)
            {
                //Destroy(gameObject);
            }
        }
    }
}
