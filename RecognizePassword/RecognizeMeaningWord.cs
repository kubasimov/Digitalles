using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RecognizePassword
{
    [SuppressMessage("ReSharper", "SwitchStatementMissingSomeCases")]

    internal static class RecognizeMeaningWord
    {
        internal static string Get(string text,
            Dictionary<string, string> dictionary)
        {
            if (dictionary.ContainsKey(text))
                return dictionary[text];
            switch (text[0])
            {
                case '~':
                    return "znak przed końcówką fleksyjną wraz z " +
                           "cząstką tematu";
                case '-':
                    return "końcówka fleksyjna";
            }

            if (int.TryParse(text[0].ToString(), out int result) 
                && text.Length == 2 && text[1] == '.')
                return result + " znaczenie hasła";
            
            return string.Empty;
        }
    }
}