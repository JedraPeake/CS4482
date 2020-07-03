using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/DialogController", order = 52)]
public class DialogController : ScriptableObject
{
	public List<SingleDialog> dialogList = new List<SingleDialog>();

	public void addDialogToList(string newdialogText)
	{
		if (newdialogText == null || newdialogText == "")
			return;

		foreach (var l in dialogList)
		{
			if (l.dialogText == newdialogText)
				return;
		}

		SingleDialog newDialog = new SingleDialog();
		newDialog.dialogText = newdialogText;
		dialogList.Add(newDialog);
	}

	public void deleteDialog(int i)
	{
		List<SingleDialog> copy = new List<SingleDialog>();
		for (int j = 0; j < dialogList.Count; j++)
		{
			if (j != i)
			{
				SingleDialog singleDialog = dialogList[j];
				if (singleDialog.dialogItems.Count > 0)
				{
					for (int k = 0; k < singleDialog.dialogItems.Count; k++)
					{
						if (singleDialog.dialogItems[k].nextKeyIndex == i)
						{
							singleDialog.dialogItems[k].nextKeyIndex = 0;
						}
					}
				}
				copy.Add(singleDialog);
			}
		}
		dialogList = copy;
	}

	public void addDialogItem(int i)
	{
		dialogList[i].dialogItems.Add(new DialogItems());
	}

	public string[] getDialogList(int i)
	{
		List<string> copy = new List<string>();
		for (int j = 0; j < dialogList.Count; j++)
		{
			if (j != i)
			{
				copy.Add(dialogList[j].dialogText);
			}
		}
		return copy.ToArray();
	}

	public int getnextDialogIndex(int i, int nextindex)
	{
		int counter = -1;
		int retVal = 0;
		for (int j = 0; j < dialogList.Count; j++)
		{
			if (j != i)
			{
				counter++;

				if (counter == nextindex) {
					retVal = j;
					continue;
				}
			}
		}
		return retVal;
	}

}

[Serializable]
public class SingleDialog
{
	public string dialogText;
	public List<DialogItems> dialogItems = new List<DialogItems>();
}

[Serializable]
public class DialogItems
{
	public int nextKeyIndex;
	public int currentKeyIndex;
	public bool endState;

	public DialogItems()
	{
		currentKeyIndex = 0;
		nextKeyIndex = 0;
	}
}