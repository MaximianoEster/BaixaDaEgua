using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletVespa : MonoBehaviour
{

    public float velocidade = 5.5f;
    public int dano = 2;
    public float destruirTiro = 5.5f;
    protected Vespa player;
    protected bool canRotate;
    protected Transform alvo;
    protected float alvoDistancia, distanciaMinima;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destruirTiro);
        alvo = FindObjectOfType<playerController>().transform;
        player = FindObjectOfType<Vespa>();
        distanciaMinima = 2;
        canRotate = true;

    }

    // Update is called once per frame
    void Update()
    {
        alvoDistancia = transform.position.x - alvo.position.x;

        if (canRotate)
        {
            if (alvoDistancia > 0)
            {
                transform.Rotate(new Vector3(0, 0, 225));
                canRotate = false;
            }
            if (alvoDistancia < 0)
            {
                transform.Rotate(new Vector3(0, 0, 315));
                canRotate = false;
            }
        }

        transform.Translate(Vector3.right * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Inimigo outroInimigo = other.GetComponent<Inimigo>();
        if (outroInimigo != null)
        {
            outroInimigo.recebeDano(dano);
        }
    }
}
