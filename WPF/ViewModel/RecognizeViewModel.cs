using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using java.nio.file;
using morfologik.speller;
using Newtonsoft.Json;
using Syncfusion.Windows.Tools.Controls;
using WPF.Enum;
using WPF.Helpers;
using WPF.Interface;
using WPF.View;
using RecognizePassword.Implement;
using RecognizePassword.Interface;
using WPF.Model;
using WPF.Properties;
using DictionaryPasswordElement = RecognizePassword.Model.DictionaryPasswordElement;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace WPF.ViewModel
{
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public class RecognizeViewModel:ViewModelBase
    {
        private Dictionary<string, string> _dictionary;
        private readonly TextImporting _textImporting = new TextImporting();
        private readonly IFactoryRecognizePassword _recognizePasswordText;
        private readonly IDataExchangeViewModel _dataExchangeViewModel;

        public RecognizeViewModel(IDataExchangeViewModel dataExchangeViewModel)
        {
            _dataExchangeViewModel = dataExchangeViewModel;

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

                _recognizePasswordListObservableCollection = new ObservableCollection<DictionaryPasswordElement>
                {
                    new DictionaryPasswordElement {Word = "AAd1", Description = "aa1"},
                    new DictionaryPasswordElement {Word = "AA2", Description = "aa2"},
                    new DictionaryPasswordElement {Word = "AA3", Description = "aa3"}
                };

                
            }
            else
            {
                if (_dataExchangeViewModel.ContainsKey(EnumExchangeViewmodel.TextToRecognize))
                {
                    _textToRecognize = (DocumentAdv)_dataExchangeViewModel.Item(EnumExchangeViewmodel.TextToRecognize);
                }
                else
                {
                    _textToRecognize = new DocumentAdv();
                }
                _recognizePasswordListObservableCollection = new ObservableCollection<DictionaryPasswordElement>();

                LoadDictionaryPassword();
            }
            _recognizePasswordText = new FactoryRecognizePassword();
        }

        //wczytanie pliku z tekstem
        private void ExecuteOpenCommand()
        {
            try
            {
                var openFileDialog = new OpenFileDialog
                {
                    Filter =
                        "Plain text (*.txt)|*.txt|"+
                         "JSON (*.json)|*.json|" +
                        "html (*.html)|*.html" ,
                        

                    Multiselect = false
                };

                var result = openFileDialog.ShowDialog();

                if (result != true) return;
                switch (openFileDialog.FilterIndex)
                {
                    case 1:
                        _textToRecognize = _textImporting.ConvertToDocumentAdv(File.Open(openFileDialog.FileName, FileMode.Open));
                        break;
                    case 2:
                        _textToRecognize = _textImporting.ConvertToDocumentAdv(JsonConvert.DeserializeObject<string>(File.ReadAllText(openFileDialog.FileName)));
                        break;
                    default:
                        _textToRecognize =
                            HTMLImporting.ConvertToDocumentAdv(File.OpenRead(openFileDialog.FileName));
                        break;
                }
                _enableAfterOpen = true;
                RaisePropertyChanged(EnableAfterOpenPropertyName);

                RaisePropertyChanged(TextToRecognizePropertyName);
            }
            catch (Exception)
            {
                MessageBox.Show(Resources.ErrorLoadDictionary, Resources.ErrorLoad, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //zapis zanalizowanego hasła do pliku
        private void ExecuteSaveCommand()
        {
            if (_recognizePasswordListObservableCollection.Count <= 0) return;

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Digitalles"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) +
                                          @"\Digitalles");
            }
            var filename = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Digitalles\" + _recognizePasswordListObservableCollection[0].Word + ".json";

            File.WriteAllText(filename, JsonConvert.SerializeObject(_recognizePasswordListObservableCollection, Formatting.Indented));
        }

        //zapis jako... zanalizowanego hasła do pliku
        private void ExecuteSaveAsCommand()
        {
            if (_recognizePasswordListObservableCollection.Count <= 0) return;

            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter =
                    "JSON (*.json)|*.json|" +
                    "html (*.html)|*.html|" +
                    "Plain text (*.txt)|*.txt",

                Title = "Zapis"
            };

            var result = saveFileDialog.ShowDialog();

            if (result != true) return;
            switch (saveFileDialog.FilterIndex)
            {
                case 1:
                    File.WriteAllText(saveFileDialog.FileName,
                        JsonConvert.SerializeObject(_recognizePasswordListObservableCollection,
                            Formatting.Indented));
                    break;

                case 2:
                    HTMLExporting.ConvertToHtml(HtmlParsing.ParsowanieHtml(_recognizePasswordListObservableCollection), File.Create(saveFileDialog.FileName));
                    break;

                default:
                    File.WriteAllText(saveFileDialog.FileName, ConvertToTxt(_recognizePasswordListObservableCollection));
                    break;
            }
        }

        //eksport hasła do słownika
        private void ExecuteExportToDictionary()
        {
            if (_recognizePasswordListObservableCollection.Count <= 0) return;
            var saveFileDialog = new SaveFileDialog
            {
                Filter =
                    "JSON (*.json)|*.json",
                Title = "Zapis"
            };

            var result = saveFileDialog.ShowDialog();

            if (result != true) return;
            
            List<List<DictionaryPasswordElement>> dictionaryFromFile;

            if (File.Exists(saveFileDialog.FileName))
            {
                dictionaryFromFile =
                    JsonConvert.DeserializeObject<List<List<DictionaryPasswordElement>>>
                        (File.ReadAllText(saveFileDialog.FileName));
            }
            else
            {
                dictionaryFromFile = new List<List<DictionaryPasswordElement>>();
            }

            dictionaryFromFile.Add(_recognizePasswordListObservableCollection.ToList());
            dictionaryFromFile.Sort(SortDictionary);
            File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(
                dictionaryFromFile, Formatting.Indented));
        }

        //analiza hasła
        private void ExecuteAnalizeCommand()
        {
            _recognizePasswordListObservableCollection.Clear();
            _recognizePasswordListObservableCollection = _recognizePasswordText.Recognize(TextExporting.ConvertToText(_textToRecognize), _dictionary);

            RaisePropertyChanged(RecognizePasswordListPropertyName);
            _enableAfterAnalize = true;
            RaisePropertyChanged(EnableAfterAnalizePropertyName);
        }

        //Sprawdzanie pisowni
        private void ExecuteSpellCommand()
        {
            var text = TextExporting.ConvertToText(_textToRecognize);

            var spellList = Spell(text);

            if (spellList.Count <= 0) return;
            _dataExchangeViewModel.Add(EnumExchangeViewmodel.SpellDictionary, spellList);
            new SpellerView().Show();
        }
        
        //koniec
        private void ExecuteExitCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseRecognizeView"));
        }

        //zerowanie wartości
        private void ExecuteNewCommand()
        {
            _textToRecognize=new DocumentAdv();
            RaisePropertyChanged(TextToRecognizePropertyName);

            _recognizePasswordListObservableCollection = new ObservableCollection<DictionaryPasswordElement>();
            RaisePropertyChanged(RecognizePasswordListPropertyName);

            _enableAfterAnalize = false;
            _enableAfterOpen = false;
            RaisePropertyChanged(EnableAfterAnalizePropertyName);
            RaisePropertyChanged(EnableAfterOpenPropertyName);
        }

        

        private void ExecuteSettingsCommand()
        {
            
        }

        
        //Wywołanie okna podglądu
        private void ExecutePreviewCommand()
        {
            //_dataExchangeViewModel.Add(EnumExchangeViewmodel.Preview,ParsowanieHtml(_recognizePasswordListObservableCollection));
            //_dataExchangeViewModel.Add(EnumExchangeViewmodel.Preview, _textToRecognize);
            ExecuteExportToDictionary();

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

        private RelayCommand _openCommand;

        public RelayCommand OpenCommand => _openCommand
                                           ?? (_openCommand = new RelayCommand(ExecuteOpenCommand));
        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand => _saveCommand
                                           ?? (_saveCommand = new RelayCommand(ExecuteSaveCommand));
        private RelayCommand _saveAsCommand;

        public RelayCommand SaveAsCommand => _saveAsCommand
                                             ?? (_saveAsCommand = new RelayCommand(ExecuteSaveAsCommand));
        private RelayCommand _exportToDictionaryCommand;

        public RelayCommand ExportToDictionary => _exportToDictionaryCommand
                                                  ?? (_exportToDictionaryCommand = new RelayCommand(ExecuteExportToDictionary));
        private RelayCommand _exitCommand;

        public RelayCommand ExitCommand => _exitCommand
                                           ?? (_exitCommand = new RelayCommand(ExecuteExitCommand));
        private RelayCommand _analizeCommand;

        public RelayCommand AnalizeCommand => _analizeCommand
                                                ?? (_analizeCommand = new RelayCommand(ExecuteAnalizeCommand));
        private RelayCommand _spellCommand;

        public RelayCommand SpellCommand => _spellCommand
                                            ?? (_spellCommand = new RelayCommand(ExecuteSpellCommand));

       
        private RelayCommand _newCommand;

        public RelayCommand NewCommand => _newCommand
                                          ?? (_newCommand = new RelayCommand(ExecuteNewCommand));
        private RelayCommand _pasteCommand;

        public RelayCommand PasteCommand => _pasteCommand
                                            ?? (_pasteCommand = new RelayCommand(ExecutePasteCommand));
        private RelayCommand _previewCommand;

        public RelayCommand PreviewCommand => _previewCommand
                                              ?? (_previewCommand = new RelayCommand(ExecutePreviewCommand));



        private RelayCommand _settingsCommand;
        
        public RelayCommand SettingsCommand => _settingsCommand
                                               ?? (_settingsCommand = new RelayCommand(ExecuteSettingsCommand));

       

        

        

        

        

        

        private void ExecutePasteCommand()
        {

        }
        
        #endregion

        
        #region Mvvm members

            #region MyDigDictionary
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

            #region RecognizePasswordList

           public const string RecognizePasswordListPropertyName = "RecognizePasswordList";

            private ObservableCollection<DictionaryPasswordElement> _recognizePasswordListObservableCollection  ;

            public ObservableCollection<DictionaryPasswordElement> RecognizePasswordList
            {
                get
                {
                    return _recognizePasswordListObservableCollection;
                }

                set
                {
                    if (_recognizePasswordListObservableCollection == value)
                    {
                        return;
                    }

                    _recognizePasswordListObservableCollection = value;
                    RaisePropertyChanged(RecognizePasswordListPropertyName);
                }
            }

        #endregion

            #region EnableAfterOpen

        public const string EnableAfterOpenPropertyName = "EnableAfterOpen";

        private bool _enableAfterOpen = false;

       
        public bool EnableAfterOpen
        {
            get => _enableAfterOpen;

            set
            {
                if (_enableAfterOpen == value)
                {
                    return;
                }

                _enableAfterOpen = value;
                RaisePropertyChanged(EnableAfterOpenPropertyName);
            }
        }

        #endregion

            #region EnableAfterAnalize
        
        public const string EnableAfterAnalizePropertyName = "EnableAfterAnalize";

        private bool _enableAfterAnalize = false;

        public bool EnableAfterAnalize
        {
            get => _enableAfterAnalize;

            set
            {
                if (_enableAfterAnalize == value)
                {
                    return;
                }

                _enableAfterAnalize = value;
                RaisePropertyChanged(EnableAfterAnalizePropertyName);
            }
        }

        #endregion

        #endregion

        #region Private_Method
        //Ładowanie pliku zawierającego sktóty
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
        
        //konwersja danych z słownika na kolekcje
        private ObservableCollection<DictionaryPasswordElement> CopyFromDictionary(Dictionary<string, string> itemDictionary)
        {
            var temp = new ObservableCollection<DictionaryPasswordElement>();

            foreach (KeyValuePair<string, string> keyValuePair in itemDictionary)
            {
                temp.Add(new DictionaryPasswordElement{Word=keyValuePair.Key,Description=keyValuePair.Value});
            }

            return temp;
        }

        //konwersja z kolekcji na tekst
        private static string ConvertToTxt(IEnumerable<DictionaryPasswordElement> recognizePasswordListObservableCollection)
        {
            var str = new StringBuilder();
            foreach (var passwordElement in recognizePasswordListObservableCollection)
            {
                str.AppendFormat("Hasło: {0,-90}\t\t\tObjaśnienie: {1}", passwordElement.Word, passwordElement.Description);
                str.AppendLine();
            }
            return str.ToString();
        }

        //pomocnicza metoda sortująca
        private int SortDictionary(List<DictionaryPasswordElement> x, List<DictionaryPasswordElement> y)
        {
            return string.CompareOrdinal(x[0].Word, y[0].Word);
        }

        //metoda sprawdzająca pisownie
        private ObservableCollection<SpellModel> Spell(string text)
        {
            var path = FileSystems.getDefault().getPath(@"D:\polish.dict");
            var spell = new Speller(morfologik.stemming.Dictionary.read(path));

            var collection = new ObservableCollection<SpellModel>();

            foreach (var s in text.Split(' '))
            {
                
                var words = spell.findReplacements(s);
                
                if (words.isEmpty()) continue;
                var str = new StringBuilder();
                for (var i = 0; i < words.size(); i++)
                {
                    str.AppendFormat("{0}   ", words.get(i));
                }
                
                collection.Add(new SpellModel{Word=s,ListSpell=str.ToString()});
            }
            return collection;
        }

        #endregion
    }
}