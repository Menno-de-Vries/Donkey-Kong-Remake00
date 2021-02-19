using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Playerstate
{ idle = 0, walking, ladder }

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    //ScribtableObject
    public m_PlayerScribtableObject m_playerstats;

    //RigidBody
    private Rigidbody2D rb;

    //Scripts
    private GameController controller;

    //Animator
    private Animator anime;

    //Enum
    public Playerstate playerState;

    //Int
    public int currentHealth;

    //GameObject
    [SerializeField] private GameObject[] swords;

    //Float
    private float timer;

    //Bool
    [SerializeField] private bool swordAttackIsPossible = false;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        currentHealth = m_playerstats.m_Health;
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        controller = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        JumpNow();
        RotatePlayer();
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -6, 9), Mathf.Clamp(transform.position.y, -11f, 20f));
        SwordAttack();
        Debug.Log(currentHealth);
    }

    private void FixedUpdate()
    {
        m_playerstats.axis.x = Input.GetAxisRaw("Horizontal");
        m_playerstats.axis.y = Input.GetAxisRaw("Vertical");

        //Voor de beweging met als de player en of er niet of wel collision is met een trigger van de ladder
        if (m_playerstats.m_GoingUpTheLadder == false)
        {
            rb.velocity = new Vector3(m_playerstats.axis.x * m_playerstats.m_Speed * Time.deltaTime, rb.velocity.y, 0);
        }
        else
        {
            rb.velocity = new Vector3(m_playerstats.axis.x * m_playerstats.m_Speed * Time.deltaTime, m_playerstats.axis.y * m_playerstats.m_Speed * Time.deltaTime, 0);
        }

        WalkingOrNot();

    }

    #region Animation
    private void WalkingOrNot()
    {
        if (m_playerstats.axis.x > 0 && m_playerstats.m_GoingUpTheLadder != true || m_playerstats.axis.x < 0 && m_playerstats.m_GoingUpTheLadder != true )
        {
            SetPlayerState(Playerstate.walking);
        }
        else if (m_playerstats.axis.x == 0 && m_playerstats.m_GoingUpTheLadder != true)
        {
            SetPlayerState(Playerstate.idle);
        }
    }
    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            SetPlayerState(Playerstate.ladder);
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
            SetPlayerState(Playerstate.idle);
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
            //Als de ton in aanraking komt met de player krijgt de player damage en word de ton gedestroyed
            TakeDamage(1);
            Destroy(collision.gameObject);
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
            m_playerstats.m_GoingUpTheLadder = false;
            m_playerstats.JumpAllowed = false;
        }
    }
    #endregion

    #region Rotate with Movement
    private void RotatePlayer()
    {
        //Welke kant de player moet op kijken
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
        return currentHealth -= damage;
    }
    #endregion

    public void SetPlayerState(Playerstate state)
    {
        playerState = state;
        anime.SetInteger("PlayerState", (int)playerState);
    }

    #region Sword Attack

    private float waitForSeconds = 0;

    private void SwordAttack()
    {
        if (swordAttackIsPossible == true)
        {
            timer += Time.deltaTime;
            waitForSeconds += Time.deltaTime;
        }

        if (swordAttackIsPossible == true && waitForSeconds > 0.2f)
        {
            SwordToggle();
            waitForSeconds = 0;
        }

        if (timer >= 4)
        {
            SwordOff();
            timer = 0;
            swordAttackIsPossible = false;
        }

    }

    private void SwordToggle()
    {
        swords[0].SetActive(!swords[0].activeSelf);
    }

    private void SwordOff()
    {
        swords[0].SetActive(false);
    }

    #endregion

}
