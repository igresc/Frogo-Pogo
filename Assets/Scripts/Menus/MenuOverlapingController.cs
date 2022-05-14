using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOverlapingController : MonoBehaviour
{
	[SerializeField] private GameObject Pause;
	[SerializeField] private GameObject Restart;
	private void Update()
	{
		if (Restart.activeSelf == true) 
		{
			Pause.SetActive(false);
		}
	}
}
