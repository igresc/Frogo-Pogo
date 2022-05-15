using System.Collections;
using UnityEngine;

public class Parry : MonoBehaviour
{
	public CharacterController2D controller;
	public Timer timer;
	public TrophyLogic score;
	public EnemyCollision enemyCollision;

	public float slowDownTime = 0.3f;
	public Vector2 parrySpeed;
	public float startParryDashTime;
	private float parryDashTime;
	public float parryDashStop = 2;

	public bool isParryMode;
	public bool isParryDash;

	public float startParryTime;
	public float midParryTime;
	private float parryTime;

	private GameObject enemy;

	private float defaultTimeFixedValue;
	private Rigidbody2D rb;

	public Animator frogo;
	public AudioSource parrySound;
	public ParticleSystem parryParticles;


	void Start()
	{
		defaultTimeFixedValue = Time.fixedDeltaTime;
		rb = GetComponent<Rigidbody2D>();
		parryDashTime = startParryDashTime;
		parryTime = startParryTime;
	}

	private void Update()
	{
		parryParticles.transform.position = transform.position;
		if ((isParryMode && Input.GetKeyDown(KeyCode.Space)) || isParryDash)
		{
			isParryDash = true;
			ParryAction();
		}
		else
		{
			ParryMode();
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		enemy = collision.gameObject;
		//Debug.Log(enemy.name);
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
			enemy = collision.transform.parent.gameObject;
			isParryMode = true;
			ParryMode();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		isParryMode = false;
		ExitParryMode();
	}

	public void ParryMode()
	{
		if(isParryMode)
		{
			//Time.timeScale = slowDownTime;
			//Time.fixedDeltaTime = Time.timeScale * .02f;

			if(parryTime <= 0)
			{
				isParryMode = false;
				parryTime = startParryTime;
			}
			//else if(parryTime <= midParryTime && parryTime > 0)
			//{
			//	Time.timeScale = 0.0000001f;
			//	Time.fixedDeltaTime = Time.timeScale * .02f;
			//}
			parryTime -= Time.fixedUnscaledDeltaTime;
		}
		else
		{
			ExitParryMode();
		}
		//Debug.Log(parryTime);
	}

	void ParryAction()
	{
		if(isParryMode)
		{
			SuccessfullParry();
		}

		isParryMode = false;
		ExitParryMode();

		if(parryDashTime <= 0)
		{
			isParryDash = false;
			parryDashTime = startParryDashTime;
			rb.velocity /= new Vector2(1, parryDashStop);
			//frogo.SetBool("IsParrying", false);
		}
		else // Succesfull parry
		{
			//Debug.Log(parryDashTime);
			parryDashTime -= Time.deltaTime;
			rb.velocity = Vector2.zero;
			rb.velocity = Vector2.up * parrySpeed;
		}
	}

	void ExitParryMode()
	{
		//frogo.SetBool("IsParrying", false);
		parryTime = startParryTime;
		//Time.timeScale = 1f;
		Time.fixedDeltaTime = defaultTimeFixedValue;
	}

	void SuccessfullParry()
	{
		StartCoroutine(ParryAnimation());
		//Debug.Log("aquiii" + enemy.name);
		if (enemy != null)
		{
			if (enemy.name.Contains("Mosco"))
			{
				MoscoAI mosco = enemy.GetComponent<MoscoAI>();
				mosco.Dead();
				timer.AddTime(mosco.addTime);
				score.AddScore(mosco.addScore);
			}

			if (enemy.name.Contains("Worm"))
			{
				WormAI worm = enemy.GetComponent<WormAI>();
				worm.Dead();
				timer.AddTime(worm.addTime);
				score.AddScore(worm.addScore);
			}

			if (enemy.name.Contains("Bullet"))
			{
				AguiluchoBullet aguilucho = enemy.GetComponent<AguiluchoBullet>();
				aguilucho.Dead();
				timer.AddTime(aguilucho.addTime);
				score.AddScore(aguilucho.addScore);
			}
			if (enemy.name.Contains("BeeSprite"))
			{
				AguiluchoAtack aa = enemy.GetComponent<AguiluchoAtack>();
				aa.isStuned = true;
			}
		}

	}

	public void FailedlParry()
	{
		if (enemy != null)
		{
			if (enemy.name.Contains("Mosco"))
			{
				MoscoAI mosco = enemy.GetComponent<MoscoAI>();
				timer.RemoveTime(mosco.removeTime);
				score.RemoveScore(mosco.removeScore);
			}

			if (enemy.name.Contains("Worm"))
			{
				WormAI worm = enemy.GetComponent<WormAI>();
				timer.RemoveTime(worm.removeTime);
				score.RemoveScore(worm.removeScore);
			}

			if (enemy.name.Contains("Bullet"))
			{
				AguiluchoBullet aguilucho = enemy.GetComponent<AguiluchoBullet>();
				timer.RemoveTime(aguilucho.removeTime);
				score.RemoveScore(aguilucho.removeScore);
			}
		}
	}

	private IEnumerator ParryAnimation()
	{
		frogo.SetBool("IsParrying", true);
		parrySound.Play();
		Instantiate(parryParticles);
		yield return new WaitForSeconds(0.4f);
		frogo.SetBool("IsParrying", false);
	}
}
