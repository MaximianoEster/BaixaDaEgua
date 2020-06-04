using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoProx : MonoBehaviour
{
    protected CollisionCheck coli;
    // Start is called before the first frame update
    void Start()
    {
        coli = FindObjectOfType<CollisionCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        if (coli.canGo)
        {
            GetComponent<Renderer>().sortingOrder = 1;
        } else
        {
            GetComponent<Renderer>().sortingOrder = -4;
        }
    }


}
