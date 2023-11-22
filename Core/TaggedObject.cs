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
    }
}