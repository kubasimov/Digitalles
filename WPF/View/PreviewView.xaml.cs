using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for PreviewView.xaml
    /// </summary>
    public partial class PreviewView : Window
    {
        public PreviewView()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, nm =>
            {
                if (nm.Notification == "ClosePreviewView")
                {
                    Messenger.Default.Unregister<NotificationMessage>(this, "ClosePreviewView");
                    Close();
                }
            });
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.UnregisterPreviewViewModel();
        }
    }
}
