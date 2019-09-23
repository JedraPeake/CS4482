using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	float timer = 5 * 60f;
	int playerScore = 0;
	PlayerController PlayerControllerScript;

	void Awake()
	{
		GameObject g2 = GameObject.FindGameObjectWithTag("Player");
		PlayerControllerScript = g2.GetComponent<PlayerController>();
	}

	void Start()
    {
        
    }

    void Update()
    {
		timer -= Time.deltaTime;

		if (!PlayerControllerScript.playerit)
			playerScore++;

		if (timer <= 0)
		{
			timer = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
	}
}
