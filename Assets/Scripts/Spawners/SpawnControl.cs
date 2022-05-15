using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
	[SerializeField] GameObject[] Spawners;
	private bool canSpawn;
	private float time;

	public ParticleSystem spawnParticles;

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
		float cooldown = 4;

		if (time >= 30)
		{
			cooldown = 150/time;
		}

		
		if(canSpawn)
		{
			spawnParticles.transform.position = Spawners[number].transform.position;
			Instantiate(spawnParticles);
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
