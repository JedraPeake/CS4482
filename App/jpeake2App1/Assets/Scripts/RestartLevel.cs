using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
	public string tag;

	void OnCollisionEnter(Collision coll)
	{
		if (coll.collider.tag == tag)
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
