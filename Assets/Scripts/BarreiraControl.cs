using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarreiraControl : MonoBehaviour
{
    private int life;
    private int count;
    // Start is called before the first frame update

    public CameraSet cameraSet;

    void Start()
    {
        life = 10;
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 7){
            GetComponent<Animator>().SetBool("vidametade", true);
        }
        if(life == 4){
            GetComponent<Animator>().SetBool("vidaquasela", true);
            GetComponent<Animator>().SetBool("vidametade", false);
        }
        if(life == 2){
            GetComponent<Animator>().SetBool("vidafim", true);
            GetComponent<Animator>().SetBool("vidametade", false);
            GetComponent<Animator>().SetBool("vidaquasela", false);
        }
        if(life <= 0){
            GetComponent<Animator>().SetBool("quebrou", true);
            GetComponent<Animator>().SetBool("vidafim", false);
            GetComponent<Animator>().SetBool("vidametade", false);
            GetComponent<Animator>().SetBool("vidaquasela", false);
            GetComponent<PolygonCollider2D>().enabled = false;
            count++;
            if (count < 20)
            {
                StartCoroutine(cameraSet.Shake(.1f, .1f));
            }
        }
        if (count > 50){
            GetComponent<Animator>().SetBool("quebrou", false);
            Destroy(gameObject, 10f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tiro"))
        {
            life--;
        }
    }
    private void On(Collision2D other) {

    }
}
