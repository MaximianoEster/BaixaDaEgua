using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaiController : MonoBehaviour
{
    private bool canCair, mariaEmcima = false, canSubir;
    private int count;
    private float count2;
    private Vector3 originalPos;
    public AudioClip caindoSom;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

// Update is called once per frame
    void Update()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        count++;
        if (canCair)
        {
            mariaEmcima = true;
            if (mariaEmcima)
            {
                if (count > 100 && count < 200)
                {
                    if (count < 102)
                    {
                        audioSource.PlayOneShot(caindoSom, .2f);
                    }
                    count2 -= .01f;
                    transform.position += new Vector3(0, count2, 0);
                }
                if (count > 250)
                {
                    canSubir = false;
                }
            }
        }
        if (count > 200)
        {
            Vector3 smoothpos = Vector3.Lerp(transform.position, originalPos, .1f);
            transform.position = smoothpos;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !canSubir)
        {
            canSubir = true;
            canCair = true;
            count = 0;
            count2 = 0;
        }
    }
}
