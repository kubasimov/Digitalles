using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
using WPF.Interface;
using WPF.Model;

namespace WPF.Implement
{
    public class DataService:IDataService
    {
        public ObservableCollection<BitmapImage> LoadImages()
        {
            var bitmapImages = new ObservableCollection<BitmapImage>();

            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".png",
                Filter =
                    "All Image (*.bmp, *.png, *.jpg, *.jpeg, *.tif, *.tiff)|*.bmp; *.png; *.jpg; *.jpeg; *.tif; *.tiff|" +
                    "BMP (*.bmp)|*.bmp|" +
                    "PNG (*.png)|*.png|" +
                    "JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|" +
                    "TIFF (*.tif, *.tiff)|*.tif;*.tiff",
                Multiselect = true
            };

            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                foreach (var fileName in openFileDialog.FileNames)
                {
                    bitmapImages.Add(new BitmapImage(new Uri(fileName)));
                }
                
            }

            return bitmapImages;
        }

        public SettingsModel LoadSettings()
        {
            //TODO Initialize from Json settings file
            return new SettingsModel
            {
                Language=new List<LangModel>
                {
                    new LangModel("Angielski","ang"),
                    new LangModel("Polski","pol")
                }, 
                Pages = 2
            };
        }
    }
}