using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using WPF.Model;

namespace WPF.Interface
{
    public interface IDataService
    {
        ObservableCollection<BitmapImage> LoadImages();
        SettingsModel LoadSettings();

    }
}
