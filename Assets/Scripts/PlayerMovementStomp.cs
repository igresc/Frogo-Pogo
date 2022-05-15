using UnityEngine;

public class PlayerMovementStomp : MonoBehaviour
{
	public CharacterController2D controller;

	public float runSpeed = 40f;
	float horizontalMove = 0f;


	//TODO coyote Jump
	private float coyoteTime = 0.2f;
	private float coyoteTimeCounter;

	//Animators
	public Animator frogo;


	public bool isJumping;

	Rigidbody2D m_Rigidbody2D;

	public AudioSource walkSound;
	public AudioSource jumpSound;
	float audioTimer = 0.5f;
	bool canJump = true;
	void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("AltJump") && canJump)
		{
			isJumping = true;
			//jumpSound.pitch = Random.Range(0.7f, 1);
			//jumpSound.Play();
			//canJump = false;

		}

		//if(controller.m_Grounded || parryController.isParryDash)
		//{
		//	frogo.SetBool("IsJumping", false);
		//	canJump = true;
		//}
		//else 
		//{
		//	frogo.SetBool("IsJumping", true);
		//}

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		//Debug.Log(horizontalMove);
		//if(horizontalMove != 0)
		//{
		//	frogo.SetBool("IsWalking", true);
		//}
		//else
		//{
		//	frogo.SetBool("IsWalking", false);
		//}
	}

	void FixedUpdate()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, false);

		if(isJumping)
		{
			isJumping = false;
			controller.Jump(); 
		}
	}
}
