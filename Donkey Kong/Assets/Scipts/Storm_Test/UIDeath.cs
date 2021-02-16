using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeath : MonoBehaviour
{

    [SerializeField] GameObject UI;
    //public bool visible = false;
    private m_PlayerScribtableObject Health;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        Health = FindObjectOfType<m_PlayerScribtableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.m_Health <= 0)
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
