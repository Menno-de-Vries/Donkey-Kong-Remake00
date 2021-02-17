using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeath : MonoBehaviour
{

    [SerializeField] GameObject UI;
    //public bool visible = false;
    private m_PlayerScribtableObject m_playerHealth;

    // Start is called before the first frame update


    private void Awake()
    {
        m_playerHealth = FindObjectOfType<m_PlayerScribtableObject>();
    }
    void Start()
    {
        UI.SetActive(false);
        //m_playerHealth = FindObjectOfType<m_PlayerScribtableObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerHealth.m_Health <= 0)
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
