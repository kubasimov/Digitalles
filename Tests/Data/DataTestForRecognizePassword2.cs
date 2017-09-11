using System.Collections.ObjectModel;
using RecognizePassword.Model;

namespace Tests
{
    public class DataTestForRecognizePassword2
    {
        
        public string Text20 = "babunin a. babuniny «należący do babuni, dotyczący babuni»: Miliony babunine spać nie dawały. Krasz. cyt. SW.";

        public ObservableCollection<DictionaryPasswordElement> Result20 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "babunin", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "a.", Description = "albo"},
                new DictionaryPasswordElement{Word = "babuniny", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "«należący do babuni, dotyczący babuni»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Miliony babunine spać nie dawały. Krasz. cyt. SW.", Description = "cytat"},
            };


        public string Text21 = "malignowy " +
                               "rzad. " +
                               "przym. " +
                               "od maligna" +
                               ": Siedział na łóżku i z krzyku, upojenia, ekstazy przeszedł w łzy i szept, i mamrot malignowy. ZEG. Zmory 401. " +
                               "To marzenie jest awanturnictwem, jest, że tak powiem, malignową sił gorączką. TRENT. Demon. 120";

        public ObservableCollection<DictionaryPasswordElement> Result21 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "malignowy", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "rzad.", Description = "rzadko używany (kwalifikator)"},
                new DictionaryPasswordElement{Word = "przym.", Description = "przymiotnik"},
                new DictionaryPasswordElement{Word = "od maligna", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Siedział na łóżku i z krzyku, upojenia, ekstazy przeszedł w łzy i szept, i mamrot malignowy. ZEG. Zmory 401.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "To marzenie jest awanturnictwem, jest, że tak powiem, malignową sił gorączką. TRENT. Demon. 120.", Description = "cytat"},
            };

        public string Text22= "kapłański " +
                              "~scy " +
                              "przym. " +
                              "od " +
                              "kapłan" +
                              ": Zażądano pozbawienia ks. Ściegiennego godności kapłańskiej. Sow. A. Ścieg. 170. " +
                              "Nie przystrojony kapłańskim ornatem, nie w twych urzędów przepychu i pysze staję, o pani, przed twym majestatem. Gosz. Lir. 89. " +
                              "// L ";

        public ObservableCollection<DictionaryPasswordElement> Result22 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "kapłański", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "~scy", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "przym.", Description = "przymiotnik"},
                new DictionaryPasswordElement{Word = "od kapłan", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Zażądano pozbawienia ks. Ściegiennego godności kapłańskiej. Sow. A. Ścieg. 170.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Nie przystrojony kapłańskim ornatem, nie w twych urzędów przepychu i pysze staję, o pani, przed twym majestatem. Gosz. Lir. 89.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
            };

        public string Text23 = "sabatowy " +
                               "przym. " +
                               "od II sabat" +
                               ": Sabatowa wieczerza. " +
                               "// SW";

        public ObservableCollection<DictionaryPasswordElement> Result23 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "sabatowy", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "przym.", Description = "przymiotnik"},
                new DictionaryPasswordElement{Word = "od II sabat", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Sabatowa wieczerza.", Description = "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny"},
                new DictionaryPasswordElement{Word = "// SW", Description = "odwołanie do Słownika warszawskiego"},
            };

        public string Text24 = "jałowcowy " +
                               "przym. " +
                               "od jałowiec" +
                               ": Iskrami trzaskały żagwie jałowcowe i dym wełnistym kłębem za wiatrem ulatał, i marszczyły się z żaru kartofle surowe. TUWIM Rzecz 7. " +
                               "Szynkę bym wędził nie na zwykłym dymie, lecz na jałowcowym, gdyż (...) dodaje osobliwego smaku. LEŚM. Przyg. 117. " +
                               "Oj, zapachniałeś dymem jałowcowymi. KONOPN. Balcer 297. " +
                               "Weźmiesz małą garstkę soli gorzkiej, trochę gencjany, tataraku, jagód jałowcowych, utrzesz to i w pysk jej [kobyłce] wpakujesz. DYGAS. Pióro 59. " +
                               "⌂ " +
                               "Kiełbasa jałowcowa " +
                               "«gatunek kiełbasy wędzonej w dymie jałowcowym»" +
                               ": Wisiały (...) jałowcowe kiełbasy, oprószone salami i lśniące, sękate kabanosy. Rus. Ziemia 17. " +
                               "// L";

        public ObservableCollection<DictionaryPasswordElement> Result24 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "jałowcowy", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "przym.", Description = "przymiotnik"},
                new DictionaryPasswordElement{Word = "od jałowiec", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Iskrami trzaskały żagwie jałowcowe i dym wełnistym kłębem za wiatrem ulatał, i marszczyły się z żaru kartofle surowe. Tuwim Rzecz 7.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Szynkę bym wędził nie na zwykłym dymie, lecz na jałowcowym, gdyż (...) dodaje osobliwego smaku. Leśm. Przyg. 117.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Oj, zapachniałeś dymem jałowcowymi. Konopn. Balcer 297.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Weźmiesz małą garstkę soli gorzkiej, trochę gencjany, tataraku, jagód jałowcowych, utrzesz to i w pysk jej [kobyłce] wpakujesz. Dygas. Pióro 59.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "⌂", Description = "znak oddzielający optycznie objaśniane związki wyrazowe"},
                new DictionaryPasswordElement{Word = "Kiełbasa jałowcowa", Description = "uszczegółowienie"},
                new DictionaryPasswordElement{Word = "«gatunek kiełbasy wędzonej w dymie jałowcowym»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Wisiały (...) jałowcowe kiełbasy, oprószone salami i lśniące, sękate kabanosy. Rus. Ziemia 17.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
            };

        public string Text25 = "II celność " +
                               "rzecz. od II celny " +
                               "«bycie celnym; to co jest celne, doskonałe»" +
                               ": W dziełach (...) rozbierają styl, myśli, wiersz, rym; wskazują wady, wskazują celność. Czart. Myśli 220. ";

        public ObservableCollection<DictionaryPasswordElement> Result25 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "II celność", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "rzecz.", Description = "rzeczownik"},
                new DictionaryPasswordElement{Word = "od II celny", Description = "odsyłanie do haseł"},
                new DictionaryPasswordElement{Word = "«bycie celnym; to co jest celne, doskonałe»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": W dziełach (...) rozbierają styl, myśli, wiersz, rym; wskazują wady, wskazują celność. Czart. Myśli 220.", Description = "cytat"},
            };

        public string Text26 = "III celny celni " +
                               "przym. " +
                               "od cło" +
                               ": Miasto objęte jest z trzech stron kordonem polskiej straży granicznej i urzędów celnych. Goj. Dzień 52. " +
                               "Rewizja celna! Wysiadać! WINAW. Znajom. 31. " +
                               "Na statku skończyła się odprawa celna i załoga schodziła już na ląd. MEIS. Sams. 21. " +
                               "Zboże, wywożone [w XV w.] przez samego szlachcica, nie podlegało opłatom celnym. BARAN. Hist. IX, 281. " +
                               "Popaliwszy budynki celne, ruszyły tłumy, aby rabować domy dzierżawców opłat miejskich. CHŁĘD.Neapol. 371. " +
                               "Prawodawstwo Rzpltej dość pilnie zajmowało się drogami, ale głównie ze względu na dochody celne, aby kupcy komor nie objeżdżali. KORZON Wewn. II, 60. " +
                               "Znane są przestare bawarskie przepisy celne dla handlu z Czechami. LEL. Polska IV, 520. " +
                               "// L";

        public ObservableCollection<DictionaryPasswordElement> Result26 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "III celny celni", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "przym.", Description = "przymiotnik"},
                new DictionaryPasswordElement{Word = "od cło", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Miasto objęte jest z trzech stron kordonem polskiej straży granicznej i urzędów celnych. Goj. Dzień 52.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Rewizja celna! Wysiadać! Winaw. Znajom. 31.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Na statku skończyła się odprawa celna i załoga schodziła już na ląd. Meis. Sams. 21.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Zboże, wywożone [w XV w.] przez samego szlachcica, nie podlegało opłatom celnym. Baran. Hist. IX, 281.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Popaliwszy budynki celne, ruszyły tłumy, aby rabować domy dzierżawców opłat miejskich. Chłęd.Neapol. 371.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Prawodawstwo Rzpltej dość pilnie zajmowało się drogami, ale głównie ze względu na dochody celne, aby kupcy komor nie objeżdżali. Korzon Wewn. II, 60.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Znane są przestare bawarskie przepisy celne dla handlu z Czechami. Lel. Polska IV, 520.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
            };

        public string Text27 = "I celność " +
                               "ż " +
                               "I " +
                               "blm " +
                               "rzecz. od I celny" +
                               ": Był to starszy już człowiek, cieszący się w szerokiej okolicy sławą Strzelca nad strzelcami. Dziwy opowiadano o pewności jego ręki, o celności oka. PIGOŃ Komb. 64. " +
                               "Najlepszą sławę zyskała sobie artyleria znakomitą celnością strzałów. KORZON Wewn. V, 93. " +
                               "W ciągnieniu kuszy nie miał sobie równego, a gdy raz wobec Batorego przy pośle tatarskim zdumiał obecnych celnością strzałów z łuku, król podarował mu dzielnego wierzchowca. SRG 443. " +
                               "Kto (...) tyle razy spudłował, sam nie ma wiary w celność swego strzału. DYGAS. Zając 72. " +
                               "◊ " +
                               "przen. " +
                               "Silną stroną utworów Tuwima jest (...) wyjątkowa celność poetyckiego wyrazu. KÓRZ. E. Lit. XI/2, 31. " +
                               "Z ogromną (...) celnością stosuje poeta rytmy o zmiennej i nieregularnej liczbie akcentów. MATUSZ. R. Lit. 56. " +
                               "Jego [Kołłątaja] świetna swada adwokacka, celność argumentów zwięzłych, a nade wszystko jasność tego umysłu pociąga i dziś jeszcze miłośników literatury prawniczej, BERENT Diog. 47. " +
                               "// SWil";

        public ObservableCollection<DictionaryPasswordElement> Result27 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "I celność", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
                new DictionaryPasswordElement{Word = "I", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "blm", Description = "bez liczby mnogiej"},
                new DictionaryPasswordElement{Word = "rzecz.", Description = "rzeczownik"},
                new DictionaryPasswordElement{Word = "od I celny", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Był to starszy już człowiek, cieszący się w szerokiej okolicy sławą Strzelca nad strzelcami. Dziwy opowiadano o pewności jego ręki, o celności oka. Pigoń Komb. 64.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Najlepszą sławę zyskała sobie artyleria znakomitą celnością strzałów. Korzon Wewn. V, 93.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "W ciągnieniu kuszy nie miał sobie równego, a gdy raz wobec Batorego przy pośle tatarskim zdumiał obecnych celnością strzałów z łuku, król podarował mu dzielnego wierzchowca. SRG 443.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Kto (...) tyle razy spudłował, sam nie ma wiary w celność swego strzału. Dygas. Zając 72.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "◊", Description = "znak używany dla wyróżnienia grup frazeologicznych, znaczeń przenośnych wyrazu i przysłów"},
                new DictionaryPasswordElement{Word = "przen.", Description = "przenośnie, przenośnia (kwalifikator)"},
                new DictionaryPasswordElement{Word = "Silną stroną utworów Tuwima jest (...) wyjątkowa celność poetyckiego wyrazu. KÓRZ. E. Lit. XI/2, 31.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Z ogromną (...) celnością stosuje poeta rytmy o zmiennej i nieregularnej liczbie akcentów. Matusz. R. Lit. 56.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Jego [Kołłątaja] świetna swada adwokacka, celność argumentów zwięzłych, a nade wszystko jasność tego umysłu pociąga i dziś jeszcze miłośników literatury prawniczej, Berent Diog. 47.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// SWil", Description = "odwołanie do Słownika wileńskiego"},
};
    }
}