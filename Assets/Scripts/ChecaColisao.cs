using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChecaColisao : MonoBehaviour
{
    public PadreSet2 padre;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<InimigoController>().vida = 0;
        }
    }
}
