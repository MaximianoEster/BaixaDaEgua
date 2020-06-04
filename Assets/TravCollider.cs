using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravCollider : MonoBehaviour
{
    protected playerController player;
    protected CameraSet cam;
    protected float posY;
    void Start()
    {
        player = FindObjectOfType<playerController>();
        cam = FindObjectOfType<CameraSet>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.travouBoss)
        {
            posY -= .01f;
            transform.position = new Vector3(transform.position.x, transform.position.y + posY, 0);
            if (transform.position.y <= .55f)
            {
                transform.position = new Vector3(transform.position.x, .55f, 0);
                if (player.stateBoss == 1)
                {
                    StartCoroutine(cam.Shake(3f, .2f));
                    player.stateBoss = 2;
                }
            }
            if (player.stateBoss == 1)
            {
                player.canMover = false;
            }
        }

    }
}
