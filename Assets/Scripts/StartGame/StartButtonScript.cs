using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonScript : MonoBehaviour
{
    public void startGame()
    {
        GameManager.Instance.changeToIslandScene();
    }
}
