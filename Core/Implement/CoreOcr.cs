using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Core.Decode;
using Core.Helpers;
using Core.Interface;
using Core.Model;
using Tesseract;

namespace Core.Implement
{
    public class CoreOcr:ICoreOcr
    {

        private Pix _imagePix;

        public async Task<bool> LoadImage(string filename)
        {
            try
            {
               _imagePix = await Task.Run(() => Pix.LoadFromFile(filename));

                return _imagePix != null;
            }
            catch (Exception e)
            {

                MessageBox.Show("Error: "+e, "Info", MessageBoxButtons.OK);
                return false;

            }
        }

        public async Task<string> OcrPages(string language, int pages)
        {
            using (var engine = new TesseractEngine(@"./tessdata",language))
            {
                var page = engine.Process(_imagePix);
                return await Task.Run(() => page.GetHOCRText(pages));
            }
        }
        

        public async Task<List<TextPage>> DecodeHocr(string text)
        {
            return await Task.Run(async () =>
            {
                var divName = XName.Get("div");

                List<TextPage> textPages = new List<TextPage>();

                XDocument textXml = XDocument.Parse(text);

                IEnumerable<XElement> pages = textXml.Descendants(divName)
                    .Where(x => (string) x.Attribute("class") == "ocr_page");


                foreach (XElement page in pages)
                {

                    TextPage textPage = new TextPage();

                    XAttribute coords = page.Attribute("title");

                    if (coords != null)
                    {
                        string[] coordlist = coords.Value.Split(' ');

                        textPage.X = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[3]));
                        textPage.Y = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[4]));
                        textPage.Width = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[5])) -
                                         Convert.ToInt32(HelperOcr.GetNumbers(coordlist[3]));
                        textPage.Height = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[6])) -
                                          Convert.ToInt32(HelperOcr.GetNumbers(coordlist[4]));
                    }
                    
                    XAttribute id = page.Attribute("id");

                    if (id != null) textPage.Id = id.Value;

                    List<TextParagraph> textParagraphs = await Task.Run(() => new DecodeParagraphs().Decode(page));

                    textPage.Paragraphs.AddRange(textParagraphs);

                    textPages.Add(textPage);

                }

                return textPages;

            });
        }
    }



}