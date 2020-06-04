using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionCheck : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("limitador"))
        {
            Debug.Log("true");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("limitador"))
        {
            Debug.Log("true");
        }
    }
}
