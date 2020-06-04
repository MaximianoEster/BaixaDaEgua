using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mula : MonoBehaviour
{ 
    public Rigidbody2D bullet;
    public Transform[] shotSpawners;
    public float minYForce, maxYForce;
    public float fireRateMin, fireRateMax;

    public GameObject enemy;
    public Transform enemySpawn;
    public float minEnemyTime, maxEnemyTime;

    public int health;

    private bool isDead = false;
    private SpriteRenderer sprit;

    

    // Start is called before the first frame update
    void Start()
    {
        Fire();
        InstantiateEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateEnemies()
    {
        if (!isDead)
        {
            Instantiate(enemy, enemySpawn.position, enemySpawn.rotation);
            Invoke("InstantiateEnemies", Random.Range(minEnemyTime, maxEnemyTime));
        }
    }

    void Fire()
    {
        if (!isDead)
        {
            Rigidbody2D tempBullet = Instantiate(bullet, shotSpawners[Random.Range(0, shotSpawners.Length)].position, Quaternion.identity);
            tempBullet.AddForce(new Vector2(0, Random.Range(minYForce, maxYForce)), ForceMode2D.Impulse);
            Invoke("Fire", Random.Range(fireRateMin, fireRateMax));
        }
    }

    public void TookDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            isDead = true;
            Inimigo[] enemies = FindObjectsOfType<Inimigo>();
            foreach (Inimigo enemy in enemies)
            {
                enemy.gameObject.SetActive(false);
            }
            Bullet[] bullets = FindObjectsOfType<Bullet>();
            foreach (Bullet bullet in bullets)
            {
                bullet.gameObject.SetActive(false);
            }

            Invoke("LoadScene", 2f);

        }
        else
        {
            StartCoroutine(TookDamageCoRoutine());
        }
    }

    IEnumerator TookDamageCoRoutine()
    {
        sprit.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprit.color = Color.white;
    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

