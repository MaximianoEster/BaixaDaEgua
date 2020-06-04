using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadreSet : MonoBehaviour
{
    public playerController player;
    public GameObject poder;
    public Transform ancora;
    
    private float height;
    private float height2 = 1;
    private float width; 
    private float width2 = 1;
    public bool touchChao = false;
    private float offsetX;
    private float offsetY;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D rigidbodyPoder = poder.GetComponent<Rigidbody2D>();
        rigidbodyPoder.position = new Vector2(ancora.position.x, ancora.position.y);


        if (player.arrebentaPadre){
            if (touchChao){
                width2 += 10f;
                poder.transform.localScale = new Vector3(width2, height2, 1);

                poder.gameObject.SetActive(true);
            } 
            
            if (!touchChao) {
                height2 += 10f;
                poder.transform.localScale = new Vector3(1, height2, 1);

                poder.gameObject.SetActive(true);

            } else {
                height2 += 0;
            }
        } else {
            poder.gameObject.SetActive(false);

        }
    }
}