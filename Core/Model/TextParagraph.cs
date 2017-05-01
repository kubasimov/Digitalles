using System.Collections.Generic;
using Core.Helpers;

namespace Core.Model
{
    public class TextParagraph :Coord 
    {
        public string id;
        
        public List<TextLine> Lines = new List<TextLine>();
    }
}