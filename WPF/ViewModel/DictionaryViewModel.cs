using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using RecognizePassword.Model;
using Syncfusion.Windows.Tools.Controls;
using WPF.Enum;
using WPF.Helpers;
using WPF.Interface;

namespace WPF.ViewModel
{

    public class DictionaryViewModel:ViewModelBase
    {
        private readonly IDataExchangeViewModel _dataExchangeViewModel;
        private readonly ObservableCollection<DictionaryPasswordElement> _dictionaryPassword;
        private List<List<DictionaryPasswordElement>> _dictionary;

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

            LoadDictionary();

            GetListPasswordFromCollectio();
        }

        private void LoadDictionary()
        {
            if (File.Exists(@"D:\dane\slownik.json"))
            {
                _dictionary =
                    JsonConvert.DeserializeObject<List<List<DictionaryPasswordElement>>>(
                        File.ReadAllText(@"D:\dane\slownik.json"));
            }
            else
            {
                _dictionary = new List<List<DictionaryPasswordElement>>();
            }

            foreach (List<DictionaryPasswordElement> elements in _dictionary)
            {
                _dictionaryPassword.Add(elements[0]);
            }

        }

        private void GetListPasswordFromCollectio()
        {
            foreach (var dictionaryPasswordElement in _dictionaryPassword)
            {
                _passwordList.Add(dictionaryPasswordElement.Word);
            }
            RaisePropertyChanged(PasswordListPropertyName);
        }
       
        private void ExecuteExitCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseDictionaryView"));
        }
        private void ExecuteOpenCommand()
        {

        }

        private void ExecuteSelectWordCommand(object obj)
        {
            var text = (string)obj;

            foreach (List<DictionaryPasswordElement> elements in _dictionary)
            {
                if (elements[0].Word==text)
                {
                    ExecuteExportToHtml(elements);

                    using (var t = File.OpenRead(@"D:\dane\text.html"))
                    {
                        _documentAdv = HTMLImporting.ConvertToDocumentAdv(t);
                        RaisePropertyChanged(DocumentPropertyName);
                    }
                }
            }
        }

        private void ExecuteExportToHtml(List<DictionaryPasswordElement> elements)
        {
            ObservableCollection<DictionaryPasswordElement> dictionaryPasswordElements = new ObservableCollection<DictionaryPasswordElement>(elements);

            DocumentAdv textDocumentAdv = HtmlParsing.ParsowanieHtml(dictionaryPasswordElements);

            using (var t = File.Create(@"D:\dane\text.html"))
            {
                HTMLExporting.ConvertToHtml(textDocumentAdv, t);
            }


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

        

        #region RecognizePassword



        #endregion
        #endregion

        #region RelayMethod

        private RelayCommand _exitCommand;

        public RelayCommand ExitCommand => _exitCommand
                                           ?? (_exitCommand = new RelayCommand(ExecuteExitCommand));

        private RelayCommand _openCommand;

       
        public RelayCommand OpenCommand => _openCommand
                                          ?? (_openCommand = new RelayCommand(ExecuteOpenCommand));

        private RelayCommand<object> _selectWordCommand;

       
        public RelayCommand<object> SelectWordCommand => _selectWordCommand
                                                 ?? (_selectWordCommand = new RelayCommand<object>(ExecuteSelectWordCommand));

        

        #endregion
    }


}