using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * fileName: The default name when the asset is created. menuName: The name of the asset as it appears in the Asset Menu.
 * order: Where the asset will be located within the Asset Menu. 
 * Unity separates assets into sub-groups by factors of 50. So 51 will put your new asset in the second grouping of the Asset Menu.
 */
[CreateAssetMenu(fileName = "New Language", menuName = "Language Data", order = 51)]	// fix file name???
public class ScriptableManager : ScriptableObject
{
	// SerializeField attribute allows you to have private script variables that are exposed in the Inspector. 
	[SerializeField]
	private string LanguageName;
	[SerializeField]
	// Turns out dictionarys dont appear in the editor -> private Dictionary<string, Dictionary<string, string>> localizedTextLanguages;
	private List<ScriptableLanguageItem> scriptableLanguageItems;

	public string GetLanguageName
	{
		get
		{
			return LanguageName;
		}
	}

	public List<ScriptableLanguageItem> GetLanguageItems
	{
		get
		{
			return scriptableLanguageItems;
		}
	}
}

[Serializable]
public class ScriptableLanguage
{

}

[Serializable]
public class ScriptableLanguageItem
{
	private string Key;
	private string Value;
}



