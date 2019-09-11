using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Lure))]
public class LureDrawer : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		EditorGUI.BeginProperty(position, label, property);
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

		var indent = EditorGUI.indentLevel;
		EditorGUI.indentLevel = 0;

		Rect lureCountRect = new Rect(position.x, position.y, 30, position.height);
		EditorGUI.PropertyField(lureCountRect, property.FindPropertyRelative("count"), GUIContent.none);

		Rect lureTypeRect = new Rect(position.x + 35, position.y, position.width - 30 - 5, position.height);
		EditorGUI.PropertyField(lureTypeRect, property.FindPropertyRelative("lureType"), GUIContent.none);

		EditorGUI.indentLevel = indent;

		EditorGUI.EndProperty();
	}
}
