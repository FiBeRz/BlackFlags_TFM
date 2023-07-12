using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Silenciar : MonoBehaviour
{
    public Image botonIMG;
    public Sprite[] botones = new Sprite[2];
    GameManager managerRef;

    // Start is called before the first frame update
    void Start()
    {
       managerRef = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        if (managerRef.GetAudioEstatus())
        {

            botonIMG.sprite = botones[1];
        }
        else
        {

            botonIMG.sprite = botones[0];
        }

        managerRef.FijarVolumen();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            CambiarEstatusAudio();
    }


    // Update is called once per frame
    public void CambiarEstatusAudio()
    {
        bool statusAudio = managerRef.CambiarEstatus();

        if (statusAudio)
        {
       
            botonIMG.sprite = botones[1];
        }
        else
        {
            
            botonIMG.sprite = botones[0];
        }
    }
}
