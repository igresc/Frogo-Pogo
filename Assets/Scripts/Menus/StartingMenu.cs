using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingMenu : MonoBehaviour
{
	[SerializeField] private Text text;
	[SerializeField] private GameObject StartingPanel;
	int countdown;
	float timeDown = 5;

	// Start is called before the first frame update
	void Start()
	{
		countdown = 3;
		text.text = System.Convert.ToString(countdown);
	}

	// Update is called once per frame
	void Update()
	{
		Invoke("Countdown", 1);
		text.text = System.Convert.ToString(countdown);
		if(countdown <= 0)
		{
			StartingPanel.SetActive(false);
		}
	}
	void CountDown()
	{
		Debug.Log("Time");
		countdown--;
	}
}
