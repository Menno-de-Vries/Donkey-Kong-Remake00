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

    //Scripts
    private GameController controller;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        JumpNow();
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        m_playerstats.axis.x = Input.GetAxisRaw("Horizontal");
        m_playerstats.axis.y = Input.GetAxisRaw("Vertical");

        //Voor de beweging met als de player niet of wel collision heeft met een trigger van de ladder
        if (m_playerstats.m_GoingUpTheLadder == false)
        {
            rb.velocity = new Vector3(m_playerstats.axis.x * m_playerstats.m_Speed * Time.deltaTime, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(m_playerstats.axis.x * m_playerstats.m_Speed * Time.deltaTime, m_playerstats.axis.y * m_playerstats.m_Speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            m_playerstats.m_GoingUpTheLadder = true;
            m_playerstats.JumpAllowed = true;
        }

        if (collision.gameObject.CompareTag("Pointer"))
        {
            controller.Scoring(10);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            m_playerstats.m_GoingUpTheLadder = false;
        }
    }

    #region jumping
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            m_playerstats.JumpAllowed = true;
        }

        if (collision.gameObject.CompareTag("Projectile_D"))
        {
            TakeDamage(1);
        }

    }

    private void JumpNow()
    {
        //Om te kunnen jumpen
        Vector2 Up = new Vector2(0, transform.position.y + m_playerstats.m_Jumphight);
        if (m_playerstats.JumpAllowed == true && Input.GetKey(KeyCode.Space))
        {
            print("jump");
            rb.AddForce(Up);
            m_playerstats.JumpAllowed = false;
        }
    }
    #endregion

    #region Rotate with Movement
    private void RotatePlayer()
    {
        //Welke kan de player moet op kijken
        if (m_playerstats.axis.x > 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        }
        else if (m_playerstats.axis.x < 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        }
    }
    #endregion

    #region Taking Damage
    //Om damage te krijgen als de player de tonnen aan raakt
    private int TakeDamage(int damage)
    {
        return m_playerstats.m_Health -= damage;
    }
    #endregion
}
