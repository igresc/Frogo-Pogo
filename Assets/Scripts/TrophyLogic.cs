using UnityEngine;
using UnityEngine.UI;

public class TrophyLogic : MonoBehaviour
{
	public Timer timer;

	public Text scoreText;
	public Parry parry;
	public int score;

	[SerializeField] private const float removeTime = 5; 
	public const int lottusRemoveScore = 50;

	public ParticleSystem addParticles;
	public Animator scoreAnim;

	float startTimer = 1;
	bool isAdding, isRemoving;

	Color defaultColor;
	private void Start()
	{
		defaultColor = scoreText.color;
		score = 0;
	}
	private void Update()
	{
		if(score <= 0)
		{
			score = 0;
		}

		//if (Input.GetKeyDown(KeyCode.U)) 
		//{
		//	AddScore();
		//}
		//if (Input.GetKeyDown(KeyCode.Y))
		//{
		//	RemoveScore();
		//}

		if(isAdding || isRemoving)
		{
			startTimer -= Time.deltaTime;
			if(startTimer <= 0)
			{
				scoreText.color = defaultColor;
				scoreAnim.SetBool("Add", false);
				isAdding = false;
				isRemoving = false;
				startTimer = 1;
			}
			else
			{
				scoreAnim.SetBool("Add", true);
				if(isRemoving) { scoreText.color = new Color(255, 0, 0, 255); }
				if(isAdding) { scoreText.color = new Color(0, 255, 0, 255); }

			}
		}

		scoreText.text = System.Convert.ToString(score);
	}

	public void AddScore(int addScore)
	{
		score += addScore;
		isAdding = true;
		addParticles.transform.position = transform.position;
		Instantiate(addParticles);
	}

	public void RemoveScore(int removeScore)
	{
		score -= removeScore;
		isRemoving = true;
		scoreText.color = new Color(255, 0, 0, 255);
	}

	// Flor collision
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Enemy"))
		{
			RemoveScore(lottusRemoveScore);
			timer.RemoveTime(removeTime);
		}
	}
}
