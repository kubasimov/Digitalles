using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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
        private IRecognizePasswordText _recognize;

        public TestRecognizePassword3(ITestOutputHelper output)
        {
            _output = output;
            LoadDictionaryPassword();
            _dataTest = new DataTestForRecognizePassword3();
        }

        [Fact]
        public void AnalizeRecognizePasswordText30()
        {
            _recognize = new RecognizePasswordTextType6();

            var text = _dataTest.Text30;
            var result = _dataTest.Result30;

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
        public void AnalizeRecognizePasswordText31()
        {
            _recognize = new RecognizePasswordTextType6();

            var text = _dataTest.Text31;
            var result = _dataTest.Result31;

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

        private void LoadDictionaryPassword()
        {
            _dictionary = File.Exists(@"D:\dane\skroty.json")
                ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json"))
                : new Dictionary<string, string>();
        }
    }
}