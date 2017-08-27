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
    public class RecognizePasswordTextType3 : IRecognizePasswordText
    {

        private int _max;
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
                GetDefiniendum.Get(ref _textToRecognize, _dictionary, _obserColl);

                //znalezienie i wycięcie tekstu do pierwszego znaku '«'
                GetDescriptionList();

                //wyszukanie znaczenia słowa z podwojnych nawiasach skosnych
                GetDefiniens(ref _textToRecognize);

                //pobranie elementów po znaku ◊
                var phraseologicalList =  GetPhraseologicalGroup();

                //trzy próby znalezienia cytatu
                GetCitation(ref _textToRecognize);

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
                        var e = RecognizeMeaningWord(match.Value);
                        WriteText.Write(match.Value, e, _obserColl);
                        text = text.Remove(0, match.Length + 1);
                    }

                    regex=new Regex(@"/+");
                    match = regex.Match(text);
                    if (match.Success)
                    {
                        GetReferenceToDictionary(ref text);
                        GetEtymologicalExplanation(ref text);
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
                                var e = RecognizeMeaningWord(match.Value);
                                WriteText.Write(match.Value, e, _obserColl);
                                text = text.Remove(0, match.Length + 1);

                                //wykrycie do znaku « i nadanie opisu
                                regex = new Regex(@"\D*«");
                                match = regex.Match(text);

                                if (match.Success)
                                {
                                    WriteText.Write(match.Value.Replace(" «",""), "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny", _obserColl);
                                    text  = text.Remove(0, match.Length - 1);
                                }

                                GetDefiniens(ref text);

                                //wykrycie sytatów
                                GetCitation(ref text);

                                
                                break;
                        }
                        case "przen.":
                        {
                                //nadanie opisu skrótowi
                                var e = RecognizeMeaningWord(match.Value);
                                WriteText.Write(match.Value, e, _obserColl);
                                text = text.Remove(0, match.Length + 1);

                                //wykrycie sytatów
                                GetCitation(ref text);


                                GetReferenceToDictionary(ref text);
                                

                                GetEtymologicalExplanation(ref text);
                                break;
                        }
                    }


                    //wykrycie ⌂
                    regex = new Regex(@"⌂");
                    match = regex.Match(text);

                    if (match.Success)
                    {
                        var e = RecognizeMeaningWord(match.Value);
                        WriteText.Write(match.Value, e, _obserColl);
                        text = text.Remove(0, match.Length);
                    } 

                    if (match.Success)
                    {
                        regex = new Regex(@"\D*«");
                        match = regex.Match(text);

                        if (match.Success)
                        {
                            WriteText.Write(match.Value.Replace(" «", ""), "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny", _obserColl);
                            text = text.Remove(0, match.Length - 1);

                            GetDefiniens(ref text);
                            GetCitation(ref text);
                            GetEtymologicalExplanation(ref text);
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

        private void GetReferenceToDictionary(ref string text)
        {
            //wykrycie odwołania i nadanie opisu
            var regex = new Regex(@"\/+ \w+");
            var match = regex.Match(text);
            var e = RecognizeMeaningWord(match.Value);
            WriteText.Write(match.Value, e, _obserColl);
            text = text.Remove(0, match.Length + 1);
        }

        private List<string> GetPhraseologicalGroup()
        {
            var regex = new Regex("◊");
            var match = regex.Match(_textToRecognize);
            var listmatch = new List<string>();

            regex = new Regex(@"⌂");

            var t = regex.Match(_textToRecognize);

            regex = new Regex(@"/+");

            var t1 = regex.Match(_textToRecognize);

            if (match.Success)
            {
                

                if (t.Success)
                {
                    listmatch.Add(_textToRecognize.Substring(match.Index, t.Index-match.Index));
                    listmatch.Add(_textToRecognize.Substring(t.Index));

                    _textToRecognize = _textToRecognize.Replace(listmatch[0], "");
                    _textToRecognize = _textToRecognize.Replace(listmatch[1], "");
                    
                }

                if (t1.Success)
                {
                    listmatch.Add(_textToRecognize.Substring(match.Index, t1.Index - match.Index));
                    listmatch.Add(_textToRecognize.Substring(t1.Index));
                    _textToRecognize = _textToRecognize.Replace(listmatch[0], "");
                    _textToRecognize = _textToRecognize.Replace(listmatch[1], "");

                }
            }
            

            return listmatch;
        }

        private void GetEtymologicalExplanation(ref string text)
        {
            RegexRecognize(@"<.*>", "wyjaśnienie etymologiczne wyrazu",text);
        }

        private void GetCitation(ref string text)
        {
            //wykrycie cytatów bez ostatniej kropki
            var regex = new Regex(@"\D+\d*(, s\. \d*|, \d*|,\d*, s. dod. \d*|,\d*)?");
            var match = regex.Match(text);

            while (match.Success && IsNumber(match.Value.Last())&&match.Value.Length>5)
            {
                WriteText.Write(match.Value + ".", "cytat", _obserColl);
                var z = match.Length + 2 < text.Length ? match.Length + 2 : match.Length;

                text = text.Remove(0,z);
                
                if (!IsNullOrEmpty(text) && text!="." && text.Length>4)
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
            text= RegexRecognize(@"«.*?»", "definiens",text);
        }

        private void GetDescriptionList()
        {
            var regex = new Regex(@"\D*?«");
            var match = regex.Match(_textToRecognize);

            if (match.Success)
            {
                AnalizeText(match.Value);
                _textToRecognize = _textToRecognize.Remove(0, match.Length - 1);
            }

        }

        
        //znajduje ciąg podany wzorem, zapisuje do słownika, i kasuje z tekstu
        private string  RegexRecognize(string regexText, string description,string toSearch)
        {
            var regex = new Regex(regexText);
            var match = regex.Match(toSearch);
            if (match.Success)
            {
                WriteText.Write(match.Value.TrimEnd(), description,_obserColl);
                toSearch = toSearch.Replace(match.Value, "");
            }
            return toSearch;
        }


        //dzielenie słowa po spacjach i analiza poszczególnych elementów

        private void AnalizeText(string text)
        {
            text = text.Replace('«', ' ').TrimEnd();

            var splitText = text.Split(' ');
            foreach (string s in splitText)
            {
                var e = RecognizeMeaningWord(s.Replace(",",""));
                WriteText.Write(s.Replace(",", ""), e,_obserColl);
            }
        }

        private string RecognizeMeaningWord(string text)
        {
            if (_dictionary.ContainsKey(text))
                return _dictionary[text];

            if (text[0] == '~')
                return "~ znak przed końcówką fleksyjną wraz z cząstką tematu";
            if (text[0] == '-')
                return "końcówka fleksyjna";

            //1. 2. itp - kolejne znaczenia jednego hasła
            if (int.TryParse(text[0].ToString(), out int result) && text.Length == 2 && text[1] == '.')
                return result + " znaczenie hasła";

            if (text.Contains("I") || text.Contains("II") || text.Contains("III") || text.Contains("IV"))
            {
                return text.Replace(",", "") + " koniugacja/deklinacja";
            }

            return Empty;
        }


    }
}