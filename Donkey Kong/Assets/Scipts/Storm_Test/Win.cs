using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField] GameObject UIwin;
    [SerializeField] GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        UIwin.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIwin.SetActive(true);
        Time.timeScale = 0f;
        UI.SetActive(false);
    }
}
