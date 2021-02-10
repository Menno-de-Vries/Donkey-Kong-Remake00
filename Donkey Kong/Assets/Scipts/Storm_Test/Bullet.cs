using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float thrust = 10.0f;
    public Rigidbody2D rb2D;
    [SerializeField] float Tijd;
    private float Teller;


    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        //rb2D.AddForce(thrust, 0, 0, ForceMode.Impulse);
        rb2D.AddForce(transform.right * thrust, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        //rb2D.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        Teller += Time.deltaTime;
        if (Teller >= Tijd)
        {
            Destroy(gameObject);
        }
    }
}
