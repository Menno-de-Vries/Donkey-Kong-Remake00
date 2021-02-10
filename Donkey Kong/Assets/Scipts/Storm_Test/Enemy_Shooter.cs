using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : MonoBehaviour
{
    public GameObject Projectile;
    private float Teller;
    private Vector3 Spawn;
    [SerializeField] float Tijd;


    // Start is called before the first frame update
    void Start()
    {
        Spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Teller += Time.deltaTime;

        if(Teller >= Tijd)
        {
            Instantiate(Projectile, Spawn, Quaternion.identity);
            Teller = 0;
        }
         

    }
}
