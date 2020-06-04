using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadreSet2 : MonoBehaviour
{
    public playerController player;
    public GameObject poder;
    public Transform ancora;
    public Transform poderSpawn;

    public GameObject efeitoPoder;
    public GameObject efeitoPoder2;

    public AudioClip somCarregar;
    public AudioClip somPoder;
    
    private float width2 = 1;
    public bool touchChao = false;
    private float count;
    GameObject particle;
    GameObject particle2;

    public AudioClip subida;
    public AudioClip poderSaindo;
    public AudioClip poderSaindo2;
    public AudioClip carregando;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(countIniciar);
        Rigidbody2D rigidbodyPoder = poder.GetComponent<Rigidbody2D>();
        rigidbodyPoder.position = new Vector2(ancora.position.x, ancora.position.y);
        AudioSource audioSource = GetComponent<AudioSource>();

        if (player.arrebentaPadre){
            poder.gameObject.SetActive(true);
            if (touchChao){
                if (count < 162)
                {
                    audioSource.PlayOneShot(poderSaindo, .5f);
                    audioSource.PlayOneShot(poderSaindo2, .7f);
                }
                count++;
                poder.GetComponent<Animator>().enabled = false;
                width2 += .5f;
                poder.transform.localScale = new Vector3(width2, 1.5f, 1);
                poderSpawn.transform.localPosition = new Vector2(width2/2.3f, -7.17f);
                particle = Instantiate(efeitoPoder, new Vector2(poderSpawn.position.x, poderSpawn.position.y + 1.5f), Quaternion.identity);
                particle2 = Instantiate(efeitoPoder2, new Vector2(ancora.position.x, ancora.position.y), Quaternion.identity);
                Destroy(particle, 1f);
                Destroy(particle2, 1f);

                if (count > 320){
                    player.arrebentaPadre = false;
                    count = 0;
                    width2 = 1;
                    GetComponent<Animator>().SetBool("atirando" ,false);
                }
            } 
            
            if (!touchChao) {
                count++;
                if (count < 2)
                {
                    audioSource.PlayOneShot(subida, .5f);
                }
                if (count > 110){
                    if (count < 112)
                    {
                        audioSource.PlayOneShot(carregando, .5f);
                    }
                    GetComponent<Animator>().SetBool("atirando" ,true);
                    poder.GetComponent<Animator>().enabled = true;
                    poder.GetComponent<Animator>().SetBool("carregar", true);
                }
                if (count > 160){
                    touchChao = true;
                }
            }
        }
        else {
            poder.GetComponent<Animator>().SetBool("carregar", false);
            poder.GetComponent<Animator>().enabled = true;
            touchChao = false;
            player.padreApareceu = false;
        }
    }
}