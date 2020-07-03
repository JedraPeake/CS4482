using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	private Transform target;

    [Header("Attributes")]
	public float range = 15f;

	// bullets
	public GameObject bulletPrefab;
	public float fireRate = 1f;
    public float fireCountdown = 0f;

	//laser
	public bool useLser = false;
	public LineRenderer lineRenderer;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

    public Transform firePoint;

	private Enemy targetEnemy;

	void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		} else
		{
			target = null;
		}

	}

	// Update is called once per frame
	void Update () {
		if (target == null)
		{
			if (useLser)
			{
				if (lineRenderer.enabled)
				{
					lineRenderer.enabled = false;
				}
			}

			return;
		}
			

		LockOnTarget();

		if (useLser)
		{
			Laser();
		}
		else
		{
			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
		}
	}

	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

    void Shoot() {
        GameObject bulletGo=(GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null) {
            bullet.Seek(target);
        }

    }

	void Laser()
	{
		targetEnemy.Slow();

		if (!lineRenderer.enabled)
			lineRenderer.enabled = true;

		lineRenderer.SetPosition(0, firePoint.position);
		lineRenderer.SetPosition(1, target.position);
	}

	void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
