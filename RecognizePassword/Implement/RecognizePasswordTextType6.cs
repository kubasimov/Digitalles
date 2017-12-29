using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Interface;
using RecognizePassword.Model;


namespace RecognizePassword.Implement
{
    public class RecognizePasswordTextType6 : IRecognizePasswordText
    {
        private readonly ObservableCollection<DictionaryPasswordElement> _obserColl = new ObservableCollection<DictionaryPasswordElement>();
        private Dictionary<string, string> _dictionary;
        private string _textToRecognize;

        public ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, Dictionary<string, string> dictionary)
        {
            _textToRecognize = textToRecognize;
            _dictionary = dictionary;

            var moreanswer = new List<string>();
            try
            {
                //znalezienie i wycięcie pierwszego słowa
                GetDefiniendum.Get(ref _textToRecognize, _dictionary, _obserColl);

                //znalezienie i wyciecie kolejnych opisów hasła
                var regex = new Regex(@" [1-9]\. ");
                var matches = regex.Matches(_textToRecognize);
                for (var i = 0; i < matches.Count - 1; i++)
                {
                    moreanswer.Add(_textToRecognize.Substring(matches[0].Index, matches[1].Index - matches[0].Index));
                }
                moreanswer.Add(_textToRecognize.Substring(matches[matches.Count - 1].Index));

                foreach (var value in moreanswer)
                {
                    _textToRecognize = _textToRecognize.Replace(value, "");
                }

                //znalezienie i wycięcie tekstu do pierwszego znaku '«'
                GetDescriptionList.Get(ref _textToRecognize,_dictionary,_obserColl);

                //wyszukanie znaczenia słowa z podwojnych nawiasach skosnych
                GetDefiniens.Get(ref _textToRecognize, _obserColl);

                AnalizeText.Get(_textToRecognize, _dictionary, _obserColl);

                foreach (var value in moreanswer)
                {
                    regex = new Regex(@" [1-9]\. ");
                    var match = regex.Match(value);
                    WriteText.Write(match.Value.Trim(), "liczbowy podział definicji", _obserColl);
                    var privatetextToRecognize = value.Replace(match.Value, "");
                    
                    regex = new Regex(@"przestarz\.|pogard\.");
                    match = regex.Match(privatetextToRecognize.Substring(0,12));
                    if (match.Success)
                    {
                        AddDescriptionToShortcutAndDelete.Get(ref privatetextToRecognize,match.Value,_dictionary,_obserColl);
                    }

                    regex = new Regex(@"p\. ");
                    match = regex.Match(privatetextToRecognize.Substring(0, 5));
                    if (match.Success)
                    {
                        AddDescriptionToShortcutAndDelete.Get(ref privatetextToRecognize, match.Value.Trim(), _dictionary, _obserColl);

                        regex = new Regex(@"^(\D*\:)");
                        match = regex.Match(privatetextToRecognize);
                        WriteText.Write(match.Value.Replace(":", "").Trim(), "odsyłanie do haseł", _obserColl);
                        privatetextToRecognize = privatetextToRecognize.Remove(0, match.Length - 1);
                    }

                    GetDefiniens.Get(ref privatetextToRecognize, _obserColl);

                    GetCitation.Get(ref privatetextToRecognize, _obserColl);


                    if (privatetextToRecognize.Length > 1)
                    {
                        regex = new Regex(@"<.*>");
                        match = regex.Match(privatetextToRecognize);

                        if (match.Success)
                        {
                            privatetextToRecognize = privatetextToRecognize.Replace(match.Value, "");
                            WriteText.Write(privatetextToRecognize.Trim(),
                                "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny", _obserColl);
                            WriteText.Write(match.Value.Trim(), "wyjaśnienie etymologiczne wyrazu", _obserColl);
                        }

                        regex = new Regex(@"!!");
                        match = regex.Match(privatetextToRecognize.Substring(0, 5));

                        if (match.Success)
                        {
                            AnalizeText.Get(match.Value, _dictionary, _obserColl);
                            privatetextToRecognize = privatetextToRecognize.Replace(match.Value, "").Trim();

                            AnalizeText.Get(privatetextToRecognize, _dictionary, _obserColl);
                        }
                        else
                        {
                            WriteText.Write(privatetextToRecognize.Trim(), "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny", _obserColl);
                        }
                    }

                    

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return _obserColl;
        }
        
    }
}