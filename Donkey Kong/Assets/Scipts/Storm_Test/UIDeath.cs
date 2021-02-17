using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeath : MonoBehaviour
{

    [SerializeField] GameObject UI;
    //public bool visible = false;
    private PlayerController m_playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        m_playerHealth = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerHealth.currentHealth <= 0)
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
