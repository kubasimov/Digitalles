﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using RecognizePassword.Interface;
using RecognizePassword.Model;


namespace RecognizePassword.Implement
{
    public class RecognizePasswordTextType5 : IRecognizePasswordText
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
                            AddDescriptionToShortcutAndDelete.Get(ref _textToRecognize, s.Replace(",", ""), _dictionary, _obserColl);

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
                            AddDescriptionToShortcutAndDelete.Get(ref _textToRecognize, s.Replace(",", ""), _dictionary, _obserColl);
                            
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
                            AddDescriptionToShortcutAndDelete.Get(ref _textToRecognize, s.Replace(",", ""), _dictionary, _obserColl);

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
                            AddDescriptionToShortcutAndDelete.Get(ref _textToRecognize, s.Replace(",", ""), _dictionary, _obserColl);
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

                GetDefiniens.Get(ref _textToRecognize, _obserColl);
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

                    GetDefiniens.Get(ref triangleText, _obserColl);
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
    }
}