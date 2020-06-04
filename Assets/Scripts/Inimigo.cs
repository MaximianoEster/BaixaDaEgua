using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public int vida;
    public float velocidade;
    public float distanciaAtaque;
    public GameObject moeda;
    public GameObject morteAnimacao;

    protected Animator anim;
    protected bool viradoDireita = true;
    protected Transform alvo;
    protected float alvoDistancia;
    protected Rigidbody2D rb2d;
    protected SpriteRenderer sprite;
    protected int countVida;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        alvo = FindObjectOfType<playerController>().transform;
        rb2d = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        alvoDistancia = transform.position.x - alvo.position.x;
        Animator anim = GetComponent<Animator>();
        if (vida <= 0)
        {
            Rigidbody2D rigid = GetComponent<Rigidbody2D>();
            rigid.velocity = new Vector2(0, 0);
            anim.SetBool("morreu", true);
            countVida ++;
            if (countVida > 50){
                anim.SetBool("morreu", false);
                CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
                collider.enabled = false;
                rigid.gravityScale = 0;
                Destroy(gameObject, 20f);
            } 
        }
    }

    protected void Flip()
    {
        viradoDireita = !viradoDireita;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void recebeDano(int dano)
    {
        vida -= dano;
        if(vida <= 0)
        {
            Instantiate(moeda, transform.position, transform.rotation);
            Instantiate(morteAnimacao, transform.position, transform.rotation);

            gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(recebendoDanoCoRoutine());
        }
    }
    IEnumerator recebendoDanoCoRoutine()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white; 
    }
}
