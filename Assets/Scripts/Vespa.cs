using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vespa : InimigoController
{
    public GameObject tiroVespaPrefab;
    public GameObject sombra;
    public float tiroTempo;
    public Transform tiroSpawnVespa;
    public float distanciaAtaque;
    public int state;
    protected int tiroCount2;
    protected bool onAir;
    protected float count2;
    protected float minY, originalPosX, originalPosY;
    protected float maxY;
    protected float vel;
    [HideInInspector] public bool atiraMaior;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        onAir = true;
        anim = GetComponent<Animator>();
        originalPosX = transform.position.x;
        originalPosY = transform.position.y;
        minY = transform.position.y - .5f;
        maxY = transform.position.y + .5f;
        vel = .04f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (vida > 0){
            posVespa();
            tiroCount2 ++;
            if (Mathf.Abs(alvoDistancia) < distanciaAtaque && tiroCount2 > 100)
            {
                anim.SetBool("atirando", true);
                tiroCount2 = 0;
                Atirando();
            }
            if (tiroCount2 > 20)
            {
                anim.SetBool("atirando", false);
            }
            if (alvoDistancia > 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (alvoDistancia < 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
        } if (vida <= 0)
        {
            rigid.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
            if (canMorrer)
            {
                sombra.SetActive(true);
            }
        }
    }

    void Atirando()
    {        
        GameObject tempTiro = Instantiate(tiroVespaPrefab, tiroSpawnVespa.position, tiroSpawnVespa.rotation);   
    }

    private void limiteVespa(float x, float y, float z, float vel)
    {
        Vector3 pos2 = new Vector3(x, y, z);
        Vector3 smoothpos1 = Vector3.Lerp(transform.position, pos2, vel);
        transform.position = smoothpos1;
    }

    private void posVespa()
    {
        if (state == 1)
        {
            limiteVespa(transform.position.x + .43f, transform.position.y - .5f, transform.position.z, vel);
            if (transform.position.y < minY)
            {
                state = 2;
            }
        }

        else if (state == 2)
        {
            limiteVespa(transform.position.x - 1.04f, transform.position.y + .5f, transform.position.z, vel);
            if (transform.position.y > maxY)
            {
                state = 3;
            }
        }

        else if (state == 3)
        {
            limiteVespa(transform.position.x - .14f, transform.position.y - .5f, transform.position.z, vel);
            if (transform.position.y < minY)
            {
                state = 4;
            }
        }

        else if (state == 4)
        {
            limiteVespa(transform.position.x + .76f, transform.position.y + .5f, transform.position.z, vel);
            if (transform.position.y > maxY)
            {
                state = 5;
            }
        }
        else if (state == 5)
        {
            limiteVespa(originalPosX, originalPosY, transform.position.z, vel);
            if (transform.position.y >= maxY - .15f)
            {
                state = 1;
            }
        }
    }
}
