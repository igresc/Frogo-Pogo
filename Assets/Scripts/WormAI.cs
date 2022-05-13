using UnityEngine;

public class WormAI : MonoBehaviour
{
	public float speed;
	public float lineOfSight = 5;
	public bool isChasing;
	private GameObject player;
	private Vector2 number;
	private float movingTime = 2;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	void Update()
	{
		if (movingTime <= 0)
		{
			number.x = Random.Range(-20, 20);
			number.y = 0;
			movingTime = 2;
		}
		else movingTime -= Time.deltaTime;

		Patroling();

		Flip();

	}
	private void Patroling()
	{
		Vector2 moveTo = number;
		transform.position = Vector2.MoveTowards(transform.position, moveTo, speed * Time.deltaTime);
		Debug.Log("Worm" + Vector2.MoveTowards(transform.position, moveTo, speed * Time.deltaTime));
	}
	private void Flip()
	{
		if (transform.position.x > player.transform.position.x)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
	}

}
