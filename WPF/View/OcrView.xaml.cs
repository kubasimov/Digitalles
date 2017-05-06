using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for OcrView.xaml
    /// </summary>
    public partial class OcrView : Window
    {
        public OcrView()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, nm =>
            {
                if (nm.Notification == "CloseOcr")
                {
                    Messenger.Default.Unregister<NotificationMessage>(this, "CloseOcr");
                    Close();
                }
            });

            
        }
    }
}
