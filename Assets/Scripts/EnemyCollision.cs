using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
	public Parry parry;

	void OnCollisionEnter2D(Collision2D collision)
	{
		//Debug.Log(collision);
		if (collision.gameObject.CompareTag("Enemy"))
		{
			parry.FailedlParry();
		}
	}

	public void KillEnemy(GameObject enemy)
    {
		Destroy(enemy);
	}


}
