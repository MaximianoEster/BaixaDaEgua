using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : Inimigo
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (alvoDistancia < distanciaAtaque)
        {

            transform.position = Vector3.MoveTowards(transform.position, alvo.transform.position, velocidade * Time.deltaTime);
        }

    }
}
