using UnityEditor;

[CustomEditor(typeof(LocalizationController))]
public class LocalizationControllerEditor : Editor
{
	private LocalizationController localizationController;
	private LangController langController;
	private SerializedObject localizationControllerSerializedObject;

	public void OnEnable()
	{
		localizationController = (LocalizationController)target;
		localizationControllerSerializedObject = new SerializedObject(localizationController);
	}
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		localizationControllerSerializedObject.Update();

		if (localizationController.LangController.languageList.Count == 0)
		{
			EditorGUILayout.LabelField("No Current Languages");
		}
		else
		{
			EditorGUILayout.LabelField("Language");
			localizationController.langKey = EditorGUILayout.Popup(localizationController.langKey, localizationController.LangController.getLanguageList());

			//tools 2
			//EditorGUILayout.LabelField("Key");
			//localizationController.textKey = EditorGUILayout.Popup(localizationController.textKey, localizationController.LangController.getKeys());
		}

		localizationControllerSerializedObject.ApplyModifiedProperties();
	}
}
