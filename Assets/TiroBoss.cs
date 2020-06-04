using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroBoss : MonoBehaviour
{
    protected int speed;
    protected playerController player;
    protected MulaIA mula;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15;
        player = FindObjectOfType<playerController>();
        mula = FindObjectOfType<MulaIA>();
        speed = Random.Range(7, 15);
        Destroy(gameObject, 6f);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y >= 15f)
        {
            float x;
            x = Random.Range(0, 15f);
            if (mula.canIr)
            {
                transform.position = new Vector3(transform.position.x + x, transform.position.y, 0);
            }
            if (!mula.canIr)
            {
                transform.position = new Vector3(transform.position.x - x, transform.position.y, 0);
            }
            transform.Rotate(0f, 0f, 180f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tiro"))
        {
            Destroy(gameObject);
        }
    }
}
