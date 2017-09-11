using System.Collections.ObjectModel;
using RecognizePassword.Model;

namespace Tests.Data
{
    public class DataTestForRecognizePassword3
    {
        public string Text30= "babstwo " +
                              "n " +
                              "III, " +
                              "Ms. " +
                              "~twie, " +
                              "blm " +
                              "1. " +
                              "przestarz. " +
                              "p. " +
                              "babskość" +
                              ": Cóż robisz? — zapytał Franciszek z podziwieniem. — Uczę się, pracuję. — Polowanie to to praca! — zawołał myśliwy — a reszta głupstwo, dzieciństwo, babstwo, mnichostwo. KRASZ. Poeta 84. " +
                              "To babstwo wiecznie mnie gubiło — zawołał po chwili, obtarł łzy i położył się na sofie. WOL. Bakal. 239. " +
                              "2. " +
                              "pogard. " +
                              "«gromada bab»" +
                              ": W czwartej oficynie, tej najbliższej od pałacu (...) same [samo] babstwo, Panie odpuść ciężkie grzechy, faworyty imościne; CHODŹ. Pisma I, 376.";

        public ObservableCollection<DictionaryPasswordElement> Result30 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "babstwo", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "n", Description = "nijaki (rodzaj)"},
                new DictionaryPasswordElement{Word = "III", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "Ms.", Description = "miejscownik"},
                new DictionaryPasswordElement{Word = "~twie", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "blm", Description = "bez liczby mnogiej"},
                new DictionaryPasswordElement{Word = "1.", Description = "liczbowy podział definicji"},
                new DictionaryPasswordElement{Word = "przestarz.", Description = "przestarzały (kwalifikator)"},
                new DictionaryPasswordElement{Word = "babskość", Description = "odsyłanie do haseł"},
                new DictionaryPasswordElement{Word = ": Cóż robisz? — zapytał Franciszek z podziwieniem. — Uczę się, pracuję. — Polowanie to to praca! — zawołał myśliwy — a reszta głupstwo, dzieciństwo, babstwo, mnichostwo. Krasz. Poeta 84.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "To babstwo wiecznie mnie gubiło — zawołał po chwili, obtarł łzy i położył się na sofie. Wol. Bakal. 239.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "2.", Description = "liczbowy podział definicji"},
                new DictionaryPasswordElement{Word = "pogard.", Description = "pogardliwy (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«gromada bab»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": W czwartej oficynie, tej najbliższej od pałacu (...) same [samo] babstwo, Panie odpuść ciężkie grzechy, faworyty imościne; Chodź. Pisma I, 376.", Description = "cytat"},
            };

    }
}