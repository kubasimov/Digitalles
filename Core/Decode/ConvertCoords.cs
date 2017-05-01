using System.Collections.Generic;
using Core.Helpers;
using Core.Interface;
using Core.Model;

namespace Core.Decode
{
    public class ConvertCoords
    {
        private List<TextPage> _pages;
        private IImage _image;
        
        public void Convert(List<TextPage> pages,IImage image)
        {
            _pages = pages;
            _image = image;

            foreach (var textPage in _pages)
            {
                var t = new Coord
                {
                    x1 = textPage.x1,
                    y1 = _image.GetHeight() - textPage.y2,
                    x2 = textPage.x2 - textPage.x1,
                    y2 = textPage.y2 - textPage.y1
                };

                textPage.x1 = t.x1;
                textPage.y1 = t.y1;
                textPage.x2 = t.x2;
                textPage.y2 = t.y2;


                foreach (var textParagraph in textPage.Paragraphs)
                {
                    var t1 = new Coord
                    {
                        x1 = textParagraph.x1,
                        y1 = _image.GetHeight() - textParagraph.y2,
                        x2 = textParagraph.x2 - textParagraph.x1,
                        y2 = textParagraph.y2 - textParagraph.y1
                    };


                }
            }


        }
    }
}