using System.Collections.ObjectModel;
using System.Diagnostics;
using RecognizePassword.Model;

namespace RecognizePassword
{
    public static class WriteText
    {
        public static void Write(string text1, string text2, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            obserColl.Add(new DictionaryPasswordElement
            {
                Word = text1,
                Description = text2
            });

            Debug.WriteLine("Hasło: {0,-90}\t\t\tObjaśnienie: {1}", text1, text2);
        }
    }
}