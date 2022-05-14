using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
	[SerializeField] private Text timeText;

	[SerializeField] private float timeValue = 90;
	[SerializeField] private const float parryAddedTime = 5; //Same time to add or to sustract

	public Animator timer;

	Color defaultColor;
	// Update is called once per frame
	void Start()
	{
		defaultColor = timeText.color;
	}
	void Update()
	{
		if(timeValue > 0)
		{
			timeValue -= Time.deltaTime;
		}
		else
		{
			timeValue = 0;
		}
		DisplayTime(timeValue);

		//Debug.Log(timeValue);
	}
	void DisplayTime(float timeToDisplay)
	{
		if(timeToDisplay < 0)
		{
			timeToDisplay = 0;
		}

		float minutes = Mathf.FloorToInt(timeToDisplay / 60);
		float seconds = Mathf.FloorToInt(timeToDisplay % 60);

		timeText.text = string.Format("{00:00}:{1:00}", minutes, seconds);

		if (seconds <= 10 && minutes <= 0)
		{
			timeText.color = new Color(255, 0, 0, 255);
			timer.SetBool("Finishing", true);
		}
		else
		{
			timeText.color = defaultColor;
			timer.SetBool("Finishing", false);
		}
	}

	public void AddParryTime()
	{
		timeValue += parryAddedTime;
		timeText.color = new Color(0, 255, 0, 255);
		timer.SetBool("Finishing", true);
	}

	public void RemoveParryTime()
	{
		timeValue -= parryAddedTime;
	}
}
