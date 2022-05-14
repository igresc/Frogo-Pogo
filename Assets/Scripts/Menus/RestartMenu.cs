using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
	public GameObject restartMenuUi;
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.K))
		{
			Time.timeScale = 0f;
			restartMenuUi.SetActive(true);
		}

	}
	public void RestartGame()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Level");
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
