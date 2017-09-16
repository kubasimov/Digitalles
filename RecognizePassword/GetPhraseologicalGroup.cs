using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace RecognizePassword
{
    [SuppressMessage("ReSharper", "InvertIf")]

    internal static class GetPhraseologicalGroup
    {
        internal static List<string> Get(ref string  textToRecognize)
        {
            var listmatch = new List<string>();
            var regex = new Regex(@"◊");
            var match = regex.Match(textToRecognize);
            var match2 = match.NextMatch();

            regex = new Regex(@"⌂");
            var t = regex.Match(textToRecognize);

            regex = new Regex(@"/+");
            var t1 = regex.Match(textToRecognize);
            
            if (match.Success)
            {
                if (match2.Success)
                {
                    listmatch.Add(textToRecognize.Substring(match.Index,
                        match2.Index - match.Index));
                    listmatch.Add(textToRecognize.Substring(match2.Index));

                    textToRecognize = textToRecognize.Replace(listmatch[0], "");
                    textToRecognize = textToRecognize.Replace(listmatch[1], "");
                }
                else if (t.Success)
                {
                    listmatch.Add(textToRecognize.Substring(match.Index, t.Index - match.Index));
                    listmatch.Add(textToRecognize.Substring(t.Index));

                    textToRecognize = textToRecognize.Replace(listmatch[0], "");
                    textToRecognize = textToRecognize.Replace(listmatch[1], "");

                }
                else if (t1.Success)
                {
                    listmatch.Add(textToRecognize.Substring(match.Index, t1.Index - match.Index));
                    listmatch.Add(textToRecognize.Substring(t1.Index));
                    textToRecognize = textToRecognize.Replace(listmatch[0], "");
                    textToRecognize = textToRecognize.Replace(listmatch[1], "");

                }
                else
                {
                    listmatch.Add(textToRecognize.Substring(match.Index));
                    textToRecognize = textToRecognize.Replace(listmatch[0], "");
                }


            }


            return listmatch;
        }

        public static void Read(ref List<string> phraseologicalList)
        {
            
        }
    }
}