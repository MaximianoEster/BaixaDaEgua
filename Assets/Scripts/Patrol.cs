using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : Inimigo {

	public GameObject bulletPrefab;
	public float fireRate;
	public Transform shotSpawner;
	private float nextFire;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	protected override void Update () {

		base.Update();
		
		/*if(targetDistance < 0)
		{
			if (!facingRight)
			{
				Flip();
			}
		}
		else
		{
			if (facingRight)
			{
				Flip();
			}
		}*/

		if(Mathf.Abs(alvoDistancia) < distanciaAtaque && Time.time > nextFire)
		{
			anim.SetTrigger("Shooting");
			nextFire = Time.time + fireRate;
		}

	}

    public void Atirando()
    {

        GameObject tempTiro = Instantiate(bulletPrefab, shotSpawner.position, shotSpawner.rotation);



    }

}
