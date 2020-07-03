using System;
using UnityEngine;
using TMPro;

public class LocalizationController : MonoBehaviour
{
	// tools 2
	public LangController LangController;
	public TextMeshProUGUI text = null;

	[NonSerialized] public int langKey;
	[NonSerialized] public int textKey;

	//tools 3
	public DialogController DialogController;
	public string invalidOptionString = "The selected option is not valid, please select a valid option";
	public string endoptionString = "This is the end of the tree, thank you for playing";

	public int currentDialogKey;
	public bool showFailMessage = false;
	public bool showEndMessage = false;

	void Start()
	{
		text.text = "";
		currentDialogKey = 0;
	}

	void Update()
	{
		// this was for tools 2
		//if (langKey > 0 && textKey > 0)
		//	text.text = LangController.getItem(langKey, textKey);

		// tools 3
		if (showEndMessage)
		{
			text.text = endoptionString;
		}
		else
		{

			if (currentDialogKey == 0 && DialogController.dialogList.Count == 0)
			{
				text.text = "No dialogs";
			}
			else
			{
				text.text = generateText();

				if (Input.GetKeyDown(KeyCode.Alpha0))
				{
					generateNextDialog(0);
					text.text = generateText();
				}
				else if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					generateNextDialog(1);
					text.text = generateText();
				}
				else if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					generateNextDialog(2);
					text.text = generateText();
				}
				else if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					generateNextDialog(3);
					text.text = generateText();
				}
				else if (Input.GetKeyDown(KeyCode.Alpha4))
				{
					generateNextDialog(4);
					text.text = generateText();
				}
				else if (Input.GetKeyDown(KeyCode.Alpha5))
				{
					generateNextDialog(5);
					text.text = generateText();
				}
			}
		}
	}

	string generateText()
	{
		string finalString = "";
		string newLine = "\n";

		// title
		finalString = $"{DialogController.dialogList[currentDialogKey].dialogText} {newLine}";

		for (int k = 0; k < DialogController.dialogList[currentDialogKey].dialogItems.Count; k++)
		{
			int optionTranslatedKey = DialogController.dialogList[currentDialogKey].dialogItems[k].currentKeyIndex;
			string translatedOption = LangController.getItem(langKey, optionTranslatedKey);
			finalString = $"{finalString} {k}: {translatedOption} {newLine}";
		}

		if (showFailMessage)
		{
			finalString = $"{finalString} {newLine} {invalidOptionString}";
		}

		return finalString;
	}

	public void generateNextDialog(int selected)
	{
		if (selected >= DialogController.dialogList[currentDialogKey].dialogItems.Count)
		{
			showFailMessage = true;
		}
		else
		{
			showFailMessage = false;

			if (DialogController.dialogList[currentDialogKey].dialogItems[selected].endState)
			{
				showEndMessage = true;
			}
			else
			{
				currentDialogKey = DialogController.getnextDialogIndex(currentDialogKey, DialogController.dialogList[currentDialogKey].dialogItems[selected].nextKeyIndex);
			}
		}
	}
}
