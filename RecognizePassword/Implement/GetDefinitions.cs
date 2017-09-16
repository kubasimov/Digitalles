using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RecognizePassword.Implement
{
    public static class GetDefinitions
    {
        public static List<string> GetList(ref string textToRecognize)
        {
            var listDefinitions = new List<string>();
            var regex = new Regex(@" \d\.");

            var match = regex.Matches(textToRecognize);
            var listmatch =  (from Match match1 in match select match1).ToList();

            for (var i = 0; i < listmatch.Count; i++)
            {
                var start = listmatch[i].Index;

                var stop = i == listmatch.Count-1 ? textToRecognize.Length-start : 
                    listmatch[i + 1].Index -start;

                listDefinitions.Add(textToRecognize.Substring(start,stop));
            }

            textToRecognize = listDefinitions.Aggregate(textToRecognize, (current, definition) 
                => current.Replace(definition, ""));

            return listDefinitions;
        }
    }
}