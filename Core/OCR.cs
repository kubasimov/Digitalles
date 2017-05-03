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
        
        private int _pages;
        private Pix _imagePix;

        public Ocr(IReadPicture readPicture)
        {
            _readPicture = readPicture;
        }


        public bool ReadFile(IMyImage _image)
        {
            _imagePix = _readPicture.ReadImageFromFile(_image);
            
            if (_imagePix != null)
            {
                _image.SetHeight(_imagePix.Height);
                _image.SetWidth(_imagePix.Width);
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