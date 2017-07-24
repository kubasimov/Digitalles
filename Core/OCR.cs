using Autofac;
using Core.Helpers;
using Core.Interface;
using Core.Model;
using Tesseract;

namespace Core
{
    public class Ocr
    {
        
        private readonly IReadPicture _readPicture;
        
        private Pix _imagePix;

        public Ocr(IReadPicture readPicture)
        {
            _readPicture = readPicture;
        }


        public bool ReadFile(string _image)
        {
            _imagePix = _readPicture.ReadImageFromFile(_image);
            
            if (_imagePix != null)
            {
                
                return true;
            }
            
            return false;
        }
        
        public string  ReadOcr(string language)
        {
            using (var tes = new TesseractEngine(@"./tessdata", language))
            {
                var page = tes.Process(_imagePix);
                
                return page.GetHOCRText(2);
            }
        }
    }
}