using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for OcrSettings.xaml
    /// </summary>
    public partial class OcrSettings : Window
    {
        public OcrSettings()
        {
            InitializeComponent();

            Messenger.Default.Register<NotificationMessage>(this, nm =>
            {
                if (nm.Notification == "CloseOcrSettings")
                {
                    Messenger.Default.Unregister<NotificationMessage>(this, "CloseOcrSettings");
                    Close();
                }
            });

        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.UnregisterRecognizeViewModel();
        }
    }
}
