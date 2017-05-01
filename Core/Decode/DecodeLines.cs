using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Core.Decode;
using Core.Helpers;
using Core.Model;

namespace Core
{
    public class DecodeLines
    {
        readonly XName _spanName = XName.Get("span");

        public List<TextLine> Decode(XElement paragraph)
        {
            List<TextLine> textLines = new List<TextLine>();

            IEnumerable<XElement> lines = paragraph.Descendants(_spanName)
                .Where(x => (string)x.Attribute("class") == "ocr_line");

            foreach (XElement line in lines)
            {
                TextLine textLine = new TextLine();
                XAttribute coords = line.Attribute("title");
                if (coords != null)
                {
                    string[] coordlist = coords.Value.Split(' ');

                    textLine.x1 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[1]));
                    textLine.y1 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[2]));
                    textLine.x2 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[3]));
                    textLine.y2 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[4]));
                }

                XAttribute id = line.Attribute("id");

                if (id != null) textLine.id = id.Value;

                List<TextWord> textWords = new DecodeWords().Decode(line);

                textLine.Words.AddRange(textWords);

                textLines.Add(textLine);
            }

            return textLines;
        }
    }
}