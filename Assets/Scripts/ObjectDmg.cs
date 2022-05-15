using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDmg : MonoBehaviour
{
	[SerializeField] AguiluchoBullet variables;
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			//Destroy(collision.gameObject);
			variables.deadParticles.transform.position = transform.position;
			Instantiate(variables.deadParticles);
			Destroy(gameObject);
		}
	}
}
