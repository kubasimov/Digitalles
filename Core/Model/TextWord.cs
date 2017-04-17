using System.Collections.Generic;

namespace Core.Model
{
    public class TextWord
    {
        public string id;
        public int x1; //left
        public int y1; //bottom
        public int x2; //right
        public int y2; //top
        public string Word;
        public List<TextLetter> Letters = new List<TextLetter>();
    }
}