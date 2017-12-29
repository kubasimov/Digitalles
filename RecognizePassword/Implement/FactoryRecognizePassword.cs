using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.RegularExpressions;
using Autofac;
using NLog;
using RecognizePassword.Interface;
using RecognizePassword.Model;

namespace RecognizePassword.Implement
{
    public class FactoryRecognizePassword :IFactoryRecognizePassword
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, 
            Dictionary<string, string> dictionary)
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
                @"przym\.",
                @"rzecz\.",
                @"fraz.",
                @" a. ",
                @"\(p\.| p\.",
                @"\/+ \w+|\/+\w+", //odwołanie do słownika
                @" [12]\.",
                @"przen\.",
                @"[a-d]\) "
            };

            foreach (var reg in regexlist)
            {
                var regex = new Regex(reg);
                var match = regex.Matches(textToRecognize);
                elementDictionary.Add(reg, match.Count);
            }

            if (elementDictionary[@"[a-d]\) "]>0)
            {
                recognizePasswordText = new RecognizePasswordTextType0();
                Logger.Log(LogLevel.Trace, "Typ - 0");
            }
            else if (elementDictionary[@" [12]\."] >0)
            {
                recognizePasswordText=new RecognizePasswordTextType6();
                Logger.Log(LogLevel.Trace, "Typ - 6");
            }
            else if (elementDictionary[@"◊"] >= 2)
            {
                recognizePasswordText=new RecognizePasswordTextType2();
                Logger.Log(LogLevel.Trace, "Typ - 2");
            }
            else if (elementDictionary[@"\(p\.| p\."]  > 0 || elementDictionary[@"przym\."]>0 ||
                elementDictionary[@"rzecz\."] > 0 ) 
            {
                recognizePasswordText = new RecognizePasswordTextType4();
                Logger.Log(LogLevel.Trace, "Typ - 4");
            }
            else if (elementDictionary[@"◊"]==1&&elementDictionary[@"⌂"]>0 || 
                elementDictionary[@"◊"] == 1 && elementDictionary[@"\/+ \w+|\/+\w+"] > 0 ||
                     elementDictionary[@"◊"] == 1 && elementDictionary[@"przen\."] > 0)
            {
                recognizePasswordText=new RecognizePasswordTextType3();
                Logger.Log(LogLevel.Trace, "Typ - 3");
            }
            
            else
            {
                recognizePasswordText = new RecognizePasswordTextType1();
                Logger.Log(LogLevel.Trace, "Typ - 1");
            }
           
            return recognizePasswordText.Recognize(textToRecognize, dictionary);

        }
    }
}