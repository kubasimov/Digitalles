using System.Windows;
using GalaSoft.MvvmLight.Messaging;

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
    }
}
