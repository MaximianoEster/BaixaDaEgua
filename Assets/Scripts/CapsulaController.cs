using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsulaController : MonoBehaviour
{
    private int count;
    public AudioClip caindo;
    [HideInInspector] public bool dir;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        Destroy(gameObject, .8f);
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        float x = (Random.Range(-180f, 180f));
        if (count == 0) {
            audioSource.PlayOneShot(caindo, .07f);
            float y = (Random.Range(90f, 200f));
            if (dir)
            {
                float x1 = (Random.Range(-100f, -20f));
                GetComponent<Rigidbody2D>().AddForce(new Vector2(x1, y));
            }
            else
            {
                float x1 = (Random.Range(20f, 100f));
                GetComponent<Rigidbody2D>().AddForce(new Vector2(x1, y));
            }
            count = 1;
        }
        gameObject.transform.Rotate(0f, 0f, x, Space.Self);
    }
}
