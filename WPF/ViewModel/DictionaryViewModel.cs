using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
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
            DocumentAdv textDocumentAdv = ParsowanieHtml(elements);

            using (var t = File.Create(@"D:\dane\text.html"))
            {
                HTMLExporting.ConvertToHtml(textDocumentAdv, t);
            }


        }

        private DocumentAdv ParsowanieHtml(List<DictionaryPasswordElement> dictionaryPasswordElements)
        {
            var documentAdv = new DocumentAdv();
            var sectionAdv = new SectionAdv();
            documentAdv.Sections.Add(sectionAdv);

            var paragraphPassword = new ParagraphAdv();
            sectionAdv.Blocks.Add(paragraphPassword);

            var paragraphDescryption = new ParagraphAdv();
            sectionAdv.Blocks.Add(paragraphDescryption);

            foreach (var element in dictionaryPasswordElements)
            {
                if (element.Description.Contains("hasło"))
                {
                    var spanAdv = new SpanAdv
                    {
                        Text = element.Word + " ",
                        Foreground = Color.FromRgb(0, 128, 0),
                        FontSize = 24,

                    };

                    paragraphPassword.Inlines.Add(spanAdv);
                }
                else if (element.Word.Contains("I") || element.Word.Contains("II") || element.Word.Contains("III") || element.Word.Contains("IV"))
                {
                    var hyperlinkAdv = new HyperlinkAdv
                    {
                        Text = element.Word + " ",
                        NavigationUrl = @"tabele/meski_" + element.Word.Trim(',') + ".jpg",
                        Foreground = Color.FromRgb(0, 255, 0)
                    };

                    paragraphPassword.Inlines.Add(hyperlinkAdv);
                }
                else if (element.Description.Contains("definicja"))
                {
                    var hyperlinkAdv = new HyperlinkAdv
                    {
                        Text = element.Word + " \n",
                        NavigationUrl = "javascript:alert('" + element.Description + "')",
                        Foreground = Colors.Black
                    };
                    paragraphDescryption.Inlines.Add(hyperlinkAdv);
                }
                else if (element.Description.Contains("cytat"))
                {
                    var paragraphCitation = new ParagraphAdv
                    {
                        ListType = ListType.Bulleted
                    };
                    sectionAdv.Blocks.Add(paragraphCitation);

                    var hyperlinkAdv = new HyperlinkAdv
                    {
                        Text = element.Word + " \n",
                        NavigationUrl = "javascript:alert('" + element.Description + "')",
                        Foreground = Colors.Black
                    };
                    paragraphCitation.Inlines.Add(hyperlinkAdv);
                }
                else if (element.Description.Contains("wyjaśnienie etymologiczne wyrazu"))
                {
                    var paragraphLatin = new ParagraphAdv();
                    sectionAdv.Blocks.Add(paragraphLatin);
                    var hyperlinkAdv = new HyperlinkAdv
                    {
                        Text = element.Word + " ",
                        NavigationUrl = "javascript:alert('" + element.Description + "')",
                        Foreground = Colors.Black
                    };
                    paragraphLatin.Inlines.Add(hyperlinkAdv);
                }
                else
                {
                    var spanAdv = new SpanAdv
                    {
                        Text = element.Word + " ",

                    };

                    paragraphPassword.Inlines.Add(spanAdv);
                }

            }

            return documentAdv;
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

        private RelayCommand _newCommand;

        public RelayCommand NewCommand => _newCommand
                                           ?? (_newCommand = new RelayCommand(ExecuteNewCommand));

        private RelayCommand _openCommand;

       
        public RelayCommand OpenCommand => _openCommand
                                          ?? (_openCommand = new RelayCommand(ExecuteOpenCommand));

        private RelayCommand<object> _selectWordCommand;

       
        public RelayCommand<object> SelectWordCommand => _selectWordCommand
                                                 ?? (_selectWordCommand = new RelayCommand<object>(ExecuteSelectWordCommand));

        

        #endregion
    }


}