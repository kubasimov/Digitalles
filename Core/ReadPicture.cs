using Core.Interface;
using Core.Model;
using Tesseract;

namespace Core
{
    public class ReadPicture : IReadPicture
    {
        public Pix ReadImageFromFile(string image)
        {
            return Pix.LoadFromFile(image);
        }
    }
}