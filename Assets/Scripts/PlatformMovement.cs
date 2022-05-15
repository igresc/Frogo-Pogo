using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
	public Transform[] moveSpot;
	private int i = 0;
	private float waitTime;
	public float startWaitTime = 2;
	private GameObject Player;
	public float speed = 1f;
	// Start is called before the first frame update
	private void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		waitTime = startWaitTime;
	}

	// Update is called once per frame
	void Update()
    {
		transform.position = Vector2.MoveTowards(transform.position, moveSpot[i].transform.position, speed * Time.deltaTime);
		if (Vector2.Distance(transform.position, moveSpot[i].transform.position) < 0.1f)
		{
			if (waitTime <= 0)
			{
				if (moveSpot[i] != moveSpot[moveSpot.Length - 1])
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
