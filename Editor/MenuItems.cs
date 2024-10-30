using UnityEditor;

namespace Rehawk.ObjectTagging
{
    public static class MenuItems
    {
        [MenuItem("Tools/Bake Object Tags")]
        private static void BakeKeys()
        {
            ObjectTagBaker.Bake();
        }
    }
}