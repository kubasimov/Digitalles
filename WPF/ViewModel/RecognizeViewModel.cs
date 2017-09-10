using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using Newtonsoft.Json;
using Syncfusion.Windows.Tools.Controls;
using WPF.Enum;
using WPF.Helpers;
using WPF.Interface;
using WPF.View;
using RecognizePassword.Model;
using RecognizePassword.Implement;
using RecognizePassword.Interface;

namespace WPF.ViewModel
{
    public class RecognizeViewModel:ViewModelBase
    {
        private Dictionary<string, string> _dictionary;
        private readonly IDataExchangeViewModel _dataExchangeViewModel;
        private readonly TextImporting _textImporting = new TextImporting();
        private readonly IRecognizePasswordText _recognizePasswordText;

        public RecognizeViewModel(IDataExchangeViewModel dataExchangeViewModel)
        {
            if (IsInDesignMode)
            {
                var _text =
                    "animalistyka ż III blm szt. «przedstawianie zwierząt lub motywów zwierzęcych w sztukach plastycznych, " +
                    "w fotografice»: Do mistrzostwa doprowadził sztukę fotograficzną, szczególniej w tak trudnym dziale jak animalistyka " +
                    "(zdjęcia zwierząt). Probl. 1954, s. 570. <łc. animal = zwierzę>";

                
                _textToRecognize = _textImporting.ConvertToDocumentAdv(_text);

                _dictionary = new Dictionary<string, string>
                {
                    {"aaa", "bbb"},
                    { "ccc", "ddd"}
                };

                _digDictionaries = new ObservableCollection<DictionaryPasswordElement>
                {
                    new DictionaryPasswordElement {Word = "Zabawa", Description = "zabawa"},
                    new DictionaryPasswordElement {Word = "AAA1", Description = "aaa1"},
                    new DictionaryPasswordElement {Word = "BBB1", Description = "bbb1"}
                };

                _recognizePasswordObservableCollection = new ObservableCollection<DictionaryPasswordElement>
                {
                    new DictionaryPasswordElement {Word = "AAd1", Description = "aa1"},
                    new DictionaryPasswordElement {Word = "AA2", Description = "aa2"},
                    new DictionaryPasswordElement {Word = "AA3", Description = "aa3"}
                };

                
            }
            else
            {


                _dataExchangeViewModel = dataExchangeViewModel;

                if (_dataExchangeViewModel.ContainsKey(EnumExchangeViewmodel.TextToRecognize))
                {
                    _textToRecognize = (DocumentAdv)_dataExchangeViewModel.Item(EnumExchangeViewmodel.TextToRecognize);
                }
                else
                {
                    _textToRecognize = new DocumentAdv();
                }

                _recognizePasswordObservableCollection = new ObservableCollection<DictionaryPasswordElement>();

                LoadDictionaryPassword();
            }
            
            //TODO: Zmienić na fabryke
            _recognizePasswordText = new RecognizePasswordTextType1();

        }

        private void ExecuteNewCommand()
        {
            _textToRecognize=new DocumentAdv();
            RaisePropertyChanged(TextToRecognizePropertyName);

            _recognizePasswordObservableCollection = new ObservableCollection<DictionaryPasswordElement>();
        }

        private void ExecuteSaveAsCommand()
        {
            var saveFileDialog = new SaveFileDialog();

            var result = saveFileDialog.ShowDialog();

            if (result==true)
            {


                File.WriteAllText(saveFileDialog.FileName, 
                    JsonConvert.SerializeObject(_recognizePasswordObservableCollection, Formatting.Indented));

            }
        }

        private void ExecuteOpenCommand()
        {
            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter =
                    "Plain text (*.txt)|*.txt;",
                Multiselect = false
            };

            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                _textToRecognize = _textImporting.ConvertToDocumentAdv(File.Open(openFileDialog.FileName,FileMode.Open));
                RaisePropertyChanged(TextToRecognizePropertyName);
            }
        }

        private void ExecuteRecognizeCommand()
        {

            _recognizePasswordObservableCollection.Clear();
            _recognizePasswordObservableCollection = _recognizePasswordText.Recognize(TextExporting.ConvertToText(_textToRecognize),_dictionary);

            RaisePropertyChanged(RecognizePasswordPropertyName);
        }

        private void ExecuteSaveCommand()
        {
            File.WriteAllText(@"D:\dane\"+ _recognizePasswordObservableCollection[0].Word+".json", JsonConvert.SerializeObject(_recognizePasswordObservableCollection, Formatting.Indented));
        }

        private void ExecuteExportToHtml()
        {
            DocumentAdv textDocumentAdv = HtmlParsing.ParsowanieHtml(_recognizePasswordObservableCollection);

            using (var t = File.Create(@"D:\dane\text.html"))
            {
                HTMLExporting.ConvertToHtml(textDocumentAdv,t);
            }
            
        }

        private void ExecuteSettingsCommand()
        {
            List<List<DictionaryPasswordElement>> dictionaryFromFile ;

            if (File.Exists(@"\slownik.json"))
            {
                dictionaryFromFile =
                    JsonConvert.DeserializeObject<List<List<DictionaryPasswordElement>>>(
                        File.ReadAllText(@"\slownik.json"));
            }
            else
            {
                dictionaryFromFile = new List<List<DictionaryPasswordElement>>();
            }
            
            dictionaryFromFile.Add(_recognizePasswordObservableCollection.ToList());
            File.WriteAllText(@"\slownik.json",JsonConvert.SerializeObject(dictionaryFromFile,Formatting.Indented));
            
        }

        private void ExecuteExitCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseRecognizeView"));
        }

        private void ExecutePreviewCommand()
        {
            //_dataExchangeViewModel.Add(EnumExchangeViewmodel.Preview,ParsowanieHtml(_recognizePasswordObservableCollection));
            //_dataExchangeViewModel.Add(EnumExchangeViewmodel.Preview, _textToRecognize);
            ExecuteExportToHtml();

            var view = new PreviewView();
            try
            {
                view.ShowDialog();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Messenger.Default.Send(new NotificationMessage(this, "ClosePreviewView"));
                
            }
            finally
            {
                Messenger.Default.Send(new NotificationMessage(this, "ClosePreviewView"));
                
            }

        }
        
        #region RelayMethod

        private RelayCommand _exitCommand;

        public RelayCommand ExitCommand => _exitCommand
                                           ?? (_exitCommand = new RelayCommand(ExecuteExitCommand));

        private RelayCommand _recognizeCommand;

        public RelayCommand RecognizeCommand => _recognizeCommand
                                           ?? (_recognizeCommand = new RelayCommand(ExecuteRecognizeCommand));

        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand => _saveCommand
                                           ?? (_saveCommand = new RelayCommand(ExecuteSaveCommand));

        private RelayCommand _settingsCommand;
        
        public RelayCommand SettingsCommand => _settingsCommand
                                               ?? (_settingsCommand = new RelayCommand(ExecuteSettingsCommand));

        private RelayCommand _openCommand;

        public RelayCommand OpenCommand => _openCommand
                                           ?? (_openCommand = new RelayCommand(ExecuteOpenCommand));

        private RelayCommand _saveAsCommand;

        public RelayCommand SaveAsCommand => _saveAsCommand
                                             ?? (_saveAsCommand = new RelayCommand(ExecuteSaveAsCommand));

        private RelayCommand _newCommand;

        public RelayCommand NewCommand => _newCommand
                                          ?? (_newCommand = new RelayCommand(ExecuteNewCommand));

        private RelayCommand _pasteCommand;

        public RelayCommand PasteCommand => _pasteCommand
                                            ?? (_pasteCommand = new RelayCommand(ExecutePasteCommand));

        private RelayCommand _exportToHtmlCommand;

        public RelayCommand ExportToHtml => _exportToHtmlCommand
                                            ?? (_exportToHtmlCommand = new RelayCommand(ExecuteExportToHtml));

        private RelayCommand _previewCommand;

        public RelayCommand PreviewCommand => _previewCommand
                                              ?? (_previewCommand = new RelayCommand(ExecutePreviewCommand));

        

        private void ExecutePasteCommand()
        {

        }
        
        #endregion

        
        #region Mvvm members

            #region MyDigDictionary
            /// <summary>
            /// The <see cref="MyDigDictionary" /> property's name.
            /// </summary>
            public const string MyDigDictionaryPropertyName = "MyDigDictionary";

            private ObservableCollection<DictionaryPasswordElement> _digDictionaries;

            public ObservableCollection<DictionaryPasswordElement> MyDigDictionary
            {
                get => _digDictionaries;

                set
                {
                    if (_digDictionaries == value)
                    {
                        return;
                    }

                    _digDictionaries = value;
                    RaisePropertyChanged(MyDigDictionaryPropertyName);
                }
            }


        #endregion

            #region TextToRecognize

            /// <summary>
            /// The <see cref="TextToRecognize" /> property's name.
            /// </summary>
            public const string TextToRecognizePropertyName = "TextToRecognize";

            private DocumentAdv _textToRecognize  ;

            public DocumentAdv TextToRecognize
            {
                get => _textToRecognize;

                set
                {
                    if (_textToRecognize == value)
                    {
                        return;
                    }

                    _textToRecognize = value;
                    RaisePropertyChanged(TextToRecognizePropertyName);
                }
            }

        #endregion

            #region RecognizePassword

            /// <summary>
                /// The <see cref="RecognizePassword" /> property's name.
                /// </summary>
            public const string RecognizePasswordPropertyName = "RecognizePassword";

            private ObservableCollection<RecognizePassword.Model.DictionaryPasswordElement> _recognizePasswordObservableCollection  ;

            /// <summary>
            /// Sets and gets the RecognizePassword property.
            /// Changes to that property's value raise the PropertyChanged event. 
            /// </summary>
            public ObservableCollection<DictionaryPasswordElement> RecognizePassword
            {
                get
                {
                    return _recognizePasswordObservableCollection;
                }

                set
                {
                    if (_recognizePasswordObservableCollection == value)
                    {
                        return;
                    }

                    _recognizePasswordObservableCollection = value;
                    RaisePropertyChanged(RecognizePasswordPropertyName);
                }
            }

            #endregion

        #endregion


        #region Private_Method

        private void LoadDictionaryPassword()
        {
            if (File.Exists(@"D:\dane\skroty.json"))
            {
                _dictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json"));
                _digDictionaries = CopyFromDictionary(_dictionary);
            }
            else
            {
                _dictionary = new Dictionary<string, string>();
                _digDictionaries = new ObservableCollection<DictionaryPasswordElement>();
            }
        }
        
        private ObservableCollection<DictionaryPasswordElement> CopyFromDictionary(Dictionary<string, string> itemDictionary)
        {
            var temp = new ObservableCollection<DictionaryPasswordElement>();

            foreach (KeyValuePair<string, string> keyValuePair in itemDictionary)
            {
                temp.Add(new DictionaryPasswordElement{Word=keyValuePair.Key,Description=keyValuePair.Value});
            }

            return temp;
        }

        private Dictionary<string, string> CopyFromObservableCollection(ObservableCollection<DictionaryPasswordElement> itemMyDictionaries)
        {
            var temp = new Dictionary<string, string>();
            
            foreach (DictionaryPasswordElement itemMyDictionary in itemMyDictionaries)
            {
                temp.Add(itemMyDictionary.Word, itemMyDictionary.Description);
            }
            return temp;
        }

       
        #endregion
    }
}