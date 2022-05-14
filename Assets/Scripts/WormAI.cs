using UnityEngine;

public class WormAI : MonoBehaviour
{
	public float speed;
	private float jumpDistance;
	public float lineOfSight = 5;
	public bool isChasing;
	private GameObject player;
	private Vector2 number;
	private GameObject trophy;

	private Rigidbody2D rb;
	public Vector2 parrySpeed;
	public ParticleSystem deathParticles;

	//public Parry parry;

	void Start()
	{
		trophy = GameObject.FindGameObjectWithTag("Trophy");
		player = GameObject.FindGameObjectWithTag("Player");
		rb = GetComponent<Rigidbody2D>();
		
		jumpDistance = 0.5f;
	} 
	void Update()
	{
		ChaseTrophy();
	}
	private void ChaseTrophy()
	{
		Vector2 moveTo = trophy.transform.position; //Trophy position
		moveTo.y = 0; //Set Y position to 0
		transform.position = Vector2.MoveTowards(transform.position, moveTo, speed * Time.deltaTime); //Move worm to the new position.

		if (moveTo.x - transform.position.x <= jumpDistance && moveTo.x - transform.position.x >= 0)
		{
			rb.velocity = Vector2.zero;
			rb.velocity = Vector2.up * parrySpeed;
		}

		if (moveTo.x - transform.position.x >= -jumpDistance && moveTo.x - transform.position.x <= 0)
		{
			rb.velocity = Vector2.zero;
			rb.velocity = Vector2.up * parrySpeed;
		}


	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject == trophy)
		{
			player.GetComponent<Parry>().FailedlParry();
			//parry.FailedlParry();
			Dead();
		}
	}

		private void Flip()
	{
		if(transform.position.x > player.transform.position.x)
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
