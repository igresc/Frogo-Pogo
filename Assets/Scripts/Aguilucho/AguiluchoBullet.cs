using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguiluchoBullet : MonoBehaviour
{
	public float speed = 20;
	public float lifeTime = 2;

	private GameObject Player;

	private void Start()
	{
		Destroy(gameObject, lifeTime);
		Player = GameObject.FindGameObjectWithTag("Player");
	}

	private void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
	}
	private void Flip()
	{
		if (transform.position.x > Player.transform.position.x)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}
}
