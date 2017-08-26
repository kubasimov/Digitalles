using System.Collections.Generic;
using System.Collections.ObjectModel;
using WPF.Model;

namespace WPF.Helpers
{
    public interface IRecognizePasswordText
    {
        ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, Dictionary<string, string> dictionary);
    }
}