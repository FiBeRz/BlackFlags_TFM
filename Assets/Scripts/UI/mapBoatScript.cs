using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapBoatScript : MonoBehaviour
{
    [SerializeField] private float speed = 40f;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isMovingBoat()){
            moveToPoint();
        }
    }

    private void moveToPoint()
    {
        Vector2 point = GameManager.Instance.getBoatPosition();
        this.GetComponent<RectTransform>().anchoredPosition = Vector2.MoveTowards(this.GetComponent<RectTransform>().anchoredPosition, point, speed * Time.deltaTime);

        if (Vector2.Distance(this.GetComponent<RectTransform>().anchoredPosition, point) < 0.1f)
        {
            GameManager.Instance.stopBoat();
        }
    }
}
