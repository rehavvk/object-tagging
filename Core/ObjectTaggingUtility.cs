using System;
using System.Collections.Generic;

namespace Rehawk.ObjectTagging
{
    public static class ObjectTaggingUtility
    {
        private static readonly List<string> tmpTagList = new List<string>();

        public static int TagToLayer(string tag)
        {
            string[] availableTags = ObjectTaggingSettings.Tags;

            int mask = 0;
            
            int index = Array.IndexOf(availableTags, tag);
            mask |= 1 << index;

            return mask;
        }
        
        public static int TagsToMask(string[] tags)
        {
            string[] availableTags = ObjectTaggingSettings.Tags;

            int mask = 0;
            for (int i = 0; i < tags.Length; i++)
            {
                int index = Array.IndexOf(availableTags, tags[i]);
                mask |= 1 << index;
            }

            return mask;
        }

        public static string[] MaskToTags(int mask)
        {
            string[] availableTags = ObjectTaggingSettings.Tags;

            tmpTagList.Clear();
            
            for (int i = 0; i < availableTags.Length; i++)
            {
                if ((mask & (1 << i)) == (1 << i))
                {
                    tmpTagList.Add(availableTags[i]);
                }
            }

            return tmpTagList.ToArray();
        }
    }
}