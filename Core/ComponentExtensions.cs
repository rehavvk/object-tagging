using UnityEngine;

namespace Rehawk.ObjectTagging
{
    public static class ComponentExtensions
    {
        public static bool HasTags(this Component component, params string[] tags)
        {
            return component.gameObject.HasTags(tags);
        } 
        
        public static bool HasTags(this Component component, int tagsMask)
        {
            return component.gameObject.HasTags(tagsMask);
        }
        
        public static bool HasAnyTag(this Component component, params string[] tags)
        {
            return component.gameObject.HasAnyTag(tags);
        }
        
        public static bool HasAnyTag(this Component component, int tagsMask)
        {
            return component.gameObject.HasAnyTag(tagsMask);
        }
    }
}