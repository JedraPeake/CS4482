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

public class MyPlayerLures : MonoBehaviour
{
	public Lure[] lures;
}
