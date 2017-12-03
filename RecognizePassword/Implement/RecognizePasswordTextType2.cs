using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Interface;
using RecognizePassword.Model;

namespace RecognizePassword.Implement
{
    public class RecognizePasswordTextType2 : IRecognizePasswordText
    {
        private readonly ObservableCollection<DictionaryPasswordElement> _obserColl = new ObservableCollection<DictionaryPasswordElement>();
        private Dictionary<string, string> _dictionary;
        private string _textToRecognize;

        public ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, Dictionary<string, string> dictionary)
        {
            _textToRecognize = textToRecognize;
            _dictionary = dictionary;

            try
            {
                //znalezienie i wycięcie pierwszego słowa
                GetDefiniendum.Get(ref _textToRecognize, _dictionary, _obserColl);

                //znalezienie i wycięcie tekstu do pierwszego znaku '«'
                GetDescriptionList.Get(ref _textToRecognize,_dictionary,_obserColl);

                //wyszukanie znaczenia słowa z podwojnych nawiasach skosnych
                GetDefiniens.Get(ref _textToRecognize,_obserColl);

                //pobranie elementów po znaku ◊
                //var phraseologicalList =  GetPhraseologicalGroup();
                var phraseologicalList = RecognizePassword.GetPhraseologicalGroup.Get(ref _textToRecognize);
                
                //trzy próby znalezienia cytatu
                GetCitation.Get(ref _textToRecognize, _obserColl);

                //rozpoznanie znaczen pomiedzy <>
                GetEtymologicalExplanation.Get(ref _textToRecognize,_obserColl);

                //rozpoznanie elemntów po znaku ◊
                foreach (string s in phraseologicalList)
                {
                    var text = s;

                    //wykrycie znaku ◊ i dodanie opisu
                    var regex = new Regex("◊");
                    var match = regex.Match(text);
                    if (match.Success)
                    {
                        var e = RecognizeMeaningWord.Get(match.Value, _dictionary);
                        WriteText.Write(match.Value, e, _obserColl);
                        text = text.Remove(0, match.Length + 1);
                    }


                    //wykrycie pierwszego słowa z kropką - skrót
                    regex=new Regex(@"\w+.");
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
                                    WriteText.Write(match.Value.Replace(" «",""), "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny", _obserColl);
                                    text  = text.Remove(0, match.Length - 1);
                                }

                                GetDefiniens.Get(ref text,_obserColl);

                                //wykrycie sytatów
                                GetCitation.Get(ref text, _obserColl);
                                break;
                        }
                        case "przen.":
                        {
                                //nadanie opisu skrótowi
                                var e = RecognizeMeaningWord.Get(match.Value, _dictionary);
                                WriteText.Write(match.Value, e, _obserColl);
                                text = text.Remove(0, match.Length + 1);

                                //wykrycie sytatów
                                GetCitation.Get(ref text, _obserColl);

                                GetReferenceToDictionary.Get(ref text, _dictionary, _obserColl);

                                GetEtymologicalExplanation.Get(ref text,_obserColl);
                                break;
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
                    listmatch.Add(_textToRecognize.Substring(match.Index, t.Index-match.Index));
                    listmatch.Add(_textToRecognize.Substring(t.Index));

                    _textToRecognize = _textToRecognize.Replace(listmatch[0], "");
                    _textToRecognize = _textToRecognize.Replace(listmatch[1], "");
                }
            }

            return listmatch;
        } 
    }
}