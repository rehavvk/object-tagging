using UnityEngine;

namespace Rehawk.ObjectTagging
{
    public class TaggedObject : MonoBehaviour
    {
        [SerializeField] private TagMask tagsMask;
        
        public bool HasTags(params string[] tags)
        {
            return HasTags(ObjectTaggingUtility.TagsToMask(tags));
        }
        
        public bool HasTags(int tagsMask)
        {
            int mask = this.tagsMask.Value;
            return (mask | tagsMask) == mask;
        }
        
        public bool HasAnyTag(params string[] tags)
        {
            for (int i = 0; i < tags.Length; i++)
            {
                int flag = ObjectTaggingUtility.TagToLayer(tags[i]);
                if ((tagsMask & flag) == flag)
                    return true;
            }

            return false;
        }
        
        public bool HasAnyTag(int tagsMask)
        {
            return HasAnyTag(ObjectTaggingUtility.MaskToTags(tagsMask));
        }
    }
}
