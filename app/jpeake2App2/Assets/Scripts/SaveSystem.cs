using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem
{
	public static void SaveLb(List<Entry> entries)
	{
		BinaryFormatter formatter = new BinaryFormatter();
		string path = Application.persistentDataPath + "/leaderboard.fun";
		using (FileStream stream = new FileStream(path, FileMode.Create))
		{
			LBEntries lbEntries = new LBEntries(entries);

			formatter.Serialize(stream, lbEntries);
		}
	}

	public static LBEntries LoadLb()
	{
		string path = Application.persistentDataPath + "/leaderboard.fun";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			using (FileStream stream = new FileStream(path, FileMode.Open))
			{
				LBEntries lbEntries = formatter.Deserialize(stream) as LBEntries;

				return lbEntries;
			}
		}
		else
		{
			Debug.Log("no file");
			return new LBEntries(new List<Entry> { new Entry("Unregistered Player", 0), new Entry("Unregistered Player", 0), new Entry("Unregistered Player", 0) });
		}
	}
}
