using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    public CameraSet cam;
    public CheckPosition position;
    public AudioClip entrouSom;
    [HideInInspector] public bool entrou;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entrou && !position.apertou) {
            cam.offset.y = 2f;
            cam.offset.z = -11;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            entrou = true;
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(entrouSom, .2f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            entrou = false;
        }
    }
}
