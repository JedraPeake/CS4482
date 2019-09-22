using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	float effectsDisplayTime = 0.2f;
	public float timeBetweenBullets = 0.15f;
	public float range = 1f;

	Ray shootRay;
	RaycastHit shootHit;
	LineRenderer gunLine;

	float timer;
	int shootableMask;

	AIController AIControllerScript;
	PlayerController PlayerControllerScript;

	void Awake()
	{
		gunLine = GetComponent<LineRenderer>();
		shootableMask = LayerMask.GetMask("AI");

		GameObject g = GameObject.FindGameObjectWithTag("AITag");
		AIControllerScript = g.GetComponent<AIController>();

		GameObject g2 = GameObject.FindGameObjectWithTag("Player");
		PlayerControllerScript = g2.GetComponent<PlayerController>();
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    void Update()
    {
		timer += Time.deltaTime;

		// If the Fire1 button is being press and it's time to fire...
		if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
		{
			// ... shoot the gun.
			Shoot();
		}

		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if (timer >= timeBetweenBullets * effectsDisplayTime)
		{
			// ... disable the effects.
			DisableEffects();
		}
	}

	public void DisableEffects()
	{
		gunLine.enabled = false;
	}

	void Shoot()
	{
		timer = 0f;
		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
		{

			Debug.Log("if");
			AIControllerScript.MakeIt();
			PlayerControllerScript.MakeNotIt();

			// Set the second position of the line renderer to the point the raycast hit.
			gunLine.SetPosition(1, shootHit.point);
		}
		else
		{
			Debug.Log("else");
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}
}
