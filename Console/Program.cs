using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {

            //var text1 =
            //    "koncentracyjny p.tom III. □ górn. Stół koncentracyjny «urządzenie do wzbogacania drobnych ziarn urobku; nachylona płyta nieruchoma, " +
            //    "drgająca lub obracająca się, po której wraz z wodą spływa urobek (dzieląc się na ziarna użyteczne i płonne)»";

            //var text2 = "koncentrak m III pot. «obóz koncentracyjny»";

            //var text3 =
            //    "koncentrator m IV, Ms. ~orze elektr.techn. «cewka indukcyjna umożliwiająca skupienie zmiennego strumienia" +
            //    " magnetycznego wielkiej częstotliwości w określonym miejscu»";

            var text4 =
                "koncentratywny rzad. «polegający na koncentracji, na skupieniu się»: Polecają(...) metodę autogenicznego" +
                " treningu, zwanego też koncentratywmym samoodprężeniem albo pospolicie relaksem. Tryb.Ludu 239,1966.";

            //var text5 =
            //    "konceptualny 1.książk. «dotyczący koncepcji, pojęciowy»: Powieści nie lepi się z samych realiów," +
            //    " powieść trzeba zbudować, a więc wprowadzić do niej czynnik projektujący, konceptualny.Polit. 32," +
            //    " 1965. 2.filoz. «odnoszący się do konceptualizmu, związany z konceptualizmem»";

            //var text6= "konceptysta m odm.jak ż IV, CMs. ~yście, lm M. ~yści, DB. - óW lit. «przedstawiciel " +
            //           "konceptyzmu, poeta piszący kwiecistym stylem; kultysta» // SW w zn. .«konceptualista»";

            //var text11 = text1.Split(' ');
            //var text21 = text2.Split(' ');
            //var text31 = text3.Split(' ');
            var text41 = text4.Split(' ');
            //var text51 = text5.Split(' ');
            //var text61 = text6.Split(' ');

            var dic =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\dictionary.json"));

            var result = new Dictionary<string, string>();

            for (var i = 0; i < text41.Length; i++)
            {
                if (dic.ContainsKey(text41[i]))
                {
                    result.Add(text41[i], dic[text41[i]]);

                }
                else if (text41[i] == "«" || text41[i].First() == '«')
                {
                    var temp = "";

                    temp += text41[i];
                    do
                    {
                        i++;

                        temp += " " + text41[i];


                    } while (!text41[i].Contains('»'));

                    if (temp.Contains(':'))
                        temp = temp.TrimEnd(':');

                    result.Add(temp, "");

                }
            }

        }
    }
}

