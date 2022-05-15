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

	public bool isStuned;
	public float timeStuned;
	float defaultTimeStun;

	void Start()
	{
		actualCooldownAttack = 0;
		defaultBeeSkin = beeSkin.color;
		defaultTimeStun = timeStuned;
	}

	// Update is called once per frame
	void Update()
	{
		actualCooldownAttack -= Time.deltaTime;

		if(timeStuned <= 0)
		{
			isStuned = false;
		}

		if(isStuned)
		{ 
			beeSkin.color = new Color(255, 0, 124, 255);
			timeStuned -= Time.deltaTime;
		}
		else
		{
			timeStuned = defaultTimeStun;
			beeSkin.color = defaultBeeSkin;
		}
	}

	private void FixedUpdate()
	{
		RaycastHit2D hit2D = Physics2D.CircleCast(transform.position, distanceRaycast, Vector2.down);

		if(hit2D.collider != null)
		{
			if(hit2D.collider.CompareTag("Player"))
			{
				if(actualCooldownAttack <= 0 && !isStuned)
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
		Instantiate(AguiluchoBullet, transform.position, transform.rotation);
	}
}
