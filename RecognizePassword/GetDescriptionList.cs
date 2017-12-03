using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Model;

namespace RecognizePassword
{
    internal static  class GetDescriptionList
    {
        internal static void Get(ref string text, Dictionary<string, string> dictionary, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            var regex = new Regex(@"\D*?«");
            var match = regex.Match(text);

            if (match.Success && match.Length > 1)
            {
                AnalizeText.Get(match.Value, dictionary, obserColl);
                text = text.Remove(0, match.Length - 1);
            }
        }
    }
}