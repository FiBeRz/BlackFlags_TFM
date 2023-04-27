using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class eventsScript : MonoBehaviour
{
    [SerializeField] private Button[] childrenButtons;
    [SerializeField] private Button[] branchButtons; 
    [SerializeField] private int eventType;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void eventClick()
    {
        if (this.GetComponent<Button>())
        {
            this.GetComponent<Button>().interactable = false;
        }

        for (int i=0; i<childrenButtons.Length; i++)
        {
            childrenButtons[i].interactable = true;
        }

        for (int i = 0; i < branchButtons.Length; i++)
        {
            branchButtons[i].interactable = false;
        }

        launchEvent();
    }

    private void launchEvent()
    {
        if (eventType == MainConstants.EVENT_UNKNOWN)
        {
            executeUnknownEvent();
        }
        else if (eventType == MainConstants.EVENT_BLESS)
        {
            executeBlessEvent();
        }
        else if (eventType == MainConstants.EVENT_CHEST)
        {
            executeChestEvent();
        }
        else if (eventType == MainConstants.EVENT_OASIS)
        {
            executeOasisEvent();
        }
        else if (eventType == MainConstants.EVENT_SHARK)
        {
            executeSharkEvent();
        }
        else if (eventType == MainConstants.EVENT_RESCUE)
        {
            executeRescueEvent();
        }
        else if (eventType == MainConstants.EVENT_BATTLE)
        {
            executeBattleEvent();
        }
        else if (eventType == MainConstants.EVENT_BOSS)
        {
            executeBossEvent();
        }
    }

    private void executeUnknownEvent()
    {
        Debug.Log("Ejecutando evento desconocido");
    }

    private void executeBlessEvent()
    {
        Debug.Log("Ejecutando evento bendición-maldición");
    }

    private void executeChestEvent()
    {
        Debug.Log("Ejecutando evento cofre");
    }

    private void executeOasisEvent()
    {
        Debug.Log("Ejecutando evento oasis");
    }

    private void executeSharkEvent()
    {
        Debug.Log("Ejecutando evento tiburón");
    }

    private void executeRescueEvent()
    {
        Debug.Log("Ejecutando evento rescate");
    }

    private void executeBattleEvent()
    {
        Debug.Log("Ejecutando evento combate");
    }

    private void executeBossEvent()
    {
        Debug.Log("Ejecutando evento boss");
    }
}
