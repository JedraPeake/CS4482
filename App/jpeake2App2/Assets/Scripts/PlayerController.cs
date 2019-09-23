using UnityEngine;

public enum MoveType { idle, walk, run };

public class PlayerController : MonoBehaviour
{
	Animator anim;
	int floorMask;
	Rigidbody playerRigidbody;
	Vector3 movement;
	float camRayLength = 100f;
	MoveType moveType = MoveType.idle;

	public float speed = 6f;
	public bool playerit;
	public GameObject playerSphere;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Ground");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		moveType = GetMoveType(h, v);

		Turning();

		Move(h, v);

		Animating();

		HideSphere();
	}

	MoveType GetMoveType(float h, float v)
	{
		if (h == 0f && v == 0f)
			return MoveType.idle;

		return Input.GetKey(KeyCode.LeftShift) ? MoveType.run : MoveType.walk;
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;
		if (moveType == MoveType.run)
			movement *= 2;

		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning()
	{
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		transform.rotation = Quaternion.Euler(new Vector3(0f, (angle *-1) - 90, 0f));
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
	{
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	void Animating()
	{
		if (moveType == MoveType.run)
			anim.SetInteger("MovementInt", 2);
		else if (moveType == MoveType.walk)
			anim.SetInteger("MovementInt", 1);
		else
			anim.SetInteger("MovementInt", 0);
	}

	void HideSphere()
	{
		if (!playerit)
		{
			playerSphere.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			playerSphere.GetComponent<Renderer>().enabled = true;
		}
	}

	public void MakeIt()
	{
		playerit = true;
	}

	public void MakeNotIt()
	{
		playerit = false;
	}
}
