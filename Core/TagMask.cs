using System;
using UnityEngine;

namespace Rehawk.ObjectTagging
{
    [Serializable]
    public class TagMask
    {
        [SerializeField] private string[] tags = Array.Empty<string>();
       
        public string[] Tags
        {
            get { return tags; }
        }
        
        public int Value
        {
            get { return ObjectTaggingUtility.TagsToMask(tags); }
            set { tags = ObjectTaggingUtility.MaskToTags(value); }
        }
        
        public static implicit operator int(TagMask mask)
        {
            return mask.Value;
        }

        public static implicit operator TagMask(int intVal)
        {
            return new TagMask
            {
                Value = intVal
            };
        }
    }
}