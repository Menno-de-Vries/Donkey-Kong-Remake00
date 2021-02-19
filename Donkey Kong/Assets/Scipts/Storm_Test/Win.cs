using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField] GameObject UIwin;
    [SerializeField] GameObject UI;
    private PlayerController m_player;


    // Start is called before the first frame update
    void Start()
    {
        UIwin.SetActive(false);
        m_player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIwin.SetActive(true);
        AudioSource.PlayClipAtPoint(m_player.sounds[4], transform.position);
        Time.timeScale = 0f;
        UI.SetActive(false);
    }
}
