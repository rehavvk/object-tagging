using UnityEditor;

namespace Rehawk.ObjectTagging
{
    public static class ObjectTaggingSettingsReceiver
    {
        private static ObjectTaggingSettings GetOrCreateSettings()
        {
            return ObjectTaggingSettings.Instance;
        }

        internal static SerializedObject GetSerializedSettings()
        {
            return new SerializedObject(GetOrCreateSettings());
        }
    }
}