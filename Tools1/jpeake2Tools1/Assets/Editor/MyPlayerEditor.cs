using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MyPlayer))]
// [CanEditMultipleObjects]    // Attribute used to make a custom editor support multi-object editing.
public class MyPlayerEditor : Editor
{
	SerializedProperty playerNameProp;
	SerializedProperty ageProp;

	SerializedProperty pokeballsProp;
	SerializedProperty incubatorsProp;
	SerializedProperty incensesProp;

	void OnEnable()
	{
		// using strings scares me !!!
		playerNameProp = serializedObject.FindProperty("playerName");
		ageProp = serializedObject.FindProperty("age");

		pokeballsProp = serializedObject.FindProperty("pokeballs"); ;
		incubatorsProp = serializedObject.FindProperty("incubators"); ;
		incensesProp = serializedObject.FindProperty("incenses"); ;
	}

	public override void OnInspectorGUI()
	{
		serializedObject.Update();

		EditorGUILayout.IntSlider(ageProp, 0, 100);

		EditorGUILayout.LabelField("Items:");
		int indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel++;

		MyPlayer myTarget = (MyPlayer)target; 
		myTarget.pokeballs = EditorGUILayout.IntField("Pokeballs", myTarget.pokeballs);
		myTarget.incubators = EditorGUILayout.IntField("Incubators", myTarget.incubators);
		myTarget.incenses = EditorGUILayout.IntField("Incenses", myTarget.incenses);

		EditorGUI.indentLevel = indent;

		EditorGUILayout.LabelField("Items3:");

		serializedObject.ApplyModifiedProperties();
	}

}
