using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using RecognizePassword.Model;

namespace RecognizePassword
{
    internal static class GetEtymologicalExplanation
    {
        internal static void Get(ref string text, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            var regex = new Regex(@"<.*>");
            var match = regex.Match(text);
            if (match.Success)
            {
                WriteText.Write(match.Value.TrimEnd(), "wyjaśnienie etymologiczne wyrazu", obserColl);
                text = text.Replace(match.Value, "");
            }
            
        }
    }
}