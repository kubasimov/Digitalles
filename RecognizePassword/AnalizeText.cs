using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Model;

namespace RecognizePassword
{
    public static class AnalizeText
    {
        public static void Get(string text, Dictionary<string, string> dictionary, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            text = text.Replace('«', ' ').TrimEnd();

            var regex = new Regex(@"odm. jak \D ");
            var match = regex.Match(text);
            
            var splitText = text.Split(' ');


            for (var i = 0; i < splitText.Length; i++)
            {
                if (splitText[i] == "odm.")
                {
                    i = +3;
                    var e = RecognizeMeaningWord.Get(match.Value.Trim(), dictionary);
                    WriteText.Write(match.Value.Trim(), e, obserColl);
                }
                else if (splitText[i]== "–" || splitText[i] == "-")
                {
                    WriteText.Write(splitText[i]+" "+splitText[i+1], "definiendum", obserColl);
                    i += 1;
                }
                else
                {
                    var e = RecognizeMeaningWord.Get(splitText[i].Replace(",", ""), dictionary);
                    WriteText.Write(splitText[i].Replace(",", ""), e, obserColl);
                }
            }


        }
    }
}