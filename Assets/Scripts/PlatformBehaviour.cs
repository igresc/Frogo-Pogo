using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
	private PlatformEffector2D effector;
	public float waitTime;
	public float moveInput;
	public bool isPlayer;
	// Start is called before the first frame update
	void Start()
	{
		effector = GetComponent<PlatformEffector2D>();
		isPlayer = false;
	}

	// Update is called once per frame
	void Update()
	{
		moveInput = Input.GetAxisRaw("Vertical");

		if(moveInput < 0 && isPlayer == true)
		{
			effector.rotationalOffset = 180f;
			waitTime -= Time.deltaTime;
		}
		if(Input.GetButtonDown("AltJump") || waitTime <= 0)
		{
			effector.rotationalOffset = 0;
			waitTime = 0.5f;
		}
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag != "Player")
		{
			effector.rotationalOffset = 0;
		}
		else if(collision.tag == "Player")
		{
			isPlayer = true;
		}
	}
}
