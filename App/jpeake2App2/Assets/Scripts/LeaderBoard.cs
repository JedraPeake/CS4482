using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
	List<Entry> entries = new List<Entry>();

	public void UpdateLb(string name, int score)
	{
		if (entries.Count < 5)
		{
			entries.Add(new Entry(name, score));
			entries = entries.OrderBy(x => x.score).ToList();
		}
		else if (entries[4].score < score)
		{
			entries.RemoveAt(4);
			entries.Add(new Entry(name, score));
			entries = entries.OrderBy(x => x.score).ToList();
		}
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

