using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Model;

namespace RecognizePassword
{
    public static class GetDefiniendum
    {
        public static void Get(ref string text,Dictionary<string,string> dictionary, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            var definiendum = "";

            var regex = new Regex(@"\D*? ");
            var matches = regex.Matches(text );


            foreach (Match match in matches)
            {
                //add first word
                if (match == matches[0])
                {
                    definiendum += match.Value;
                    continue;
                }


                if (!dictionary.ContainsKey(match.Value.TrimEnd(' ', ',')) && match.Value[0]!= '«' &&match.Value[0]!='~')
                {
                    definiendum += match.Value;
                }
                else
                {
                    WriteText.Write(definiendum.TrimEnd(' '), "definiendum", obserColl);
                    text  = text.Remove(0, definiendum.Length);
                    break;
                }
            }
        }
    }
}