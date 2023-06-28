using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class reputationPopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;

    private float disappearTimer;
    private float moveYSpeed = 4f;
    private float moveXSpeed = -7f;

    void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int reputationPoints)
    {
        textMesh.SetText(reputationPoints.ToString());
        if (reputationPoints < 0)
        {
            textColor = Color.red;
        }
        else
        {
            textColor = Color.green;
        }
        
        disappearTimer = 1f;
        textMesh.color = textColor;
    }

    private void Update()
    {
        transform.position += new Vector3(moveXSpeed, moveYSpeed) * Time.deltaTime;

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
