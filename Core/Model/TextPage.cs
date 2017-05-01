using System.Collections.Generic;
using Core.Helpers;
using Core.Interface;

namespace Core.Model
{
    public class TextPage:Coord
    {
        public string Id;
        public List<TextParagraph> Paragraphs = new List<TextParagraph>();
    }
}