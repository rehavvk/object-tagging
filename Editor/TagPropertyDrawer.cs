using System;
using UnityEditor;
using UnityEngine;

namespace Rehawk.ObjectTagging
{
    [CustomPropertyDrawer(typeof(Tag))]
    public class TagPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty tagProperty = property.FindPropertyRelative("tag");
            
            string[] tags = ObjectTaggingSettings.Tags;

            int tagIndex = Array.IndexOf(tags, tagProperty.stringValue);
            
            var tagsContent = new GUIContent[tags.Length];
            for (int i = 0; i < tagsContent.Length; i++)
            {
                tagsContent[i] = new GUIContent(tags[i]);
            }
            
            var fieldRect = new Rect(position);
            fieldRect.width -= 22;
            
            var buttonRect = new Rect(position);
            buttonRect.x += fieldRect.width + 2;
            buttonRect.width = 20;

            EditorGUI.BeginChangeCheck();
            {
                if (tags == null || tags.Length > 0)
                {
                    tagIndex = EditorGUI.Popup(fieldRect, label, tagIndex, tagsContent);
                }
                else
                {
                    EditorGUI.LabelField(fieldRect, label, new GUIContent("No tags found"));    
                }
            }
            if (EditorGUI.EndChangeCheck())
            {
                tagProperty.stringValue = tags[tagIndex];
            }

            if (GUI.Button(buttonRect, new GUIContent("T", "Show Tags")))
            {
                SettingsService.OpenProjectSettings("Project/Object Tagging");
            }
        }
    }
}