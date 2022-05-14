using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Parry parryController;

	public float runSpeed = 40f;
	float horizontalMove = 0f;

	[SerializeField] public float fallMultiplier = 6f;
	[SerializeField] public float lowJumpMultiplier = 5.5f;


	public bool isJumping;

	Rigidbody2D m_Rigidbody2D;

	void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if(Input.GetButtonDown("AltJump"))
		{
			isJumping = true;
		}

		//if(m_Rigidbody2D.velocity.y < 0)
		//{
		//	m_Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime; // -1 acount for the physics system normal gravity
		//}
		//else if(m_Rigidbody2D.velocity.y > 0 && !Input.GetButton("AltJump"))
		//{
		//	m_Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime; // -1 acount for the physics system normal gravity
		//}

	}
	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false);
		//if(isJumping)
		//{
		//	isJumping = false;
		//	controller.Jump();
		//}
	}
}
