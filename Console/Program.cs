using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using static System.String;

namespace Console
{
    class Program
    {
        public static Dictionary<string, string> dic;
        private static int max;

        static void Main(string[] args)
        {
            dic =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\dictionary.json"));

            var text1 =
                "anilana ż IV, CMs. ~anie «syntetyczne włókno produkcji krajowej»: Godne polecenia są zwłaszcza dzianiny z anilany. Jest ona bardzo lekka" +
                " i łatwo się pierze. Exp. 155, 1966. Polska anilana na warsztatach kilkunastu fabryk tekstylnych zastępuje z powodzeniem naturalną wełnę." +
                "Tryb. Ludu 216, 1965. < (?) port.anil = indygo >";

            var text2 =
                "anilanowy przym. od anilana: Włókno anilanowe będzie służyć m.in. do wyrobu sweterków, koców, szali." +
                " Exp. 151, 1965. Z anilanowej włóczki robione są swetry.Exp. 55, 1965.";

            var text3 =
                "animalistyka ż III blm szt. «przedstawianie zwierząt lub motywów zwierzęcych w sztukach plastycznych, " +
                "w fotografice»: Do mistrzostwa doprowadził sztukę fotograficzną, szczególniej w tak trudnym dziale jak animalistyka " +
                "(zdjęcia zwierząt). Probl. 1954, s. 570. <łc. animal = zwierzę>";

            var text4 =
                "animalizować ndk IV, ~owany rzad. «posługiwać się zwierzętami lub motywami zwierzęcy mi w sztukach plastycznych, " +
                "w fotografice»: Największe wzięcie miały i mają tematy „życiowe\" .Zwykłe, choć groteskowo podane przygody i zwykłe" +
                ", choć animalizowane charaktery disneyowskiej rodzinki. Kult. 28, 1965.";

            var text5 =
                "animator m IV, Ms. ~orze, lm M. ~orzy 1. p. tom I. 2. film. «specjalista w zakresie wykonywania filmów animowanych»" +
                " 3. teatr. «osoba uruchamiająca kukiełki w teatrze kukiełkowym» ";

            var text6 =
                "ankieter m IV, Ms. ~erze, lm M. ~erzy środ. «ten, kto układa ankietę, posługuje sie ankietą»: Ankieter — trudno," +
                " nieładne ale potrzebne.  Nowa nauka, nowi pracownicy o określonej specjalizacji, przeprowadzający właśnie ankiety —  " +
                "jak ich nazwać? Ten wyraz chyba zostanie w języku. Życie Warsz. 29, 1959. Przed kilkoma miesiącami przy Polskim Radio powstał" +
                " Ośrodek Badania Opinii Publicznej. Nowa placówka badawcza potrzebowała licznych pracowników w charakterze tzw. ankieterów. Prz. Kult." +
                " 26, 1958. <fr. enqućteur = ankietujący>";

            //var text11 = text1.Split(' ');
            //var text21 = text2.Split(' ');
            //var text31 = text3.Split(' ');
            //var text41 = text4.Split(' ');
            //var text51 = text5.Split(' ');
            //var text61 = text6.Split(' ');

            //var result = RecognizeText(text11);
            //var result1 = RecognizeText(text21);

            RecognizeWord(text1);
            RecognizeWord(text2);
            RecognizeWord(text3);
            RecognizeWord(text4);
            RecognizeWord(text5);
            RecognizeWord(text6);

            System.Console.ReadKey();
        }

        private static void RecognizeWord(string text1)
        {
            //pomocnicze wyświetlenie obrabianego hasła
            System.Console.WriteLine("\n\n"+text1 + "\n\n");

            var temptext = "";

            //pobranie pierwszego słowa jako hasło i zmniejszenie tekstu o te słowo + spacja
            var pass = text1.Substring(0, text1.IndexOf(" ", StringComparison.Ordinal));

            WriteText(pass, "hasło");

            text1 = text1.Remove(0, pass.Length + 1);


            //przejscie po całym zdaniu (bez pierwszego słowa

            var counter = 0;
            max = text1.Length;
            int result;

            for (counter = 0; counter < max; counter++)
            {
                //wyszukanie znaczenia słowa z podwojnych nawiasach skosnych
                if (text1[counter] == '«')
                {
                    do
                    {
                        temptext += text1[counter];
                        counter++;
                    } while (text1[counter] != '»');

                    temptext += text1[counter];
                    counter++;

                    WriteText(temptext, "definicja");
                    temptext = Empty;
                }

                //rozpoznanie początku cyctatow
                if (text1[counter] == ':')
                {
                    var isnumeric = false;

                    for (int j = counter + 2; j < text1.Length; j++)
                    {
                        //cytat kończy się gdy jest koniec linii lub gdy po cyfrze z kropka jest spacja i litera np."1996. Poczatek"
                        //dodanie kolejnego znaku do słowa
                        if (text1[j] == '<')
                        {
                            break;
                        }


                        temptext += text1[j];

                        //sprawdzenie czy znak jest liczbą, jesli prawda to flage liczby ustawiamy na true

                        if (int.TryParse(text1[j].ToString(), out result))
                        {
                            isnumeric = true;
                        }

                        //jesli była znaleziona liczba i kolejny znak to '.' i nastepny znak to spacja i znak to mamy cały cytat 954, s. 570.
                        var letter = false;

                        if (j == max || j + 1 == max || j + 2 == max)
                        {
                            letter = true;
                        }
                        else if (!int.TryParse(text1[j + 2].ToString(), out result))
                        {
                            letter = true;
                        }

                        if (isnumeric && text1[j] == '.' && letter)
                        {
                            WriteText(temptext, "cytat");
                            j++;
                            temptext = Empty;
                            isnumeric = false;
                            counter = j + 1 > max ? max - 1 : j + 1;
                        }
                    }
                }

                //rozpoznanie znaczen pomiedzy <>
                if (text1[counter] == '<')
                {
                    do
                    {
                        temptext += text1[counter];
                        counter++;
                    } while (text1[counter] != '>');

                    temptext += text1[counter];
                    //countrer++;

                    WriteText(temptext, "wyjaśnienie etymologiczne wyrazu");
                    temptext = Empty;
                }


                if (text1[counter] != ' ')
                {
                    temptext += text1[counter];
                    //jesli znaleziono przymiotnik
                    if (temptext == "przym.")
                    {
                        var meaning = RecognizeMeaningWord(temptext);
                        WriteText(temptext, meaning);
                        temptext = Empty;
                        counter += 2;

                        do
                        {
                            temptext += text1[counter];
                            counter++;
                        } while (text1[counter] != ':');
                        counter--;
                        WriteText(temptext, "Przymiotnik hasła");
                        temptext = Empty;

                        //jesli hasło ma numerowane znaczenia
                    }//jesli jest cyfra
                    //else if (int.TryParse(temptext[0].ToString(),out result)&&temptext.Length==2)
                    //{
                    //    //po cyfrze jest kropka
                    //    if (temptext[1]=='.')
                    //    {
                    //        WriteText(temptext,result+" znaczenie hasła");
                    //        temptext = Empty;
                    //    }
                    //}
                }
                else
                {
                    if (temptext != "")
                    {
                        //wyszukanie słowa w słowniku znaczeń
                        var meaning = RecognizeMeaningWord(temptext);
                        WriteText(temptext, meaning);
                        temptext = Empty;
                    }
                }
            }
        }

        private static string RecognizeMeaningWord(string text)
        {
            if (dic.ContainsKey(text))
                return dic[text];

            if (text[0] == '~')
                return "końcówka fleksyjna wraz z cząstką tematu";
            if (text[0] == '-')
                return "końcówka fleksyjna";

            if (int.TryParse(text[0].ToString(), out int result) && text.Length == 2 && text[1]=='.')
                return result + " znaczenie hasła";

            if (text.Contains("I") || text.Contains("II") || text.Contains("III") || text.Contains("IV"))
            {
                return text.TrimEnd(',','.') + " koniugacja/ deklinacja";
            }


            return Empty;
        }

        private static void WriteText(string text1, string text2 = "")
        {
            System.Console.WriteLine("Hasło: {0,-90}\t\t\tObjaśnienie: {1}", text1, text2);
        }

        //private static Dictionary<string, string> RecognizeText(string[] text)
        //{


        //    var result = new Dictionary<string, string>();

        //    result.Add("password", text[0]);


        //    for (var i = 0; i < text.Length; i++)
        //    {
        //        if(text[i].Contains("1"))


        //        if (dic.ContainsKey(text[i]))
        //        {
        //            result.Add(text[i], dic[text[i]]);
        //        }
        //        else if (text[i] == "«" || text[i].First() == '«')
        //        {
        //            var temp = "";

        //            temp += text[i];
        //            do
        //            {
        //                i++;

        //                temp += " " + text[i];
        //            } while (!text[i].Contains('»'));

        //            if (temp.Contains(':'))
        //                temp = temp.TrimEnd(':');

        //            result.Add("description", temp);
        //        }
        //        var temp1 = "";

        //        if (text[i].Contains(':'))
        //        {
        //            for (int j = i + 1; j < text.Length; j++)
        //            {
        //                temp1 += text[j] + " ";
        //                i = j;
        //            }

        //            result.Add("citation", temp1);
        //        }
        //    }
        //    return result;
        //}
    }
}