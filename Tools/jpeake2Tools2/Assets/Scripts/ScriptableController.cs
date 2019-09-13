using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableController : ScriptableObject
{
	[SerializeField]
	// [HideInInspector] // [HideInInspector] tag; we don't actually need Unity to display the ScriptableObject, our code will handle that
	private ScriptableManager scriptableManger;

	public void switchLanguage(ScriptableManager newScriptableManger)
	{
		scriptableManger = newScriptableManger;
	}
}
