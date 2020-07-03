using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LangController))]
public class LangControllerEditor : Editor
{
	private LangController langController;
	private SerializedObject langControllerSerializedObject;
	private SerializedProperty langControllerSerializedProperty;

	private string newLanguageName;
	private string newKeyValue;

	private SerializedProperty languageListSize;
	private static string listSize = "languageList.Array.size";

	public void OnEnable()
	{
		langController = (LangController)target;
		langControllerSerializedObject = new SerializedObject(langController);
		langControllerSerializedProperty = langControllerSerializedObject.FindProperty("languageList");
		languageListSize = langControllerSerializedObject.FindProperty(listSize);
	}

	public override void OnInspectorGUI()
	{
		// base.OnInspectorGUI();
		langControllerSerializedObject.Update();

		// add lang horizontal
		EditorGUILayout.BeginHorizontal();
		newLanguageName = EditorGUILayout.TextField("New Language Name", newLanguageName);
		GUI.backgroundColor = Color.green;
		if (GUILayout.Button("Add Language"))
		{
			langController.addLanguageToList(newLanguageName);
		}
		GUI.backgroundColor = Color.white;
		EditorGUILayout.EndHorizontal();

		// add key horizontal
		if (languageListSize.intValue > 0)
		{
			EditorGUILayout.BeginHorizontal();
			newKeyValue = EditorGUILayout.TextField("New Key Name", newKeyValue);
			GUI.backgroundColor = Color.green;
			if (GUILayout.Button("Add Key"))
			{
				langController.addNewKeyToList(newKeyValue);
			}
			GUI.backgroundColor = Color.white;
			EditorGUILayout.EndHorizontal();
		}

		// show no lang if size == 0
		if (languageListSize.intValue == 0)
		{
			EditorGUILayout.LabelField("No Current Languages");
		}
		else
		{
			for (int i = 0; i < languageListSize.intValue; i++)
			{
				if (langController.languageList[i] != null)
				{
					EditorGUILayout.LabelField(langController.languageList[i].languageName);

					// show keys if count > 0
					if (langController.keyList.Count > 0)
					{
						EditorGUILayout.LabelField("Key and Values");
						for (int k = 0; k < langController.languageList[i].languageItems.Count; k++)
						{
							EditorGUILayout.BeginHorizontal();
							EditorGUILayout.LabelField(langController.languageList[i].languageItems[k].key);
							langController.languageList[i].languageItems[k].value = EditorGUILayout.TextField(langController.languageList[i].languageItems[k].value);
							EditorGUILayout.EndHorizontal();
						}
					}

					// delete lang button
					GUI.backgroundColor = Color.red;
					if (GUILayout.Button("Delete Language"))
					{
						langController.deleteLanguage(i);
					}
					GUI.backgroundColor = Color.white;
				}
			}

			// delete all keys option if count > 0
			if (langController.keyList.Count > 0)
			{
				GUI.backgroundColor = Color.red;
				if (GUILayout.Button("Delete All Keys"))
				{
					langController.deleteAllKeys();
				}
				GUI.backgroundColor = Color.white;
			}
		}

		langControllerSerializedObject.ApplyModifiedProperties();
	}
}
