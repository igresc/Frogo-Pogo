using UnityEngine;

public class Parry : MonoBehaviour
{
	public CharacterController2D controller;
	public Timer timer;
	public LayerMask enemyLayer;

	public float slowDownTime = 0.3f;
	public Vector2 parrySpeed;
	public float startParryDashTime;
	private float parryDashTime;
	public float parryDashStop = 2;

	public bool isParryMode;
	public bool isParryDash;

	public float startParryTime;
	private float parryTime;

	private float defaultTimeFixedValue;
	private Rigidbody2D rb;
	// Start is called before the first frame update
	void Start()
	{
		defaultTimeFixedValue = Time.fixedDeltaTime;
		rb = GetComponent<Rigidbody2D>();
		parryDashTime = startParryDashTime;
	}

	private void Update()
	{
		if((isParryMode && Input.GetKeyDown(KeyCode.Space)) || isParryDash)
		{
			isParryDash = true;
			ParryAction();
		}

	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		//if(collision.CompareTag("Enemy"))
		//{
		//	isParryMode = true;
		//	Time.timeScale = slowDownTime;
		//	Time.fixedDeltaTime = Time.timeScale * 0.02f;
		//	if(isParryMode)
		//	{
		//		ParryMode();
		//	}
		//	else
		//	{
		//		//Take_Damage();
		//	}
		//}
		//else
		if(collision.CompareTag("Parryable"))
		{
			ParryMode();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isParryMode = false;
		Time.timeScale = 1f;
		Time.fixedDeltaTime = defaultTimeFixedValue;
	}

	public void ParryMode()
	{
		Time.timeScale = slowDownTime;
		Time.fixedDeltaTime = Time.timeScale * .02f;
		isParryMode = true;
		//parryTime = startParryTime;

		//ParryAction();
	}

	void ParryAction()
	{
		if(isParryMode)
		{
			timer.AddParryTime();
		}

		isParryMode = false;
		Time.timeScale = 1f;
		Time.fixedDeltaTime = defaultTimeFixedValue;

		if(parryDashTime <= 0)
		{
			isParryDash = false;
			parryDashTime = startParryDashTime;
			rb.velocity /= new Vector2(1, parryDashStop);
		}
		else // Succesfull parry
		{
			Debug.Log(parryDashTime);
			parryDashTime -= Time.deltaTime;
			rb.velocity = Vector2.up * parrySpeed;
		}
	}
}
