using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using WPF.ViewModel;

namespace WPF.View
{
    /// <summary>
    /// Interaction logic for SpellerView.xaml
    /// </summary>
    public partial class SpellerView : Window
    {
        public SpellerView()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, nm =>
            {
                if (nm.Notification == "CloseSpellerView")
                {
                    Messenger.Default.Unregister<NotificationMessage>(this, "CloseSpellerView");
                    Close();
                }
            });
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            ViewModelLocator.UnregisterSpellerViewModel();
        }
    }
}
