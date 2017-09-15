using System.Collections.Generic;
using System.Collections.ObjectModel;
using RecognizePassword.Model;

namespace RecognizePassword.Interface
{
    public interface IFactoryRecognizePassword
    {
        ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, Dictionary<string, string> dictionary);
    }
}