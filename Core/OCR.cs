using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Core.Model;
using Tesseract;

namespace Core
{
    public class Ocr
    {
        private Image image;
        private int _pages;
        private Pix _imagePix;
        
        public Ocr(string fileName,int pages)
        {
            image.filename = fileName;
            _pages = pages;
        }
        
        public bool ReadFile()
        {

            _imagePix = Pix.LoadFromFile(image.filename);
            if (_imagePix != null)
            {
                image.height = _imagePix.Height;
                image.width = _imagePix.Width;
                return true;
            }
            
            return false;
        }
        
        public string  ReadOcr()
        {
            using (var tes = new TesseractEngine(@"./tessdata", "pol"))
            {
                var page = tes.Process(_imagePix);

                return page.GetHOCRText(_pages);
            }
        }

        public int GetImageHeight()
        {
            return image.height;
        }

        public int GetImageWidth()
        {
            return image.width;
        }
    }
}