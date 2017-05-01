using System.Collections.Generic;
using Core.Helpers;

namespace Core.Model
{
    public class TextWord:Coord
    {
        public string id;
       
        public string Word;
        public List<TextLetter> Letters = new List<TextLetter>();
    }
}