using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameController : MonoBehaviour
{
	float defTimer = 5 * 60f;
	static float timer; 
	int playerScore = 0;

	PlayerController PlayerControllerScript = null;
	LeaderBoard leaderBoard = null;
	TextMeshProUGUI time = null;
	TextMeshProUGUI score = null;

	void Awake()
	{
		GameObject g = GameObject.FindGameObjectWithTag("Player");
		if (g != null)
			PlayerControllerScript = g.GetComponent<PlayerController>();

		GameObject g2 = GameObject.FindGameObjectWithTag("StaticObj");
		if (g2 != null)
			leaderBoard = g2.GetComponent<LeaderBoard>();

		GameObject g3 = GameObject.FindGameObjectWithTag("PlayerTime");
		if (g3 != null)
			time = g3.GetComponent<TextMeshProUGUI>();

		GameObject g4 = GameObject.FindGameObjectWithTag("PlayerScore");
		if (g4 != null)
			score = g4.GetComponent<TextMeshProUGUI>();
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

			if (score == null)
			{
				GameObject g4 = GameObject.FindGameObjectWithTag("PlayerScore");
				if (g4 != null)
					score = g4.GetComponent<TextMeshProUGUI>();
			}

			if (time == null)
			{
				GameObject g3 = GameObject.FindGameObjectWithTag("PlayerTime");
				if (g3 != null)
					time = g3.GetComponent<TextMeshProUGUI>();
			}

			timer -= Time.deltaTime;
			char minutes = (timer / 60).ToString()[0];
			float seconds = (float)Math.Round(timer - ((int)char.GetNumericValue(minutes) * 60), 0);
			if (seconds == 0 || seconds == 1 || seconds == 2 || seconds == 3 || seconds == 4 || seconds == 5 || seconds == 6 || seconds == 7 || seconds == 8 || seconds == 9)
				time.text = "Time left: " + minutes + ":0" + seconds.ToString();
			else
				time.text = "Time left: " + minutes + ":" + seconds.ToString();

			if (!PlayerControllerScript.playerit)
			{
				playerScore++;
				score.text = "Score: " + playerScore.ToString();
			}

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
