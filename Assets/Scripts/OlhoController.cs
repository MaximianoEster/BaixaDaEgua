using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhoController : MonoBehaviour
{
    public Transform target;
    private float originalPosX, originalPosY;
    private float olho;
    private float limiteMenor, limiteMaior;
    public playerController player;
    // Start is called before the first frame update
    void Start()
    {
        originalPosX = transform.position.x;
        originalPosY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        float movimento = Input.GetAxis("Horizontal");
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        limiteMenor = originalPosX - 6f;
        limiteMaior = originalPosX + 8f;

        if (target.position.x < limiteMenor)
        {
            transform.position = new Vector2(originalPosX, originalPosY);
        } 
        if (target.position.x > limiteMaior )
        {
            transform.position = new Vector2(originalPosX + .27f, originalPosY) ;
        } 
        if (target.position.x > limiteMenor && target.position.x < limiteMaior) 
        {
            if (rigidbody.velocity.x > 0)
            {
                olho += .003f * rigidbody.velocity.x;
            }
            if (rigidbody.velocity.x < 0)
            {
                olho -= .003f * -rigidbody.velocity.x;
                originalPosY += olho / 10000;
            }
            else
            {
                olho += 0;
            }
            if (target.position.x < (limiteMaior + limiteMenor) / 2)
            {
                transform.position = new Vector2(originalPosX + olho * .1f, originalPosY);
            }
            if (target.position.x > (limiteMaior + limiteMenor) / 2)
            {
                if (rigidbody.velocity.x != 0)
                transform.position = new Vector2(originalPosX + olho * .1f, originalPosY);
            }
        }
    }
}
