using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using WPF.Helpers;
using WPF.Model;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

[assembly: CollectionBehavior(DisableTestParallelization = true)]
namespace Tests
{
    public class TestRecognizePassword
    {
        private Dictionary<string, string> _dictionary;
        private readonly ITestOutputHelper output;
        private DataTestForRecognizePassword dataTest;
        private void LoadDictionaryPassword()
        {
            _dictionary = File.Exists(@"D:\dane\skroty.json") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json")) : new Dictionary<string, string>();
        }

        public TestRecognizePassword(ITestOutputHelper output)
        {
            this.output = output;
            LoadDictionaryPassword();
            dataTest = new DataTestForRecognizePassword();
        }

        //string _text1 = "animalistyka ż III blm szt. " +
        //                                "«przedstawianie zwierząt lub motywów zwierzęcych w sztukach plastycznych, " +
        //                                "w fotografice»: Do mistrzostwa doprowadził sztukę fotograficzną," +
        //                                " szczególniej w tak trudnym dziale jak animalistyka (zdjęcia" +
        //                                " zwierząt). Probl. 1954, s. 570. <łc. animal = zwierzę>";

        //private ObservableCollection<DictionaryPasswordElement> _result1 =
        //    new ObservableCollection<DictionaryPasswordElement>
        //    {
        //        new DictionaryPasswordElement {Word = "animalistyka", Description = "hasło"},
        //        new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
        //        new DictionaryPasswordElement{Word = "III", Description = "III koniugacja/deklinacja"},
        //        new DictionaryPasswordElement{Word = "blm", Description = "bez liczby mnogiej"},
        //        new DictionaryPasswordElement{Word = "szt.", Description = "bez liczby mnogiej"},
        //        new DictionaryPasswordElement{Word = "«przedstawianie zwierząt lub motywów zwierzęcych w " +
        //                                             "sztukach plastycznych, w fotografice»",
        //            Description = "definicja"},
        //        new DictionaryPasswordElement{Word = "Do mistrzostwa doprowadził sztukę fotograficzną," +
        //                                             " szczególniej w tak trudnym dziale jak animalistyka" +
        //                                             " (zdjęcia zwierząt). Probl. 1954, s. 570.", Description = "cytat"},
        //        new DictionaryPasswordElement{Word = "<łc. animal = zwierzę>",
        //            Description = "wyjaśnienie etymologiczne wyrazu"},
        //    };

        //private string _text2 = "babusz m II, lm D. -y a. -ów przestarz. «pantofel turecki»: Na wschodzie biała płeć," +
        //                                 " która jest złotą, babusz (tak się zwie czerwony pantofel) zdejmuje z pięknej nóżki..." +
        //                                 " i zwycięża pantoflem... gacha lub wroga, lub męża. Słow. Ben. 263.\r\n<pers. papusz = obuwie>\r\n";

        //private ObservableCollection<DictionaryPasswordElement> _result2 =
        //    new ObservableCollection<DictionaryPasswordElement>
        //    {
        //        new DictionaryPasswordElement{Word = "babusz", Description = "definiendum"},
        //        new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
        //        new DictionaryPasswordElement{Word = "II", Description = "II koniugacja/deklinacja"},
        //        new DictionaryPasswordElement{Word = "lm", Description = "liczba mnoga"},
        //        new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
        //        new DictionaryPasswordElement{Word = "-y", Description = "końcówka fleksyjna"},
        //        new DictionaryPasswordElement{Word = "a.", Description = "albo"},
        //        new DictionaryPasswordElement{Word = "-ów", Description = "końcówka fleksyjna"},
        //        new DictionaryPasswordElement{Word = "przestarz.", Description = "przestarzały (kwalifikator)"},
        //        new DictionaryPasswordElement{Word = "«pantofel turecki»", Description = "definiens"},
        //        new DictionaryPasswordElement{Word = ": Na wschodzie biała płeć, która jest złotą, babusz (tak się zwie czerwony pantofel) zdejmuje z pięknej nóżki... " +
        //                                             "i zwycięża pantoflem... gacha lub wroga, lub męża. Słow. Ben. 263.", Description = "cytat"},
        //        new DictionaryPasswordElement{Word = "<pers. papusz = obuwie>", Description = "wyjaśnienie etymologiczne wyrazu"},

        //    };

        //private string _text3 = "celofan m IV, D. -u, Ms. ~anie, blm «masa plastyczna otrzymywana z celulozy, służąca do wyrobu nie tłukących się błon (szyb)," +
        //                                 " okładek do legitymacji, sztucznych kwiatów, papieru szklistego, przezroczystego itp.; same te wyroby»: W celu zabezpieczenia" +
        //                                 " przed wysychaniem taśma powinna być opakowana w papier przetłuszczony, ‘celofan lub cynfolię i zamknięta w pudełku metalowym" +
        //                                 " lub bakelitowym. Kołak. Towarozn. 123. Arkusz celofanu.\r\nQ przen. Ważka, o skrzydłach z niebieskiego celofanu. BREZA Niebo II," +
        //                                 " 209.\r\n<nm. Zellophan, od nazwy celulozy + gr. phänós = jasny, przejrzysty>\r\n";

        //private ObservableCollection<DictionaryPasswordElement> _result3 =
        //    new ObservableCollection<DictionaryPasswordElement>
        //    {
        //        new DictionaryPasswordElement{Word = "celofan", Description = "definiendum"},
        //        new DictionaryPasswordElement{Word = "m", Description = "męski (rodzaj)"},
        //        new DictionaryPasswordElement{Word = "IV", Description = "IV koniugacja/deklinacja"},
        //        new DictionaryPasswordElement{Word = "D.", Description = "dopełniacz"},
        //        new DictionaryPasswordElement{Word = "-u", Description = "końcówka fleksyjna"},
        //        new DictionaryPasswordElement{Word = "Ms.", Description = "miejscownik"},
        //        new DictionaryPasswordElement{Word = "~anie", Description = "~ znak przed końcówką fleksyjną wraz z cząstką tematu"},
        //        new DictionaryPasswordElement{Word = "blm", Description = "bez liczby mnogiej"},
        //        new DictionaryPasswordElement{Word = "«masa plastyczna otrzymywana z celulozy, służąca do wyrobu nie tłukących się błon (szyb), okładek do legitymacji, " +
        //                                             "sztucznych kwiatów, papieru szklistego, przezroczystego itp.; same te wyroby»", Description = "definiens"},
        //        new DictionaryPasswordElement{Word = ": W celu zabezpieczenia przed wysychaniem taśma powinna być opakowana w papier przetłuszczony, " +
        //                                             "‘celofan lub cynfolię i zamknięta w pudełku metalowym lub bakelitowym. Kołak. Towarozn. 123.", Description = "cytat"},
        //        new DictionaryPasswordElement{Word = "Arkusz celofanu.", Description = "przykład/połączenie wyrazowe (kolokacja)"},
        //        new DictionaryPasswordElement{Word = "?", Description = "znak używany dla wyróżnienia grup frazeologicznych, znaczeń przenośnych wyrazu i przysłów"},
        //        new DictionaryPasswordElement{Word = "przen.", Description = "przenośnie, przenośnia (kwalifikator)"},
        //        new DictionaryPasswordElement{Word = "Ważka, o skrzydłach z niebieskiego celofanu. Breza Niebo II, 209.", Description = "cytat"},
        //        new DictionaryPasswordElement{Word = "<nm. Zellophan, od nazwy celulozy + gr. phänós = jasny, przejrzysty>", Description = "wyjaśnienie etymologiczne wyrazu"},


        //    };




       
        [Fact]
        public void AnalizeRecognizePasswordText3()
        {
            var text = dataTest.Text3;
            var result = dataTest.Result3;

            var test = new RecognizePasswordText().Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                Assert.Equal(result[i].Word, test[i].Word);
                Assert.Equal(result[i].Description, test[i].Description);
            }
        }

        [Fact]
        public void AnalizeRecognizePasswordText4()
        {
            var text = dataTest.Text4;
            var result = dataTest.Result4;

            var test = new RecognizePasswordText().Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                Assert.Equal(result[i].Word, test[i].Word);
                Assert.Equal(result[i].Description, test[i].Description);
            }
        }

        [Fact]
        public void AnalizeRecognizePasswordText5()
        {
            var text = dataTest.Text5;
            var result = dataTest.Result5;

            var test = new RecognizePasswordText().Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                Assert.Equal(result[i].Word, test[i].Word);
                Assert.Equal(result[i].Description, test[i].Description);
            }
        }
    }
}