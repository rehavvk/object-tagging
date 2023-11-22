using System;
using System.IO;
using System.Linq;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Rehawk.ObjectTagging
{
    public static class ObjectTagBaker
    {
        private const string FILE_TEMPLATE = "public static class ObjectTags\n{\n[CONST_PLACEHOLDER]\n}";

        public static void Bake()
        {
            string path = EditorUtility.SaveFilePanel("Save object tag file", "", "ObjectTags.cs", "cs");

            if (path.Length != 0)
            {
                var stringBuilder = new StringBuilder();

                foreach (string tag in ObjectTaggingSettings.Tags.OrderBy(t => t))
                {
                    string constName = StringToConstantCase(tag);
                
                    stringBuilder.Append($"\tpublic const string {constName} = \"{tag}\";");
                    stringBuilder.AppendLine();
                }

                string fileContent = FILE_TEMPLATE.Replace("[CONST_PLACEHOLDER]", stringBuilder.ToString());
            
                File.WriteAllText(path, fileContent);
            
                Debug.Log("<b>Object Tags Baked</b>");
            }
        }
        
        private static string StringToConstantCase(this string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var sb = new StringBuilder();
            
            sb.Append(char.ToUpperInvariant(text[0]));

            bool previousCharWasLower = false;
            for (int i = 1; i < text.Length; ++i)
            {
                char c = text[i];

                if (c == ' ')
                {
                    c = '_';
                }
                
                if (previousCharWasLower && char.IsUpper(c))
                {
                    sb.Append('_');
                    sb.Append(char.ToUpperInvariant(c));
                }
                else
                {
                    sb.Append(char.ToUpperInvariant(c));
                }

                previousCharWasLower = char.IsLower(c);
            }

            return sb.ToString();
        }
    }
}