using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosao : MonoBehaviour
{

    public int dano = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inimigo outroInimigo = other.GetComponent<Inimigo>();
        if (outroInimigo != null)
        {
            outroInimigo.recebeDano(dano);
        }


       
    }
}
