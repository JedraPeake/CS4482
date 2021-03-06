﻿using UnityEngine;

public class AIShooting : MonoBehaviour
{
	public float timeBetweenBullets = 4.0f;
	public float range = 1f;

	readonly float effectsDisplayTime = 0.2f;
	float timer;

	Ray shootRay;
	RaycastHit shootHit;
	LineRenderer gunLine;
	int shootableMask;

	AIController AIControllerScript;
	PlayerController PlayerControllerScript;

	void Start()
    {
		gunLine = GetComponent<LineRenderer>();
		shootableMask = LayerMask.GetMask("Player");

		GameObject g = GameObject.FindGameObjectWithTag("AITag");
		AIControllerScript = g.GetComponent<AIController>();

		GameObject g2 = GameObject.FindGameObjectWithTag("Player");
		PlayerControllerScript = g2.GetComponent<PlayerController>();
	}

	void Update()
	{
		if (AIControllerScript.aIIt)
		{
			timer += Time.deltaTime;

			if (Random.Range(0.0f, 15.0f) > 14 && timer >= timeBetweenBullets)
			{
				Shoot();
			}

			if (timer >= timeBetweenBullets * effectsDisplayTime)
			{
				DisableEffects();
			}
		}
	}

	public void DisableEffects()
	{
		gunLine.enabled = false;
	}

	public void Shoot()
	{
		timer = 0f;
		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
		{
			AIControllerScript.MakeNotIt();
			PlayerControllerScript.MakeIt();
			gunLine.SetPosition(1, shootHit.point);

			DisableEffects();
		}
		else
		{
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}
}
