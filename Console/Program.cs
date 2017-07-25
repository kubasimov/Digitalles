using System;
using System.Collections.Generic;
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

            var text1 = "anilana ż IV, CMs. ~anie «syntetyczne włókno produkcji krajowej»: Godne polecenia są zwłaszcza dzianiny z anilany. Jest ona bardzo lekka" +
                        " i łatwo się pierze. Exp. 155, 1966. Polska anilana na warsztatach kilkunastu fabryk tekstylnych zastępuje z powodzeniem naturalną wełnę." +
                        "Tryb. Ludu 216, 1965. < (?) port.anil = indygo >";

            var text2 =
                "anilanowy przym. od anilana: Włókno anilanowe będzie służyć m.in. do wyrobu sweterków, koców, szali." +
                " Exp. 151, 1965.Z anilanowej włóczki robione są swetry.Exp. 55, 1965.";

            //koncentrak m III pot. «obóz koncentracyjny»";

            //var text3 =
            //    "koncentrator m IV, Ms. ~orze elektr.techn. «cewka indukcyjna umożliwiająca skupienie zmiennego strumienia" +
            //    " magnetycznego wielkiej częstotliwości w określonym miejscu»";

            //var text4 =
            //    "koncentratywny rzad. «polegający na koncentracji, na skupieniu się»: Polecają(...) metodę autogenicznego" +
            //    " treningu, zwanego też koncentratywmym samoodprężeniem albo pospolicie relaksem. Tryb.Ludu 239,1966.";

            //var text5 =
            //    "konceptualny 1. książk. «dotyczący koncepcji, pojęciowy»: Powieści nie lepi się z samych realiów," +
            //    " powieść trzeba zbudować, a więc wprowadzić do niej czynnik projektujący, konceptualny.Polit. 32," +
            //    " 1965. 2.filoz. «odnoszący się do konceptualizmu, związany z konceptualizmem»";

            //var text6= "konceptysta m odm.jak ż IV, CMs. ~yście, lm M. ~yści, DB. - óW lit. «przedstawiciel " +
            //           "konceptyzmu, poeta piszący kwiecistym stylem; kultysta» // SW w zn. .«konceptualista»";

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


            System.Console.ReadKey();

        }

        private static void RecognizeWord(string text1)
        {
            var temptext = "";

            //pobranie pierwszego słowa jako hasło i zmniejszenie tekstu o te słowo + spacja
            var pass = text1.Substring(0, text1.IndexOf(" ", StringComparison.Ordinal));

            WriteText(pass, "hasło");

            text1 = text1.Remove(0, pass.Length + 1);




            //przejscie po całym zdaniu (bez pierwszego słowa

            var counter = 0;
            max = text1.Length;

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

                    WriteText(temptext, "znaczenie");
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
                        int result;

                        if (int.TryParse(text1[j].ToString(), out result))
                        {
                            isnumeric = true;
                        }

                        //jesli była znaleziona liczba i kolejny znak to '.' i nastepny znak to spacja i znak to mamy cały cytat
                        var letter = false;

                        if (j == max)
                        {
                            letter = true;
                        }
                        else if (!int.TryParse(text1[counter + 2].ToString(), out result))
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

                    WriteText(temptext, "nawiasy <> ");
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
                    }
                }
                else
                {
                    //wyszukanie słowa w słowniku znaczeń
                    var meaning = RecognizeMeaningWord(temptext);
                    WriteText(temptext, meaning);
                    temptext = Empty;
                }

            }

           
        }

        private static string RecognizeMeaningWord(string text)
        {
            if (dic.ContainsKey(text))
                return dic[text];
            
            if (text[0]=='~')
                return "odmiana";
            
            return Empty;
        }

        private static void WriteText(string text1, string text2="")
        {
            System.Console.WriteLine("Hasło: {0,-90}\t\t\tObjaśnienie: {1}",text1,text2);
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

