using Core.Interface;
using Core.Model;
using Tesseract;

namespace Core
{
    public class ReadPicture : IReadPicture
    {
        public Pix ReadImageFromFile(IMyImage image)
        {
            return Pix.LoadFromFile(image.GetName());
        }
    }
}