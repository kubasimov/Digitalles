using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Interface;
using RecognizePassword.Model;


namespace RecognizePassword.Implement
{
    public class RecognizePasswordTextType0 : IRecognizePasswordText
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
                GetDefiniendum.Get(ref _textToRecognize,_dictionary,_obserColl );

                //znalezienie i wyciecie kolejnych opisów hasła
                var regex = new Regex(@"[a-d]\) ");
                var matches = regex.Matches(_textToRecognize);
                for (var i = 0; i < matches.Count-1; i++)
                {
                    moreanswer.Add(_textToRecognize.Substring(matches[0].Index,matches[1].Index-matches[0].Index));
                }
                moreanswer.Add(_textToRecognize.Substring(matches[matches.Count-1].Index));

                foreach (var value in moreanswer)
                {
                    _textToRecognize = _textToRecognize.Replace(value, "");
                }

                //znalezienie i wycięcie tekstu do pierwszego znaku '«'
                GetDescriptionList();

                //wyszukanie znaczenia słowa z podwojnych nawiasach skosnych
                GetDefiniens.Get(ref _textToRecognize,_obserColl);

                AnalizeText.Get(_textToRecognize,_dictionary,_obserColl);

                foreach (var value in moreanswer)
                {
                    regex = new Regex(@"[a-d]\) ");
                    var match=regex.Match(value);
                    WriteText.Write(match.Value.Trim(), "literowy podział definicji", _obserColl);
                    var privatetextToRecognize = value.Replace(match.Value, "");


                    GetDefiniens.Get(ref privatetextToRecognize,_obserColl);

                    GetCitation.Get(ref privatetextToRecognize,_obserColl);


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

        private void GetDescriptionList()
        {
            var regex = new Regex(@"\D*?«");
            var match = regex.Match(_textToRecognize);

            if (match.Success&&match.Length>1)
            {
                AnalizeText.Get(match.Value, _dictionary, _obserColl);
                _textToRecognize = _textToRecognize.Remove(0, match.Length - 1);
            }

        }
        
    }
}