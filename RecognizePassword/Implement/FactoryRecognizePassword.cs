using System.Collections.Generic;
using System.Collections.ObjectModel;
using RecognizePassword.Interface;
using RecognizePassword.Model;

namespace RecognizePassword.Implement
{
    public class FactoryRecognizePassword :IFactoryRecognizePassword
    {
        public ObservableCollection<DictionaryPasswordElement> Recognize(string textToRecognize, Dictionary<string, string> dictionary)
        {
            throw new System.NotImplementedException();
        }
    }
}