using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraSet : MonoBehaviour
{
    private bool onShake = false;
    public Transform target;
    public float smothSpeed;
    public Vector3 offset;
    public Vector3 offset2;
    public GameObject maximo;
    public CheckPosition position;
    public AreaController area;
    public float offsetX, offsetY, offsetZ;
    public float correY;
    protected GiganteArea gigante;
    protected RaycastController raycast;
    public playerController player;
    protected MulaIA mula;
    protected int countBoss;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        gigante = FindObjectOfType<GiganteArea>();
        raycast = FindObjectOfType<RaycastController>();
        mula    = FindObjectOfType<MulaIA>();
        offset.x = offsetX;
        offset.y = offsetY;
        offset.z = offsetZ;

        minX = 30f;
        maxX = 277f;
        minY = -.45f;
        maxY = 15f;
    }

    void FixedUpdate()
    {
        if (!onShake)
        {
            float x = Mathf.Clamp(target.position.x, minX, maxX);
            float y = Mathf.Clamp(target.position.y, minY, maxY);
            Vector3 pos = new Vector3(x + offset2.x + offset.x, y + offset.y, offset.z);

            Vector3 smoothpos1 = Vector3.Lerp(transform.position, pos, smothSpeed);
            transform.position = smoothpos1;
            limiteCamXInvocar(target.position.y);

            if (player.padreApareceu)
            {
                if (player.getPos())
                {
                    offset2.x = 4;
                }
                else
                {
                    offset2.x = -4;
                }
            }
            if (!player.padreApareceu)
            {
                offset2.x = 0;
            }
        }

    }

    public IEnumerator Shake(float duracao, float forcaShake)
    {
        Vector3 originalPos = transform.localPosition;

        float tempo = 0.0f;
        Rigidbody2D rbPlayer = target.GetComponent<Rigidbody2D>();
        float posPlayerX = rbPlayer.position.x;


        while (tempo < duracao)
        {
            onShake = true;
            float x = Random.Range(-1f, 1f) * forcaShake;
            float y = Random.Range(-1f, 1f) * forcaShake;
            float z = Random.Range(-.5f, .5f) * forcaShake;
            if (posPlayerX <= minX || gigante.pedraGo)
            {
                transform.localPosition = new Vector3(x + originalPos.x, y + originalPos.y, originalPos.z + z);
            }
            else if (posPlayerX >= maxX || gigante.pedraGo)
            {
                transform.localPosition = new Vector3(x + originalPos.x, y + originalPos.y, originalPos.z + z);

            }

            else
            {
                transform.localPosition = new Vector3(x + target.position.x, y + originalPos.y, originalPos.z + z);
            }
            tempo += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        onShake = false;
    }

    public IEnumerator Shake2(float duracao, float forcaShake)
    {
        Vector3 originalPos = transform.localPosition;

        float tempo = 0.0f;

        while (tempo < duracao)
        {
            onShake = true;
            float x = Random.Range(-1f, 1f) * forcaShake;
            float y = Random.Range(-1f, 1f) * forcaShake;
            float z = Random.Range(-.5f, .5f) * forcaShake;
            transform.localPosition = new Vector3(x + originalPos.x, y + originalPos.y, originalPos.z + z);
            tempo += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
        onShake = false;
    }

    private void limiteCamXInvocar(float yPadre)
    {
        if (player.invocando)
        {
            offset.y = yPadre;
            offset.z = -4f;
        }
        else
        {
            if (!area.entrou)
            {
                offset.x = offsetX;
                offset.y = offsetY;
                offset.z = offsetZ;
            }
        }
        if (player.travouBoss)
        {
            if (player.stateBoss == 1 || player.stateBoss == 3)
            {
                offset.z = -19;
                minX = 257.5f;
                maxX = 257.5f;
                minY = 4.2f;
                maxY = 15f;
            }
            if (player.stateBoss == 2)
            {
                countBoss++;
                transform.position = new Vector3 (mula.transform.position.x, mula.transform.position.y, -8);
                if (countBoss > 100)
                {
                    player.stateBoss = 3;
                    player.canMover = true;
                }
            }
            if (player.stateBoss == 3)
            {
                player.canMover = true;
            }
        }
        else
        {
            minX = 30f;
            maxX = 277f;
            minY = -.45f;
            maxY = 15f;
        }
    }
}