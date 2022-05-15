using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
	[SerializeField] GameObject PauseMenu;
	[SerializeField] GameObject RestartMenu;
	[SerializeField] GameObject StartScreen;
	private void Update()
	{
		if (PauseMenu.activeSelf || RestartMenu.activeSelf || StartScreen.activeSelf)
		{
			Time.timeScale = 0f;
		}
		else { Time.timeScale = 1f; }
	}
}
