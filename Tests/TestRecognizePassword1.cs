using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using NLog;
using RecognizePassword.Implement;
using RecognizePassword.Interface;
using Tests.Data;
using Xunit;
using Xunit.Abstractions;


namespace Tests
{
    public class TestRecognizePassword1
    {
        private Dictionary<string, string> _dictionary;
        private readonly ITestOutputHelper _output;
        private readonly DataTestForRecognizePassword1 _dataTest;
        private readonly IFactoryRecognizePassword _factoryRecognize = new FactoryRecognizePassword();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private void LoadDictionaryPassword()
        {
            _dictionary = File.Exists(@"D:\dane\skroty.json") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json")) : new Dictionary<string, string>(); 
        }

        public TestRecognizePassword1(ITestOutputHelper output)
        {
            _output = output;
            LoadDictionaryPassword();   
            _dataTest = new DataTestForRecognizePassword1();
        }
        [Fact]
        public void ą__typ0()        
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);

            var text = _dataTest.Text1;
            var result = _dataTest.Result1;
            
            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void aut__typ1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text2;
            var result = _dataTest.Result2;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void babusz__typ1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text3;
            var result = _dataTest.Result3;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void ichtiobiologia__typ1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text4;
            var result = _dataTest.Result4;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void łach__typ2()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text5;
            var result = _dataTest.Result5;

            var test = _factoryRecognize.Recognize(text, _dictionary);
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
        public void auspicje__typ3()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text6;
            var result = _dataTest.Result6;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void gablotka__typ1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text7;
            var result = _dataTest.Result7;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void egzystować__typ1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text8;
            var result = _dataTest.Result8;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void maligna__typ3()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text9;
            var result = _dataTest.Result9;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void gachować_się__typ1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text10;
            var result = _dataTest.Result10;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void jałowieć__typ3()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text11;
            var result = _dataTest.Result11;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void gacenie__typ4()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text12;
            var result = _dataTest.Result12;

            var test = _factoryRecognize.Recognize(text, _dictionary);
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
        public void kapnięcie__typ4()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text13;
            var result = _dataTest.Result13;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void autarcha__typ1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text14;
            var result = _dataTest.Result14;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void ex__typ4()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text15;
            var result = _dataTest.Result15;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void kapnąć__typ4()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text16;
            var result = _dataTest.Result16;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void ranga__typ4()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text17;
            var result = _dataTest.Result17;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void ęsi__typ1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text18;
            var result = _dataTest.Result18;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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
        public void ubezwładniać__typ3()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text19;
            var result = _dataTest.Result19;

            var test = _factoryRecognize.Recognize(text, _dictionary);

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