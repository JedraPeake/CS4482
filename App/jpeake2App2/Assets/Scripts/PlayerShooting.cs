using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
	public float timeBetweenBullets = 0.15f;
	public float range = 1f;

	readonly float effectsDisplayTime = 0.2f;
	float timer;

	Ray shootRay;
	RaycastHit shootHit;
	LineRenderer gunLine;
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

    void Update()
    {
		if (PlayerControllerScript.playerit)
		{
			timer += Time.deltaTime;

			if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
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

	void Shoot()
	{
		timer = 0f;
		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		shootRay.origin = transform.position;
		shootRay.direction = transform.forward;

		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
		{
			AIControllerScript.MakeIt();
			PlayerControllerScript.MakeNotIt();
			gunLine.SetPosition(1, shootHit.point);

			DisableEffects();
		}
		else
		{
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}
}
