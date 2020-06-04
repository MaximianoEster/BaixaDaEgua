using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPosition : MonoBehaviour
{
    public GameObject aviso1;
    public GameObject qrCode;
    public CameraSet cam;
    public bool apertou = false;
    private bool inside;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                qrCode.gameObject.SetActive(true);
                aviso1.gameObject.SetActive(false);
                cam.offset.y = -1f;
                cam.offset.z = -4;
                apertou = true;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                aviso1.gameObject.SetActive(true);
                qrCode.gameObject.SetActive(false);
                cam.offset.y = 2f;
                cam.offset.z = -11;
                apertou = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            aviso1.gameObject.SetActive(true);
            inside = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            aviso1.gameObject.SetActive(false);
            qrCode.gameObject.SetActive(false);
            inside = false;
            apertou = false;
        }
    }
}
