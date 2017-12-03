using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Model;

namespace RecognizePassword
{
    internal static  class GetDefiniens
    {
        internal static void Get(ref string text, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            var regex = new Regex(@"«.*?»");
            var match = regex.Match(text);
            if (match.Success)
            {
                WriteText.Write(match.Value.TrimEnd(), "definiens", obserColl);
                text = text.Replace(match.Value, "");
            }

        }
    }
}