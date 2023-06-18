using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mapBoatScript : MonoBehaviour
{
    [SerializeField] private float speed = 40f;
    [SerializeField] private Image startWaypoint;

    void Start()
    {
        GameManager.Instance.setBoatPosition(startWaypoint.GetComponent<RectTransform>().anchoredPosition);
        this.GetComponent<RectTransform>().anchoredPosition = startWaypoint.GetComponent<RectTransform>().anchoredPosition;
    }

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
