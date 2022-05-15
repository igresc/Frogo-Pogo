using UnityEngine;

public class WormAI : MonoBehaviour
{
	public float speed;
	private float jumpDistance;
	public float lineOfSight = 5;
	public bool isChasing;
	private GameObject player;
	private GameObject trophy;

	private Rigidbody2D rb;
	public Vector2 parrySpeed;
	public ParticleSystem deathParticles;

	public AudioSource spawnSound;

	void Start()
	{
		trophy = GameObject.FindGameObjectWithTag("Trophy");
		player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody2D>();

		jumpDistance = 0.5f;
		spawnSound.Play();
	}

	void Update()
	{
		ChaseTrophy();
		Flip();
	}

	private void ChaseTrophy()
	{
		Vector2 moveTo = trophy.transform.position; //Trophy position
		moveTo.y = 0; //Set Y position to 0
		transform.position = Vector2.MoveTowards(transform.position, moveTo, speed * Time.deltaTime); //Move worm to the new position.

		if(moveTo.x - transform.position.x <= jumpDistance && moveTo.x - transform.position.x >= 0)
		{
			rb.velocity = Vector2.zero;
			rb.velocity = Vector2.up * parrySpeed;
		}

		if(moveTo.x - transform.position.x >= -jumpDistance && moveTo.x - transform.position.x <= 0)
		{
			rb.velocity = Vector2.zero;
			rb.velocity = Vector2.up * parrySpeed;
		}
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Trophy"))
		{
			player.GetComponent<Parry>().FailedlParry();
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
