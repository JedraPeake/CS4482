using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	// set up enemy track point
	Transform[] points;
	GameObject waypoint;
	string waypointTag = "Waypoint";

	// player controller
	int lives = 20;
	int startMoney = 600;

	// wave controller
	float lastwave = 30;
	float timeBetweenWaves = 5f;
	float countdown = 2f;
	float waveIndex = 0;
	WaveSpawner WaveSpawner = null;

	// ui controller
	UIController UIController = null;

	private void Awake()
	{
		waypoint = GetObjectByTag(waypointTag);

		GameObject g = GameObject.FindGameObjectWithTag("Enemies");
		if (g != null)
			WaveSpawner = g.GetComponent<WaveSpawner>();

		GameObject g2 = GameObject.FindGameObjectWithTag("UI");
		if (g2 != null)
			UIController = g2.GetComponent<UIController>();
	}

	void Start()
	{
		FindWayPoints();

		PlayerController.currentMoney = startMoney;
		PlayerController.lives = lives;

		UIController.lastwave = lastwave;
		UIController.SetLives(PlayerController.lives);
		UIController.SetMoney(PlayerController.currentMoney);
	}

	void Update()
	{
		if (waveIndex < lastwave)
		{
			if (countdown <= 0f)
			{
				waveIndex++;
				UIController.SetWaveCounterText(waveIndex);
				StartCoroutine(WaveSpawner.SpawnWave(waveIndex));
				countdown = timeBetweenWaves;
			}

			countdown -= Time.deltaTime;
			UIController.SetwaveCountdownText(Mathf.Round(countdown));
		}
		else
		{
			GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
			if (enemies == null || enemies.Length == 0)
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
		}
	}

	public void FindWayPoints()
	{
		if (waypoint == null)
			waypoint = GetObjectByTag(waypointTag);

		if (waypoint != null)
		{
			points = new Transform[waypoint.transform.childCount];
			for (int i = 0; i < waypoint.transform.childCount; i++)
			{
				points[i] = waypoint.transform.GetChild(i);
			}
		}
	}

	private GameObject GetObjectByTag(string tag)
	{
		GameObject gameObject = GameObject.FindGameObjectWithTag(tag);
		return gameObject;
	}

	public Transform[] GetWayPoints()
	{
		return points;
	}

	public void removeLive(int hitsleft)
	{
		PlayerController.lives -= hitsleft;
		UIController.SetLives(PlayerController.lives);

		if (PlayerController.lives <= 0)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}

	public void addMoney()
	{
		PlayerController.currentMoney = PlayerController.currentMoney + 3;
		UIController.SetMoney(PlayerController.currentMoney);
	}
}
