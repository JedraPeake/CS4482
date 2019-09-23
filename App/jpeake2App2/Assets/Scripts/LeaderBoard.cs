using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
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
		entries.AddRange(new List<Entry> { new Entry("Unregistered Player", 0), new Entry("Unregistered Player", 0), new Entry("Unregistered Player", 0) });
	}

	public void UpdateLb(string name, int score)
	{
		Debug.Log("up");
		if (entries[2].score < score)
		{
			entries.RemoveAt(2);
			entries.Add(new Entry(name, score));
			entries = entries.OrderByDescending(x => x.score).ToList();
		}
	}

	public List<Entry> GetLB()
	{
		
		return entries;
	}
}

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

