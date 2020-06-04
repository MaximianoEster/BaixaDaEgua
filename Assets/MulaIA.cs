using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MulaIA : MonoBehaviour
{
    protected playerController player;
    protected int stateAtque;
    protected Rigidbody2D rigid;
    [HideInInspector] public bool canIr, foi;
    [HideInInspector] public float vidaBoss;
    protected int count;
    protected CameraSet cam;
    GameObject particle;
    GameObject particle2;
    
    [SerializeField] private GameObject tiro_mula;
    [SerializeField] private GameObject carregarPartcile;
    [SerializeField] private GameObject carregarPartcile2;
    [SerializeField] private Transform spawn;
    [SerializeField] private Transform spawn2;
    [SerializeField] private Transform cabeca;
    void Start()
    {
        player = FindObjectOfType<playerController>();
        rigid = GetComponent<Rigidbody2D>();
        cam = FindObjectOfType<CameraSet>();
        canIr = false;
        vidaBoss = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaBoss > 70 && vidaBoss <= 100)
        {
            stateAtque = 1;
        }
        if (vidaBoss > 30 && vidaBoss <= 70)
        {
            stateAtque = 2;
        }
        if (vidaBoss < 30)
        {
            stateAtque = 3;
        }
        count++;
        if (player.stateBoss > 2)
        {
            if (stateAtque == 1)
            {
                if (count < 2)
                {
                    GetComponent<Animator>().SetBool("carregando", true);
                    StartCoroutine(cam.Shake(1f, .1f));
                }
                if (count < 150)
                {
                    carregarPartcile.transform.localScale = new Vector3(2, 2, 2);
                    particle = Instantiate(carregarPartcile, new Vector2(spawn.position.x, spawn.position.y), Quaternion.identity);
                    Destroy(particle, 1.0f);

                    carregarPartcile2.transform.localScale = new Vector3(2, 2, 2);
                    particle2 = Instantiate(carregarPartcile2, new Vector2(spawn2.position.x, spawn2.position.y), Quaternion.identity);
                    Destroy(particle2, 1.0f);
                }
                if (count > 150)
                {
                    GetComponent<Animator>().SetBool("carregando", false);
                    GetComponent<Animator>().SetBool("correndo", true);
                }
                if (!canIr && count > 150)
                {
                    rigid.velocity = new Vector2(-10, rigid.velocity.y);
                }
                if (canIr && count > 150)
                {
                    rigid.velocity = new Vector2(10, rigid.velocity.y);
                }
            }
            if (stateAtque == 2)
            {
                if (count < 2)
                {
                    GetComponent<Animator>().SetBool("carregando", false);
                    GetComponent<Animator>().SetBool("correndo", false);
                    foi = true;
                    StartCoroutine(cam.Shake(1f, .1f));

                }
                if (!canIr && count > 300)
                {
                    rigid.velocity = new Vector2(-10, rigid.velocity.y);
                    GetComponent<Animator>().SetBool("correndo", true);
                }
                if (canIr && count > 300)
                {
                    rigid.velocity = new Vector2(10, rigid.velocity.y);
                    GetComponent<Animator>().SetBool("correndo", true);
                }
                if (foi)
                {
                    tiroMula(25);
                    foi = false;
                }
            }
            if (stateAtque == 3)
            {
                if (count < 2)
                {
                    GetComponent<Animator>().SetBool("carregando", true);
                }
                if (count < 150)
                {
                    carregarPartcile.transform.localScale = new Vector3(2, 2, 2);
                    particle = Instantiate(carregarPartcile, new Vector2(spawn.position.x, spawn.position.y), Quaternion.identity);
                    Destroy(particle, 1.0f);

                    carregarPartcile2.transform.localScale = new Vector3(2, 2, 2);
                    particle2 = Instantiate(carregarPartcile2, new Vector2(spawn2.position.x, spawn2.position.y), Quaternion.identity);
                    Destroy(particle2, 1.0f);
                }
                if (!canIr && count > 250)
                {
                    rigid.velocity = new Vector2(-10, rigid.velocity.y);
                    GetComponent<Animator>().SetBool("correndo", true);
                    foi = true;
                }
                if (canIr && count > 250)
                {
                    rigid.velocity = new Vector2(10, rigid.velocity.y);
                    GetComponent<Animator>().SetBool("correndo", true);
                    foi = true;
                }
                if (foi)
                {
                    tiroMula(1);
                    foi = false;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("travaesquerda"))
        {
            canIr = true;
            count = 0;
            transform.Rotate(0f, 180f, 0f);
        }
        if (collision.gameObject.CompareTag("travadireita"))
        {
            canIr = false;
            count = 0;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void tiroMula(int num)
    {
        for (int a = 0; a < num; a++)
        {
            Instantiate(tiro_mula, cabeca.position, Quaternion.identity);
        }
    }
}
