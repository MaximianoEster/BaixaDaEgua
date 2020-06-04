using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerBoss : MonoBehaviour
{
    [Header("Move Settings")]
    public float velocidadeMaxima;
    public float forcaPulo;

    [Header("Bullet Settings")]
    public float tiroVel = 0f;
    public float atirarDenovo;
    public float tempoDano = 2f;
    public GameObject tiroPrefab;
    public Transform tiroSpawn;

    [Header("Bomb Settings")]
    public GameObject bombaPrefab;

    [Header("Sombra Settings")]
    public Transform sombra;

    [Header("Camera Settings")]
    public CameraSetBoss cameraSet;

    [Header("Padre Settings")]
    public GameObject padreCicero;
    public PadreSet2 padreset;
    [HideInInspector] public bool arrebentaPadre = false;
    [HideInInspector] public bool padreApareceu = false;

    [Header("Effects")]
    public GameObject dashEffect;
    public GameObject punchEffect;
    public GameObject tiroEfeito;
    public GameObject efeitoPulo;
    public GameObject efeitoDano;
    public Ghost ghost;

    [Header("UI")]
    public StaminaController3 barraPadre;
    public StaminaController2 barraVida;
    public StaminaController barraMana;

    [Header("Capsula Tiro")]
    public GameObject capsulaPrefab;
    public CapsulaController capsulaController;

    [Header("Sons")]
    public AudioClip invocar;
    public AudioClip atirarSound;
    public AudioClip somMorte;
    public AudioClip somDash;
    public AudioClip reza;
    public AudioClip danoSound;
    [SerializeField] private AudioClip[] sonsPulo;

    [HideInInspector] public bool saiu = false;
    [HideInInspector] public bool olharCima;
    [HideInInspector] public bool olharBaixo;
    [HideInInspector] public bool canJump;
    [HideInInspector] public bool cimaCabeca = false;
    [HideInInspector] public bool canMover = true;
    [HideInInspector] public bool invocando = false;
    [HideInInspector] public bool podeChamar;
    [HideInInspector] public bool dashOn;

    GameObject particle;

    private bool olharDireita = true;
    private bool tomandoDano = false;
    private float correctionY;
    private float correctionX;

    [HideInInspector] public int vida = 5;
    private int maxVida;
    private int bombas;
    private int tiros;
    private int countTiro = 0;
    private int atirando;
    private int combo;
    private float velTiro;

    private float dash = 20f;
    private float correx, correy;
    private float timeDash;
    private float passou;
    private bool abaixado = false;
    private bool touchEnemy = false;
    private int countParada;
    private int jumpCount;

    private bool atacando = false;
    private float canAtacar;
    private float dash2 = 1.5f;
    private int attack;
    private int pressed = 0;
    private int morreu = 0;

    private int invocaPadre;
    private bool estaMorto = false;
    private bool canKickar = false;
    private float canLancar = 120;

    private float yPosPadre = 0;
    private bool canCountPadre = false;
    private int atirou;

    GameManager gameManager;
    private GameObject tempBomb;
    private Rigidbody2D corpoBomba;
    private Bomb bombeta;

    protected Rigidbody2D rigid;
    protected AudioSource audioSource;
    AnimatorControllerParameter[] parameter;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        gameManager = GameManager.gameManager;

        bombas = gameManager.bombas;
        barraPadre.CurrentStamina = gameManager.staminaPadre;
        barraMana.CurrentStamina = gameManager.staminaMana;
        barraVida.CurrentStamina = gameManager.vida;

        UpdateMoedasUI();
    }

    void Update()
    {
        inputPlayer();
        updatePadre();
        countParada++;
        if (canMover)
        {
            passou += Time.deltaTime;
            timeDash += Time.deltaTime;
            canAtacar++;
        }
        /*
        if(cimaCabeca){
            Time.timeScale = .5f;
            Time.fixedDeltaTime = Time.timeScale * .5f;
        } else {
            Time.timeScale = 1f;
        }
        */
    }

    void inputPlayer()
    {
        if (canMover)
        {
            float movimento = Input.GetAxis("Horizontal"); // se Negativa para esquerda, se positiva para direita
            float yPos = Input.GetAxis("Vertical"); // se Negativa para baixo, se positiva para cima
            rigid.gravityScale = 1.8f;

            if (abaixado)
            {
                rigid.velocity = new Vector2(movimento * velocidadeMaxima * .5f, rigid.velocity.y);
            }
            if (cimaCabeca)
            {
                rigid.velocity = new Vector2(movimento * velocidadeMaxima * .4f, rigid.velocity.y);
                rigid.gravityScale = 2.4f;
                StartCoroutine(cameraSet.Shake(.01f, .01f));
            }
            if (!abaixado && !cimaCabeca)
            {
                rigid.velocity = new Vector2(movimento * velocidadeMaxima, rigid.velocity.y);
                Time.timeScale = 1f;
            }
            // movimentação da maria

            //checando lado
            if (movimento > 0 && !olharDireita)
            {
                Flip();
            }
            else if (movimento < 0 && olharDireita)
            {
                Flip();
            }

            //animacao de andar

            if (movimento > 0.3 || movimento < -0.3)
            {
                GetComponent<Animator>().SetBool("andar", true);
                GetComponent<Animator>().SetBool("atiraCimaCorrendo", false);
                if (olharCima && canJump)
                {
                    GetComponent<Animator>().SetBool("atiraCimaCorrendo", true);
                }
                if (abaixado)
                {
                    GetComponent<Animator>().SetBool("andaragachado", true);
                }
                else
                {
                    GetComponent<Animator>().SetBool("andaragachado", false);
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("andar", false);
                GetComponent<Animator>().SetBool("atiraCimaCorrendo", false);
            }

            if (!canJump && vida > 0)
            {
                GetComponent<Animator>().SetBool("pular", true);
            }
            if (canJump)
            {
                GetComponent<Animator>().SetBool("pular", false);
            }
            //botão de pulo
            jumpCount++;
            if (Input.GetKeyDown(KeyCode.Space) && canJump && jumpCount > 50) //verifica se o espaço foi apertado
            {
                jumpCount = 0;
                AudioClip somPulo = GetRandomClip();
                audioSource.PlayOneShot(somPulo, .8f);
                rigid.AddForce(new Vector2(0, forcaPulo)); // adiciona a força do pulo no eixo Y
                GetComponent<Animator>().SetBool("cima", false);
                GetComponent<Animator>().SetBool("atiraCimaCorrendo", false);
                GetComponent<Animator>().SetBool("pular", true); // aciona o gatilho da animação 

                particle = Instantiate(efeitoPulo, new Vector2(rigid.position.x, tiroSpawn.position.y - .8f), Quaternion.identity);
                Destroy(particle, 2f);
                olharCima = false;
            }
            atirando++;

            //botãoo tiro
            if (Input.GetButton("Fire1") && atirando > 5 && combo < 3)
            {
                audioSource.PlayOneShot(atirarSound, .2f);
                barraPadre.CurrentStamina2 += 10;

                if (movimento == 0 && canJump)
                {
                    cameraSet.smothSpeed = 10;
                    StartCoroutine(cameraSet.Shake(.1f, .01f));
                }
                correctionY = (Random.Range(-.1f, .1f));
                atirando = 0;
                canAtacar = 0;
                combo++;
                atirarDenovo = Time.time + tiroVel;
                GameObject tempTiro = Instantiate(tiroPrefab, new Vector2(tiroSpawn.position.x, tiroSpawn.position.y + correctionY), tiroSpawn.rotation);
                if (olharDireita)
                {
                    capsulaController.dir = true;
                    correx = -.5f;
                    correy = .03f;
                }
                else
                {
                    capsulaController.dir = false;
                    correx = .5f;
                    correy = .03f;
                }
                if (olharCima)
                {
                    correx = 0f;
                    correy = -.35f;
                }
                GameObject tempCapsula = Instantiate(capsulaPrefab, new Vector2(tiroSpawn.position.x + correx, tiroSpawn.position.y + correy), tiroSpawn.rotation);
                particle = Instantiate(tiroEfeito, new Vector2(tiroSpawn.position.x, tiroSpawn.position.y), Quaternion.identity);
                Destroy(particle, .08f);

                if (canAtacar < 15 && olharCima && canJump)
                {
                    if (movimento == 0)
                    {
                        GetComponent<Animator>().SetBool("cima", true);
                    }
                }
                if (canAtacar < 15 && !canJump && !olharCima)
                {
                    GetComponent<Animator>().SetBool("atiraPulando", true);
                }

                if (canAtacar < 15 && canJump && !olharCima)
                {
                    if (movimento == 0)
                    {
                        GetComponent<Animator>().SetBool("atirar", true);
                        GetComponent<Animator>().SetBool("atiraCorrendo", false);
                    }
                    if (movimento != 0)
                    {
                        GetComponent<Animator>().SetBool("atirar", false);
                        GetComponent<Animator>().SetBool("atiraCorrendo", true);
                    }
                }

                if (canAtacar < 15 && olharBaixo && !olharCima)
                {
                    GetComponent<Animator>().SetBool("atirabaixo", true);
                }

                if (!olharDireita)
                {
                    tempTiro.transform.eulerAngles = new Vector3(0, 0, 180);
                }
                if (olharCima && canJump)
                {
                    tempTiro.transform.eulerAngles = new Vector3(0, 0, 90);
                }
                if (olharBaixo && !canJump)
                {
                    olharCima = false;
                    tempTiro.transform.eulerAngles = new Vector3(0, 0, -90);
                }
            }
            if (Input.GetButtonUp("Fire1"))
            {
                combo = 0;
            }

            if (canAtacar > 15)
            {
                GetComponent<Animator>().SetBool("atiraCorrendo", false);
                GetComponent<Animator>().SetBool("atiraPulando", false);
                GetComponent<Animator>().SetBool("atirabaixo", false);
                GetComponent<Animator>().SetBool("atirar", false);
                GetComponent<Animator>().SetBool("cima", false);
            }

            if (canAtacar > 5)
            {
                cameraSet.smothSpeed = .1f;
            }

            //agachar
            if (yPos < -.3)
            {
                if (canJump)
                {
                    GetComponent<Animator>().SetBool("agachar", true);
                    abaixado = true;
                }
                if (!canJump)
                {
                    olharBaixo = true;
                    GetComponent<Animator>().SetBool("atirabaixo", true);
                }
            }
            //olhar pra cima 
            else if (yPos > .3)
            {
                olharCima = true;
                if (!canJump)
                {
                    GetComponent<Animator>().SetBool("atiraPulando", true);
                }
            }
            else
            {
                GetComponent<Animator>().SetBool("cima", false);
                GetComponent<Animator>().SetBool("agachar", false);
                GetComponent<Animator>().SetBool("atirabaixo", false);
                GetComponent<Animator>().SetBool("andaragachado", false);
                olharCima = false;
                abaixado = false;
                olharBaixo = false;
            }

            canLancar++;
            //bomba
            if (Input.GetButtonDown("Fire2") && bombas > 0 && canLancar > 120)
            {
                tempBomb = Instantiate(bombaPrefab, new Vector2(tiroSpawn.position.x, tiroSpawn.position.y), transform.rotation);
                corpoBomba = tempBomb.GetComponent<Rigidbody2D>();
                bombeta = tempBomb.GetComponent<Bomb>();
                pressed++;
                canLancar = 0;
                if (olharDireita)
                {
                    corpoBomba.AddForce(new Vector3(4, 8), ForceMode2D.Impulse);
                }
                else
                {
                    corpoBomba.AddForce(new Vector3(-4, 8), ForceMode2D.Impulse);
                }

                bombas--;
                gameManager.bombas--;
            }
            if (pressed >= 1)
            {
                if (bombeta.shake)
                {
                    StartCoroutine(cameraSet.Shake(.15f, .15f));
                    bombeta.shake = false;
                }
            }

            //botão dash
            if (passou < .2f && Input.GetKeyDown(KeyCode.X) && barraMana.CurrentStamina > 33.34f)
            {
                dashOn = true;
                StartCoroutine(cameraSet.Shake(.15f, .1f));
                timeDash = 0;
                audioSource.PlayOneShot(somDash, .35f);
                barraMana.LoseStamina(33.34f);
                if (olharDireita)
                {
                    StartCoroutine(Dash(.2f, dash, rigid));
                }
                else if (!olharDireita)
                {
                    StartCoroutine(Dash(.2f, -dash, rigid));
                }
                particle = Instantiate(dashEffect, transform.position, Quaternion.identity);
                passou = 0.0f;
                Destroy(particle, 1.0f);
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                passou = 0.0f;
            }
            else if (passou > .2f)
            {
                dashOn = false;
            }

            //combo de faca
            if (Input.GetKeyDown(KeyCode.C))
            {
                atacando = true;
                particle = Instantiate(punchEffect, new Vector2(tiroSpawn.position.x, tiroSpawn.position.y), Quaternion.identity);
                Destroy(particle, 1.0f);
                if (atacando && attack == 1)
                {
                    StartCoroutine(cameraSet.Shake(.1f, .01f));
                    canAtacar = 0;
                    attack = 2;
                    //GetComponent<Animator>().SetBool("ataque1", true);
                    if (olharDireita)
                    {
                        StartCoroutine(Dash(.2f, dash2, rigid));
                    }
                    else if (!olharDireita)
                    {
                        StartCoroutine(Dash(.2f, -dash2, rigid));
                    }
                }
                else if (atacando && attack == 2)
                {
                    StartCoroutine(cameraSet.Shake(.1f, .01f));
                    canAtacar = 0;
                    attack = 3;
                    //GetComponent<Animator>().SetBool("ataque2", true);
                    if (olharDireita)
                    {
                        StartCoroutine(Dash(.2f, dash2, rigid));
                    }
                    else if (!olharDireita)
                    {
                        StartCoroutine(Dash(.2f, -dash2, rigid));
                    }
                }
                else if (atacando && attack == 3)
                {
                    StartCoroutine(cameraSet.Shake(.1f, .01f));
                    canAtacar = 0;
                    attack = 1;
                    //GetComponent<Animator>().SetBool("ataque3", true);
                    if (olharDireita)
                    {
                        StartCoroutine(Dash(.2f, dash2, rigid));
                    }
                    else if (!olharDireita)
                    {
                        StartCoroutine(Dash(.2f, -dash2, rigid));
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Z) && barraPadre.CurrentStamina > 99.99f)
            {
                audioSource.PlayOneShot(invocar, .7f);
                invocaPadre = 0;
                invocando = true;
            }

            if (canAtacar > 10)
            {
                atacando = false;
            }

            if (canAtacar > 30)
            {
                attack = 1;
            }

            if (canJump)
            {
                sombra.position = new Vector2(rigid.position.x, rigid.position.y - .85f);
                GetComponent<Animator>().SetBool("atirabaixo", false);
            }

            if (!canJump)
            {
                sombra.position = new Vector2(rigid.position.x, sombra.position.y);
                GetComponent<Animator>().SetBool("agachar", false);
            }
            if (vida <= 0)
            {
                canMover = false;
            }
            if (transform.position.y <= -10)
            {
                RecarregarFase();
            }
            if (touchEnemy)
            {
                Time.timeScale = 0;
            }
            if (countParada > 15)
            {
                Time.timeScale = 1;
            }

        }
        else
        {
            float movimento = Input.GetAxis("Horizontal");
            if (vida > 0)
            {
                rigid.velocity = new Vector2(0, 0);
                rigid.gravityScale = 0;
            }
            if (movimento != 0)
            {
                Animator anim = GetComponent<Animator>();
                foreach (AnimatorControllerParameter parameter in anim.parameters)
                {
                    anim.SetBool(parameter.name, false);
                }
            }
            if (vida <= 0)
            {
                sombra.position = new Vector2(rigid.position.x, rigid.position.y - .85f);
                Time.timeScale = .5f;
                if (morreu == 0)
                {
                    audioSource.PlayOneShot(somMorte, .6f);
                    if (olharDireita)
                    {
                        StartCoroutine(DashDano(.3f, -dash / 5, dash / 2, rigid));
                    }
                    else if (!olharDireita)
                    {
                        StartCoroutine(DashDano(.3f, dash / 5, dash / 2, rigid));
                    }
                    morreu = 1;
                }
            }
        }
        if (invocando)
        {
            invocaPadre++;
            if (invocaPadre < 2)
            {
                audioSource.PlayOneShot(reza, .6f);
            }
            yPosPadre = 0;
            canMover = false;
        }
        if (invocaPadre > 270 && invocaPadre < 275 && barraPadre.CurrentStamina > 99.99f)
        {
            canMover = false;
            invocando = false;
            invocaPadre = 0;
            padreCicero.gameObject.SetActive(true);
            padreApareceu = true;
            yPosPadre = 0;
            canCountPadre = true;
            padreset.touchChao = false;
            padreCicero.GetComponent<Animator>().SetBool("subindo", true);
            barraPadre.LoseStamina(100);
            barraPadre.CurrentStamina2 = 0;
        }
    }

    void updatePadre()
    {

        yPosPadre++;
        if (padreApareceu)
        {
            canMover = false;

            if (padreset.touchChao)
            {
                StartCoroutine(cameraSet.Shake2(.4f, .1f));
            }
            else
            {
                arrebentaPadre = true;
            }
        }
        else
        {
            if (yPosPadre > 400)
            {
                padreCicero.GetComponent<Animator>().SetBool("subindo", false);
                if (vida > 0)
                {
                    canMover = true;
                }
                if (vida <= 0)
                {
                    canMover = false;
                }
            }
        }
    }

    void Flip()
    {
        olharDireita = !olharDireita;

        transform.Rotate(0f, 180f, 0f);
    }

    void UpdateMoedasUI()
    {
        FindObjectOfType<UIManager>().UpdateMoedasUI();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo") && !tomandoDano)
        {
            touchEnemy = true;
            countParada = 0;
            StartCoroutine(TomouDano());
        }
        if (other.CompareTag("saiu"))
        {
            saiu = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("saiu") && canJump)
        {
            saiu = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Inimigo") && !tomandoDano)
        {
            touchEnemy = true;
            countParada = 0;
            StartCoroutine(TomouDano());
        }

        else if (other.gameObject.CompareTag("Coin"))
        {
            gameManager.moedas += 1;
            UpdateMoedasUI();
        }
        if (other.gameObject.CompareTag("plataforma"))
        {
            canJump = true;
            GetComponent<Animator>().SetBool("pular", false);
            GetComponent<Animator>().SetBool("atiraPulando", false);
            saiu = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("plataforma"))
        {
            canJump = false;
            GetComponent<Animator>().SetBool("andar", false);
            GetComponent<Animator>().SetBool("atiraCorrendo", false);
            if (vida == 0)
            {
                canKickar = true;
            }
        }
    }

    IEnumerator TomouDano()
    {
        tomandoDano = true;
        vida--;
        gameManager.vida--;
        countParada = 0;
        StartCoroutine(cameraSet.Shake(.2f, .05f));
        particle = Instantiate(efeitoDano, new Vector2(rigid.position.x, rigid.position.y), Quaternion.identity);
        Destroy(particle, 1f);
        if (vida <= 0)
        {
            estaMorto = true;
            GetComponent<Animator>().SetTrigger("morto");
            Physics2D.IgnoreLayerCollision(8, 10);
            Invoke("RecarregarFase", 2f);
        }
        else
        {
            if (!estaMorto)
            {
                audioSource.PlayOneShot(danoSound, .3f);
                Physics2D.IgnoreLayerCollision(8, 10);
                if (olharDireita)
                {
                    StartCoroutine(DashDano(.3f, -dash / 2, dash / 2, rigid));
                }
                if (!olharDireita)
                {
                    StartCoroutine(DashDano(.3f, dash / 2, dash / 2, rigid));
                }
                for (float i = 0; i < tempoDano; i += 0.2f)
                {
                    yield return new WaitForSeconds(0.1f);
                    GetComponent<SpriteRenderer>().enabled = false;
                    yield return new WaitForSeconds(0.1f);
                    GetComponent<SpriteRenderer>().enabled = true;
                    yield return new WaitForSeconds(0.1f);
                }
                Physics2D.IgnoreLayerCollision(8, 10, false);
                tomandoDano = false;
            }
        }
    }

    void RecarregarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Physics2D.IgnoreLayerCollision(8, 10, false);
        canMover = true;
    }

    //função dash
    public IEnumerator Dash(float duracao, float forcaDash, Rigidbody2D rb)
    {
        float tempo = 0.0f;
        Physics2D.IgnoreLayerCollision(8, 10);

        while (tempo < duracao)
        {
            ghost.makeGhost = true;

            rb.velocity = new Vector2(forcaDash, 0);

            tempo += Time.deltaTime;

            yield return null;
        }
        Physics2D.IgnoreLayerCollision(8, 10, false);
        dashOn = false;
        ghost.makeGhost = false;

    }

    public IEnumerator DashDano(float duracao, float forcaDashX, float forcaDashY, Rigidbody2D rb)
    {
        float tempo = 0.0f;

        while (tempo < duracao)
        {
            rb.velocity = new Vector2(forcaDashX, forcaDashY / 3);

            tempo += Time.deltaTime;

            yield return null;
        }

    }

    public bool getPos()
    {
        return olharDireita;
    }

    private AudioClip GetRandomClip()
    {
        return sonsPulo[UnityEngine.Random.Range(0, sonsPulo.Length)];
    }
}
