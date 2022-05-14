using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguiluchoAtack : MonoBehaviour
{
	public Animator animator;

	public float distanceRaycast = 0.5f;

	public float cooldownAttack = 1.5f;

	public GameObject AguiluchoBullet;

	private float actualCooldownAttack;


	void Start()
	{
		actualCooldownAttack = 0;

	}

	// Update is called once per frame
	void Update()
	{
		actualCooldownAttack -= Time.deltaTime;
	}

	private void FixedUpdate()
	{
		RaycastHit2D hit2D = Physics2D.CircleCast(transform.position, 7, Vector2.down, distanceRaycast);

		if(hit2D.collider != null)
		{
			if(hit2D.collider.CompareTag("Player"))
			{
				if(actualCooldownAttack <= 0)
				{
					Invoke("launchBullet", 0.5f);
					//animator.Play("Attack");
					actualCooldownAttack = cooldownAttack;
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
