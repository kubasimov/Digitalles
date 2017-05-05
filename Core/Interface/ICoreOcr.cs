using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Core.Helpers;
using Core.Model;

namespace Core.Interface
{
    public interface ICoreOcr
    {
        Task<bool> LoadImage(string filename);
        //bool LoadImage(BitmapImage bitmapImage);
        //bool LoadImage(Image image);

        Task<string> OcrPages(string language, int pages);
        //List<TextPage> OcrPages(BitmapImage bitmapImage);
        //List<TextPage> OcrPages(Image image);

        Task<List<TextPage>> DecodeHocr(string page);
    }
}