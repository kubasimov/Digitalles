using Core;
using System.IO;
using Core.Decode;
using Core.Model;
using Xunit;

namespace Tests
{
    public class TestsCore
    {
        readonly string _image;
        readonly Start _start = new Start();

        public TestsCore()
        {
            const string fileName = @"F:/3.jpg";

            var filename = Path.Combine(Path.GetDirectoryName(fileName), Path.GetFileName(fileName));

            _image=filename;

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
    }
}
