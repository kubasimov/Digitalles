using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using RecognizePassword.Interface;
using RecognizePassword.Model;
using static System.Char;
using static System.String;

namespace RecognizePassword.Implement
{
    public class RecognizePasswordTextType1 : IRecognizePasswordText
    {
        private readonly ObservableCollection<DictionaryPasswordElement> _obserColl = new ObservableCollection<DictionaryPasswordElement>();
        private Dictionary<string, string> _dictionary;
        private string _textToRecognize;
        private readonly List<string> _regexCitationList = new List<string>
        {
            @":.*?[0-9]{3}.",
            @":.*, s.*?[0-9]{3}.",
            @":.*?[0-9]{4,4}.",
            @":.*?[0-9]{3,4}.",
            @".*?[0-9]{3,4}.",
            @":.*s.?[0-9]{3,4}.",
            @":.*?[0-9]{3,4}."
        };
        

        public ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, Dictionary<string, string> dictionary)
        {
            _textToRecognize = textToRecognize;
            _dictionary = dictionary;

            try
            {
                //znalezienie i wycięcie pierwszego słowa
                GetDefiniendum.Get(ref _textToRecognize,_dictionary,_obserColl );

                //znalezienie i wycięcie tekstu do pierwszego znaku '«'
                GetDescriptionList();

                //wyszukanie znaczenia słowa z podwojnych nawiasach skosnych
                GetDefiniens(ref _textToRecognize);

                //pobranie elementów po znaku ◊
                var phraseologicalList = GetPhraseologicalGroup();

                //trzy próby znalezienia cytatu
                GetCitation(ref _textToRecognize);

                GetReferenceToDictionary.Get(ref _textToRecognize, _dictionary, _obserColl);

                //rozpoznanie znaczen pomiedzy <>
                GetEtymologicalExplanation(ref _textToRecognize);

                //rozpoznanie elemntów po znaku ◊
                foreach (string s in phraseologicalList)
                {
                    var text = s;

                    //wykrycie znaku ◊ i dodanie opisu
                    var regex = new Regex("◊");
                    var match = regex.Match(text);
                    if (match.Success)
                    {
                        var e = RecognizeMeaningWord.Get(match.Value,_dictionary);
                        WriteText.Write(match.Value, e, _obserColl);
                        text = text.Remove(0, match.Length + 1);
                    }


                    //wykrycie pierwszego słowa z kropką - skrót
                    regex = new Regex(@"\w+.");
                    match = regex.Match(text);

                    //zależnie od wykrytego skrótu
                    switch (match.Value)
                    {
                        case "fraz.":
                            {
                                //nadanie opisu skrótowi
                                var e = RecognizeMeaningWord.Get(match.Value, _dictionary);
                                WriteText.Write(match.Value, e, _obserColl);
                                text = text.Remove(0, match.Length + 1);

                                //wykrycie do znaku « i nadanie opisu
                                regex = new Regex(@"\D*«");
                                match = regex.Match(text);

                                if (match.Success)
                                {
                                    WriteText.Write(match.Value.Replace(" «", ""), "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny", _obserColl);
                                    text = text.Remove(0, match.Length - 1);
                                }

                                GetDefiniens(ref text);

                                //wykrycie sytatów
                                GetCitation(ref text);
                                break;
                            }
                        case "przen.":
                            {
                                //nadanie opisu skrótowi
                                var e = RecognizeMeaningWord.Get(match.Value, _dictionary);
                                WriteText.Write(match.Value, e, _obserColl);
                                text = text.Remove(0, match.Length + 1);

                                //wykrycie sytatów
                                GetCitation(ref text);

                                GetReferenceToDictionary.Get(ref text, _dictionary, _obserColl);

                                GetEtymologicalExplanation(ref text);
                                break;
                            }
                    }

                }

                GetReferenceToDictionary.Get(ref _textToRecognize, _dictionary, _obserColl);


            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }

            return _obserColl;
        }

        
        private List<string> GetPhraseologicalGroup()
        {
            var regex = new Regex("◊");
            var match = regex.Match(_textToRecognize);
            var listmatch = new List<string>();
            if (match.Success)
            {
                var t = match.NextMatch();

                if (t.Success)
                {
                    listmatch.Add(_textToRecognize.Substring(match.Index, t.Index - match.Index));
                    listmatch.Add(_textToRecognize.Substring(t.Index));

                    _textToRecognize = _textToRecognize.Replace(listmatch[0], "");
                    _textToRecognize = _textToRecognize.Replace(listmatch[1], "");
                }
            }

            return listmatch;
        }

        private void GetEtymologicalExplanation(ref string text)
        {
            RegexRecognize(@"<.*>", "wyjaśnienie etymologiczne wyrazu", text);
        }

        private void GetCitation(ref string text)
        {
            //wykrycie cytatów bez ostatniej kropki
            var regex = new Regex(@"\D+\d*(, s\. \d*|, \d*|,\d*, s. dod. \d*|,\d*, s. \d*|,\d*)?");
            var match = regex.Match(text);

            while (match.Success && IsNumber(match.Value.Last()) && match.Value.Length > 5)
            {
                WriteText.Write(match.Value + ".", "cytat", _obserColl);
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

        private void GetDefiniens(ref string text)
        {
            text = RegexRecognize(@"«.*?»", "definiens", text);
        }

        private void GetDescriptionList()
        {
            var regex = new Regex(@"\D*?«");
            var match = regex.Match(_textToRecognize);

            if (match.Success && match.Length>1)
            {
                AnalizeText.Get(match.Value,_dictionary,_obserColl);
                _textToRecognize = _textToRecognize.Remove(0, match.Length - 1);
            }

        }

        //znajduje ciąg podany wzorem, zapisuje do słownika, i kasuje z tekstu
        private string RegexRecognize(string regexText, string description, string toSearch)
        {
            var regex = new Regex(regexText);
            var match = regex.Match(toSearch);
            if (match.Success)
            {
                WriteText.Write(match.Value.TrimEnd(), description, _obserColl);
                toSearch = toSearch.Replace(match.Value, "");
            }
            return toSearch;
        }


        
    }

        
}
