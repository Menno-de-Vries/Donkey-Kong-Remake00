using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterTon : MonoBehaviour
{
    //Int
    [SerializeField] private int movingSpeed;

    private void Start()
    {
        //Zorgt voor dat de pijl de goede kant op wijst van waar hij de ton naar toe schiet
        if (transform.position.x < 0)
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 180, transform.rotation.w);
        }
        else
        {
            transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 0, transform.rotation.w);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile_D") && transform.position.x < 0)
        {
            //Als de booster aan de linkerkant van de level staat schiet hij de ton naar rechts
            print("go");
            Vector2 right = Vector2.right * movingSpeed;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(right, ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Projectile_D") && transform.position.x > 0)
        {
            //Als de booster aan de rechterkant van de level staat schiet hij de ton naar links
            print("go");
            Vector2 right = Vector2.left * movingSpeed;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(right, ForceMode2D.Impulse);
        }

    }

}
