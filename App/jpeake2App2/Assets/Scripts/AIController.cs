using UnityEngine;

public class AIController : MonoBehaviour
{
	public Transform player;

	public float speed = 6f;
	public bool aIIt;
	public GameObject AISphere;

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
