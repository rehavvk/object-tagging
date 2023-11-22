using UnityEngine;

namespace Rehawk.ObjectTagging
{
    public static class GameObjectExtensions
    {
        public static bool HasTags(this GameObject obj, params string[] tags)
        {
            if (obj.TryGetComponent(out TaggedObject objectTags))
            {
                return objectTags.HasTags(tags);
            }

            return false;
        }
        
        public static bool HasTags(this GameObject obj, int tagsMask)
        {
            if (obj.TryGetComponent(out TaggedObject objectTags))
            {
                return objectTags.HasTags(tagsMask);
            }

            return false;
        }
    }
}