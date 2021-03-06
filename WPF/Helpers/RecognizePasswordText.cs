using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using WPF.Model;

namespace WPF.Helpers
{
    public class RecognizePasswordText //: IRecognizePasswordText
    {
       
        //private int _max;
        //private readonly ObservableCollection<DictionaryPasswordElement> ObserColl = new ObservableCollection<DictionaryPasswordElement>();
        //private Dictionary<string, string> _dictionary;
        //private string _textToRecognize;
        //private readonly List<string > RegexCitationList = new List<string>
        //{
        //    @":.*?[0-9]{3}.",
        //    @":.*, s.*?[0-9]{3}.",
        //    @":.*?[0-9]{4,4}.",
        //    @":.*?[0-9]{3,4}.",
        //    @".*?[0-9]{3,4}.",
        //    @":.*s.?[0-9]{3,4}.",
        //    @":.*?[0-9]{3,4}."
        //};
        
        //public ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, Dictionary<string, string> dictionary)
        //{
        //    _textToRecognize = textToRecognize;
        //    _dictionary = dictionary;
        //    try
        //    {
        //        //znalezienie i wyci�cie pierwszego s�owa
                
        //        GetDefiniendum();
        //        //znalezienie i wyci�cie tekstu do pierwszego znaku '�' o ile istnieje (has�o typowe wersja 1)

        //        var regex = new Regex(@"\D*�");
        //        var match = regex.Match(_textToRecognize);
                
        //        if (match.Success)
        //        {
        //            AnalizeText(match.Value);

        //            _textToRecognize =_textToRecognize.Remove(0, match.Length - 1);

        //            //wyszukanie znaczenia s�owa z podwojnych nawiasach skosnych
        //            for (var i = 0; i < 3; i++)
        //            {
        //                RegexRecognize(@"�.*?�", "definiens");
        //            }


        //            //trzy pr�by znalezienia cytatu
        //            for (var i = 0; i < 3; i++)
        //            {
        //                //rozpoznanie pocz�tku cyctatu / cytat�w
        //                foreach (var s in RegexCitationList)
        //                {
        //                    var success = RegexRecognize(s, "cytat");
        //                    if (success)
        //                    {
        //                        break;
        //                    }
        //                }
        //            }
                   
        //            //rozpoznanie znaczen pomiedzy <>
        //            RegexRecognize( @"<.*>", "wyja�nienie etymologiczne wyrazu");
                    
        //        }
                
        //        //przejscie po ca�ym zdaniu (bez pierwszego s�owa
        //        var temptext = "";
        //        int counter;
        //        _max = _textToRecognize.Length;

        //        for (counter = 0; counter < _max; counter++)
        //        {
        //            if (_textToRecognize[counter] != ' ')
        //            {
        //                temptext += _textToRecognize[counter];
        //                //jesli znaleziono przymiotnik
        //                if (temptext == "przym.")
        //                {
        //                    var meaning = RecognizeMeaningWord(temptext);
        //                    WriteText(temptext, meaning);
        //                    temptext = String.Empty;
        //                    counter += 2;

        //                    do
        //                    {
        //                        temptext += _textToRecognize[counter];
        //                        counter++;
        //                    } while (_textToRecognize[counter] != ':');
        //                    counter--;
        //                    WriteText(temptext, "Przymiotnik has�a");
        //                    temptext = String.Empty;

        //                    //jesli has�o ma numerowane znaczenia
        //                }//jesli jest cyfra
        //                //else if (int.TryParse(temptext[0].ToString(),out result)&&temptext.Length==2)
        //                //{
        //                //    //po cyfrze jest kropka
        //                //    if (temptext[1]=='.')
        //                //    {
        //                //        WriteText(temptext,result+" znaczenie has�a");
        //                //        temptext = Empty;
        //                //    }
        //                //}
        //            }
        //            else
        //            {
        //                if (temptext != "")
        //                {
        //                    //wyszukanie s�owa w s�owniku znacze�
        //                    var meaning = RecognizeMeaningWord(temptext);
        //                    WriteText(temptext, meaning);
        //                    temptext = String.Empty;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
                
        //    }

        //    return ObserColl;
        //}

        //private void GetDefiniendum()
        //{
        //    var regex = new Regex(@"\D*? ");
        //    var match = regex.Match(_textToRecognize);
        //    if (match.Success)
        //    {
        //        WriteText(match.Value.TrimEnd(), "definiendum");
        //        _textToRecognize = _textToRecognize.Remove(0, match.Length);
        //    }

        //}

        ////znajduje ci�g podany wzorem, zapisuje do s�ownika, i kasuje z tekstu
        //private bool RegexRecognize(string regexText,string description)
        //{
        //    var regex = new Regex(regexText);
        //    var match = regex.Match(_textToRecognize);
        //    if (match.Success)
        //    {
        //        WriteText(match.Value.TrimEnd(), description);
        //        _textToRecognize = _textToRecognize.Replace(match.Value, "");
        //    }
        //    return match.Success;
        //}


        ////dzielenie s�owa po spacjach i analiza poszczeg�lnych element�w

        //private void AnalizeText(string text)
        //{
        //    text = text.Replace('�', ' ').TrimEnd();

        //    var splitText = text.Split(' ');
        //    foreach (string s in splitText)
        //    {
        //        var e = RecognizeMeaningWord(s);
        //        WriteText(s.Replace(",",""),e);
        //    }
        //}

        //private string RecognizeMeaningWord(string text)
        //{
        //    if (_dictionary.ContainsKey(text))
        //        return _dictionary[text];

        //    if (text[0] == '~')
        //        return "~ znak przed ko�c�wk� fleksyjn� wraz z cz�stk� tematu";
        //    if (text[0] == '-')
        //        return "ko�c�wka fleksyjna";

        //    //1. 2. itp - kolejne znaczenia jednego has�a
        //    if (int.TryParse(text[0].ToString(), out int result) && text.Length == 2 && text[1] == '.')
        //        return result + " znaczenie has�a";

        //    if (text.Contains("I") || text.Contains("II") || text.Contains("III") || text.Contains("IV"))
        //    {
        //        return text.Replace("," , "") + " koniugacja/deklinacja";
        //    }
            
        //    return String.Empty;
        //}


        //private void WriteText(string text1, string text2 = "")
        //{
        //    ObserColl.Add(new DictionaryPasswordElement{Word=text1,Description=text2});

        //    Debug.WriteLine("Has�o: {0,-90}\t\t\tObja�nienie: {1}", text1, text2);
        //}
    }
}