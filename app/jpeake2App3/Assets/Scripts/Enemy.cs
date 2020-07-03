using UnityEngine;

public class Enemy : MonoBehaviour {

	public float Startspeed = 10f;
	public float speed;
	GameController GameControllerScript;

	private Transform target;
	Transform[] wayPoints;
	private int currentWavePointIndex = 0;
	public int hits;

	void Start ()
	{
		GameObject g = GameObject.FindGameObjectWithTag("MainCamera");
		GameControllerScript = g.GetComponent<GameController>();

		speed = Startspeed;
	}

	void Update ()
	{
		moveTowardsNextWaypoint();
	}

	void moveTowardsNextWaypoint()
	{
		if (target == null)
		{
			Transform[] temp = GameControllerScript.GetWayPoints();
			target = temp[0];
			wayPoints = temp;
		}

		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= 0.2f)
		{

			if (currentWavePointIndex > wayPoints.Length)
			{
				GameControllerScript.removeLive(hits);
				Destroy(gameObject);
			}
			else
			{
				currentWavePointIndex++;
				target = wayPoints[currentWavePointIndex];
			}
		}

		speed = Startspeed;
	}

	public void ImHit()
	{
		hits--;

		if (hits <= 0)
		{
			Destroy(gameObject);
		}

		GameControllerScript.addMoney();
	}

	public void Slow()
	{
		speed = 5f;
	}
}
