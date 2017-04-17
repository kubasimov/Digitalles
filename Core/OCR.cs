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
        private string _fileName;
        private int _pages;
        private Pix _imagePix;

        public Ocr(string fileName,int pages)
        {
            _fileName = fileName;
            _pages = pages;
        }


        public bool ReadFile()
        {

            _imagePix = Pix.LoadFromFile(_fileName);
            if (_imagePix!=null) return true;
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

        public TextPage DecodeHocr(string text)
        {
            TextPage textPage = new TextPage();

            XDocument textXml = XDocument.Parse(text);

            XName spanName = XName.Get("span");
            IEnumerable<XElement> lines = textXml.Root.Descendants(spanName)
                .Where(x => (string)x.Attribute("class") == "ocr_line");

            if (lines.Count() == 0)
            {
                spanName=XName.Get("span","http://www.w3.org/1999/xhtml");
                lines = textXml.Root.Descendants(spanName)
                    .Where(x => (string) x.Attribute("class") == "ocr_line");
            }

            foreach (XElement line in lines)
            {
                TextLine textLine = new TextLine();

                IEnumerable<XElement> words = line.Descendants(spanName);

                foreach (XElement word in words)
                {
                    TextWord textWord = new TextWord();

                    XAttribute coords = word.Attribute("title");
                    string[] coordlist = coords.Value.Split(' ');

                    textWord.x1 = Convert.ToInt32(coordlist[1]);
                    textWord.y1 = Convert.ToInt32(coordlist[2]);
                    textWord.x2 = Convert.ToInt32(coordlist[3]);
                    textWord.y2 = Convert.ToInt32(coordlist[4]);

                    textWord.text = word.Value;
                    textLine.words.Add(textWord);
                }

                textPage.lines.Add(textLine);
            }

            return textPage;
        }
    }
}