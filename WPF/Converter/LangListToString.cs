using System.Collections.Generic;
using WPF.Model;

namespace WPF.Converter
{
    public static class LangListToString
    {
        public static string Convert(List<LangModel> languages)
        {
            var  temp = "";

            foreach (var language in languages)
            {
                if (string.IsNullOrEmpty(temp))
                {
                    temp = language.Shortname;
                }
                else
                {
                    temp = temp + "+" + language.Shortname;
                }
                
            }
            return temp;
        }
    }
}