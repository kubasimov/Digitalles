using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.Helpers;
using Core.Model;

namespace Core
{
    public class DecodeParagraphs
    {
        XName _paraName = XName.Get("p");

        public List<TextParagraph> Decode(XElement element)
        {
            List<TextParagraph> textParagraphs = new List<TextParagraph>();

            IEnumerable<XElement> paragraphs = element.Descendants(_paraName)
                .Where(x => (string)x.Attribute("class") == "ocr_par");

            foreach (XElement paragraph in paragraphs)
            {
                TextParagraph textParagraph = new TextParagraph();

                XAttribute coords = paragraph.Attribute("title");
                if (coords != null)
                {
                    string[] coordlist = coords.Value.Split(' ');

                    textParagraph.x1 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[1]));
                    textParagraph.y1 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[2]));
                    textParagraph.x2 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[3]));
                    textParagraph.y2 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[4]));
                }

                XAttribute id = paragraph.Attribute("id");

                if (id != null) textParagraph.id = id.Value;

                List<TextLine> textLines = new DecodeLines().Decode(paragraph);

                textParagraph.Lines.AddRange(textLines);

                textParagraphs.Add(textParagraph);
            }

            return textParagraphs;
        }
    }
}