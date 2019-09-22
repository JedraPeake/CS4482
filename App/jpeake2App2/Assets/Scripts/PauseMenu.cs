using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
	public static bool GameIsPasued = false;
	public GameObject PauseMenuUi;

    void Start()
    {
        
    }

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (GameIsPasued)
			{
				Resume();
			}
			else
			{
				Pause();
			}
		}
    }

	public void Resume()
	{
		PauseMenuUi.SetActive(false);
		Time.timeScale = 1f;
		GameIsPasued = false;
	}

	void Pause()
	{
		PauseMenuUi.SetActive(true);
		Time.timeScale = 0f;
		GameIsPasued = true;
	}

	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
