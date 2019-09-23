using UnityEngine;

public class AIController : MonoBehaviour
{
	Transform player;
	Rigidbody aiRigidbody;
	Vector3 movement;

	int maxDist = 1000;
	int minDist = 0;

	public float speed = 6f;
	public bool aIIt;
	public GameObject AISphere;

	AIShooting AIShootingScript;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		aiRigidbody = GetComponent<Rigidbody>();

		GameObject g = GameObject.FindGameObjectWithTag("AIShoot");
		AIShootingScript = g.GetComponent<AIShooting>();
	}

	void Start()
	{
	}

	void Update()
	{
		Turn();

		Move();

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
		var calcPos = transform.forward * speed * Time.deltaTime;
		if (Random.Range(0.0f, 15.0f) > 10)
			calcPos *= 2;

		transform.position += calcPos;
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
