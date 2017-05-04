﻿using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace WPF.Interface
{
    public interface IDataService
    {
        ObservableCollection<BitmapImage> LoadImages();

    }
}
