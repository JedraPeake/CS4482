using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LureTypes { Normal, Moss, Magnetic, Glacial }

[System.Serializable]
public class Lure
{
	public int count;
}

public class MyPlayer : MonoBehaviour
{
	public int age;
	public string playerName;   // using string name gives a warning

	public string email = "system@pokemongo.com";

	public int pokeballs;
	public int incubators;
	public int incenses;
	public Lure[] lures;

	//// Start is called before the first frame update
	//void Start()
	//{

	//}

	//// Update is called once per frame
	//void Update()
	//{

	//}

	//item validation? or count?
}
