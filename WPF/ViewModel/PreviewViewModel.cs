using System.IO;
using Syncfusion.Windows.Tools.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPF.Enum;
using WPF.Interface;

namespace WPF.ViewModel
{
    public class PreviewViewModel:ViewModelBase
    {
        public PreviewViewModel(IDataExchangeViewModel dataExchangeViewModel)
        {
            if (dataExchangeViewModel.ContainsKey(EnumExchangeViewmodel.Preview))
            {
                //_documentAdv=new DocumentAdv();
                //_documentAdv = (DocumentAdv) dataExchangeViewModel.Item(EnumExchangeViewmodel.Preview);


                
            }
            else
            {
                //_documentAdv=new DocumentAdv();
            }

            using (var t = File.OpenRead(@"D:\dane\text.html"))
            {
                _documentAdv = HTMLImporting.ConvertToDocumentAdv(t);

            }

            RaisePropertyChanged(DocumentAdvPropertyName);
        }
        private void ExecuteExitCommand()
        {
            
            Messenger.Default.Send(new NotificationMessage(this, "ClosePreviewView"));
            
        }

        #region Mvvm members

        public const string DocumentAdvPropertyName = "DocumentAdv";

        private DocumentAdv _documentAdv;

        public DocumentAdv DocumentAdv
        {
            get => _documentAdv;

            set
            {
                if (_documentAdv == value)
                {
                    return;
                }

                _documentAdv = value;
                RaisePropertyChanged(DocumentAdvPropertyName);
            }
        }

        #endregion

        #region RelayMethod

        private RelayCommand _exitCommand;
        
        public RelayCommand ExitCommand => _exitCommand
                                           ?? (_exitCommand = new RelayCommand(ExecuteExitCommand));

        

        #endregion

    }
}