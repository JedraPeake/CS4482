using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
	Transform player;

	public float speed = 6f;
	Rigidbody aiRigidbody;
	Vector3 movement;

	int MaxDist = 100;
	int MinDist = 5;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		aiRigidbody = GetComponent<Rigidbody>();
	}

	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.LookAt(player);
		Move();
	}

	void Move()
	{
		// random sprint activated!!

		if (Vector3.Distance(transform.position, player.position) >= MinDist)
		{
			transform.position += transform.forward * speed * Time.deltaTime;

			if (Vector3.Distance(transform.position, player.position) <= MaxDist)
			{
				//Here Call any function U want Like Shoot at here or something
			}

		}
	}
}
