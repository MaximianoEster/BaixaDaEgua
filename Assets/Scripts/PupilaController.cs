using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilaController : MonoBehaviour
{
    public CollisionCheck collision;
    private int foi = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y);
        foi = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collision.canGo && foi < 5)
        {
            Vector3 pos1 = new Vector3(transform.position.x - 1.4f, transform.position.y, transform.position.z);
            Vector3 smoothpos = Vector3.Lerp(transform.position, pos1, .2f);
            transform.position = smoothpos;
            foi++;
        }
        if (!collision.canGo && foi > 0)
        {
            Vector3 pos1 = new Vector3(transform.position.x + 1.4f, transform.position.y, transform.position.z);
            Vector3 smoothpos = Vector3.Lerp(transform.position, pos1, .2f);
            transform.position = smoothpos;
            foi--;
        }
        if (foi > 5)
        {
            foi = 5;
        }
        if (foi < 0)
        {
            foi = 0;
        }
    }
}
