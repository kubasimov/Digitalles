using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using morfologik.stemming;
using morfologik.stemming.polish;
using Newtonsoft.Json;
using RecognizePassword.Model;
using Syncfusion.Windows.Tools.Controls;
using WPF.Helpers;
using WPF.Properties;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace WPF.ViewModel
{

    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    [SuppressMessage("ReSharper", "PossibleUnintendedReferenceComparison")]
    public class DictionaryViewModel:ViewModelBase
    {
        private readonly ObservableCollection<DictionaryPasswordElement> _dictionaryPassword;
        private List<List<DictionaryPasswordElement>> _dictionary;

        public DictionaryViewModel()
        {
            _dictionaryPassword = new ObservableCollection<DictionaryPasswordElement>();
            
            _documentAdv = new DocumentAdv();
            _searcText = "Wyszukiwany text";
            
        }

        //wczytanie pliku słownika
        private void ExecuteOpenCommand()
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter =
                        "JSON (*.json)|*.json",
                    Multiselect = false
                };

                var result = openFileDialog.ShowDialog();

                if (result != true) return;

                LoadDictionary(openFileDialog.FileName);
                _enableAfterOpenDictionary = true;
                RaisePropertyChanged(EnableAfterOpenDictionaryPropertyName);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.ErrorLoadDictionary, Resources.ErrorLoad, MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
        
        //Wyjście
        private void ExecuteExitCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseDictionaryView"));
        }

        //komenda wyszukanie hasła
        private void ExecuteSearchCommand(object obj)
        {
            var text = (string)obj;
            
            if (text!="")
            {
                var speller = new PolishStemmer();
                var textWordData = (speller.lookup(text).toArray().FirstOrDefault() as WordData);

                if (textWordData != null)
                {
                    text = textWordData.getStem().toString();
                }
                
                Search(text.Trim().ToLower());
            }
        }

        //wyszukanie wybranego hasła z listy
        private void ExecuteSelectWordCommand(object obj)
        {
            var text = (string)obj;

            Search(text);
        }

        //metoda wyszukująca hasło w słowniku
        private void Search(string text)
        {
            foreach (var elements in _dictionary)
            {
                if (elements[0].Word.Trim().ToLower() == text.Trim().ToLower())
                {
                    ExecuteExportToHtml(elements);
                    var filename = Path.GetTempPath() + @"\temp.html";

                    using (var t = File.OpenRead(filename))
                    {
                        _documentAdv = HTMLImporting.ConvertToDocumentAdv(t);
                        RaisePropertyChanged(DocumentPropertyName);
                    }
                }
            }
        }

        //export hasła do tymczasowego pliku Html
        private static void ExecuteExportToHtml(List<DictionaryPasswordElement> elements)
        {
            var dictionaryPasswordElements = new ObservableCollection<DictionaryPasswordElement>(elements);

            var textDocumentAdv = HtmlParsing.ParsowanieHtml(dictionaryPasswordElements);

            using (var t = File.Create(Path.GetTempPath() + @"\temp.html"))
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
        
        public const string EnableAfterOpenDictionaryPropertyName = "EnableAfterOpenDictionary";

        private bool _enableAfterOpenDictionary = false;

        public bool EnableAfterOpenDictionary
        {
            get => _enableAfterOpenDictionary;

            set
            {
                if (_enableAfterOpenDictionary == value)
                {
                    return;
                }

                _enableAfterOpenDictionary = value;
                RaisePropertyChanged(EnableAfterOpenDictionaryPropertyName);
            }
        }
        
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

        private RelayCommand<object> _searchCommand;

        public RelayCommand<object> SearchCommand => _searchCommand
                                                         ?? (_searchCommand = new RelayCommand<object>(ExecuteSearchCommand));

        

        #endregion

        #region PrivateMethod

        //wczytanie pliku słownika
        //dodanie haseł słownika do listy haseł i prywatnej listy haseł z opisem
        private void LoadDictionary(string filename)
        {
            if (File.Exists(filename))
            {
                _dictionary =
                    JsonConvert.DeserializeObject<List<List<DictionaryPasswordElement>>>(
                        File.ReadAllText(filename));

                _passwordList = new List<string>();

                foreach (var elements in _dictionary)
                {
                    _dictionaryPassword.Add(elements[0]);
                    _passwordList.Add(elements[0].Word);
                }

                RaisePropertyChanged(PasswordListPropertyName);
            }
            else
            {
                _dictionary = new List<List<DictionaryPasswordElement>>();
            }
        }
        
        #endregion
    }


}