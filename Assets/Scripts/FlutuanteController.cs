using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlutuanteController : MonoBehaviour
{
    private bool canCair;
    public int count = 0;
    public float count2;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if (count < 150)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y + count2, transform.position.z);
            Vector3 smoothpos = Vector3.Lerp(transform.position, pos, .05f);
            transform.position = smoothpos;

        } if (originalPos.y < transform.position.y && count > 150)
        {
            Vector3 pos = new Vector3(transform.position.x, transform.position.y - count2, transform.position.z);
            Vector3 smoothpos = Vector3.Lerp(transform.position, pos, .05f);
            transform.position = smoothpos;
        }
        if (count > 300)
        {
            count = 0;
        }

    }
}
