using System.Collections;
using UnityEngine;

public class Stomp : MonoBehaviour
{
	public CharacterController2D characterController;
	public float stompForce;

	private Rigidbody2D rb;

	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if(Input.GetAxisRaw("Jump") > 0)
		{
			Debug.Log("Stomp");
			StompMove();
		}
	}

	void StompMove()
	{
		rb.AddForce(Vector2.down * stompForce, ForceMode2D.Impulse);
		//rb.velocity = Vector2.down * stompForce;
	}


}
