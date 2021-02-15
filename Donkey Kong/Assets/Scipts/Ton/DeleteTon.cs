using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTon : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deleter"))
        {
            //Om tonnen die de eind vam de map behalen te deleten zo dat de game niet crashed als er te veel tonnen komen
            Destroy(gameObject);
        }
    }
}
