using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RecognizePassword.Implement;
using RecognizePassword.Interface;
using Xunit;
using Xunit.Abstractions;


namespace Tests
{
    public class TestRecognizePassword
    {
        private Dictionary<string, string> _dictionary;
        private readonly ITestOutputHelper _output;
        private readonly DataTestForRecognizePassword _dataTest;

        private IRecognizePasswordText _recognize;
        private void LoadDictionaryPassword()
        {
            _dictionary = File.Exists(@"D:\dane\skroty.json") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json")) : new Dictionary<string, string>();
        }

        public TestRecognizePassword(ITestOutputHelper output)
        {
            _output = output;
            LoadDictionaryPassword();
            _dataTest = new DataTestForRecognizePassword();
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
            _recognize = new RecognizePasswordTextType1();

            var text = _dataTest.Text3;
            var result = _dataTest.Result3;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word, test[i].Word);
                Assert.Equal(result[i].Description, test[i].Description);
            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText4()
        {
            _recognize = new RecognizePasswordTextType1();

            var text = _dataTest.Text4;
            var result = _dataTest.Result4;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word, test[i].Word);
                Assert.Equal(result[i].Description, test[i].Description);
            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText5()
        {
            _recognize = new RecognizePasswordTextType2();
            var text = _dataTest.Text5;
            var result = _dataTest.Result5;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word+"\t"+ result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());
                
            }

            Assert.Equal(result.Count,test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText6()
        {
            _recognize = new RecognizePasswordTextType3();
            var text = _dataTest.Text6;
            var result = _dataTest.Result6;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText7()
        {
            _recognize = new RecognizePasswordTextType1();
            var text = _dataTest.Text7;
            var result = _dataTest.Result7;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText8()
        {
            _recognize = new RecognizePasswordTextType1();
            var text = _dataTest.Text8;
            var result = _dataTest.Result8;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText9()
        {
            _recognize = new RecognizePasswordTextType3();
            var text = _dataTest.Text9;
            var result = _dataTest.Result9;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText10()
        {
            _recognize = new RecognizePasswordTextType1();
            var text = _dataTest.Text10;
            var result = _dataTest.Result10;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText11()
        {
            _recognize = new RecognizePasswordTextType3();
            var text = _dataTest.Text11;
            var result = _dataTest.Result11;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText12()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text12;
            var result = _dataTest.Result12;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText13()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text13;
            var result = _dataTest.Result13;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText14()
        {
            _recognize = new RecognizePasswordTextType1();
            var text = _dataTest.Text14;
            var result = _dataTest.Result14;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText15()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text15;
            var result = _dataTest.Result15;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText16()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text16;
            var result = _dataTest.Result16;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        //[Fact]
        //public void AnalizeRecognizePasswordText17()
        //{
        //    _recognize = new RecognizePasswordTextType4();
        //    var text = _dataTest.Text17;
        //    var result = _dataTest.Result17;

        //    var test = _recognize.Recognize(text, _dictionary);

        //    for (var i = 0; i < test.Count; i++)
        //    {
        //        _output.WriteLine(result[i].Word + "\t" + result[i].Description);
        //        _output.WriteLine(test[i].Word + "\t" + test[i].Description);
        //        Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
        //        Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

        //    }

        //    Assert.Equal(result.Count, test.Count);
        //}

        [Fact]
        public void AnalizeRecognizePasswordText18()
        {
            _recognize = new RecognizePasswordTextType1();
            var text = _dataTest.Text18;
            var result = _dataTest.Result18;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText19()
        {
            _recognize = new RecognizePasswordTextType3();
            var text = _dataTest.Text19;
            var result = _dataTest.Result19;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText20()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text20;
            var result = _dataTest.Result20;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }

        [Fact]
        public void AnalizeRecognizePasswordText21()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text21;
            var result = _dataTest.Result21;

            var test = _recognize.Recognize(text, _dictionary);

            for (var i = 0; i < test.Count; i++)
            {
                _output.WriteLine(result[i].Word + "\t" + result[i].Description);
                _output.WriteLine(test[i].Word + "\t" + test[i].Description);
                Assert.Equal(result[i].Word.ToLower(), test[i].Word.ToLower());
                Assert.Equal(result[i].Description.ToLower(), test[i].Description.ToLower());

            }

            Assert.Equal(result.Count, test.Count);
        }
    }
}