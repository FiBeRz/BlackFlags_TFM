using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorPirate : MonoBehaviour
{
    [SerializeField]
    Renderer rend;
    [SerializeField]
    private bool killOnPier = false, killOnMap = false, killOnBoat = false;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rend.enabled == false)
        { 


        if (killOnBoat && killOnPier && killOnBoat)
        {
            if (GameManager.Instance.pierPirateIndex > 0 
                    && GameManager.Instance.hasBoat
                    && GameManager.Instance.hasMap)
            {
                rend.enabled = true;
            }
        }
        else if(killOnBoat && GameManager.Instance.pierPirate)
            {
                rend.enabled = true;
            }
            else if (killOnMap && GameManager.Instance.pierPirate)
            {
                rend.enabled = true;
            }
        }

        if (GameManager.Instance.pierPirateIndex > 0 && killOnPier && !killOnMap)
            Destroy(gameObject);

        if (GameManager.Instance.hasMap && killOnMap && !killOnBoat)
            Destroy(gameObject);

        if (GameManager.Instance.hasBoat  && killOnBoat && !killOnMap)
            Destroy(gameObject);
    }
}
