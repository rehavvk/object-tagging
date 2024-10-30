using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rehawk.ObjectTagging
{
    internal static class ObjectTaggingSettingsIMGUIRegister
    {
        [SettingsProvider]
        public static SettingsProvider CreateObjectTaggingSettingsProvider()
        {
            var provider = new SettingsProvider("Project/Object Tagging", SettingsScope.Project)
            {
                label = "Object Tagging",
                
                guiHandler = searchContext =>
                {
                    SerializedObject settings = ObjectTaggingSettingsReceiver.GetSerializedSettings();
                    
                    if (GUILayout.Button("Bake"))
                    {
                        ObjectTagBaker.Bake();
                    }
                    
                    EditorGUILayout.PropertyField(settings.FindProperty("tags"), new GUIContent("Tags"));
                    
                    settings.ApplyModifiedPropertiesWithoutUndo();
                },

                keywords = new HashSet<string>(new[] { "Tags" })
            };

            return provider;
        }
    }
}