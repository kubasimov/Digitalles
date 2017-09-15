using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RecognizePassword.Model;
using static System.Char;
using static System.String;

namespace RecognizePassword
{
    internal static class GetCitation
    {
        internal static void Get(ref string text, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            //wykrycie cytatów bez ostatniej kropki


            var regex = new Regex(@"\D+\d*(, s\. \d*|, \d*|,\d*, s. dod. \d*|,\d*, s. \d*|,\d*)?");


            var match = regex.Match(text.TrimStart());

            while (match.Success && IsNumber(match.Value.Last()) && match.Value.Length > 5 || match.Success && match.Value.Contains("cyt."))
            {
                WriteText.Write(match.Value.Last() == '.' ? match.Value : match.Value + ".", "cytat", obserColl);
                var z = match.Length + 2 < text.Length ? match.Length + 2 : match.Length;

                text = text.Remove(0, z);

                if (!IsNullOrEmpty(text) && text != "." && text.Length > 4)
                {
                    match = regex.Match(text);
                }
                else
                {
                    break;
                }

            }
        }

        internal static bool Contains(string text)
        {
            var regex = new Regex(@"\D+\d*(, s\. \d*|, \d*|
,\d*, s. dod. \d*|,\d*, s. \d*|,\d*)?");
            var match = regex.Match(text.TrimStart());

            return match.Success && IsNumber(match.Value.Last());
        }
    }
}
