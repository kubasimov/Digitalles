﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Model;

namespace RecognizePassword
{
    internal static class GetReferenceToDictionary
    {
        internal static void Get(ref string text, Dictionary<string, string> dictionary,ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            //wykrycie odwołania i nadanie opisu
            var regex = new Regex(@"\/+ \w+|\/+\w+");
            var match = regex.Match(text);
            if (match.Success)
            {
                var e = RecognizeMeaningWord.Get(match.Value, dictionary);
                WriteText.Write(match.Value, e, obserColl);
                text = text.Remove(0, match.Length + 1);
            }
        }

    }
}