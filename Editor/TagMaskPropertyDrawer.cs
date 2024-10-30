using System;
using UnityEditor;
using UnityEngine;

namespace Rehawk.ObjectTagging
{
    [CustomPropertyDrawer(typeof(TagMask))]
    public class TagMaskPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty tagsProperty = property.FindPropertyRelative("tags");
            
            string[] tags = ObjectTaggingSettings.Tags;
            
            int tagsMask = 0;
            for (int i = 0; i < tagsProperty.arraySize; i++)
            {
                string tag = tagsProperty.GetArrayElementAtIndex(i).stringValue;
                int index = Array.IndexOf(tags, tag);

                tagsMask |= 1 << index;
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
                    tagsMask = EditorGUI.MaskField(fieldRect, label, tagsMask, tags);
                }
                else
                {
                    EditorGUI.LabelField(fieldRect, label, new GUIContent("No tags found"));    
                }
            }
            if (EditorGUI.EndChangeCheck())
            {
                tagsProperty.ClearArray();
                
                int arrayIndex = 0;
                for (int i = 0; i < tags.Length; i++)
                {
                    if ((tagsMask & (1 << i)) == (1 << i))
                    {
                        tagsProperty.InsertArrayElementAtIndex(arrayIndex);
                        tagsProperty.GetArrayElementAtIndex(arrayIndex).stringValue = tags[i];

                        arrayIndex += 1;
                    }
                }
            }

            if (GUI.Button(buttonRect, new GUIContent("T", "Show Tags")))
            {
                SettingsService.OpenProjectSettings("Project/Object Tagging");
            }
        }
    }
}