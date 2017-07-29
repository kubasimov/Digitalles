using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Win32;
using Newtonsoft.Json;
using Syncfusion.Data.Extensions;
using Syncfusion.Windows.Tools.Controls;
using WPF.Enum;
using WPF.Interface;
using WPF.Model;
using WPF.View;
using Color = System.Windows.Media.Color;

namespace WPF.ViewModel
{
    public class RecognizeViewModel:ViewModelBase
    {
        private Dictionary<string, string> _dictionary;
        private readonly IDataExchangeViewModel _dataExchangeViewModel;
        private readonly TextImporting _textImporting = new TextImporting();
       
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
                    new DictionaryPasswordElement {Word = "AAdkcjabsdvbakdsjbvhabdcvkhabdfvkhabdvhbadfhvbalkdfhbvjahdfbvlkajhdbvjhadbvlahsbdvlhasbdljvhbasdlhvbaljdshbvlahjsdbvljahdsbvljahbsdvjhabsdlvhjba1", Description = "aa1"},
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
                File.WriteAllText(saveFileDialog.FileName, JsonConvert.SerializeObject(_recognizePasswordObservableCollection, Formatting.Indented));

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
            _recognizePasswordObservableCollection = new ObservableCollection<DictionaryPasswordElement>();

            RecognizePasswordText(TextExporting.ConvertToText(_textToRecognize));

            RaisePropertyChanged(RecognizePasswordPropertyName);
        }

        private void ExecuteSaveCommand()
        {
            File.WriteAllText(@"D:\dane\"+ _recognizePasswordObservableCollection[0].Word+".json", JsonConvert.SerializeObject(_recognizePasswordObservableCollection, Formatting.Indented));
        }

        private void ExecuteExportToHtml()
        {
            DocumentAdv textDocumentAdv = ParsowanieHtml(_recognizePasswordObservableCollection);

            using (var t = File.Create(@"D:\dane\text.html"))
            {
                HTMLExporting.ConvertToHtml(textDocumentAdv,t);
            }
            
        }

        private DocumentAdv ParsowanieHtml(ObservableCollection<DictionaryPasswordElement> dictionaryPasswordElements)
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
                        Foreground = Color.FromRgb(0,128,0),
                        FontSize=24,
                        
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

        private void ExecuteSettingsCommand()
        {
            List<List<DictionaryPasswordElement>> tt ;

            if (File.Exists(@"D:\dane\slownik.json"))
            {
                tt =
                    JsonConvert.DeserializeObject<List<List<DictionaryPasswordElement>>>(
                        File.ReadAllText(@"D:\dane\slownik.json"));
            }
            else
            {
                tt = new List<List<DictionaryPasswordElement>>();
            }

            var t = _recognizePasswordObservableCollection.ToList();
            
            tt.Add(t);
            
            File.WriteAllText(@"D:\dane\slownik.json",JsonConvert.SerializeObject(tt,Formatting.Indented));
            
            
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

            private ObservableCollection<DictionaryPasswordElement> _recognizePasswordObservableCollection  ;

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

        #region RecognizeTextMethod

        private int _max;

        private void RecognizePasswordText(string textToRecognize)
        {
            try
            {
                
                //pomocnicze wyświetlenie obrabianego hasła
                System.Console.WriteLine("\n\n" + textToRecognize + "\n\n");

                var temptext = "";

                //pobranie pierwszego słowa jako hasło i zmniejszenie tekstu o te słowo + spacja
                var pass = textToRecognize.Substring(0, textToRecognize.IndexOf(" ", StringComparison.Ordinal));

                WriteText(pass, "hasło");

                textToRecognize = textToRecognize.Remove(0, pass.Length + 1);


                //przejscie po całym zdaniu (bez pierwszego słowa

                var counter = 0;
                _max = textToRecognize.Length;
                int result;

                for (counter = 0; counter < _max; counter++)
                {
                    //wyszukanie znaczenia słowa z podwojnych nawiasach skosnych
                    if (textToRecognize[counter] == '«')
                    {
                        do
                        {
                            temptext += textToRecognize[counter];
                            counter++;
                        } while (textToRecognize[counter] != '»');

                        temptext += textToRecognize[counter];
                        counter++;

                        WriteText(temptext, "definicja");
                        temptext = String.Empty;
                    }

                    //rozpoznanie początku cyctatow
                    if (textToRecognize[counter] == ':')
                    {
                        var isnumeric = false;

                        for (int j = counter + 2; j < textToRecognize.Length; j++)
                        {
                            //cytat kończy się gdy jest koniec linii lub gdy po cyfrze z kropka jest spacja i litera np."1996. Poczatek"
                            //dodanie kolejnego znaku do słowa
                            if (textToRecognize[j] == '<')
                            {
                                break;
                            }


                            temptext += textToRecognize[j];

                            //sprawdzenie czy znak jest liczbą, jesli prawda to flage liczby ustawiamy na true

                            if (int.TryParse(textToRecognize[j].ToString(), out result))
                            {
                                isnumeric = true;
                            }

                            //jesli była znaleziona liczba i kolejny znak to '.' i nastepny znak to spacja i znak to mamy cały cytat 954, s. 570.
                            var letter = false;

                            if (j == _max || j + 1 == _max || j + 2 == _max)
                            {
                                letter = true;
                            }
                            else if (!int.TryParse(textToRecognize[j + 2].ToString(), out result))
                            {
                                letter = true;
                            }

                            if (isnumeric && textToRecognize[j] == '.' && letter)
                            {
                                WriteText(temptext, "cytat");
                                j++;
                                temptext = String.Empty;
                                isnumeric = false;
                                counter = j + 1 > _max ? _max - 1 : j + 1;
                            }
                        }
                    }

                    //rozpoznanie znaczen pomiedzy <>
                    if (textToRecognize[counter] == '<')
                    {
                        do
                        {
                            temptext += textToRecognize[counter];
                            counter++;
                        } while (textToRecognize[counter] != '>');

                        temptext += textToRecognize[counter];
                        //countrer++;

                        WriteText(temptext, "wyjaśnienie etymologiczne wyrazu");
                        temptext = String.Empty;
                    }


                    if (textToRecognize[counter] != ' ')
                    {
                        temptext += textToRecognize[counter];
                        //jesli znaleziono przymiotnik
                        if (temptext == "przym.")
                        {
                            var meaning = RecognizeMeaningWord(temptext);
                            WriteText(temptext, meaning);
                            temptext = String.Empty;
                            counter += 2;

                            do
                            {
                                temptext += textToRecognize[counter];
                                counter++;
                            } while (textToRecognize[counter] != ':');
                            counter--;
                            WriteText(temptext, "Przymiotnik hasła");
                            temptext = String.Empty;

                            //jesli hasło ma numerowane znaczenia
                        }//jesli jest cyfra
                        //else if (int.TryParse(temptext[0].ToString(),out result)&&temptext.Length==2)
                        //{
                        //    //po cyfrze jest kropka
                        //    if (temptext[1]=='.')
                        //    {
                        //        WriteText(temptext,result+" znaczenie hasła");
                        //        temptext = Empty;
                        //    }
                        //}
                    }
                    else
                    {
                        if (temptext != "")
                        {
                            //wyszukanie słowa w słowniku znaczeń
                            var meaning = RecognizeMeaningWord(temptext);
                            WriteText(temptext, meaning);
                            temptext = String.Empty;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }
        }

        private string RecognizeMeaningWord(string text)
        {
            if (_dictionary.ContainsKey(text))
                return _dictionary[text];

            if (text[0] == '~')
                return "końcówka fleksyjna wraz z cząstką tematu";
            if (text[0] == '-')
                return "końcówka fleksyjna";

            if (int.TryParse(text[0].ToString(), out int result) && text.Length == 2 && text[1] == '.')
                return result + " znaczenie hasła";

            if (text.Contains("I") || text.Contains("II") || text.Contains("III") || text.Contains("IV"))
            {
                return text.TrimEnd(',', '.') + " koniugacja/ deklinacja";
            }


            return String.Empty;
        }

        private void WriteText(string text1, string text2 = "")
        {
            _recognizePasswordObservableCollection.Add(new DictionaryPasswordElement{Word=text1,Description=text2});

            Debug.WriteLine("Hasło: {0,-90}\t\t\tObjaśnienie: {1}", text1, text2);
        }

        #endregion
        
        #endregion
    }
}