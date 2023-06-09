using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueTutorialButtonScriptIsland : MonoBehaviour
{
    public void continueEvent()
    {
        GameManager.Instance.changeTutorialIndex();
    }
}
