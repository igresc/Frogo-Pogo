using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguiluchoAtack : MonoBehaviour
{
	public Animator animator;

	public float distanceRaycast = 20f;

	public float cooldownAttack = 1.5f;

	public GameObject AguiluchoBullet;

	private float actualCooldownAttack;

	public SpriteRenderer beeSkin;

	Color defaultBeeSkin;

	public AudioSource beeShoot;
	void Start()
	{
		actualCooldownAttack = 0;
		defaultBeeSkin = beeSkin.color;
	}

	// Update is called once per frame
	void Update()
	{
		actualCooldownAttack -= Time.deltaTime;
	}

	private void FixedUpdate()
	{
		RaycastHit2D hit2D = Physics2D.CircleCast(transform.position, distanceRaycast, Vector2.down);

		if(hit2D.collider != null)
		{
			if(hit2D.collider.CompareTag("Player"))
			{
				if(actualCooldownAttack <= 0)
				{
					Invoke("launchBullet", 0.5f);
					//beeSkin.color = new Color(255, 0, 0, 255);
					//animator.Play("Attack");
					actualCooldownAttack = cooldownAttack;
					beeShoot.Play();
				}
			}
		}
	}

	void launchBullet()
	{
		GameObject newBullet;

		newBullet = Instantiate(AguiluchoBullet, transform.position, transform.rotation);

	}
}
