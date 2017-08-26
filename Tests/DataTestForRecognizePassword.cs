using System.Collections.ObjectModel;
using WPF.Model;

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
                new DictionaryPasswordElement{Word = "II", Description = "II koniugacja/deklinacja"},
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
                new DictionaryPasswordElement{Word = "I", Description = "I koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "DCMs.", Description = "dopełniacz, celownik, miejscownik"},
                new DictionaryPasswordElement{Word = "~gii", Description = "~ znak przed końcówką fleksyjną wraz z cząstką tematu"},
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
                              "<możliwe pochodzenie od staro-wysoko-niemieckiego: lahhan; wg Brücknera: z gr. od łata>\r\n";



        public ObservableCollection<DictionaryPasswordElement> Result5 =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement{Word = "łach", Description = "definiendum"},
                new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
                new DictionaryPasswordElement{Word = "III", Description = "III koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "pot.", Description = "potoczny (kwalifikator)"},
                new DictionaryPasswordElement{Word = "«ubranie liche, stare, zniszczone (czasem ironicznie o każdym ubraniu); brudny, zniszczony kawałek tkaniny; łachman., szmata, gałgan»", Description = "definiens"},
                new DictionaryPasswordElement{Word = ": Górnicy długo się myli, powoli wkładali swoje łachy, kapelusze i czapki. Szew. Kleszcze 63.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Na jednym z krzeseł leżała otwarta walizka, pełna nieporządnie porozrzucanych kolorowych łachów. Andrz. Popiół 173.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Coraz niechętniej przyjmowała pracę po domach. Wolała u siebie prać ludzkie łachy. Kłos. Wiosna 117.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Czy ja gdzieś chodzę, czy się ubieram. Mam ma to? Wstyd pokazać się w tych łachach. Wikt. Miasto 102.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "Siadła na stoiku, wytarłszy go (przedtem jakimś łachem. Bogusz. Kura 204.", Description = "cytat"},
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
    
    }
}