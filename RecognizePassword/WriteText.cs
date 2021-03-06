﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using RecognizePassword.Model;

namespace RecognizePassword
{
    internal static class WriteText
    {
        internal static void Write(string word, string description, ObservableCollection<DictionaryPasswordElement> obserColl)
        {
            obserColl.Add(new DictionaryPasswordElement
            {
                Word = word,
                Description = description
            });

            Debug.WriteLine("Hasło: {0,-90}\t\t\tObjaśnienie: {1}", word, description);
        }
    }
}