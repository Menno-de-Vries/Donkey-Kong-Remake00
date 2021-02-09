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

    private void Update()
    {
        JumpNow();
    }

    private void FixedUpdate()
    {
        m_playerstats.axis.x = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3 (m_playerstats.axis.x * m_playerstats.m_Speed * Time.deltaTime, rb.velocity.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_playerstats.JumpAllowed = true;
        }
    }


    private void JumpNow()
    {
        Vector2 Up = new Vector2(0, transform.position.y + m_playerstats.m_Jumphight);
        if (m_playerstats.JumpAllowed == true && Input.GetKey(KeyCode.Space))
        {
            print("jump");
            rb.AddForce(Up);
            m_playerstats.JumpAllowed = false;
        }
    }

}
