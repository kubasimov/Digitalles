using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Core;
using System.IO;
using System.Linq;
using Core.Decode;
using Core.Interface;
using Core.Model;
using Moq;
using Newtonsoft.Json;
using Tesseract;
using WPF.Helpers;
using WPF.Model;
using Xunit;

namespace Tests
{
    public class TestsCore
    {
        readonly string _image;
        readonly Start _start = new Start();

        private Dictionary<string, string> _dictionary;
       
        public TestsCore()
        {
            const string fileName = @"F:/3.jpg";

            var filename = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileName(fileName));

            _image=filename;

            LoadDictionaryPassword();
            
        }


        private void LoadDictionaryPassword()
        {
            if (File.Exists(@"D:\dane\skroty.json"))
            {
                _dictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json"));
                
            }
            else
            {
                _dictionary = new Dictionary<string, string>();
                
            }
        }

        
        [Fact]
        public void ReadFileFromStringName()
        {
            var test = _start.ReadFile(_image);

            Assert.True(test);
        }

        [Fact]
        public void ReadFileFormStringNameAndCorrectOcrProcess()
        {
            _start.ReadFile(_image);
            var text = _start.Ocr();

            Assert.NotNull(text);
        }

        [Fact]
        public void ReadTextFromFirstReadFile()
        {
            _start.ReadFile(_image);
            var text = _start.Ocr();

            var page = new DecodeHocr().Decode(text);
            Assert.NotNull(page);
        }



        

     
        [Fact]
        public void ReadImageToPix()
        {
            Mock<IReadPicture> mock = new Mock<IReadPicture>();
            mock.Setup(m => m.ReadImageFromFile("Test")).Returns(Pix.Create(200, 200, 32));

            Ocr ocr = new Ocr(mock.Object);
            var test = ocr.ReadFile("Test");

            Assert.True(test);
            
        }


        private readonly string _text = "animalistyka ż III blm szt. " +
                              "«przedstawianie zwierząt lub motywów zwierzęcych w sztukach plastycznych, " +
                                        "w fotografice»: Do mistrzostwa doprowadził sztukę fotograficzną," +
                                        " szczególniej w tak trudnym dziale jak animalistyka (zdjęcia" +
                                        " zwierząt). Probl. 1954, s. 570. <łc. animal = zwierzę>";

        private readonly ObservableCollection<DictionaryPasswordElement> _result =
            new ObservableCollection<DictionaryPasswordElement>
            {
                new DictionaryPasswordElement {Word = "animalistyka", Description = "hasło"},
                new DictionaryPasswordElement{Word = "ż", Description = "żeński (rodzaj)"},
                new DictionaryPasswordElement{Word = "III", Description = "III koniugacja/deklinacja"},
                new DictionaryPasswordElement{Word = "blm", Description = "bez liczby mnogiej"},
                new DictionaryPasswordElement{Word = "szt.", Description = "bez liczby mnogiej"},
                new DictionaryPasswordElement{Word = "«przedstawianie zwierząt lub motywów zwierzęcych w " +
                                                     "sztukach plastycznych, w fotografice»",
                    Description = "definicja"},
                new DictionaryPasswordElement{Word = "Do mistrzostwa doprowadził sztukę fotograficzną," +
                                                     " szczególniej w tak trudnym dziale jak animalistyka" +
                                                     " (zdjęcia zwierząt). Probl. 1954, s. 570.", Description = "cytat"},
                new DictionaryPasswordElement{Word = "<łc. animal = zwierzę>",
                    Description = "wyjaśnienie etymologiczne wyrazu"},
            };
        
        [Fact]
        public void AnalizeRecognizePasswordText()
        {
            var test = RecognizePasswordText.Recognize(_text, _dictionary);

            Assert.Equal(_result,test);
        }

    }
}
