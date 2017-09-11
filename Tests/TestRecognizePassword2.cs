using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using RecognizePassword.Implement;
using RecognizePassword.Interface;
using Xunit;
using Xunit.Abstractions;


namespace Tests
{
    public class TestRecognizePassword2
    {
        private Dictionary<string, string> _dictionary;
        private readonly ITestOutputHelper _output;
        private readonly DataTestForRecognizePassword2 _dataTest;

        private IRecognizePasswordText _recognize;
        private void LoadDictionaryPassword()
        {
            _dictionary = File.Exists(@"D:\dane\skroty.json") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json")) : new Dictionary<string, string>();
        }

        public TestRecognizePassword2(ITestOutputHelper output)
        {
            _output = output;
            LoadDictionaryPassword();
            _dataTest = new DataTestForRecognizePassword2();
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

        [Fact]
        public void AnalizeRecognizePasswordText22()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text22;
            var result = _dataTest.Result22;

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
        public void AnalizeRecognizePasswordText23()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text23;
            var result = _dataTest.Result23;

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
        public void AnalizeRecognizePasswordText24()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text24;
            var result = _dataTest.Result24;

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
        public void AnalizeRecognizePasswordText25()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text25;
            var result = _dataTest.Result25;

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
        public void AnalizeRecognizePasswordText26()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text26;
            var result = _dataTest.Result26;

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
        public void AnalizeRecognizePasswordText27()
        {
            _recognize = new RecognizePasswordTextType4();
            var text = _dataTest.Text27;
            var result = _dataTest.Result27;

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