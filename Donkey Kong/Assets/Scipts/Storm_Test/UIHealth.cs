using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealth : MonoBehaviour
{

    [SerializeField] GameObject HP1;
    [SerializeField] GameObject HP2;
    [SerializeField] GameObject HP3;
    private PlayerController m_playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        m_playerHealth = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerHealth.currentHealth <= 2)
        {
            HP3.SetActive(false);
        }

        if (m_playerHealth.currentHealth <= 1)
        {
            HP2.SetActive(false);
        }

        if (m_playerHealth.currentHealth < 1)
        {
            HP1.SetActive(false);
        }
    }
}
