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
    public class TestRecognizePassword3
    {
        private readonly DataTestForRecognizePassword3 _dataTest;
        private readonly ITestOutputHelper _output;
        private Dictionary<string, string> _dictionary;
        private readonly IFactoryRecognizePassword _factoryRecognize = new FactoryRecognizePassword();
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public TestRecognizePassword3(ITestOutputHelper output)
        {
            _output = output;
            LoadDictionaryPassword();
            _dataTest = new DataTestForRecognizePassword3();
        }

        [Fact]
        public void babstwo__typ6()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name); var text = _dataTest.Text30;
            var result = _dataTest.Result30;

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
        public void pachwina__typ6()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name); var text = _dataTest.Text31;
            var result = _dataTest.Result31;

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
        public void babusin__1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text32;
            var result = _dataTest.Result32;

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
        public void celofan__1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text33;
            var result = _dataTest.Result33;

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
        public void ewoluować__1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text34;
            var result = _dataTest.Result34;

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
        public void fagas__1()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text35;
            var result = _dataTest.Result35;

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
        public void fagocista__0()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);
            var text = _dataTest.Text36;
            var result = _dataTest.Result36;

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
        public void haftarnia()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);

            var text = _dataTest.Text37;
            var result = _dataTest.Result37;

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
        public void kapłanka()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);

            var text = _dataTest.Text38;
            var result = _dataTest.Result38;

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
        public void lakierniczy()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);

            var text = _dataTest.Text39;
            var result = _dataTest.Result39;

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
        public void naciąganie()
        {
            Logger.Log(LogLevel.Debug, MethodBase.GetCurrentMethod().Name);

            var text = _dataTest.Text40;
            var result = _dataTest.Result40;

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
        private void LoadDictionaryPassword()
        {
            _dictionary = File.Exists(@"D:\dane\skroty.json")
                ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json"))
                : new Dictionary<string, string>();
        }
    }
}