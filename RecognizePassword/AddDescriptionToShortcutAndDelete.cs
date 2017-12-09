using System.Collections.Generic;
using System.Collections.ObjectModel;
using RecognizePassword.Model;

namespace RecognizePassword
{
    internal static class AddDescriptionToShortcutAndDelete
    {
        internal static void Get(ref string text, string recognizeText, Dictionary<string, string> dictionary, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            var e = RecognizeMeaningWord.Get(recognizeText, dictionary);
            WriteText.Write(recognizeText, e, obserColl);
            text = text.Remove(0, recognizeText.Length + 1);
        }
    }
}