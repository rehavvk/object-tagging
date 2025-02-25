using System;
using UnityEngine;

namespace Rehawk.ObjectTagging
{
    [Serializable]
    public class TagMask
    {
        [SerializeField] private string[] tags = Array.Empty<string>();
       
        public int Value
        {
            get { return ObjectTaggingUtility.TagsToMask(tags); }
            set { tags = ObjectTaggingUtility.MaskToTags(value); }
        }
        
        public static implicit operator int(TagMask mask)
        {
            return mask.Value;
        }

        public static implicit operator TagMask(int intValue)
        {
            return new TagMask
            {
                Value = intValue
            };
        }
    }
}