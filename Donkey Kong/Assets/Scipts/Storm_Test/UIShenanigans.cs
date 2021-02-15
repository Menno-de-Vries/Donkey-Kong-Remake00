using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShenanigans : MonoBehaviour
{

    [SerializeField] GameObject UI;
    public bool visible = false;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("escape") && visible == false) //Momenteel wordt dit scherm geactiveerd via de Esc toets.e
        {
            //visible = true;
            //UI.SetActive(true);
            //Time.timeScale = 0f;
            Menu_ON();
            
        }
        else if (Input.GetKeyUp("escape") && visible == true)
        {
            //visible = false;
            //UI.SetActive(false);
            //Time.timeScale = 1f;
            Menu_OFF();
        }
        
    }

    public void Menu_ON()
    {
        visible = true;
        UI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Menu_OFF()
    {
        visible = false;
        UI.SetActive(false);
        Time.timeScale = 1f;
    }
}
