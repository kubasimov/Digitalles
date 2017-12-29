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
                              ": Cóż robisz? — zapytał Franciszek z podziwieniem. — Uczę się, pracuję. — Polowanie to to praca! — zawołał myśliwy — a reszta głupstwo, dzieciństwo, babstwo, mnichostwo. Krasz. Poeta 84. " +
                              "To babstwo wiecznie mnie gubiło — zawołał po chwili, obtarł łzy i położył się na sofie. Wol. Bakal. 239. " +
                              "2. " +
                              "pogard. " +
                              "«gromada bab»" +
                              ": W czwartej oficynie, tej najbliższej od pałacu (...) same [samo] babstwo, Panie odpuść ciężkie grzechy, faworyty imościne; Chodź. Pisma I, 376.";

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
                new DictionaryPasswordElement{Word = "p.", Description = "patrz"},
                new DictionaryPasswordElement{Word = "babskość", Description = "odsyłanie do haseł"},
                new DictionaryPasswordElement{Word = ": Cóż robisz? — zapytał Franciszek z podziwieniem. — Uczę się, pracuję. — Polowanie to to praca! — zawołał myśliwy — a reszta głupstwo, dzieciństwo, babstwo, mnichostwo. Krasz. Poeta 84.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "To babstwo wiecznie mnie gubiło — zawołał po chwili, obtarł łzy i położył się na sofie. Wol. Bakal. 239.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "2.", Description = "liczbowy podział definicji"},
                new DictionaryPasswordElement{Word = "pogard.", Description = "pogardliwy (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«gromada bab»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": W czwartej oficynie, tej najbliższej od pałacu (...) same [samo] babstwo, Panie odpuść ciężkie grzechy, faworyty imościne; Chodź. Pisma I, 376.", Description = "cytat"},
            };

        public string Text31 = "pachwina ż IV, CMs. ~inie 1. " +
                               "«zagłębienie, miejsce między dolną boczną częścią brzucha a wewnętrzną powierzchnią górnej części uda»" +
                               ": Dostał wrzodów w okolicy pachwiny. BRAND. K. Antyg. 363. " +
                               "Buty z gumy sięgające do pachwin. NAŁK. Z. Gran. 244. " +
                               "Pan Jaksa-Świerkowski, zrujnowany obywatel (...) szlachcic kolosalnych rozmiarów, w butach z cholewami po same pachwiny — nie tyle śmiał się, ile rżał. ZER. Opow. II, 109. " +
                               "A wtem przez drzwi weszła księżna (...) przybrana w czerwony płaszcz i szatę zieloną, z pozłoconym pasem na biodrach, idącym wzdłuż pachwin i zapiętym nisko wielką klamrą. SIENK. Krzyż. I, 14. " +
                               "!! bud. Pachwina sklepieniowa p. pacha w zn. 3. 2. bot. «miejsce między górną stroną nasady liścia a łodygą»: Każdy pęd (...) ma po bokach pączki boczne, osadzone w kątach, czyli pachwi nach liści. SZAF. W. Bot. 43. // L";

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
                new DictionaryPasswordElement{Word = ": Dostał wrzodów w okolicy pachwiny. BRAND. K. Antyg. 363.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Buty z gumy sięgające do pachwin. NAŁK. Z. Gran. 244.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Pan Jaksa-Świerkowski, zrujnowany obywatel (...) szlachcic kolosalnych rozmiarów, w butach z cholewami po same pachwiny — nie tyle śmiał się, ile rżał. ZER. Opow. II, 109.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "A wtem przez drzwi weszła księżna (...) przybrana w czerwony płaszcz i szatę zieloną, z pozłoconym pasem na biodrach, idącym wzdłuż pachwin i zapiętym nisko wielką klamrą. SIENK. Krzyż. I, 14.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "!!", Description = "znak oddzielający optycznie objaśniane związki wyrazowe"},
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

        public string Text32 = "babusin a. babusiny «należący do babusi, właściwy babusi»: Babusina wnuczka.";
        public ObservableCollection<DictionaryPasswordElement> Result32 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "babusin", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "a.", Description = "albo"},
                new DictionaryPasswordElement{Word = "babusiny", Description = "odmiana"},
                new DictionaryPasswordElement{Word = "«należący do babusi, właściwy babusi»", Description = "definiens"},
            };

        public string Text33 = "celofan m IV, D. -u, Ms. ~anie, blm «masa plastyczna otrzymywana z celulozy, służąca do wyrobu nie tłukących się błon (szyb), okładek do legitymacji, sztucznych kwiatów, papieru szklistego, przezroczystego itp.; same te wyroby»: W celu zabezpieczenia przed wysychaniem taśma powinna być opakowana w papier przetłuszczony, celofan lub cynfolię i zamknięta w pudełku metalowym lub bakelitowym. Kolak. Towarozn. 123, Arkusz celofanu.? przen.Ważka, o skrzydłach z niebieskiego celofanu.Breza Niebo II, 209.<nm. Zellophan, od nazwy celulozy + gr. phänós = jasny, przejrzysty>";
        public ObservableCollection<DictionaryPasswordElement> Result33 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "celofan", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
                new DictionaryPasswordElement{Word = "IV", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
                new DictionaryPasswordElement{Word = "-u", Description = "końcówka fleksyjna"},
                new DictionaryPasswordElement{Word = "Ms.", Description = "miejscownik"},
                new DictionaryPasswordElement{Word = "~anie", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "blm", Description = "bez liczby mnogiej"},
                new DictionaryPasswordElement{Word = "«masa plastyczna otrzymywana z celulozy, służąca do wyrobu nie tłukących się błon (szyb), okładek do legitymacji, sztucznych kwiatów, papieru szklistego, przezroczystego itp.; same te wyroby»", Description = "definiens"},
                new DictionaryPasswordElement{Word = "<nm. Zellophan, od nazwy celulozy + gr. phänós = jasny, przejrzysty>", Description = "wyjaśnienie etymologiczne wyrazu"},
            };

        public string Text34 = "ewoluować ndk IV «rozwijać się; zmieniać się, przechodzić ewolucję»: Łatwiej zmienić przekonania polityczne lub religijne niż bardzo tylko powoli i częściowo ewoluujący język-styl. Jęz. Pol. 1935, s.43. <fr. évoluer>";
        public ObservableCollection<DictionaryPasswordElement> Result34 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "ewoluować", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ndk", Description = "niedokonany (aspekt)"},
                new DictionaryPasswordElement{Word = "IV", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "«rozwijać się; zmieniać się, przechodzić ewolucję»", Description = "definiens"},
                new DictionaryPasswordElement{Word = "<fr. évoluer>", Description = "wyjaśnienie etymologiczne wyrazu"},
            };

        public string Text35 = "fagas m IV, Ms. ~asie, lm M. -y a. ~asi pogard, «służący, sługus, lokaj, posługacz»: Zarumieniony stał za krzesłem, które mu wskazał czerwony na twarzy fagas, i czekał aż poczęto się schodzić. Iwasz. J. Księżyc 33. Kelner! prędzej, prędzej!... Co za harde fagasy! Berent Fach. 163. Kiwnął na fagasa, żeby mu dolał wina. Ritt. Duchy 50. Stawaj na placu, taki synu, bierz w łapę pistolet, a nie, to cię fagasom każę rozszarpać na szczętki [szczątki]. Żer. Grzech 51. Spotkał się z zuchwałym spojrzeniem lokaja ustawiającego krzesła. Najęty fagas — rumiany, tęgi, dobrze odżywiony z dziwną ironią spoglądał na wychudłego grajka. Zap. G. Krzyż 148. Wyposaża pokojówkę żony i wydaje ją za swojego fagasa. Buz. Rozh. 114. ? przen. «o człowieku wysługującym się komu, o lizusie, pochlebcy»: Magnaci i ich fagasi sabotowali jednak prace Sejmu, wygłaszali długie przemówienia, aby zyskać na czasie, aby się doczekać chwili, gdy Katarzyna będzie miała wolne ręce. Fiedl. F. Konst. 29. Otoczony zawsze zgrają pasożytów, pieczeniarzy, fagasów karmił ich, poił i — poniewierał. Gomul. Ciury II, 138. Oto fagas! przemknęło mu przez głowę. — I ja... ja!... miałbym z takimi ludźmi robić sobie ceremonie?... Prus Lalka 1,151. " +
                               "// SWil <może nm. dialektyczne: Fagas = włóczęga>";
        public ObservableCollection<DictionaryPasswordElement> Result35 =
                    new ObservableCollection<DictionaryPasswordElement>
                    {
new DictionaryPasswordElement{Word = "fagas", Description = "definiendum"},
new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
new DictionaryPasswordElement{Word = "IV", Description = "koniugacja/deklinacja"},
new DictionaryPasswordElement{Word = "Ms.", Description = "miejscownik"},
new DictionaryPasswordElement{Word = "~asie", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
new DictionaryPasswordElement{Word = "lm", Description = "liczba mnoga"},
new DictionaryPasswordElement{Word = "M.", Description = "mianownik"},
new DictionaryPasswordElement{Word = "-y", Description = "końcówka fleksyjna"},
new DictionaryPasswordElement{Word = "a.", Description = "albo"},
new DictionaryPasswordElement{Word = "~asi", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
new DictionaryPasswordElement{Word = "pogard", Description = "odmiana"},
new DictionaryPasswordElement{Word = "«służący, sługus, lokaj, posługacz»", Description = "definiens"},
new DictionaryPasswordElement{Word = ": Zarumieniony stał za krzesłem, które mu wskazał czerwony na twarzy fagas, i czekał aż poczęto się schodzić. Iwasz. J. Księżyc 33.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Kelner! prędzej, prędzej!... Co za harde fagasy! Berent Fach. 163.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Kiwnął na fagasa, żeby mu dolał wina. Ritt. Duchy 50.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Stawaj na placu, taki synu, bierz w łapę pistolet, a nie, to cię fagasom każę rozszarpać na szczętki [szczątki]. Żer. Grzech 51.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Spotkał się z zuchwałym spojrzeniem lokaja ustawiającego krzesła. Najęty fagas — rumiany, tęgi, dobrze odżywiony z dziwną ironią spoglądał na wychudłego grajka. Zap. G. Krzyż 148.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Wyposaża pokojówkę żony i wydaje ją za swojego fagasa. Buz. Rozh. 114.", Description = "cytat"},
new DictionaryPasswordElement{Word = "? przen. «o człowieku wysługującym się komu, o lizusie, pochlebcy»: Magnaci i ich fagasi sabotowali jednak prace Sejmu, wygłaszali długie przemówienia, aby zyskać na czasie, aby się doczekać chwili, gdy Katarzyna będzie miała wolne ręce. Fiedl. F. Konst. 29.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Otoczony zawsze zgrają pasożytów, pieczeniarzy, fagasów karmił ich, poił i — poniewierał. Gomul. Ciury II, 138.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Oto fagas! przemknęło mu przez głowę. — I ja... ja!... miałbym z takimi ludźmi robić sobie ceremonie?... Prus Lalka 1,151.", Description = "cytat"},
new DictionaryPasswordElement{Word = "// SWil", Description = "odwołanie do Słownika wileńskiego"},
new DictionaryPasswordElement{Word = "<może nm. dialektyczne: Fagas = włóczęga>", Description = "wyjaśnienie etymologiczne wyrazu"},
         };


        public string Text36 = "fagocista m odm. jak i IV, CMs. ~iście, lm M. ~iści, DB. -ów " +
                               "«grający na fagocie»" +
                               ": Ogólnie trzeba stwierdzić, że poziom konkursu był wysoki, szczególnie wyróżniło się dwóch świetnych puzonistów i fagocistów. Dz. Pol. 308, 1954. " +
                               "Mokry od deszczu, w fantazyjnej pelerynie, z przemokłymi, obwisłymi skrzydłami szerokiego kapelusza, tłusty a zbiedzony, młody lekarz przypominał wędrownego grajka: basistę lub fagocistę. Gomul. Ciury /, 70. " +
                               "Rano, najpóźniej o godzinie 6, już wszyscy chorzy przy źrzódle; tu dopiero kiepska dęta muzyka (z kilkunastu karykatur w rozmaitym guście złożona, na czele których fagocista) (...) przygrywa. Chopin Wyb. 22. " +
                               "//L";
        public ObservableCollection<DictionaryPasswordElement> Result36 =
                    new ObservableCollection<DictionaryPasswordElement>
                    {
new DictionaryPasswordElement{Word = "fagocista", Description = "definiendum"},
new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
new DictionaryPasswordElement{Word = "odm. jak i", Description = "odmiana"},
new DictionaryPasswordElement{Word = "IV", Description = "koniugacja/deklinacja"},
new DictionaryPasswordElement{Word = "CMs.", Description = "celownik, miejscownik"},
new DictionaryPasswordElement{Word = "~iście", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
new DictionaryPasswordElement{Word = "lm", Description = "liczba mnoga"},
new DictionaryPasswordElement{Word = "M.", Description = "mianownik"},
new DictionaryPasswordElement{Word = "~iści", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
new DictionaryPasswordElement{Word = "DB.", Description = "odmiana"},
new DictionaryPasswordElement{Word = "-ów", Description = "końcówka fleksyjna"},
new DictionaryPasswordElement{Word = "«grający na fagocie»", Description = "definiens"},
new DictionaryPasswordElement{Word = ": Ogólnie trzeba stwierdzić, że poziom konkursu był wysoki, szczególnie wyróżniło się dwóch świetnych puzonistów i fagocistów. Dz. Pol. 308, 1954.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Mokry od deszczu, w fantazyjnej pelerynie, z przemokłymi, obwisłymi skrzydłami szerokiego kapelusza, tłusty a zbiedzony, młody lekarz przypominał wędrownego grajka: basistę lub fagocistę. Gomul. Ciury /, 70.", Description = "cytat"},
new DictionaryPasswordElement{Word = "//L", Description = "odwołanie do Słownika Lindego"},
new DictionaryPasswordElement{Word = "//L", Description = "odwołanie do Słownika Lindego"},
         };

        public string Text37 = "haftarnia ż I, lm D. -i daw. p. hafciarnia. //SW";
        public ObservableCollection<DictionaryPasswordElement> Result37 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "haftarnia", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
                new DictionaryPasswordElement{Word = "//SW", Description = "odwołanie do Słownika warszawskiego"},
            };


        public string Text38 = "kapłanka ż III, lm D. ~nek «kobieta poświęcająca się służbie bóstwu»: Była ona kapłanką ponurej, bogini nocy Hekaty i prawie całe ży¬cie spędziła w jej świątyni, w oparach dymu krwawych ofiar i wśród odwarów ziół i ko¬rzeni o sile tajemnej. MARK. W. Mity 213. My¬śli moje jak kapłanki Westy snuły się białe, ci¬che. JASTR. Poemat 7. Gdyby kapłanka od og¬nia nie dotrzymała ślubu czystości, musiałaby umrzeć. PRUS Far. II, 73. Gracje, bóstwa mi¬łości najpierwsze kapłanki, plotły złote jej ko¬sy, upinały wianki. BRODZ. Poezje 45. ? przen. Przysiągłem w duchu, że — kapłanką mego rodzinnego ogniska będzie — albo Ka¬rolina, albo — żadna!... PRUS NOW.III, 178. O! cześć, ci, święta aniołów kochanko! kapłan¬ko piękna! natchnienia kapłanko! GRUDZ.Po¬ezje 15. // L";
public ObservableCollection<DictionaryPasswordElement> Result38 =
            new ObservableCollection<DictionaryPasswordElement>
            {
new DictionaryPasswordElement{Word = "kapłanka", Description = "definiendum"},
new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
new DictionaryPasswordElement{Word = "III", Description = "koniugacja/deklinacja"},
new DictionaryPasswordElement{Word = "lm", Description = "liczba mnoga"},
new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
new DictionaryPasswordElement{Word = "~nek", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
new DictionaryPasswordElement{Word = "«kobieta poświęcająca się służbie bóstwu»", Description = "definiens"},
new DictionaryPasswordElement{Word = ": Była ona kapłanką ponurej, bogini nocy Hekaty i prawie całe ży¬cie spędziła w jej świątyni, w oparach dymu krwawych ofiar i wśród odwarów ziół i ko¬rzeni o sile tajemnej. MARK. W. Mity 213.", Description = "cytat"},
new DictionaryPasswordElement{Word = "My¬śli moje jak kapłanki Westy snuły się białe, ci¬che. JASTR. Poemat 7.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Gdyby kapłanka od og¬nia nie dotrzymała ślubu czystości, musiałaby umrzeć. PRUS Far. II, 73.", Description = "cytat"},
new DictionaryPasswordElement{Word = "Gracje, bóstwa mi¬łości najpierwsze kapłanki, plotły złote jej ko¬sy, upinały wianki. BRODZ. Poezje 45.", Description = "cytat"},
new DictionaryPasswordElement{Word = "? przen. Przysiągłem w duchu, że — kapłanką mego rodzinnego ogniska będzie — albo Ka¬rolina, albo — żadna!... PRUS NOW. III, 178.", Description = "cytat"},
new DictionaryPasswordElement{Word = "O! cześć, ci, święta aniołów kochanko! kapłan¬ko piękna! natchnienia kapłanko! GRUDZ. Po¬ezje 15.", Description = "cytat"},
 };

        public string Text39 = "lakierniczy przym. odpowiadający rzecz. lakier a. lakiernictwo a. lakiernik: Materiały lakiernicze służą do pokrywania przedmiotów celem ich ochrony przed niszczącym działaniem otaczającego środowiska. Wiedza 715,5. 7. Przemysł, warsztat, surowiec lakierniczy. Benzyna lakiernicza.? przen. «nacechowany lakiernictwem; polegający na interesownym, zakłamanym przedstawianiu jakichś spraw w lepszym świetle niż są w rzeczywistości»: Potrafimy[w krytyce filmowej] wskazać i wykryć oczywiste fałsze, tale np.jak lakierniczy obraz środowiska młodzieżowego w „Załodze” Prz.Kult. 33, 1954. // SW";
        public ObservableCollection<DictionaryPasswordElement> Result39 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "lakierniczy", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "przym.", Description = "przymiotnik"},
                new DictionaryPasswordElement{Word = "odpowiadający rzecz. lakier a. lakiernictwo a. lakiernik", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Materiały lakiernicze służą do pokrywania przedmiotów celem ich ochrony przed niszczącym działaniem otaczającego środowiska. Wiedza 715,5.", Description = "cytat"},
                new DictionaryPasswordElement{Word = ". Przemysł, warsztat, surowiec lakierniczy. Benzyna lakiernicza.? przen. «nacechowany lakiernictwem; polegający na interesownym, zakłamanym przedstawianiu jakichś spraw w lepszym świetle niż są w rzeczywistości»: Potrafimy[w krytyce filmowej] wskazać i wykryć oczywiste fałsze, tale np.jak lakierniczy obraz środowiska młodzieżowego w „Załodze” Prz.Kult. 33, 1954.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// SW", Description = "odwołanie do Słownika warszawskiego"},
            };

        public string Text40 = "naciąganie naciągać (p. n I forma naciągnąć).";
        public ObservableCollection<DictionaryPasswordElement> Result40 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "naciąganie naciągać (p.", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "n", Description = "nijaki (rodzaj)"},
                new DictionaryPasswordElement{Word = "I", Description = "koniugacja/deklinacja"},
            };


    }
}