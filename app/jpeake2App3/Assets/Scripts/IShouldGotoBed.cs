using UnityEngine;
using UnityEngine.SceneManagement;

public class IShouldGotoBed : MonoBehaviour
{
	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
