using UnityEngine;

public class MoscoAI : MonoBehaviour
{
	public float speed;
	public float lineOfSight = 5;
	public bool isChasing;
	private GameObject trophy;
	private Vector2 number;

	public ParticleSystem deathParticles;
	public Parry parry;

	void Start()
	{
		trophy = GameObject.FindGameObjectWithTag("Trophy");
		
	}

	void Update()
	{
		ChaseTrophy();
		Flip();
	}

	private void ChaseTrophy()
	{
		transform.position = Vector2.MoveTowards(transform.position, trophy.transform.position, speed * Time.deltaTime);
		if(Random.Range(0f, 1f) >= .3f)
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject == trophy)
		{
			parry.FailedlParry();
			Dead();
		}
	}

	private void Flip()
	{
		if(transform.position.x > trophy.transform.position.x)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}

	public void Dead()
	{
		Instantiate(deathParticles, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
