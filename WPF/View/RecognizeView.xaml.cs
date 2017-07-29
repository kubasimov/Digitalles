using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for RecognizeView.xaml
    /// </summary>
    public partial class RecognizeView : Window
    {
        public RecognizeView()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, nm =>
            {
                if (nm.Notification == "CloseRecognizeView")
                {
                    Messenger.Default.Unregister<NotificationMessage>(this, "CloseRecognizeView");
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
