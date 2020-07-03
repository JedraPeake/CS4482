using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/LangController", order = 51)]
public class LangController : ScriptableObject
{
	public List<SingleLanguage> languageList = new List<SingleLanguage>();
	public List<DictionaryItems> keyList = new List<DictionaryItems>();
	public int langKey;

	public void addLanguageToList(string newLanguageName)
	{
		if (newLanguageName == null || newLanguageName == "")
			return;

		// make sure doesnt exist
		foreach (var l in languageList)
		{
			if (l.languageName == newLanguageName)
				return;
		}

		SingleLanguage newLanguage = new SingleLanguage();
		newLanguage.languageName = newLanguageName;
		foreach (var l in keyList)
		{
			newLanguage.languageItems.Add(new DictionaryItems(l.key, l.value));
		}
		languageList.Add(newLanguage);
	}

	public void deleteLanguage(int i)
	{
		List<SingleLanguage> copy = new List<SingleLanguage>();
		for (int j = 0; j < languageList.Count; j++)
		{
			if (j != i)
			{
				copy.Add(languageList[j]);
			}
		}
		languageList = copy;
	}

	public void addNewKeyToList(string newKeyValue)
	{
		if (newKeyValue == null || newKeyValue == "")
			return;

		// make sure doesnt exist
		foreach (var k in keyList)
		{
			if (k.key == newKeyValue)
				return;
		}

		// add to default list
		keyList.Add(new DictionaryItems(newKeyValue, ""));

		// update all existing langs
		foreach (var l in languageList)
		{
			l.languageItems.Add(new DictionaryItems(newKeyValue, ""));
		}
	}

	public void deleteAllKeys()
	{
		// remove from defualt list
		keyList = new List<DictionaryItems>();

		// remove from lang lists
		foreach (var l in languageList)
		{
			l.languageItems = new List<DictionaryItems>();
		}
	}

	public string[] getLanguageList()
	{
		string[] arr = new string[languageList.Count];
		for (int i = 0; i < languageList.Count; i++)
		{
			arr[i] = languageList[i].languageName;
		}
		return arr;
	}

	public string[] getKeys()
	{
		string[] arr = new string[keyList.Count];
		for (int i = 0; i < keyList.Count; i++)
		{
			arr[i] = keyList[i].key;
		}
		return arr;
	}

	public string getItem(string lang, string key)
	{
		foreach (var l in languageList)
		{
			if (l.languageName == lang)
			{
				foreach (var i in l.languageItems)
				{
					if (i.key == key)
						return i.value;
				}
			}
		}
		return "";
	}

	public string getItem(int lang, int key)
	{
		var currentLang = languageList[lang];
		if (currentLang.languageItems.Count < key)
			return "";
		return currentLang.languageItems[key].value;
	}
}

[Serializable]
public class SingleLanguage {
	public string languageName;
	public List<DictionaryItems> languageItems = new List<DictionaryItems>();
}

[Serializable]
public class DictionaryItems {
	public string key;
	public string value;

	public DictionaryItems()
	{
	}

	public DictionaryItems(string _key, string _value)
	{
		key = _key;
		value = _value;
	}
}
