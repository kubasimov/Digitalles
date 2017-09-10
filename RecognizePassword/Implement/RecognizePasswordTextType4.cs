﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using RecognizePassword.Interface;
using RecognizePassword.Model;


namespace RecognizePassword.Implement
{
    public class RecognizePasswordTextType4 : IRecognizePasswordText
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
                GetDefiniendum.Get(ref _textToRecognize,_dictionary,_obserColl );

                var regex3 = new Regex(@"⌂");
                var t = regex3.Match(_textToRecognize);
                var triangleText = "";

                if (t.Success)
                {
                    triangleText = _textToRecognize.Substring(t.Index);
                    _textToRecognize = _textToRecognize.Replace(triangleText, "");
                }

                var splitText = _textToRecognize.Split(' ');

                foreach (string s in splitText)
                {
                    if (_dictionary.ContainsKey(s))
                    {
                        if (s=="p.")
                        {
                            var e = RecognizeMeaningWord.Get(s.Replace(",", ""), _dictionary);
                            WriteText.Write(s.Replace(",", ""), e, _obserColl);
                            _textToRecognize = _textToRecognize.Remove(0, s.Length + 1);

                            var regex1 = new Regex(@"\/+ \w+");
                            var match1 = regex1.Match(_textToRecognize);

                            if (match1.Success)
                            {
                                var text = _textToRecognize.Substring(0, match1.Index);
                                WriteText.Write(text.Trim(), "definiens", _obserColl);
                                break;
                            }
                            else
                            {
                                WriteText.Write(_textToRecognize.Trim(), "odsyłanie do haseł", _obserColl);
                                break;
                            }
                            
                        }
                        if (s == "a.")
                        {
                            var e = RecognizeMeaningWord.Get(s.Replace(",", ""), _dictionary);
                            WriteText.Write(s.Replace(",", ""), e, _obserColl);
                            _textToRecognize = _textToRecognize.Remove(0, s.Length + 1);

                            var regex1 = new Regex(@"\w+");
                            var match1 = regex1.Match(_textToRecognize);

                            if (match1.Success)
                            {
                                var text = _textToRecognize.Substring(0, match1.Length);
                                WriteText.Write(text.Trim(), "definiendum", _obserColl);
                                _textToRecognize = _textToRecognize.Replace(text, "");
                                break;
                            }
                           

                        }
                        if (s=="przym.")
                        {
                            var e = RecognizeMeaningWord.Get(s.Replace(",", ""), _dictionary);
                            WriteText.Write(s.Replace(",", ""), e, _obserColl);
                            _textToRecognize = _textToRecognize.Remove(0, s.Length + 1);

                            var regex1 = new Regex(@"\D*:");
                            var match1 = regex1.Match(_textToRecognize);

                            if (match1.Success)
                            {
                                var text = _textToRecognize.Substring(0, match1.Length-1);
                                WriteText.Write(text.Trim(), "definiens", _obserColl);
                                _textToRecognize = _textToRecognize.Replace(text.TrimEnd(':'), "");


                                if (!GetCitation.Contains(_textToRecognize))
                                {
                                    var regex2 = new Regex(@"\D* \/");
                                    var match2 = regex2.Match(_textToRecognize);
                                    WriteText.Write(match2.Value.TrimEnd('/',' '), "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny", _obserColl);
                                    _textToRecognize = _textToRecognize.Replace(match2.Value.TrimEnd('/'), "");
                                }
                                else
                                {
                                    GetCitation.Get(ref _textToRecognize,_obserColl);
                                }

                                break;
                            }


                        }
                        else
                        {
                            var e = RecognizeMeaningWord.Get(s.Replace(",", ""), _dictionary);
                            WriteText.Write(s.Replace(",", ""), e, _obserColl);
                            _textToRecognize=_textToRecognize.Remove(0,s.Length+1);
                        }
                    }
                    else if (s[0]=='~')
                    {
                        AnalizeText.Get(s,_dictionary,_obserColl);
                        _textToRecognize = _textToRecognize.Remove(0, s.Length + 1);
                    }
                    else
                    {
                        break;
                    }
                }

                


                var regex = new Regex(@"\(p\.\D*?\).?");
                var match = regex.Match(_textToRecognize);
                if (match.Success)
                {
                    var text = _textToRecognize.Substring(0,match.Index);
                    WriteText.Write(text.Trim(),"definiens",_obserColl);
                    _textToRecognize = _textToRecognize.Replace(text, "");

                    if (match.Length==4)
                    {
                        var e = RecognizeMeaningWord.Get(match.Value.Replace(",", ""), _dictionary);
                        WriteText.Write(match.Value.Replace(",", ""), e, _obserColl);
                    }
                    else
                    {
                        WriteText.Write(match.Value.Replace(",", ""), "patrz + bezokolicznik", _obserColl);
                    }
                }

                GetDefiniens(ref _textToRecognize);
                GetCitation.Get(ref _textToRecognize,_obserColl);
                GetReferenceToDictionary.Get(ref _textToRecognize,_dictionary,_obserColl);


                if (t.Success)
                {
                    var e = RecognizeMeaningWord.Get(triangleText[0].ToString(), _dictionary);
                    WriteText.Write(triangleText[0].ToString(), e, _obserColl);
                    triangleText = triangleText.Remove(0, 2);

                    regex3 = new Regex(@"\D*?«");
                    t = regex3.Match(triangleText);
                    WriteText.Write(t.Value.Replace("«", ""), "uszczegółowienie", _obserColl);
                    triangleText = triangleText.Remove(0, t.Length - 1);

                    GetDefiniens(ref triangleText);
                    GetCitation.Get(ref triangleText, _obserColl);
                    GetReferenceToDictionary.Get(ref triangleText,_dictionary,_obserColl);

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

        

        private void GetDefiniens(ref string text)
        {
            text = RegexRecognize(@"«.*?»", "definiens", text);
        }

        private void GetDescriptionList()
        {
            var regex = new Regex(@"\D*?«");
            var match = regex.Match(_textToRecognize);

            if (match.Success)
            {
                AnalizeText.Get(match.Value, _dictionary, _obserColl);
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