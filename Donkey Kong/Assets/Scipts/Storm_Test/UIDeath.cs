using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeath : MonoBehaviour
{

    [SerializeField] GameObject UI;
    [SerializeField] GameObject help;
    //public bool visible = false;
    private PlayerController m_player;

    // Start is called before the first frame update
    void Start()
    {
        UI.SetActive(false);
        m_player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_player.currentHealth <= 0)
        {
            UI.SetActive(true);
            Time.timeScale = 0f;
            AudioSource.PlayClipAtPoint(m_player.sounds[4], help.transform.position);
        }
    }

   
}
