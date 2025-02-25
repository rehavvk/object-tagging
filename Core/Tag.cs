using System;
using UnityEngine;

namespace Rehawk.ObjectTagging
{
    [Serializable]
    public class Tag
    {
        [SerializeField] private string tag;
       
        public int Value
        {
            get { return ObjectTaggingUtility.TagToLayer(tag); }
            set { tag = ObjectTaggingUtility.LayerToTag(value); }
        }
        
        public static implicit operator int(Tag tag)
        {
            return tag.Value;
        }

        public static implicit operator Tag(int intValue)
        {
            return new Tag
            {
                Value = intValue
            };
        }
        
        public static implicit operator string(Tag tag)
        {
            return tag.tag;
        }
    }
}