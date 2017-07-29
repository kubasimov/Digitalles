using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Syncfusion.Windows.Tools.Controls;
using WPF.Enum;
using WPF.Interface;
using WPF.Model;

namespace WPF.ViewModel
{

    public class DictionaryViewModel:ViewModelBase
    {
        private IDataExchangeViewModel _dataExchangeViewModel;
        private ObservableCollection<DictionaryPasswordElement> _dictionaryPassword;

        public DictionaryViewModel(IDataExchangeViewModel dataExchangeViewModel)
        {
            _dataExchangeViewModel = dataExchangeViewModel;
            _dictionaryPassword = new ObservableCollection<DictionaryPasswordElement>();
            _passwordList=new List<string>();
            _searcText = "Search text";


            if (_dataExchangeViewModel.ContainsKey(EnumExchangeViewmodel.RecognizeView))
            {
                _documentAdv = (DocumentAdv) _dataExchangeViewModel.Item(EnumExchangeViewmodel.Dictionary);
            }
            else
            {
                _documentAdv=new DocumentAdv();
            }


            ReadDictionary();

            GetListPasswordFromCollectio();
        }

        private void GetListPasswordFromCollectio()
        {
            foreach (var dictionaryPasswordElement in _dictionaryPassword)
            {
                _passwordList.Add(dictionaryPasswordElement.Word);
            }
            RaisePropertyChanged(PasswordListPropertyName);
        }

        private void ReadDictionary()
        {
            var t = new DictionaryPasswordElement
            {
                Word = "przygoda",
                Description = "dksabcfhdsbckjhas"
            };
            var t1 = new DictionaryPasswordElement
            {
                Word = "przygod1a",
                Description = "dksabcfhdsbckjhas"
            };
            var t2 = new DictionaryPasswordElement
            {
                Word = "przygoda2",
                Description = "dksabcfhdsbckjhas"
            };
            _dictionaryPassword.Add(t);
            _dictionaryPassword.Add(t1);
            _dictionaryPassword.Add(t2);
        }

        private void ExecuteNewCommand()
        {

        }

        private void ExecuteExitCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseDictionaryView"));
        }
        private void ExecuteOpenCommand()
        {

        }
        #region Mvvm members
        public const string SearchTextPropertyName = "SearchText";

        private string _searcText  ;

        public string SearchText
        {
            get => _searcText;

            set
            {
                if (_searcText == value)
                {
                    return;
                }

                _searcText = value;
                RaisePropertyChanged(SearchTextPropertyName);
            }
        }


        public const string DocumentPropertyName = "Document";

        private DocumentAdv _documentAdv  ;

        public DocumentAdv Document
        {
            get => _documentAdv;

           set
            {
                if (_documentAdv == value)
                {
                    return;
                }

                _documentAdv = value;
                RaisePropertyChanged(DocumentPropertyName);
            }
        }
        
        public const string PasswordListPropertyName = "PasswordList";

        private List<string > _passwordList  ;

        public List<string > PasswordList
        {
            get => _passwordList;

            set
            {
                if (_passwordList == value)
                {
                    return;
                }

                _passwordList = value;
                RaisePropertyChanged(PasswordListPropertyName);
            }
        }
        #endregion

        #region RelayMethod

        private RelayCommand _exitCommand;

        public RelayCommand ExitCommand => _exitCommand
                                           ?? (_exitCommand = new RelayCommand(ExecuteExitCommand));

        private RelayCommand _newCommand;

        public RelayCommand NewCommand => _newCommand
                                           ?? (_newCommand = new RelayCommand(ExecuteNewCommand));

        private RelayCommand _openCommand;

       
        public RelayCommand OpenCommand => _openCommand
                                          ?? (_openCommand = new RelayCommand(ExecuteOpenCommand));

        

        #endregion
    }


}