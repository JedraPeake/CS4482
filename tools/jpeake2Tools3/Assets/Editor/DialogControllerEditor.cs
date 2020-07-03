using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogController))]
public class DialogControllerEditor : Editor
{
	private DialogController dialogController;
	private SerializedObject dialogControllerSerializedObject;
	private SerializedProperty dialogControllerSerializedProperty;

	private string newDialogText;
	//private string newKeyValue;

	private SerializedProperty dialogListSize;
	private static string listSize = "dialogList.Array.size";

	public string[] keyOptions;

	public void OnEnable()
	{
		dialogController = (DialogController)target;
		dialogControllerSerializedObject = new SerializedObject(dialogController);
		dialogControllerSerializedProperty = dialogControllerSerializedObject.FindProperty("dialogList");
		dialogListSize = dialogControllerSerializedObject.FindProperty(listSize);

		GameObject go = GameObject.Find("GameObject");
		LocalizationController other = (LocalizationController)go.GetComponent(typeof(LocalizationController));
		keyOptions = other.LangController.getKeys();
	}

	public override void OnInspectorGUI()
	{
		// base.OnInspectorGUI();
		dialogControllerSerializedObject.Update();

		// add dialog
		EditorGUILayout.BeginHorizontal();
		newDialogText = EditorGUILayout.TextField("New Dialog Text", newDialogText);
		GUI.backgroundColor = Color.green;
		if (GUILayout.Button("Add Dialog"))
		{
			dialogController.addDialogToList(newDialogText);
		}
		GUI.backgroundColor = Color.white;
		EditorGUILayout.EndHorizontal();

		// show no lang if size == 0
		if (dialogListSize.intValue == 0)
		{
			EditorGUILayout.LabelField("No Current Dialogs");
		}
		else
		{
			for (int i = 0; i < dialogListSize.intValue; i++)
			{
				if (dialogController.dialogList[i] != null)
				{
					EditorGUILayout.LabelField(dialogController.dialogList[i].dialogText);

					// show keys if count > 0
					if (dialogController.dialogList[i].dialogItems.Count > 0)
					{
						EditorGUILayout.LabelField("Options:");
						for (int k = 0; k < dialogController.dialogList[i].dialogItems.Count; k++)
						{
							EditorGUILayout.BeginHorizontal();
							dialogController.dialogList[i].dialogItems[k].endState = EditorGUILayout.Toggle("Exit option:", dialogController.dialogList[i].dialogItems[k].endState);

							if (!dialogController.dialogList[i].dialogItems[k].endState)
							{
								string[] nextDialogOptions = dialogController.getDialogList(i);
								if (nextDialogOptions == null || nextDialogOptions.Length == 0)
								{
									EditorGUILayout.LabelField("No Other Dialogs");
								}
								else
								{
									if (dialogController.dialogList[i].dialogItems[k].nextKeyIndex > nextDialogOptions.Length)
										dialogController.dialogList[i].dialogItems[k].nextKeyIndex = 0;

									dialogController.dialogList[i].dialogItems[k].nextKeyIndex = EditorGUILayout.Popup("Next Dialog option:", dialogController.dialogList[i].dialogItems[k].nextKeyIndex, nextDialogOptions);
								}
							}
							EditorGUILayout.EndHorizontal();

							EditorGUILayout.BeginHorizontal();
							if (keyOptions == null || keyOptions.Length == 0)
							{
								EditorGUILayout.LabelField("No Current Keys");
							}
							else
							{
								if (dialogController.dialogList[i].dialogItems[k].currentKeyIndex > keyOptions.Length)
									dialogController.dialogList[i].dialogItems[k].currentKeyIndex = 0;

								dialogController.dialogList[i].dialogItems[k].currentKeyIndex = EditorGUILayout.Popup("Current option:", dialogController.dialogList[i].dialogItems[k].currentKeyIndex, keyOptions);
							}
							EditorGUILayout.EndHorizontal();
						}
					}
					else
					{
						EditorGUILayout.LabelField("No Current Dialog Options");
					}

					// add key horizontal
					EditorGUILayout.BeginHorizontal();
					GUI.backgroundColor = Color.green;
					if (GUILayout.Button("New Dialog Option"))
					{
						dialogController.addDialogItem(i);
					}
					GUI.backgroundColor = Color.white;
					EditorGUILayout.EndHorizontal();

					// delete lang button
					GUI.backgroundColor = Color.red;
					if (GUILayout.Button("Delete Dialog"))
					{
						dialogController.deleteDialog(i);
					}
					GUI.backgroundColor = Color.white;
				}
			}

			dialogControllerSerializedObject.ApplyModifiedProperties();
		}
	}
}
