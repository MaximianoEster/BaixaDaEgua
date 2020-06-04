using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int kick = 0;
    private int rotZ;
    private float countEstouro;
    private float tempoAtual;
    private CapsuleCollider2D capsule;

    public GameObject explosao;
    public AudioClip estouro;
    public bool shake, tomouDano;
    GameObject particle;

    protected CircleCollider2D circle;
    protected Animator anim;
    protected SpriteRenderer sprite;
    protected playerController player;
    void Start()
    {
        capsule = GetComponent<CapsuleCollider2D>();
        player = FindObjectOfType<playerController>();
        circle = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        capsule.enabled = false;
        tomouDano = false;
    }
    void Update()
    {
        countEstouro++;
        rotZ += 20;
        AudioSource audioSource = GetComponent<AudioSource>();
        Rigidbody2D tempBomb = GetComponent<Rigidbody2D>();
        if (tempBomb.velocity.x > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -rotZ);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, rotZ);
        }


        if (countEstouro < 2 && kick == 1)
        {
            shake = true;
            particle = Instantiate(explosao, transform.position, transform.rotation);
            Destroy(particle, 3f);
            audioSource.PlayOneShot(estouro, .4f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        circle.enabled = false;
        anim.enabled = false;
        sprite.enabled = false;
        Destroy(gameObject, 1f);
        capsule.enabled = true;
        countEstouro = 0;
        kick = 1;
        if (other.gameObject.CompareTag("Inimigo") && !tomouDano)
        {
            InimigoController vida = other.gameObject.GetComponent<InimigoController>();
            vida.vida -= 5;
            player.barraPadre.CurrentStamina2 += .2f;
            circle.enabled = false;
            anim.enabled = false;
            sprite.enabled = false;
            Destroy(gameObject, 1f);
            capsule.enabled = true;
            countEstouro = 0;
            kick = 1;
            tomouDano = true;
        }
        if (other.gameObject.CompareTag("mulaBoss"))
        {
            other.gameObject.GetComponent<MulaIA>().vidaBoss -= 2f;
            circle.enabled = false;
            anim.enabled = false;
            sprite.enabled = false;
            Destroy(gameObject, 1f);
            capsule.enabled = true;
            countEstouro = 0;
            kick = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tiro"))
        {
            circle.enabled = false;
            anim.enabled = false;
            sprite.enabled = false;
            Destroy(gameObject, 1f);
            capsule.enabled = true;
            countEstouro = 0;
            kick = 1;
        }
        if (other.gameObject.CompareTag("Inimigo") && !tomouDano)
        {
            tomouDano = true;
            kick = 2;
            countEstouro = 20;
            InimigoController vida = other.gameObject.GetComponent<InimigoController>();
            vida.vida -= 5;
            player.barraPadre.CurrentStamina2 += .2f;
        }
    }
}

