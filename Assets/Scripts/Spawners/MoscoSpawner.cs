using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoscoSpawner : MonoBehaviour
{
	[SerializeField]
	GameObject[] Mosco;

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
	void Update()
	{
		Spawn();
	}

	void Spawn()
	{
		Debug.Log("Spawning");
		if (innerCount >= maxCount)
		{
			Destroy(this);
		}
		else
		{
			Vector2 pos = new Vector2(Random.Range(transform.position.x - 2, transform.position.x + 2), Random.Range(transform.position.y - 2, transform.position.y + 2));
			number = Random.Range(0, 2);
			Debug.Log(number);
			switch (number)
			{
				case 0:
					Instantiate(Mosco[0], pos, Quaternion.identity);
					innerCount++;
					break;
				case 1:
					Instantiate(Mosco[1], pos, Quaternion.identity);
					innerCount++;
					break;
			}
		}
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = new Color(0, 0, 1, 0.5f);
		Gizmos.DrawCube(center, size);
	}
}
