using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
	public void FS()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void CS()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
	}

	public void G()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
