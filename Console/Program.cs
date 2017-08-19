using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Console
{
    class Program
    {
        public static Dictionary<string, string> dic;
        private static int max;

        static void Main(string[] args)
        {
            dic =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json"));

            //var text1 =
            //    "anilana ż IV, CMs. ~anie «syntetyczne włókno produkcji krajowej»: Godne polecenia są zwłaszcza dzianiny z anilany. Jest ona bardzo lekka" +
            //    " i łatwo się pierze. Exp. 155, 1966. Polska anilana na warsztatach kilkunastu fabryk tekstylnych zastępuje z powodzeniem naturalną wełnę." +
            //    "Tryb. Ludu 216, 1965. < (?) port.anil = indygo >";
            //var text2 =
            //    "anilanowy przym. od anilana: Włókno anilanowe będzie służyć m.in. do wyrobu sweterków, koców, szali." +
            //    " Exp. 151, 1965. Z anilanowej włóczki robione są swetry.Exp. 55, 1965.";
            //var text3 =
            //    "animalistyka ż III blm szt. «przedstawianie zwierząt lub motywów zwierzęcych w sztukach plastycznych, " +
            //    "w fotografice»: Do mistrzostwa doprowadził sztukę fotograficzną, szczególniej w tak trudnym dziale jak animalistyka " +
            //    "(zdjęcia zwierząt). Probl. 1954, s. 570. <łc. animal = zwierzę>";
            //var text4 =
            //    "animalizować ndk IV, ~owany rzad. «posługiwać się zwierzętami lub motywami zwierzęcy mi w sztukach plastycznych, " +
            //    "w fotografice»: Największe wzięcie miały i mają tematy „życiowe\" .Zwykłe, choć groteskowo podane przygody i zwykłe" +
            //    ", choć animalizowane charaktery disneyowskiej rodzinki. Kult. 28, 1965.";
            //var text5 =
            //    "animator m IV, Ms. ~orze, lm M. ~orzy 1. p. tom I. 2. film. «specjalista w zakresie wykonywania filmów animowanych»" +
            //    " 3. teatr. «osoba uruchamiająca kukiełki w teatrze kukiełkowym» ";
            //var text6 =
            //    "ankieter m IV, Ms. ~erze, lm M. ~erzy środ. «ten, kto układa ankietę, posługuje sie ankietą»: Ankieter — trudno," +
            //    " nieładne ale potrzebne.  Nowa nauka, nowi pracownicy o określonej specjalizacji, przeprowadzający właśnie ankiety —  " +
            //    "jak ich nazwać? Ten wyraz chyba zostanie w języku. Życie Warsz. 29, 1959. Przed kilkoma miesiącami przy Polskim Radio powstał" +
            //    " Ośrodek Badania Opinii Publicznej. Nowa placówka badawcza potrzebowała licznych pracowników w charakterze tzw. ankieterów. Prz. Kult." +
            //    " 26, 1958. <fr. enqućteur = ankietujący>";
            //var text7 =
            //    "ankietka ż III, lm D. ~tek zdr. od ankieta, tom I: Powiada dalej o wynikach ankietki, jaką miał przeprowadzić wśród uczestników turnusu. Życie Warsz. 211, 1965.";
            //var text8 =
            //    "ankietomania ż I, DCMs. ~nii, lm D. ~nii a. ~nij rząd. «mania stosowania ankiet, posługiwania się ankietami»: Trafność tych stwierdzeń oczywiście należy brać z pewną dozą sceptycyzmu i ostrożności, jak wszystko, co opiera się na statystyce i tak rozpowszechnionej dziś ankietomanii. Życie Warsz. 170, 1960.";
            //var text9 =
            //    "ankietować ndk IV, ~owany środ. «przeprowadzać badania za pomocą ankiety, ankiet, pytać za pomocą ankiety»: Większość ankietowanych krajów opowiedziała się, jak wynika z raportu, właśnie za tym ostatnim typem mieszkań. Zycie Warsz. 218, 1965.";
            //var text10 = "bajończyk m III hist. «członek Legionu Bajońskiego, tj. polskiego ochotniczego oddziału wojskowego utworzonego w 1914 r. we Francji»: Złożyła ona [delegacja polska] wieniec pod pomnikiem słynnego korpusu bajończyków, zdziesiątkowanego podczas pierwszej wojny światowej. Zycie Warsz. 112, 1965.\r\n<Bayonne, nazwa miejscowości we Francji, gdzie powstał ten legion>";
            //var text11 = "bajzel m I, D.~zlu wulg. «dom publiczny; burdel»: Nim wróciłem, dziewucha skurwiła się, skończyła w bajzlu w pobliskim mieście. Pauk. Po burzy 339.\r\n<Nm, Beisel, z hebr. = knajpa>";
            //var text12 =
            //    "bakteroid m IV, D. -u, Ms. ~dzie biol. zwykle w lm «rozwojowa postać bakterii brodawkowych współżyjących z roślinami motylkowymi»\r\n<n.-łc. bacterium + gr, eidos = postać>\r\n";
            //var text13 =
            //    "baktrian m IV, Ms. ~anie zool. «Camelus bactrianus, wielbłąd dwugarbny; przeżuwacz z rodziny wielbłądów (Camelidae), pokryty długą wełnistą sierścią, żyjący dziś w stanie dzikim jedynie w Azji Środkowej; hodowany powszechnie w Azji jako wytrzymałe zwierzę juczne, dostarcza też wełny do wyrobu tkanin»";
            //var text14 =
            //    "balansjerka ż III, lm D. ~rek men. «przyrząd do bicia monet wynaleziony w XVI w., a używany do 1830 r.»: Król [St. August] (...) lubił osobiście wybić parę dukatów (ze swym popiersiem) na pięknie zdobionej, włoskiej prasie — balansjerce. Exp. 252,1965. <fr. balancier>";
            //var text15 =
            //    "balistokardiografia i I, DCMs, blm med. «metoda badania układu krążenia, polegająca na rejestracji drgań ciała wywołanych mechaniczną pracą serca»: Balistokardiografia może służyć jako kontrola wyników pooperacyjnych. Pol. Tyg. Lek. 25,1953, s. dod. 194.";
            //var text16 =
            //    "banian m IV, D. -u a. -a bot. «Ficus bengalensis, drzewo z rodziny morwowatych (Moraceae) rosnące dziko w górach tropikalnej Afryki i u podnóży Himalajów; dostarcza owoców jadalnych i garbników; z drewna otrzymuje się szelak; figowiec indyjski»: Drzewo sandałowe, twarde drzewo tekowe, banian z korzeniami powietrznymi (...) są charakterystyczne dla obszaru indyjskiego. Lewiń. J. Życie 227. // SWil w zn. «tłumacz i makler w Indiach»";
            //var text17 =
            //    "przeciwprzykład m IV, D. -u, Ms. ~adzie mat. «przedmiot matematyczny, mający wszyst- kie właściwości wypowiedziane w założeniu, nie mający natomiast właściwości wypowiedzianych w twierdzeniu, będący oczywistym dowodem na to, że twierdzenie jest fałszywe»: Czasem natu- ra zagadnienia nasuwa przypuszczenie, że teore- mat, który mamy udowodnić, jest błędny. Wtedy szukamy tzw. „przeciwprzykładu”, czyli kon- struujemy twór matematyczny spełniający za- łożenie, a nie spełniający twierdzenia. STEIN. Mat. 88. ";

            //RecognizeWord(text1);
            //RecognizeWord(text2);
            //RecognizeWord(text3);
            //RecognizeWord(text4);
            //RecognizeWord(text5);
            //RecognizeWord(text6);
            //RecognizeWord(text7);
            //RecognizeWord(text8);
            //RecognizeWord(text9);
            //RecognizeWord(text10);
            //RecognizeWord(text11);
            //RecognizeWord(text12);
            ////RecognizeWord(text13);
            //RecognizeWord(text14);
            //RecognizeWord(text15);
            //RecognizeWord(text16);
            //RecognizeWord(text17);


           




            System.Console.ReadKey();
        }

        
    }
}