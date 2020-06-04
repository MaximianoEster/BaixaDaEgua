using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiganteArea : MonoBehaviour
{
    public GameObject pedra;
    public playerController player;
    public CameraSet cam;
    [HideInInspector] public bool pedraGo;
    private int count, count2;
    public AudioClip somRisada;
    public AudioClip somPedra;
    void Start()
    {
        pedraGo = false;
        pedra.gameObject.SetActive(true);
        pedra.GetComponent<Animator>().SetBool("foi", false);
        count2 = 1;
    }

    void Update()
    {
        count++;
        AudioSource audioSource = GetComponent<AudioSource>();
        if (pedraGo)
        {
            player.canMover = false;
            cam.offset.x = 6f;
            pedra.gameObject.SetActive(true);
            count2 = 2;
            if (count > 0 && count < 2)
            {
                audioSource.PlayOneShot(somRisada, .4f);

            }
            if (count > 40)
            {
                if (count > 80 && count < 82)
                {
                    pedra.GetComponent<AudioSource>().PlayOneShot(somPedra, 1f);
                }
                pedra.GetComponent<Animator>().SetBool("foi", true);
                StartCoroutine(cam.Shake(.1f, .1f));
            }
            if (count > 220)
            {
                if (player.vida > 0){
                    player.canMover = true;
                }
                cam.offset.x = 0f;
                pedra.gameObject.SetActive(false);
                pedraGo = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && count2 == 1)
        {
            pedraGo = true;
            count = 0;
        }
    }
}