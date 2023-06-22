using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorTutorial : MonoBehaviour
{
    Renderer rend;
    [SerializeField] public int mostrarEn = 1;
    [SerializeField] public int borrarEn = 2;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
     if(rend.enabled == false)
        {
          if(  GameManager.Instance.getTutorialGroup() >= mostrarEn)
            {
                rend.enabled = true;
            }
        }

        if (GameManager.Instance.getTutorialGroup() >= borrarEn)
            Destroy(gameObject);
    }
}
