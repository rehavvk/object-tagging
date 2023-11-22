using UnityEditor;

namespace Rehawk.ObjectTagging
{
    public static class MenuItems
    {
        [MenuItem("Tools/Object Tagging/Bake")]
        private static void BakeKeys()
        {
            ObjectTagBaker.Bake();
        }
    }
}