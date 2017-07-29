using System.Diagnostics;
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

        private void RichTextBoxAdv_SelectionChanged(object obj, Syncfusion.Windows.Tools.Controls.SelectionChangedEventArgs args)
        {
            Debug.WriteLine("SelectionChanged  "+obj);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.UnregisterOcrViewViewModel();
        }
    }
}
