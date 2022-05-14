using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
	[SerializeField] GameObject[] Spawners;

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.T))
		{
			int number = Random.Range(0, Spawners.Length);
			Debug.Log(number);
			switch(number)
			{
				case 0:
					Spawners[0].SetActive(true);
					break;
				case 1:
					Spawners[1].SetActive(true);
					break;
				case 2:
					Spawners[2].SetActive(true);
					break;
				case 3:
					Spawners[3].SetActive(true);
					break;
			}
		}
	}

}
