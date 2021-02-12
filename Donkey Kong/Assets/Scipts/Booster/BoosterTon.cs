using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTon : MonoBehaviour
{
    //Int
    [SerializeField] private int movingSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile_D") && transform.position.x < 0)
        {
            print("go");
            Vector2 right = Vector2.right * movingSpeed;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(right, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Projectile_D") && transform.position.x > 0)
        {
            print("go");
            Vector2 right = Vector2.left * movingSpeed;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(right, ForceMode2D.Impulse);
        }

    }

}
