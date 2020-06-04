using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoController : MonoBehaviour
{
    public int vida = 1, numCoin;
    public GameObject coin;

    protected int countVida;
    protected float alvoDistancia;
    protected float distanciaMinima;
    protected int tiroCount = 101;
    protected int retornoNormal = 150;
    protected bool canMorrer, oneTime;
    protected Rigidbody2D rigid;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected Transform alvo;
    protected playerController pos;
    protected BoxCollider2D colisor;
    [HideInInspector] public bool tomouDano;
    protected virtual void Start()
    {
        countVida = 0;
        oneTime = true;
        sprite = GetComponent<SpriteRenderer>();
        alvo = FindObjectOfType<playerController>().transform;
        pos = FindObjectOfType<playerController>();
        colisor = GetComponent<BoxCollider2D>();
        distanciaMinima = 2;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        tiroCount = retornoNormal;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        alvoDistancia = transform.position.x - alvo.position.x;
        tiroCount++;
        morreu();
        if (tomouDano)
        {
            StartCoroutine(recebendoDanoCoRoutine());
        }
        if (vida <= 0)
        {
            if (oneTime)
            {
                coins(numCoin);
                oneTime = false;
            }
        }
    }

    IEnumerator recebendoDanoCoRoutine()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
        tomouDano = false;
    }

    public void coins(int num)
    {
        for (int a = 0; a < num; a++)
        {
            Instantiate(coin, transform.position, Quaternion.identity);
        }
    }
    public void morreu()
    {

        if (vida <= 0)
        {
            //Instantiate(moeda, transform.position, transform.rotation);
            if (countVida < 2)
            {
                anim.SetBool("morreu", true);
            }
            countVida++;
            rigid.gravityScale = 1;
            rigid.velocity = new Vector2(0, rigid.velocity.y);
            colisor.enabled = true;
            if (canMorrer)
            {
                rigid.gravityScale = 0;
                rigid.velocity = new Vector2(0, 0);
                colisor.enabled = false;
            }
            if (canMorrer && countVida > 50)
            {
                anim.SetBool("morreu", false);
                Destroy(gameObject, 5f);
            }
        }
    }
    public void confuse()
    {
        if (vida > 0)
        {
            if (Mathf.Abs(alvoDistancia) < distanciaMinima && pos.dashOn)
            {
                if (pos.getPos())
                {
                    anim.SetBool("confuse1", true);
                }
                else
                {
                    anim.SetBool("confuse", true);
                }
                rigid.velocity = new Vector2(0, 0);
                tiroCount = 0;
            }
            if (tiroCount > retornoNormal)
            {
                anim.SetBool("confuse", false);
                anim.SetBool("confuse1", false);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("plataforma"))
        {
            canMorrer = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tiro"))
        {
            vida -= 1;
            tomouDano = true;
        }
    }
}