﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruirVespa : MonoBehaviour
{
    public float tempoDestruir;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, tempoDestruir);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
