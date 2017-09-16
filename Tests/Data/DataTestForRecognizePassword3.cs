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

        public string Text31 = "pachwina ż IV, CMs. ~inie 1. «zagłębienie, miejsce między dolną boczną częścią brzucha a wewnętrzną powierzchnią górnej części uda»: Dostał wrzodów w okolicy pachwiny. BRAND. K. Antyg. 363. Buty z gumy sięgające do pachwin. NAŁK. Z. Gran. 244. Pan Jaksa-Świerkowski, zrujnowany obywatel (...) szlachcic kolosalnych rozmiarów, w butach z cholewami po same pachwiny — nie tyle śmiał się, ile rżał. ZER. Opow. II, 109. A wtem przez drzwi weszła księżna (...) przybrana w czerwony płaszcz i szatę zieloną, z pozłoconym pasem na biodrach, idącym wzdłuż pachwin i zapiętym nisko wielką klamrą. SIENK. Krzyż. I, 14. ! bud. Pachwina\r\nsklepieniowa p. pacha w zn. 3.\r\n2. bot. «miejsce między górną stroną nasady liścia a łodygą»: Każdy pęd (...) ma po bokach pączki boczne, osadzone w kątach, czyli pachwi nach liści. SZAF. W. Bot. 43. // L";

        public ObservableCollection<DictionaryPasswordElement> Result31 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "pachwina", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
                new DictionaryPasswordElement{Word = "IV", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "CMs.", Description = "celownik, miejscownik"},
                new DictionaryPasswordElement{Word = "~inie", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "1.", Description = "liczbowy podział definicji"},
                new DictionaryPasswordElement{Word = "«zagłębienie, miejsce między dolną boczną częścią brzucha a wewnętrzną powierzchnią górnej części uda»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Dostał wrzodów w okolicy pachwiny. Brand. K. Antyg. 363.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Buty z gumy sięgające do pachwin. Nałk. Z. Gran. 244.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Pan Jaksa-Świerkowski, zrujnowany obywatel (...) szlachcic kolosalnych rozmiarów, w butach z cholewami po same pachwiny — nie tyle śmiał się, ile rżał. Zer. Opow. II, 109.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "A wtem przez drzwi weszła księżna (...) przybrana w czerwony płaszcz i szatę zieloną, z pozłoconym pasem na biodrach, idącym wzdłuż pachwin i zapiętym nisko wielką klamrą. Sienk. Krzyż. I, 14.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "«!»", Description = "znak oddzielający optycznie objaśniane związki wyrazowe"},
                new DictionaryPasswordElement{Word = "bud.", Description = "budownictwo (kwalifikator)"},
                new DictionaryPasswordElement{Word = "Pachwina sklepieniowa", Description = "uszczegółowienie"},
                new DictionaryPasswordElement{Word = "p.", Description = "patrz"},
                new DictionaryPasswordElement{Word = "przestarz.", Description = "przestarzały (kwalifikator)"},
                new DictionaryPasswordElement{Word = "pacha w zn. 3", Description = "odsyłanie do haseł"},
                new DictionaryPasswordElement{Word = "2.", Description = "liczbowy podział definicji"},
                new DictionaryPasswordElement{Word = "bot.", Description = "botanika (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«miejsce między górną stroną nasady liścia a łodygą»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Każdy pęd (...) ma po bokach pączki boczne, osadzone w kątach, czyli pachwi nach liści. Szaf. W. Bot. 43.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
            };


    }
}