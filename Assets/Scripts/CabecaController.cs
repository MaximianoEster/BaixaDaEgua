using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabecaController : MonoBehaviour
{
    public GameObject particula1;
    public GameObject particula2;
    public Transform tiroSpawn;
    GameObject particle, particle1;
    private int count;
    private float count2;
    private bool emCima, particleGo;
    public playerController player;
    public AudioClip somCaindo;
    public AudioClip somEmcima;
    private Vector3 originalPos;
    private bool podeSubir = true;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        count = 0;
        count2 = 0;        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (emCima){
            count ++;
            podeSubir = false;
            Destroy(particle, 3.5f);
            Destroy(particle1, 3.5f);

            if (count > 0 && count < 2)
            {
                audioSource.PlayOneShot(somEmcima, .3f);
            }
        }
        if (count > 200 && count < 280)
        {
            if (count < 202)
            {
                audioSource.PlayOneShot(somCaindo, .3f);
            }
            player.cimaCabeca = false;
            count2 -= .01f;
            transform.position += new Vector3(0, count2, 0);
        }
        if (count > 300)
        {
            Vector3 smoothpos = Vector3.Lerp(transform.position, originalPos, .1f);
            transform.position = smoothpos;

        }
        if (count > 350)
        {
            count = 0;
            emCima = false;
            count2 = 0;
            podeSubir = true;
        }

        if (particleGo)
        {
            if (count > 1 && count < 10)
            {
                particle = Instantiate(particula1, new Vector2(tiroSpawn.position.x , tiroSpawn.position.y), Quaternion.identity);
                particle1 = Instantiate(particula2, new Vector2(tiroSpawn.position.x + 4.8f, tiroSpawn.position.y), Quaternion.identity);
                particleGo = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") && podeSubir){
            player.cimaCabeca = true;
            emCima = true;
            particleGo = true;
        }
    }
}
