using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SombraController : MonoBehaviour
{
    protected playerController player;
    private float tempo;
    void Start()
    {
        player = FindObjectOfType<playerController>();
    }

    private bool saiu;
    void Update()
    {
        if (player.canJump){
            GetComponent<Animator>().SetBool("pulando", false);
            tempo = Time.time + .8f;
            GetComponent<SpriteRenderer>().enabled = true;

        }
        if (!player.canJump){
            GetComponent<Animator>().SetBool("pulando", true);
            if (Time.time > tempo){
                GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if(player.saiu){
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
