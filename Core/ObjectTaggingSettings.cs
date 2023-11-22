using System;
using UnityEngine;

namespace Rehawk.ObjectTagging
{
    public class ObjectTaggingSettings : ScriptableObject
    {
        private const string ASSETS_PATH = "Assets/Resources/ObjectTaggingSettings.asset";
        private const string RESOURCES_PATH = "ObjectTaggingSettings";

        [SerializeField] private string[] tags = Array.Empty<string>();
        
        private static ObjectTaggingSettings instance;
        
        public static ObjectTaggingSettings Instance
        {
            get
            {
                if (instance == null)
                {
#if UNITY_EDITOR
                    if (!Application.isPlaying)
                    {
                        instance = UnityEditor.AssetDatabase.LoadAssetAtPath<ObjectTaggingSettings>(ASSETS_PATH);

                        if (instance == null)
                        {
                            instance = CreateInstance<ObjectTaggingSettings>();

                            UnityEditor.AssetDatabase.CreateAsset(instance, ASSETS_PATH);
                            UnityEditor.AssetDatabase.SaveAssets();
                        }
                    }
                    else
                    {
                        instance = Resources.Load<ObjectTaggingSettings>(RESOURCES_PATH);
                    }
#else
                    instance = Resources.Load<ObjectTaggingSettings>(RESOURCES_PATH);
#endif
                    
                }
                
                return instance;
            }
        }
        
        public static string[] Tags
        {
            get { return Instance.tags; }
            set { Instance.tags = value; }
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void OnSubsystemRegistration()
        {
            instance = null;
        }
    }
}