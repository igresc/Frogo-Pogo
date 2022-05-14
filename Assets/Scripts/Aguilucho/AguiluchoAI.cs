using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguiluchoAI : MonoBehaviour
{
	public Animator animator;

	public SpriteRenderer spritrender;

	public float speed = 0.5f;

	private float waitTime;

	public Transform[] moveSpot;

	public float startWaitTime = 2;

	private int i = 0;

	private Vector2 actualPos;

	private void Start()
	{
		waitTime = startWaitTime;
	}

	private void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, moveSpot[i].transform.position, speed * Time.deltaTime);

		if(Vector2.Distance(transform.position, moveSpot[i].transform.position) < 0.1f)
		{
			if(waitTime <= 0)
			{
				if(moveSpot[i] != moveSpot[moveSpot.Length - 1])
				{
					i++;
				}
				else
				{
					i = 0;
				}

				waitTime = startWaitTime;
			}
			else
			{
				waitTime -= Time.deltaTime;
			}
		}
	}


}
