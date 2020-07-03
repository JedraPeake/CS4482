using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
	TMP_InputField Input = null;
	string currentPlayerName = "New Player";

	public static LeaderBoard Instance;
	List<Entry> entries = new List<Entry>();

	void Awake()
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		LBEntries ent = SaveSystem.LoadLb();
		entries = ent.getEntriesList();
	}

	void Update()
	{
		if (SceneManager.GetActiveScene().buildIndex == 0)
		{
			if (Input == null)
			{
				GameObject g = GameObject.FindGameObjectWithTag("PlayerName");
				Input = g.GetComponent<TMP_InputField>();
			}

			currentPlayerName = Input.text;

		}
		else
		{
			Input = null;
		}
	}

	public void UpdateLb(int score)
	{
		if (entries[2].score < score)
		{
			entries.RemoveAt(2);
			entries.Add(new Entry(currentPlayerName, score));
			entries = entries.OrderByDescending(x => x.score).ToList();

			SaveSystem.SaveLb(entries);
		}
	}

	public List<Entry> GetLB()
	{	
		return entries;
	}
}

[System.Serializable]
public class LBEntries
{
	readonly List<Entry> entries;

	public LBEntries(List<Entry> ent)
	{
		entries = ent;
	}

	public List<Entry> getEntriesList()
	{
		return entries;
	}
}

[System.Serializable]
public class Entry
{
	public string name;
	public int score;

	public Entry(string n, int s)
	{
		name = n;
		score = s;
	}
}

