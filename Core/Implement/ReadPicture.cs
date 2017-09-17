using Core.Interface;
using Tesseract;

namespace Core.Implement
{
    public class ReadPicture : IReadPicture
    {
        public Pix ReadImageFromFile(string image)
        {
            return Pix.LoadFromFile(image);
        }
    }
}