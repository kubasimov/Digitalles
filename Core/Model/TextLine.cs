using System.Collections.Generic;
using Core.Helpers;

namespace Core.Model
{
    public class TextLine:Coord
    {
        public string id;
       
        public List<TextWord> Words = new List<TextWord>();
    }
}