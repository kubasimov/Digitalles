﻿using System;
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
    }
}
