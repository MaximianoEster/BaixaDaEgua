using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaRotacao : MonoBehaviour
{
    private bool canRotacionar;
    public CameraSet cam;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canRotacionar)
        {
            GetComponent<Rigidbody2D>().freezeRotation = false;
            //StartCoroutine(cam.Shake(.01f, .1f));
            cam.smothSpeed = 1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRotacionar = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canRotacionar = false;
        }
    }
}
