using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locatePlayer : MonoBehaviour
{
    [SerializeField] GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.setPlayer(playerGO);
        Debug.Log("jugador creado");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
