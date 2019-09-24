using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	float defTimer = 5 * 60f;
	static float timer; 
	int playerScore = 0;
	PlayerController PlayerControllerScript = null;
	LeaderBoard leaderBoard = null;

	void Awake()
	{
		GameObject g2 = GameObject.FindGameObjectWithTag("Player");
		if (g2 != null)
			PlayerControllerScript = g2.GetComponent<PlayerController>();

		GameObject g = GameObject.FindGameObjectWithTag("StaticObj");
		if (g != null)
			leaderBoard = g.GetComponent<LeaderBoard>();
	}

	void Start()
    {
		timer = defTimer;
    }

    void Update()
    {
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			timer = defTimer;
		}
		else
		{
			if (PlayerControllerScript == null)
			{
				GameObject g2 = GameObject.FindGameObjectWithTag("Player");
				if (g2 != null)
					PlayerControllerScript = g2.GetComponent<PlayerController>();
			}

			timer -= Time.deltaTime;

			if (!PlayerControllerScript.playerit)
				playerScore++;

			if (timer <= 0)
			{
				if (leaderBoard == null)
				{
					GameObject g = GameObject.FindGameObjectWithTag("StaticObj");
					leaderBoard = g.GetComponent<LeaderBoard>();
				}

				timer = 0;
				leaderBoard.UpdateLb(playerScore);
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
			}
		}
	}
}
