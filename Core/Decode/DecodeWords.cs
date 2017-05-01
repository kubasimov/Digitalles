using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Core.Helpers;
using Core.Model;

namespace Core.Decode
{
    public class DecodeWords
    {
        readonly XName _spanName = XName.Get("span");

        public List<TextWord> Decode(XElement line)
        {
            List<TextWord> textWords = new List<TextWord>();
            
            IEnumerable<XElement> words = line.Descendants(_spanName);

            foreach (XElement word in words)
            {
                TextWord textWord = new TextWord();
                XAttribute coords = word.Attribute("title");
                if (coords != null)
                {
                    string[] coordlist = coords.Value.Split(' ');

                    textWord.x1 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[1]));
                    textWord.y1 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[2]));
                    textWord.x2 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[3]));
                    textWord.y2 = Convert.ToInt32(HelperOcr.GetNumbers(coordlist[4]));
                }

                XAttribute id = word.Attribute("id");

                if (id != null) textWord.id = id.Value;
                textWord.Word = word.Value;

                textWords.Add(textWord);
            }

            return textWords;
        }
    }
}