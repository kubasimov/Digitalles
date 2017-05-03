using System;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using WPF.Interface;

namespace WPF.Implement
{
    public class DataService:IDataService
    {
        public BitmapImage LoadImage()
        {
            var bitmapImage = new BitmapImage();

            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".png",
                Filter =
                    "All Image (*.bmp, *.png, *.jpg, *.jpeg, *.tif, *.tiff)|*.bmp; *.png; *.jpg; *.jpeg; *.tif; *.tiff|" +
                    "BMP (*.bmp)|*.bmp|" +
                    "PNG (*.png)|*.png|" +
                    "JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|" +
                    "TIFF (*.tif, *.tiff)|*.tif;*.tiff"
            };

            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                bitmapImage=new BitmapImage(new Uri(openFileDialog.FileName));
            }

            return bitmapImage;
        }
    }
}