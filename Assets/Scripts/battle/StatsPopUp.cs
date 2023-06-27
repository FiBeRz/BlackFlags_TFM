using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatsPopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;

    private float disappearTimer;
    private float moveYSpeed = 3f;

    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
        textColor = textMesh.color;
    }

    public void Setup(int damage)
    {
        textMesh.SetText(damage.ToString());
        disappearTimer = 1f;
    }

    public void ShowBuff(string buff)
    {
        textMesh.SetText(buff);
        disappearTimer = 1f;
    }

    private void Update() 
    {
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;

        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
