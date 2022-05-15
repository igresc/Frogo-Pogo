using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
	[SerializeField] GameObject[] Spawners;
	private bool canSpawn;
	private float time;

	private void Start()
	{
		time = 0;
		canSpawn = true;
		
	}

	private void Update()
	{
		time += Time.deltaTime;
		spawnActive();
		
	}

	private void spawnActive()
	{
		int number = Random.Range(0, Spawners.Length);
		float cooldown = 7;

		if (time >= 30)
		{
			cooldown = 200/time;
		}

		
		if(canSpawn)
		{
			StartCoroutine(CooldownSpawns(cooldown));
			Spawners[number].SetActive(true);
		}
			
	}

	private IEnumerator CooldownSpawns(float time)
	{
		canSpawn = false;
		yield return new WaitForSeconds(time);
		canSpawn = true;
	}
}
