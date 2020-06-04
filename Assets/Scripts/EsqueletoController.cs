using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsqueletoController : InimigoController
{
    private int enemyState = 1;
    
    public float speed;
    private float minX;
    private float maxX;
    public float correMax;
    protected override void Start()
    {
        base.Start();
        minX = transform.position.x;
        maxX = transform.position.x + correMax;
    } 
    
    // Update is called once per frame
    protected override void Update()
    {
        Physics2D.IgnoreLayerCollision(10,10);
        base.Update();
        enemyMoviment();
        confuse();
    }

    public void enemyMoviment()
    {
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (vida > 0 && tiroCount > retornoNormal){
          // Move para a DIREITA
            if(enemyState == 1)
            {
                anim.SetBool("Walk", true);
                rigid.velocity = new Vector2(speed, rigid.velocity.y);
                if (transform.position.x  > maxX)
                {
                    enemyState = 2; 
                }
            }
            
            // Espera na DIREITA
            else if (enemyState == 2)
            {
                anim.SetBool("Walk", false);
                enemyState =3; 
                transform.Rotate(0f, 180f,0f);
            }

            // Move para a ESQUERDA
            else if (enemyState == 3)
            {
                anim.SetBool("Walk", true);
                rigid.velocity = new Vector2(-speed, rigid.velocity.y);
                if (transform.position.x  < minX)
                {
                    enemyState = 4;      
                } 
            }

            // Espera na ESQUERDA
            else if (enemyState == 4)
            {
                anim.SetBool("Walk", false);
                enemyState = 1; 
                transform.Rotate(0f, 180f,0f);
            }
        }
        if (tiroCount < retornoNormal)
        {
            rigid.velocity = new Vector2(0, rigid.velocity.y);
        }
    }    
}
