using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OlhoMoviment : MonoBehaviour
{
    public Transform target;
    private float originalPosX, originalPosY;
    private float olho;
    private float limiteMenor, limiteMaior;
    public playerController player;
    void Start()
    {
        originalPosX = transform.position.x;
        originalPosY = transform.position.y;
    }

    void Update()
    {
        float movimento = Input.GetAxis("Horizontal");
        Rigidbody2D rigidbody = player.GetComponent<Rigidbody2D>();
        limiteMenor = originalPosX - 3f;
        limiteMaior = originalPosX + 25f;

        if (target.position.x < limiteMenor)
        {
            transform.position = new Vector2(originalPosX, originalPosY);
        }
        if (target.position.x > limiteMaior)
        {
            transform.position = new Vector2(originalPosX + 1.2f, originalPosY);
        }
        if (target.position.x > limiteMenor && target.position.x < limiteMaior)
        {
            if (rigidbody.velocity.x > 0)
            {
                olho += .005f * rigidbody.velocity.x;
            }
            if (rigidbody.velocity.x < 0)
            {
                olho -= .005f * -rigidbody.velocity.x;
            }
            else
            {
                olho += 0;
            }
            transform.position = new Vector2(originalPosX + olho * .1f, originalPosY);
        }
    }
}
