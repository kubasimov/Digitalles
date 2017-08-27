using System.Collections.ObjectModel;
using RecognizePassword.Model;

namespace Tests
{
    public class DataTestForRecognizePassword
    {
        public string Text1 = "ą" +
                              " «litera alfabetu łacińskiego z dodatkowym\r\nznakiem u dołu»" +
                              ": a)" +
                              " «odpowiada ogólnopolskiej wymawianej nosowo samogłosce o lub samo-głosce o w połączeniu ze spółgłoską nosową m albo n»" +
                              ": Trzeba stwierdzić, że nosowość końcowego ą utrzymuje się nawet potocznie nie tylko w Krakowie i Poznaniu, ale też w wiel-kopolskich, a nawet nieraz w małopolskich i mazowieckich częściach b[yłej] Kongresów¬ki\r\nki, przeważnie i w Warszawie, Jęz. Pol. 1928, s. 120." +
                              "\r\nb) " +
                              "«w naukowej transkrypcji fonetycznej ozna¬cza samogłoskę a z rezonansem nosowym»" +
                              ": W gwarach małopolskich zamiast literackiego i wielkopolskiego ę występuje, a zwłaszcza wy-stępowało w przeszłości, przeważnie ą (tj. a no-sowe, jak w wyrazach obcych kwadrans, awan-sować). Wiedza 276, s. 13.";

        public ObservableCollection<DictionaryPasswordElement> Result1 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "ą", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "«litera alfabetu łacińskiego z dodatkowym znakiem u dołu»", Description = "definiens"},
                new DictionaryPasswordElement{Word = "a)", Description = "literowy podział definicji"},
                new DictionaryPasswordElement{Word = "«odpowiada ogólnopolskiej wymawianej nosowo samogłosce o lub samogłosce o w połączeniu ze spółgłoską nosową m albo n»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Trzeba stwierdzić, że nosowość końcowego ą utrzymuje się nawet potocznie nie tylko w Krakowie i Poznaniu, ale też w wielkopolskich, a nawet nieraz w małopolskich i mazowieckich częściach b[yłej] Kongresówki, przeważnie i w Warszawie, Jęz. Pol. 1928, s. 120.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "b)", Description = "literowy podział definicji"},
                new DictionaryPasswordElement{Word = "«w naukowej transkrypcji fonetycznej oznacza samogłoskę a z rezonansem nosowym»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": W gwarach małopolskich zamiast literackiego i wielkopolskiego ę występuje, a zwłaszcza występowało w przeszłości, przeważnie ą (tj. a nosowe, jak w wyrazach obcych kwadrans, awansować). Wiedza 276, s. 13.", Description = "cytat"},
                };




        public string Text2 = "aut " +
                              "m " +
                              "IV, " +
                              "D, " +
                              "-u, " +
                              "Ms. " +
                              "aucie " +
                              "sport. " +
                              "a) " +
                              "«w tenisie, siatkówce, piłce nożnej itp. wyjście piłki poza granice boiska albo kortu»" +
                              ": [Gracz] posyła piłkę na linię, lecz sędziowie ogłaszają aut. Sport i Wcz. 45,1949. " +
                              "Aut boczny. Odbić, posłać, wybić piłkę na aut. " +
                              "b) " +
                              "«miejsce poza boiskiem w pobliżu granicy pola gry»" +
                              ": Dopóki nie usłyszysz gwizdka, nie ustawaj w grze, chociażbyś był przekonany (...) że piłka wyszła na aut. Weys. Jan Piik. 168. " +
                              "Rzut z autu. Brać piłkę z autu. Stać na aucie. " +
                              "<ang. out = zewnątrz, poza>";

        public ObservableCollection<DictionaryPasswordElement> Result2 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "aut", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
                new DictionaryPasswordElement{Word = "IV", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
                new DictionaryPasswordElement{Word = "-u", Description = "końcówka fleksyjna"},
                new DictionaryPasswordElement{Word = "Ms.", Description = "miejscownik"},
                new DictionaryPasswordElement{Word = "aucie", Description = "odmiana"},
                new DictionaryPasswordElement{Word = "sport.", Description = "sport, sportowy (kwalifikator)"},
                new DictionaryPasswordElement{Word = "a)", Description = "literowy podział definicji"},
                new DictionaryPasswordElement{Word = "«w tenisie, siatkówce, piłce nożnej itp. wyjście piłki poza granice boiska albo kortu»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": [Gracz] posyła piłkę na linię, lecz sędziowie ogłaszają aut. Sport i Wcz. 45,1949.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Aut boczny. Odbić, posłać, wybić piłkę na aut.", Description = "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny"},
                new DictionaryPasswordElement{Word = "b)", Description = "literowy podział definicji"},
                new DictionaryPasswordElement{Word = "«miejsce poza boiskiem w pobliżu granicy pola gry»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Dopóki nie usłyszysz gwizdka, nie ustawaj w grze, chociażbyś był przekonany (...) że piłka wyszła na aut. Weys. Jan Piik. 168.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Rzut z autu. Brać piłkę z autu. Stać na aucie.", Description = "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny"},
                new DictionaryPasswordElement{Word = "<ang. out = zewnątrz, poza>", Description = "wyjaśnienie etymologiczne wyrazu"}
            };

        public string Text3 = "babusz " +
                              "m " +
                              "II, " +
                              "lm " +
                              "D. " +
                              "-y " +
                              "a. " +
                              "-ów " +
                              "przestarz. " +
                              "«pantofel turecki»" +
                              ": Na wschodzie biała płeć, która jest złotą, babusz (tak się zwie czerwony pantofel) zdejmuje z pięknej nóżki... i zwycięża pantoflem... gacha lub wroga, lub męża. Słow. Ben. 263.\r\n" +
                              "<pers. papusz = obuwie>\r\n";


        public ObservableCollection<DictionaryPasswordElement> Result3 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "babusz", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
                new DictionaryPasswordElement{Word = "II", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "lm", Description = "liczba mnoga"},
                new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
                new DictionaryPasswordElement{Word = "-y", Description = "końcówka fleksyjna"},
                new DictionaryPasswordElement{Word = "a.", Description = "albo"},
                new DictionaryPasswordElement{Word = "-ów", Description = "końcówka fleksyjna"},
                new DictionaryPasswordElement{Word = "przestarz.", Description = "przestarzały (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«pantofel turecki»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Na wschodzie biała płeć, która jest złotą, babusz (tak się zwie czerwony pantofel) zdejmuje z pięknej nóżki... " +
                                                     "i zwycięża pantoflem... gacha lub wroga, lub męża. Słow. Ben. 263.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "<pers. papusz = obuwie>", Description = "wyjaśnienie etymologiczne wyrazu"},

            };

        public string Text4 ="ichtiobiologia " +
                             "ż " +
                             "I, " +
                             "DCMs. " +
                             "~gii, " +
                             "blm " +
                             "«biologia ryb»" +
                             ": W wyniku polskich badań o sielawie istnieją już obfite materiały zgromadzone w nie opublikowanych opracowaniach Zakładu Ichtiobiologii i Rybactwa SGGW. Staff F. Ryby 114. " +
                             "<gr. ichthys = ryba + biologia> "
            ;

        public ObservableCollection<DictionaryPasswordElement> Result4 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "ichtiobiologia", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
                new DictionaryPasswordElement{Word = "I", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "DCMs.", Description = "dopełniacz, celownik, miejscownik"},
                new DictionaryPasswordElement{Word = "~gii", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "blm", Description = "bez liczby mnogiej"},
                new DictionaryPasswordElement{Word = "«biologia ryb»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": W wyniku polskich badań o sielawie istnieją już obfite materiały zgromadzone w nie opublikowanych opracowaniach Zakładu Ichtiobiologii i Rybactwa SGGW. Staff F. Ryby 114.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "<gr. ichthys = ryba + biologia>", Description = "wyjaśnienie etymologiczne wyrazu"},
            };


        public string Text5 = "łach " +
                              "m " +
                              "III " +
                              "pot. " +
                              "«ubranie liche, stare, zniszczone (czasem ironicznie o każdym ubraniu); brudny, zniszczony kawałek tkaniny; łachman., szmata, gałgan»" +
                              ": Górnicy długo się myli, powoli wkładali swoje łachy, kapelusze i czapki. Szew. Kleszcze 63." +
                              " Na jednym z krzeseł leżała otwarta walizka, pełna nieporządnie porozrzucanych kolorowych łachów. Andrz. Popiół 173." +
                              " Coraz niechętniej przyjmowała pracę po domach. Wolała u siebie prać ludzkie łachy. Kłos. Wiosna 117." +
                              " Czy ja gdzieś chodzę, czy się ubieram. Mam ma to? Wstyd pokazać się w tych łachach. Wikt. Miasto 102." +
                              " Siadła na stoiku, wytarłszy go przedtem jakimś łachem. Bogusz. Kura 204." +
                              " W dużym pokoju były rzucone na podłodze różne łachy mężczyzn i kobiet, palta i buty. Nałk. Z. Medal. 74." +
                              " Sprzedam salopę. To łach. PRUS Wiecz. 65." +
                              " Stare gałgany i łachy sukienne, które dawniej wyrzucaliśmy na śmiecie, przerabiają się teraz na wełnę. Dz. Lit. Lw. 24,1857." +
                              "◊ " +
                              "fraz. " +
                              "(Brać) łachy pod pachy " +
                              "«zabierać z sobą swoje rzeczy, żeby wyjść, przenieść się gdzie»" +
                              ": Po co się z nią [teściową] cackasz? Łachy pod pachy, a ty weź dziewczynę do dziecka. Kunc. Dni 316. " +
                              "Łachy pod pachy i marsz do kwatery. PRUS  To i owo 150." +
                              "◊ " +
                              "przen. " +
                              "Z obrzydzeniem zdzierał zabrudzone łachy komedianctwa. WIKT. Miasto 4." +
                              " // L " +
                              "<możliwe pochodzenie od staro-wysoko-niemieckiego: lahhan; wg Brücknera: zgr. od łata>\r\n";



        public ObservableCollection<DictionaryPasswordElement> Result5 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "łach", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
                new DictionaryPasswordElement{Word = "III", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "pot.", Description = "potoczny (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«ubranie liche, stare, zniszczone (czasem ironicznie o każdym ubraniu); brudny, zniszczony kawałek tkaniny; łachman., szmata, gałgan»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Górnicy długo się myli, powoli wkładali swoje łachy, kapelusze i czapki. Szew. Kleszcze 63.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Na jednym z krzeseł leżała otwarta walizka, pełna nieporządnie porozrzucanych kolorowych łachów. Andrz. Popiół 173.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Coraz niechętniej przyjmowała pracę po domach. Wolała u siebie prać ludzkie łachy. Kłos. Wiosna 117.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Czy ja gdzieś chodzę, czy się ubieram. Mam ma to? Wstyd pokazać się w tych łachach. Wikt. Miasto 102.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Siadła na stoiku, wytarłszy go przedtem jakimś łachem. Bogusz. Kura 204.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "W dużym pokoju były rzucone na podłodze różne łachy mężczyzn i kobiet, palta i buty. Nałk. Z. Medal. 74.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Sprzedam salopę. To łach. Prus Wiecz. 65.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Stare gałgany i łachy sukienne, które dawniej wyrzucaliśmy na śmiecie, przerabiają się teraz na wełnę. Dz. Lit. Lw. 24,1857.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "◊", Description = "znak używany dla wyróżnienia grup frazeologicznych, znaczeń przenośnych wyrazu i przysłów"},
                new DictionaryPasswordElement{Word = "fraz.", Description = "frazeologia (kwalifikator)"},
                new DictionaryPasswordElement{Word = "(Brać) łachy pod pachy", Description = "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny"},
                new DictionaryPasswordElement{Word = "«zabierać z sobą swoje rzeczy, żeby wyjść, przenieść się gdzie»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Po co się z nią [teściową] cackasz? Łachy pod pachy, a ty weź dziewczynę do dziecka. Kunc. Dni 316.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Łachy pod pachy i marsz do kwatery. Prus  To i owo 150.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "◊", Description = "znak używany dla wyróżnienia grup frazeologicznych, znaczeń przenośnych wyrazu i przysłów"},
                new DictionaryPasswordElement{Word = "przen.", Description = "przenośnie, przenośnia (kwalifikator)"},
                new DictionaryPasswordElement{Word = "Z obrzydzeniem zdzierał zabrudzone łachy komedianctwa. Wikt. Miasto 4.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
                new DictionaryPasswordElement{Word = "<możliwe pochodzenie od staro-wysoko-niemieckiego: lahhan; wg Brücknera: zgr. od łata>", Description = "wyjaśnienie etymologiczne wyrazu"},
                };


        public string Text6 = "auspicje " +
                              "blp, " +
                              "D. " +
                              "-ów " +
                              "«w starożytnym Rzymie wróżenie, zwłaszcza z lotu ptaków; wróżba» " +
                              "◊ " +
                              "fraz. " +
                              "Pod dobrymi, złymi, pomyślnymi, fatalnymi auspicjami " +
                              "«pod dobrą itp. wróżbą»" +
                              ": Pierwsze przyjęcie w mieście i w gimnazjum odbyło się pod złymi auspicjami: z grubą awanturą. PIGOŃ Komb. 120." +
                              "⌂" +
                              "Pod czyimi auspicjami " +
                              "«pod czyją opieką, kierownictwem, zwierzchnictwem, wpływem»" +
                              ": Wy, Polacy, obejmując tu stanowiska po Niemcach, zwłaszcza pod auspicjami rządu, powinniście wprowadzać naszą kulturę! KRAH. Zdrada 257. " +
                              "Kto nie pamięta pod czyimi auspicjami rozpoczął się i prowadził ten kunktatorski sposób wojowania? LAM J. Kron.251. " +
                              "<łc. lm auspicia>";


        public ObservableCollection<DictionaryPasswordElement> Result6 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "auspicje", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "blp", Description = "bez liczby pojedynczej"},
                new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
                new DictionaryPasswordElement{Word = "-ów", Description = "końcówka fleksyjna"},
                new DictionaryPasswordElement{Word = "«w starożytnym Rzymie wróżenie, zwłaszcza z lotu ptaków; wróżba»", Description = "definiens"},
                new DictionaryPasswordElement{Word = "◊", Description = "znak używany dla wyróżnienia grup frazeologicznych, znaczeń przenośnych wyrazu i przysłów"},
                new DictionaryPasswordElement{Word = "fraz.", Description = "frazeologia (kwalifikator)"},
                new DictionaryPasswordElement{Word = "Pod dobrymi, złymi, pomyślnymi, fatalnymi auspicjami", Description = "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny"},
                new DictionaryPasswordElement{Word = "«pod dobrą itp. wróżbą»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Pierwsze przyjęcie w mieście i w gimnazjum odbyło się pod złymi auspicjami: z grubą awanturą. Pigoń Komb. 120.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "⌂", Description = "znak oddzielający optycznie objaśniane związki wyrazowe"},
                new DictionaryPasswordElement{Word = "Pod czyimi auspicjami", Description = "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny"},
                new DictionaryPasswordElement{Word = "«pod czyją opieką, kierownictwem, zwierzchnictwem, wpływem»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Wy, Polacy, obejmując tu stanowiska po Niemcach, zwłaszcza pod auspicjami rządu, powinniście wprowadzać naszą kulturę! Krah. Zdrada 257.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Kto nie pamięta pod czyimi auspicjami rozpoczął się i prowadził ten kunktatorski sposób wojowania? Lam J. Kron.251.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "<łc. lm auspicia>", Description = "wyjaśnienie etymologiczne wyrazu"}
                };

        public string Text7 = "gablotka " +
                              "ż " +
                              "III, " +
                              "lm " +
                              "D. " +
                              "~tek " +
                              "«oszklona szafka, półka albo oszklone pudło służące do wystawiania różnego rodzaju okazów, przedmiotów wartościowych, artystycznie wykonanych itp.»" +
                              ": Porcelana przetarra z kurzu, kryształy wypucowane odświętnie wypełniły szklane gablotki. PUTR. Wrzes, 197. " +
                              "Pokazuje gablotkę, w której piętrzy się gipsowy model tamy. KUREK Woda 205. " +
                              "Był to nie tyle sklep, ile raczej mała knajpa. W pierwszej izbie stała gablotka z gotowanymi jajami, salcesonem i wyschłą szynką, w tyle — półki z delikatesami. Rus. Wiatr 135. " +
                              "Robił przegląd towarów w gablotkach i szafach. Prus Lalka I, 13. " +
                              "// SW "
            ;

        public ObservableCollection<DictionaryPasswordElement> Result7 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "gablotka", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
                new DictionaryPasswordElement{Word = "III", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "lm", Description = "liczba mnoga"},
                new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
                new DictionaryPasswordElement{Word = "~tek", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "«oszklona szafka, półka albo oszklone pudło służące do wystawiania różnego rodzaju okazów, przedmiotów wartościowych, artystycznie wykonanych itp.»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Porcelana przetarra z kurzu, kryształy wypucowane odświętnie wypełniły szklane gablotki. Putr. Wrzes, 197.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Pokazuje gablotkę, w której piętrzy się gipsowy model tamy. Kurek Woda 205.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Był to nie tyle sklep, ile raczej mała knajpa. W pierwszej izbie stała gablotka z gotowanymi jajami, salcesonem i wyschłą szynką, w tyle — półki z delikatesami. Rus. Wiatr 135.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Robił przegląd towarów w gablotkach i szafach. Prus Lalka I, 13.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// SW", Description = "odwołanie do Słownika warszawskiego"},
                };

        public string Text8 = "egzystować " +
                             "ndk " +
                             "IV " +
                             "«istnieć, być, znajdować się na świecie; żyć, mieć środki do życia»" +
                             ": Wrażenia to nie substancje, które mogą egzystować samoistnie. AJD. Zagadn. 126. " +
                             "Zawsze mnie interesowało, z czego właściwie i jak Lewicki egzystuje. CHOYN. Miód. 38. " +
                             "Egzystuję — na razie. Bo jeszcze nie sprzedało się wszystkich gratów na tandecie. Ale co będzie potem? RITT. NOC. 104. " +
                             "Byliśmy w Kachariath: jest to mały kościółek bizantyjski, w którym, lubo go zmieniono na meczet, dochowały się mozaiki w przedsionkach, jedne z najpiękniejszych, jakie egzystują. SIENK. Koresp. I, 328. " +
                             "W tamtych czasach w górzystym kraju siedmiogrodzkim egzystował bogaty klasztor benedyktynów, zbudowany na skale. PRUS Wlecz. 173. " +
                             "W czasie kiedy Gucewicz katedrę na nowo z gruzów stwarzał, zamek dolny egzystował jeszcze. KRASZ. Wilno II, 195. " +
                             "Lepiej więc, że się rozstaniemy, że ja zniknę, jak gdybym nigdy nie egzystował, nigdy nie żył. SLOW. Listy 11,151. " +
                             "Za króla Łokietka, półpięta wieku egzystujące Bolesławów państwo, zdawało się, że dogorywa i gaśnie. LEL. Polska IV, 245. " +
                             "// L " +
                             "<łc. ezisto = trwam, jestem>";

        public ObservableCollection<DictionaryPasswordElement> Result8 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "egzystować", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ndk", Description = "niedokonany (aspekt)"},
                new DictionaryPasswordElement{Word = "IV", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "«istnieć, być, znajdować się na świecie; żyć, mieć środki do życia»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Wrażenia to nie substancje, które mogą egzystować samoistnie. Ajd. Zagadn. 126.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Zawsze mnie interesowało, z czego właściwie i jak Lewicki egzystuje. Choyn. Miód. 38.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Egzystuję — na razie. Bo jeszcze nie sprzedało się wszystkich gratów na tandecie. Ale co będzie potem? Ritt. Noc. 104.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Byliśmy w Kachariath: jest to mały kościółek bizantyjski, w którym, lubo go zmieniono na meczet, dochowały się mozaiki w przedsionkach, jedne z najpiękniejszych, jakie egzystują. Sienk. Koresp. I, 328.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "W tamtych czasach w górzystym kraju siedmiogrodzkim egzystował bogaty klasztor benedyktynów, zbudowany na skale. Prus Wlecz. 173.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "W czasie kiedy Gucewicz katedrę na nowo z gruzów stwarzał, zamek dolny egzystował jeszcze. Krasz. Wilno II, 195.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Lepiej więc, że się rozstaniemy, że ja zniknę, jak gdybym nigdy nie egzystował, nigdy nie żył. Slow. Listy 11,151.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Za króla Łokietka, półpięta wieku egzystujące Bolesławów państwo, zdawało się, że dogorywa i gaśnie. Lel. Polska IV, 245.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
                new DictionaryPasswordElement{Word = "<łc. ezisto = trwam, jestem>", Description = "wyjaśnienie etymologiczne wyrazu"},
                };

        public string Text9 = "maligna " +
                             "ż " +
                             "IV, " +
                             "CMs. " +
                             "~gnie, " +
                             "blm " +
                             "«nieprzytomność połączona z majaczeniem, wywołana bardzo silną gorączką»" +
                             ": Wpatrywała się do świtu w rozgorączkowaną twarz ojca, nasłuchując jego bredzeń i trzymając go za ręce, gdy chciał zrywać się z łóżka w malignie. Brand. K. Obyw. 358. " +
                             "Miała silną malignę, rzucała się na łóżku, i gadała od rzeczy. Gomul. Obraz. 93. " +
                             "Leżał w gorączce i malignie, z gnijącą w brudzie raną i zakażeniem krwi. Święt. A. T winko 145. " +
                             "Pierwszej nocy ogarnęła mię maligna: zdawało mi się widzieć przed oczyma szeroko rozlane morze i na nim dwa okręty jakby należące do mnie. Niemc. Pam. czasów 307. " +
                             "◊ " +
                             "fraz. " +
                             "Mówić, pot. gadać, daw. prawić itp. jak w malignie " +
                             "«mówić, gadać itp. bez sensu, od rzeczy»" +
                             ": Ten, jak w malignie, prawi trzy po trzy. Zabł. Zabob. 56. " +
                             "Jam to przed ludźmi prawił jako pewne dzieje, aż niejeden uczony natrząsa się, śmieje, mówiąc w oczy, że prawię dziwactwa, androny właśnie jakby w malignie. Piotr. Satyr 120. " +
                             "// L " +
                             "<łc. maligna (febris) = złośliwa (gorączka)>";

        public ObservableCollection<DictionaryPasswordElement> Result9 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "maligna", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
                new DictionaryPasswordElement{Word = "IV", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "CMs.", Description = "celownik, miejscownik"},
                new DictionaryPasswordElement{Word = "~gnie", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "blm", Description = "bez liczby mnogiej"},
                new DictionaryPasswordElement{Word = "«nieprzytomność połączona z majaczeniem, wywołana bardzo silną gorączką»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Wpatrywała się do świtu w rozgorączkowaną twarz ojca, nasłuchując jego bredzeń i trzymając go za ręce, gdy chciał zrywać się z łóżka w malignie. Brand. K. Obyw. 358.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Miała silną malignę, rzucała się na łóżku, i gadała od rzeczy. Gomul. Obraz. 93.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Leżał w gorączce i malignie, z gnijącą w brudzie raną i zakażeniem krwi. Święt. A. T winko 145.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Pierwszej nocy ogarnęła mię maligna: zdawało mi się widzieć przed oczyma szeroko rozlane morze i na nim dwa okręty jakby należące do mnie. Niemc. Pam. czasów 307.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "◊", Description = "znak używany dla wyróżnienia grup frazeologicznych, znaczeń przenośnych wyrazu i przysłów"},
                new DictionaryPasswordElement{Word = "fraz.", Description = "frazeologia (kwalifikator)"},
                new DictionaryPasswordElement{Word = "Mówić, pot. gadać, daw. prawić itp. jak w malignie", Description = "przykład/połączenie wyrazowe (kolokacja)/związek frazeologiczny"},
                new DictionaryPasswordElement{Word = "«mówić, gadać itp. bez sensu, od rzeczy»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Ten, jak w malignie, prawi trzy po trzy. Zabł. Zabob. 56.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Jam to przed ludźmi prawił jako pewne dzieje, aż niejeden uczony natrząsa się, śmieje, mówiąc w oczy, że prawię dziwactwa, androny właśnie jakby w malignie. Piotr. Satyr 120.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
                new DictionaryPasswordElement{Word = "<łc. maligna (febris) = złośliwa (gorączka)>", Description = "wyjaśnienie etymologiczne wyrazu"},
            };

        public string Text10 = "gachować się daw. «stroić się, robić z siebie eleganta» // L ";

        public ObservableCollection<DictionaryPasswordElement> Result10 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "gachować się", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "daw.", Description = "dawny, dawniej (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«stroić się, robić z siebie eleganta»", Description = "definiens"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
            };

        public string Text11 = "jałowieć " +
                             "ndk " +
                             "III " +
                             "«stawać się jałowym»" +
                             ": Marnuje się bezużytecznie, bezpłodnie ziemia (...) Ziemia, która zamiast jałowieć w chwastach i cierniach (...) mogłaby rodzić kukurydzę na smaczną polentę, pszenicę na chleb. ZAR. Ślad. 65. " +
                             "Odłogiem leżące ziemie jałowieją... POL Obrazy I, 271. " +
                             "◊ " +
                             "przen. " +
                             "Mnóstwo umysłów jałowieje ze strachu, ażeby nie paść ofiarą ludzi płytkich, którzy jutro będą karmili się chlebem, dziś przez nich samych oplutym. PRUS NOW. III, 107. " +
                             "// L ";

        public ObservableCollection<DictionaryPasswordElement> Result11 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "jałowieć", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ndk", Description = "niedokonany (aspekt)"},
                new DictionaryPasswordElement{Word = "III", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "«stawać się jałowym»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Marnuje się bezużytecznie, bezpłodnie ziemia (...) Ziemia, która zamiast jałowieć w chwastach i cierniach (...) mogłaby rodzić kukurydzę na smaczną polentę, pszenicę na chleb. Zar. Ślad. 65.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Odłogiem leżące ziemie jałowieją... Pol Obrazy I, 271.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "◊", Description = "znak używany dla wyróżnienia grup frazeologicznych, znaczeń przenośnych wyrazu i przysłów"},
                new DictionaryPasswordElement{Word = "przen.", Description="przenośnie, przenośnia (kwalifikator)"},
                new DictionaryPasswordElement{Word = "Mnóstwo umysłów jałowieje ze strachu, ażeby nie paść ofiarą ludzi płytkich, którzy jutro będą karmili się chlebem, dziś przez nich samych oplutym. Prus Now. III, 107.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
            };

        public string Text12 = "gacenie n I forma rzeczownikowa czas. gacić (p.)";

        public ObservableCollection<DictionaryPasswordElement> Result12 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "gacenie", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "n", Description = "nijaki (rodzaj)"},
                new DictionaryPasswordElement{Word = "I", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "forma rzeczownikowa czas. gacić", Description = "definiens"},
                new DictionaryPasswordElement{Word = "(p.)", Description = "patrz"},
            };

        public string Text13 = "kapnięcie n I forma rzeczownikowa czas. kapnąć (p. kapać).";

        public ObservableCollection<DictionaryPasswordElement> Result13 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement {Word = "kapnięcie", Description = "definiendum"},
                new DictionaryPasswordElement {Word = "n", Description = "nijaki (rodzaj)"},
                new DictionaryPasswordElement {Word = "I", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement {Word = "forma rzeczownikowa czas. kapnąć", Description = "definiens"},
                new DictionaryPasswordElement {Word = "(p. kapać).", Description = "patrz + bezokolicznik"},
            };


        public string Text14 = "autarcha m odm. jak ż III, lm M. -owie, D. -ów «władca nieograniczony; samowładca, despota» <p. autarchia> ";
        public ObservableCollection<DictionaryPasswordElement> Result14 =
                new ObservableCollection<DictionaryPasswordElement>
                {
                    new DictionaryPasswordElement{Word = "autarcha", Description = "definiendum"},
                    new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
                    new DictionaryPasswordElement{Word = "odm. jak ż", Description = "odmiana jak żeński (rodzaj)"},
                    new DictionaryPasswordElement{Word = "III", Description = "koniugacja/deklinacja"},
                    new DictionaryPasswordElement{Word = "lm", Description = "liczba mnoga"},
                    new DictionaryPasswordElement{Word = "M.", Description = "mianownik"},
                    new DictionaryPasswordElement{Word = "-owie", Description = "końcówka fleksyjna"},
                    new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
                    new DictionaryPasswordElement{Word = "-ów", Description = "końcówka fleksyjna"},
                    new DictionaryPasswordElement{Word = "«władca nieograniczony; samowładca, despota»", Description = "definiens"},
                    new DictionaryPasswordElement{Word = "<p. autarchia>", Description = "wyjaśnienie etymologiczne wyrazu"},
                };

        public string Text15 = "ex p. eks. // L";
        public ObservableCollection<DictionaryPasswordElement> Result15 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "ex", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "p.", Description = "patrz"},
                new DictionaryPasswordElement{Word = "eks.", Description = "definiens"},
                new DictionaryPasswordElement{Word = "// L", Description = "odwołanie do Słownika Lindego"},
            };

        public string Text16 = "kapnąć p. kapać.";
        public ObservableCollection<DictionaryPasswordElement> Result16 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "kapnąć", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "p.", Description = "patrz"},
                new DictionaryPasswordElement{Word = "kapać.", Description = "odsyłanie do haseł"},
            };


        public string Text17 = "ranga " +
                               "ż " +
                               "III " +
                               "p. " +
                               "tom VII. " +
                               "⌂ " +
                               "jęz. " +
                               "Ranga wyrazu " +
                               "«w statystyce leksykalnej: liczba porządkowa wyrazu na liście ułożonej według zmniejszającej się częstości występowania wyrazów w tekstach badanego języka»";

        public ObservableCollection<DictionaryPasswordElement> Result17 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "ranga", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
                new DictionaryPasswordElement{Word = "III", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "p.", Description = "patrz"},
                new DictionaryPasswordElement{Word = "tom VII.", Description = "odsyłanie do haseł"},
                new DictionaryPasswordElement{Word = "⌂", Description = "znak oddzielający optycznie objaśniane związki wyrazowe"},
                new DictionaryPasswordElement{Word = "jęz.", Description = "językoznawstwo (kwalifikator)"},
                new DictionaryPasswordElement{Word = "Ranga wyrazu", Description = "uszczegółowienie"},
                new DictionaryPasswordElement{Word = "«w statystyce leksykalnej: liczba porządkowa wyrazu na liście ułożonej według zmniejszającej się częstości występowania wyrazów w tekstach badanego języka»", Description = "definiens"},
            };

        public string Text18 = "ęsi " +
                               "«okrzyk dziecka zawiadamiający o potrzebie naturalnej; potrzeba naturalna (u dziecka)»" +
                               ": Kiedyś, zamkniętej, zachciało mi się strasznie „ęsi”. Co tu zrobić — matka wyniosła nocnik na płot. Witów. Ludzie 21. " +
                               "Ale kto ma liczną dziatwę, nic mu w życiu nie jest łatwe. Franio się przestraszył gęsi, a Maryjka woła ęsi. Boy Słow. 30.";

        public ObservableCollection<DictionaryPasswordElement> Result18 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "ęsi", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "«okrzyk dziecka zawiadamiający o potrzebie naturalnej; potrzeba naturalna (u dziecka)»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Kiedyś, zamkniętej, zachciało mi się strasznie „ęsi”. Co tu zrobić — matka wyniosła nocnik na płot. Witów. Ludzie 21.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Ale kto ma liczną dziatwę, nic mu w życiu nie jest łatwe. Franio się przestraszył gęsi, a Maryjka woła ęsi. Boy Słow. 30.", Description = "cytat"},
            };

        public string Text19 = "ubezwładniać " +
                               "ndk " +
                               "I, " +
                               "~any " +
                               "– ubezwładnić " +
                               "dk " +
                               "VIa, " +
                               "~nij, " +
                               "~ony " +
                               "przestarz. " +
                               "«czynić bezwładnym, paraliżować, pozbawiać siły, władzy, swobody ruchów; obezwładniać, krępować»" +
                               ": Chwytają mnie pod ramiona jak w kleszcze, ubezwładniają mnie w mig i prowadzą na odwach. WROŃ. Pam. 210. " +
                               "Piotr Wysocki, ranny i ubezwładniony zwichnięciem nogi, dostał się do niewoli. SOKOŁ. A. Dzieje III, 373. " +
                               "Trząsł się wszystek ubezwładniającym spazmem śmiechu. Lamus 8,1910, s. 453. " +
                               "Dąży do odosobnienia, ubezwładnienia albo i zagłady słabszego państwa przeciwnika. Niwa VI, 1874, s. 590. " +
                               "◊ " +
                               "przen. " +
                               "«pozbawiać możności działania, utrudniać, przeszkadzać; uniemożliwiać»" +
                               ": W pracy przeszkadzali, a nawet ją ubezwładniali bezustannym wtrącaniem się w jego twórcze zamiary. PRZYBYSZ. Współ. II, 106. " +
                               "Czyjeś oczy rzuciły nań urok ubezwładniający. GOMUL. Miecz II, 138. ";
        public ObservableCollection<DictionaryPasswordElement> Result19 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "ubezwładniać", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "ndk", Description = "niedokonany (aspekt)"},
                new DictionaryPasswordElement{Word = "I", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "~any", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "– ubezwładnić", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "dk", Description = "dokonany (aspekt)"},
                new DictionaryPasswordElement{Word = "VIa", Description = "koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "~nij", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "~ony", Description = "znak przed końcówką fleksyjną wraz z cząstką tematu"},
                new DictionaryPasswordElement{Word = "przestarz.", Description = "przestarzały (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«czynić bezwładnym, paraliżować, pozbawiać siły, władzy, swobody ruchów; obezwładniać, krępować»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Chwytają mnie pod ramiona jak w kleszcze, ubezwładniają mnie w mig i prowadzą na odwach. Wroń. Pam. 210.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Piotr Wysocki, ranny i ubezwładniony zwichnięciem nogi, dostał się do niewoli. Sokoł. A. Dzieje III, 373.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Trząsł się wszystek ubezwładniającym spazmem śmiechu. Lamus 8,1910, s. 453.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Dąży do odosobnienia, ubezwładnienia albo i zagłady słabszego państwa przeciwnika. Niwa VI, 1874, s. 590.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "◊", Description = "znak używany dla wyróżnienia grup frazeologicznych, znaczeń przenośnych wyrazu i przysłów"},
                new DictionaryPasswordElement{Word = "przen.", Description="przenośnie, przenośnia (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«pozbawiać możności działania, utrudniać, przeszkadzać; uniemożliwiać»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": W pracy przeszkadzali, a nawet ją ubezwładniali bezustannym wtrącaniem się w jego twórcze zamiary. Przybysz. Współ. II, 106.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Czyjeś oczy rzuciły nań urok ubezwładniający. Gomul. Miecz II, 138.", Description = "cytat"},
};

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
    }
}