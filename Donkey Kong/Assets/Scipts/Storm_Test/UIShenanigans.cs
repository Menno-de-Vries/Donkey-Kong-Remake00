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
        if (Input.GetKeyUp("escape") && visible == false) //Momenteel wordt dit scherm geactiveerd via de Esc toets.
        {
            visible = true;
            UI.SetActive(true);
            
        }
        else if (Input.GetKeyUp("escape") && visible == true)
        {
            visible = false;
            UI.SetActive(false);
        }
        
    }
}
