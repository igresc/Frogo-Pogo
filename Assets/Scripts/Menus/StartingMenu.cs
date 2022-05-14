using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingMenu : MonoBehaviour
{
	[SerializeField] private GameObject StartScreen;
	bool isActive = true;
	void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			Time.timeScale = 1f;
			StartScreen.SetActive(false);
			isActive = false;
		}
		else if (isActive == true) 
		{
			Time.timeScale = 0f;
		}
	}
}
