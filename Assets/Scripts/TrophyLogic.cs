using UnityEngine;
using UnityEngine.UI;

public class TrophyLogic : MonoBehaviour
{
	public Text scoreText;
	public Parry parry;
	public int score;

	public int addScore = 50;
	public int removeScore = 100;
	private void Start()
	{
		score = 0;
	}
	private void Update()
	{
		if (score <= 0)
		{
			score = 0;
		}

		scoreText.text = System.Convert.ToString(score);
	}
	void AddScore()
	{
		score += addScore;
	}
	void RemoveScore()
	{
		score -= removeScore;
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Enemy"))
		{
			RemoveScore();
		}
	}
}
