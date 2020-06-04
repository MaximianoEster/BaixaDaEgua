using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float velocidade = 5.5f;
    public int dano = 2;
    public float destruirTiro = 1.5f;
    protected playerController player;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Animator>().SetBool("colidiu", false);
        Destroy(gameObject, destruirTiro);
        player = FindObjectOfType<playerController>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Destroy(gameObject, .2f);
            velocidade = 0f;
            GetComponent<Animator>().SetBool("colidiu", true);
            player.barraPadre.CurrentStamina2 += .1f;
        }
        if (other.CompareTag("plataforma"))
        {
            Destroy(gameObject, .2f);
            velocidade = 0f;
            GetComponent<Animator>().SetBool("colidiu", true);

        }
        if (other.CompareTag("barreira"))
        {
            Destroy(gameObject, .2f);
            velocidade = 0f;
            GetComponent<Animator>().SetBool("colidiu", true);

        }
        if (other.CompareTag("mulaBoss"))
        {
            other.GetComponent<MulaIA>().vidaBoss -= .3f;
            Destroy(gameObject, .2f);
            velocidade = 0f;
            GetComponent<Animator>().SetBool("colidiu", true);
        }
    }
}
