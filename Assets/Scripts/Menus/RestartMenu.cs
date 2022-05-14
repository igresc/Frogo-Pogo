using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
	public GameObject restartMenuUi;
	public GameObject Pause;
	private void Update()
	{
		//if(Input.GetKeyDown(KeyCode.K))
		//{
		//	Time.timeScale = 0f;
		//	restartMenuUi.SetActive(true);
		//}
		if (restartMenuUi.activeSelf == true)
		{
			Pause.SetActive(false);
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
