using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltPlayerMovement : MonoBehaviour
{
	private float horizontal;
	private float speed = 8f;
	private float jumpingPower = 20f;
	private bool isFacingRight = true;

	private bool isJumping;

	private float coyoteTime = 0.2f;
	private float coyoteTimeCounter;

	private float jumpBufferTime = 0.2f;
	private float jumpBufferCounter;

	[SerializeField] private Rigidbody2D rb;
	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask groundLayer;

	private void Update()
	{
		horizontal = Input.GetAxisRaw("Horizontal");

		if(IsGrounded())
		{
			coyoteTimeCounter = coyoteTime;
		}
		else
		{
			coyoteTimeCounter -= Time.deltaTime;
		}

		if(Input.GetButtonDown("Jump"))
		{
			jumpBufferCounter = jumpBufferTime;
		}
		else
		{
			jumpBufferCounter -= Time.deltaTime;
		}

		if(coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

			jumpBufferCounter = 0f;

			StartCoroutine(JumpCooldown());
		}

		if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
		{
			rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

			coyoteTimeCounter = 0f;
		}

		if(rb.velocity.y < 0)
		{
			rb.velocity += Vector2.up * Physics2D.gravity.y * (3 - 1) * Time.deltaTime; // -1 acount for the physics system normal gravity
		}

		Flip();
	}

	private void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
	}

	private bool IsGrounded()
	{
		return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
	}

	private void Flip()
	{
		if(isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
		{
			Vector3 localScale = transform.localScale;
			isFacingRight = !isFacingRight;
			localScale.x *= -1f;
			transform.localScale = localScale;
		}
	}

	private IEnumerator JumpCooldown()
	{
		isJumping = true;
		yield return new WaitForSeconds(0.4f);
		isJumping = false;
	}
}
