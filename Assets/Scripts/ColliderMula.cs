using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMula : MonoBehaviour
{
    public testeCollider collider;
    public int count;
    public bool mulaCanGo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator anim = GetComponent<Animator>();
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        if (collider.podeIr){
            count++;
            mulaCanGo = false;
        }
        if (count > 150){
            Time.timeScale = .35f;
            collider.podeIr = false;
            mulaCanGo = true;
            anim.SetBool("correndo", true);
            rigid.velocity = new Vector2(- 5, rigid.velocity.y);
        }

    }

}
