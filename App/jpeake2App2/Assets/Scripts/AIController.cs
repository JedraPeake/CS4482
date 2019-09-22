using UnityEngine;

public class AIController : MonoBehaviour
{
	Transform player;
	Rigidbody aiRigidbody;
	Vector3 movement;

	int maxDist = 100;
	int minDist = 5;

	public float speed = 6f;
	public bool aIIt;
	public GameObject AISphere;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		aiRigidbody = GetComponent<Rigidbody>();
	}

	void Start()
	{
	}

	void Update()
	{
		Turn();
		Move();

		// fix this
		HideSphere();

	}

	void Turn()
	{
		if (!aIIt)
		{
			var t = Random.Range(0.0f, 15.0f);
			if (t > 14)
				transform.rotation = Quaternion.Euler(new Vector3(0f, Random.Range(-90.0f, 90.0f), 0f));
		}
		else
		{
			transform.LookAt(player);
		}
	}

	void HideSphere()
	{
		if (!aIIt)
		{
			AISphere.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			AISphere.GetComponent<Renderer>().enabled = true;
		}
	}

	void Move()
	{
		if (!aIIt)
		{
			var calcPos = transform.forward * speed * Time.deltaTime;
			var t = Random.Range(0.0f, 15.0f);
			if (t > 10)
				calcPos *= 2;

			transform.position += calcPos;
		}
		else
		{
			if (Vector3.Distance(transform.position, player.position) >= minDist)
			{
				transform.position += transform.forward * speed * Time.deltaTime;

				if (Vector3.Distance(transform.position, player.position) <= maxDist)
				{
					//Here Call any function U want Like Shoot at here or something
				}

			}
		}
	}

	public void MakeIt()
	{
		aIIt = true;
	}

	public void MakeNotIt()
	{
		aIIt = false;
	}
}
