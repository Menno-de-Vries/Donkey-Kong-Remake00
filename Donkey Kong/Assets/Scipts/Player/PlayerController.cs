using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    //ScribtableObject
    public m_PlayerScribtableObject m_playerstats;

    //RigidBody
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        m_playerstats.axis.x = Input.GetAxisRaw("Horizontal");

        rb.velocity = m_playerstats.axis * m_playerstats.m_Speed * Time.deltaTime;
    }
}
