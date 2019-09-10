using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LureTypes { Normal, Moss, Magnetic, Glacial }

[Serializable]
public class Lure
{
	public int count;
	public LureTypes lureType;
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
}
