using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDmg : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.transform.CompareTag("Player"))
		{
			//Destroy(collision.gameObject);
			Destroy(gameObject);
		}
	}
}
