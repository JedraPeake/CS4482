using System;
using UnityEngine;
using TMPro;

public class LocalizationController : MonoBehaviour
{
	public LangController LangController;
	public TextMeshProUGUI text = null;

	[NonSerialized] public int langKey;
	[NonSerialized] public int textKey;

	void Start()
	{
		text.text = "";
	}

	void Update()
	{
		if (langKey > 0 && textKey > 0)
			text.text = LangController.getItem(langKey, textKey);
	}
}
