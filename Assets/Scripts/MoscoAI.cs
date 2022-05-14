using UnityEngine;

public class MoscoAI : MonoBehaviour
{
	public float speed;
	public bool is_IA_enabled = true;
	private GameObject trophy;

	public ParticleSystem deathParticles;

	void Start()
	{
		if(is_IA_enabled)
			trophy = GameObject.FindGameObjectWithTag("Trophy");
	}

	void Update()
	{
		if(is_IA_enabled)
		{
			ChaseTrophy();
			Flip();
		}
	}

	private void ChaseTrophy()
	{
		transform.position = Vector2.MoveTowards(transform.position, trophy.transform.position, speed * Time.deltaTime);
		if(Random.Range(0f, 1f) >= .3f)
			gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
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
