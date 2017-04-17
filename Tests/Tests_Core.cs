using Core;
using System.IO;
using Xunit;

namespace Tests
{
    public class TestsCore
    {
        private const string FileName = @"F:/3.jpg";

        public string Filename = Path.Combine(Path.GetDirectoryName(FileName), Path.GetFileName(FileName));

        [Fact]
        public void ReadFileFromStringName()
        {
            var ocr = new Ocr(Filename,2);

            var test = ocr.ReadFile();

            Assert.True(test);
        }

        [Fact]
        public void ReadFileFormStringNameAndCorrectOcrProcess()
        {
            var ocr = new Ocr(Filename,2);

            ocr.ReadFile();
            var text = ocr.ReadOcr();

            Assert.NotNull(text);
        }

        
    }
}
