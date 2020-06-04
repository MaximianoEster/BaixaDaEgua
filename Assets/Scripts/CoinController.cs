using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    protected AudioSource audioSource;
    protected int count, count2, flipX;
    protected float jumpY, jumpX;
    protected bool canCount, canJump;
    [SerializeField] private AudioClip soundCoin;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        count = 0;
        flipX = Random.Range(0, 2);

        canJump = true;
    }

    // Update is called once per frame
    void Update()
    {
        jumpY = Random.Range(5f, 12f);
        jumpX = Random.Range(1, 5);
        Physics2D.IgnoreLayerCollision(11, 10);
        Physics2D.IgnoreLayerCollision(11, 11);
        flip();

        if (canCount)
        {
            count++;
        }
        if (count > 20)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            canCount = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<CircleCollider2D>().enabled = false;
            audioSource.PlayOneShot(soundCoin, .4f);
        }
    }
    private void flip()
    {
        if (flipX == 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            salto(jumpX);

        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            salto(-jumpX);
        }
    }

    private void salto(float x)
    {
        if (canJump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(x, jumpY), ForceMode2D.Impulse);
            canJump = false;
        }
    }
}
