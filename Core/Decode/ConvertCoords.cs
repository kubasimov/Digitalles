using System.Collections.Generic;
using Core.Helpers;
using Core.Interface;
using Core.Model;

namespace Core.Decode
{
    public class ConvertCoords
    {
        private List<TextPage> _pages;
        private IMyImage _image;
        
        public void Convert(List<TextPage> pages,IMyImage image)
        {
            _pages = pages;
            _image = image;

            foreach (var textPage in _pages)
            {
                var t = new Coord
                {
                    X = textPage.X,
                    Width = _image.GetHeight() - textPage.Height,
                    Y = textPage.Y - textPage.X,
                    Height = textPage.Height - textPage.Width
                };

                textPage.X = t.X;
                textPage.Width = t.Width;
                textPage.Y = t.Y;
                textPage.Height = t.Height;


                foreach (var textParagraph in textPage.Paragraphs)
                {
                    var t1 = new Coord
                    {
                        X = textParagraph.X,
                        Width = _image.GetHeight() - textParagraph.Height,
                        Y = textParagraph.Y - textParagraph.X,
                        Height = textParagraph.Height - textParagraph.Width
                    };


                }
            }


        }
    }
}