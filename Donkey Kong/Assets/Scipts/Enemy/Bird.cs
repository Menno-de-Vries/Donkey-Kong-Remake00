using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float speed = 5f;
    public int checker;
   

    // Start is called before the first frame update
    void Start()
    {
        checker = Random.Range(-15, -40);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if (transform.position.x < checker)
        {
            Vector2 teleportpos = new Vector2(15, Random.Range(-3, 4));
            checker = Random.Range(-15, -40);
            transform.position = teleportpos;
        }
    }
}
