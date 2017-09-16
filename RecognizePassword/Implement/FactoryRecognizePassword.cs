using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Interface;
using RecognizePassword.Model;

namespace RecognizePassword.Implement
{
    public class FactoryRecognizePassword :IFactoryRecognizePassword
    {
        public ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, Dictionary<string, string> dictionary)
        {
            IRecognizePasswordText recognizePasswordText;
            var elementDictionary = new Dictionary<string, int>();

            var regexlist = new List<string>
            {
                @"◊",
                @"⌂",
                @"/+",
                @"~",
                @"<.*>",
                @"przym.",
                @"\(p\.| p\.",
                @"\/+ \w+|\/+\w+", //odwołanie do słownika
                @" [12]\.",
                @"przen\."
            };

            foreach (var reg in regexlist)
            {
                var regex = new Regex(reg);
                var match = regex.Matches(textToRecognize);
                elementDictionary.Add(reg, match.Count);
            }

            
            if (elementDictionary[@" [12]\."] >0)
            {
                recognizePasswordText=new RecognizePasswordTextType6();
            }

            else if (elementDictionary[@"◊"] >= 2)
            {
                recognizePasswordText=new RecognizePasswordTextType2();
            }

            else if (elementDictionary[@"◊"]==1&&elementDictionary[@"⌂"]>0 || 
                elementDictionary[@"◊"] == 1 && elementDictionary[@"\/+ \w+|\/+\w+"] > 0 ||
                     elementDictionary[@"◊"] == 1 && elementDictionary[@"przen\."] > 0)
            {
                recognizePasswordText=new RecognizePasswordTextType3();
            }

            else if (elementDictionary[@"\(p\.| p\."]  > 0)
            {
                recognizePasswordText = new RecognizePasswordTextType4();
            }

            else
            {
                recognizePasswordText = new RecognizePasswordTextType1();
            }
           
            return recognizePasswordText.Recognize(textToRecognize, dictionary);

        }
    }
}