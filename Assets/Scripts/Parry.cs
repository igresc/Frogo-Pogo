using UnityEngine;

public class Parry : MonoBehaviour
{
	public CharacterController2D controller;
	public Timer timer;
	public bool isParrying;
	public float slowDownTime = 0.3f;
	public Vector2 impulseForce;

	float defaultTimeFixedValue;
	// Start is called before the first frame update
	void Start()
	{
		defaultTimeFixedValue = Time.fixedDeltaTime;
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			isParrying = true;
			Time.timeScale = slowDownTime;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
			if (isParrying)
				Parry_Time();

			else
			{
				//Take_Damage();
			}
		}
		else if (collision.CompareTag("Parryable"))
		{
			isParrying = true;
			Time.timeScale = slowDownTime;
			Time.fixedDeltaTime = Time.timeScale * 0.02f;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isParrying = false;
		Time.timeScale = 1f;
		Time.fixedDeltaTime = defaultTimeFixedValue;
	}

	public void Parry_Time()
	{
		timer.ParryAddTime();

		Debug.Log(isParrying);
		Time.timeScale = 1f;
		Time.fixedDeltaTime = defaultTimeFixedValue;

		GetComponent<Rigidbody2D>().velocity = Vector2.zero;
		GetComponent<Rigidbody2D>().AddForce(impulseForce, ForceMode2D.Impulse);

	}
}