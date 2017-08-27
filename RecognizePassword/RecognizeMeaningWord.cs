using System;
using System.Collections.Generic;

namespace RecognizePassword
{
    public static class RecognizeMeaningWord
    {
        public static string Get(string text, Dictionary<string, string> dictionary)
        {
            if (dictionary.ContainsKey(text))
                return dictionary[text];

            if (text[0] == '~')
                return "~ znak przed końcówką fleksyjną wraz z cząstką tematu";
            if (text[0] == '-')
                return "końcówka fleksyjna";

            //1. 2. itp - kolejne znaczenia jednego hasła
            if (int.TryParse(text[0].ToString(), out int result) && text.Length == 2 && text[1] == '.')
                return result + " znaczenie hasła";

            if (text.Contains("I") || text.Contains("II") || text.Contains("III") || text.Contains("IV"))
            {
                return " koniugacja/deklinacja";
            }

            return String.Empty;
        }
    }
}