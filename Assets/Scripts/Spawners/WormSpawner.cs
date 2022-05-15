using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawner : MonoBehaviour
{
	[SerializeField]
	GameObject Worm;

	//Variables
	public int maxCount;
	int innerCount;
	int number;

	public Vector2 center;
	public Vector2 size;

	private void Start()
	{
		center = new Vector2(transform.position.x, transform.position.y);
	}
	void FixedUpdate()
	{
		Spawn();
	}

	void Spawn()
	{
		
		int x = Random.Range(1, maxCount+1);

		if (innerCount >= x)
		{
			gameObject.SetActive(false);
			innerCount = 0;
		}
		else
		{
			Vector2 pos = new Vector2(Random.Range(transform.position.x - 2, transform.position.x + 2), transform.position.y);
			Instantiate(Worm, pos, Quaternion.identity);
			innerCount++;
		}
		//Time.timeSinceLevelLoad;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0, 0, 1, 0.5f);
		Gizmos.DrawCube(center, size);
	}
}
