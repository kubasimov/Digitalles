using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Core.Interface;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;
using WPF.Interface;
using WPF.Converter;
using WPF.Enum;
using WPF.Helpers;
using WPF.Model;
using WPF.View;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

namespace WPF.ViewModel
{
    [SuppressMessage("ReSharper", "ExplicitCallerInfoArgument")]
    public class OcrViewModel : ViewModelBase
    {
        #region Private Field

        private readonly IDataService _dataService;
        private readonly ICoreOcr _coreOcr;
        private readonly IDataExchangeViewModel _dataExchangeViewModel;
        private SettingsModel _settingsModel;
        private List<LangModel> _languages;
        private ObservableCollection<DocumentAdv> _documentsAdv;
        
        #endregion
        
        //constructor
        public OcrViewModel(IDataService dataService,ICoreOcr coreOcr,IDataExchangeViewModel dataExchangeViewModel)
        {
            _coreOcr = coreOcr;
            _dataService = dataService;
            _dataExchangeViewModel = dataExchangeViewModel;
            _settingsModel = _dataService.LoadSettings();
            _pageCounter = 0;
            _languages = new List<LangModel> {_settingsModel.Language.First(c => c.Name == "Polski")};

            _selectionAdvtext = new SelectionAdv();
           

            if (IsInDesignMode)
            {
                _bitmapImages = new ObservableCollection<BitmapImage>
                {
                    new BitmapImage(new Uri(@"D:/1.jpg")),
                    new BitmapImage(new Uri(@"D:/3.jpg")),
                    new BitmapImage(new Uri(@"D:/1.jpg")),
                    new BitmapImage(new Uri(@"D:/3.jpg")),
                    new BitmapImage(new Uri(@"D:/1.jpg")),
                    new BitmapImage(new Uri(@"D:/3.jpg"))
                };

                _bitmapImage = _bitmapImages[_pageCounter];
                
            }
            else
            {
                _bitmapImages =new ObservableCollection<BitmapImage>();
            }
            
            _documentsAdv = new ObservableCollection<DocumentAdv>();
        }

        //Zerowanie zmiennych
        private void ExecuteNewCommand()
        {
            _bitmapImage = null;
            _bitmapImages = new ObservableCollection<BitmapImage>();
            _pageCounter = 0;
            _documentsAdv = new ObservableCollection<DocumentAdv>();
            _documentAdv = null;
            _buttonOcrEnabled = false;
            _buttonAnalyzeEnabled = false;
            _buttonSaveEnabled = false;

            RaisePropertyChanged(BitmapImagePropertyName);
            RaisePropertyChanged(BitmapImagesPropertyName);
            RaisePropertyChanged(DocumentADVPropertyName);

            RaisePropertyChanged(ButtonOcrEnabledPropertyName);
            RaisePropertyChanged(ButtonAnalyzePropertyName);
            RaisePropertyChanged(ButtonSavePropertyName);
            ExecuteShowImage(0);
        }

        //Wczytanie obrazu
        private void ExecuteOpenImage()
        {
            _bitmapImages = _dataService.LoadImages();
            if (_bitmapImages.Count > 0)
            {
                _bitmapImage = _bitmapImages[_pageCounter];
                _buttonOcrEnabled = true;
            }
               
            RaisePropertyChanged(BitmapImagePropertyName);
            RaisePropertyChanged(BitmapImagesPropertyName);
            RaisePropertyChanged(ButtonOcrEnabledPropertyName);
        }

        //Rozpoznanie strony
        private async void ExecuteOcrPage()
        {
            //_showBusy = true;
            //RaisePropertyChanged(ShowBusyPropertyName);

            //await _coreOcr.LoadImage(Path.GetFullPath(_bitmapImage.UriSource.AbsolutePath).Replace("%20"," "));
            try
            {
                MessageBox.Show("Poczatek", "Info", MessageBoxButtons.OK);
                var text = await _coreOcr.OcrPages(LangListToString.Convert(_languages), _settingsModel.Pages);
                MessageBox.Show("Dekodowanie HOCR", "Info", MessageBoxButtons.OK);
                var page = await _coreOcr.DecodeHocr(text);

                _documentsAdv.Add(DocumentAdvCrud.LoadDocumentAdv(page));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "B³ad rozpoznawania",MessageBoxButtons.OK);
            }
            

            _showBusy = false;
            RaisePropertyChanged(ShowBusyPropertyName);
            
            _documentAdv = _documentsAdv[_pageCounter];
            RaisePropertyChanged(DocumentADVPropertyName);

            _buttonAnalyzeEnabled = true;
            _buttonSaveEnabled = true;
            RaisePropertyChanged(ButtonAnalyzePropertyName);
            RaisePropertyChanged(ButtonSavePropertyName);
        }

        //przes³anie tekstu do analizy has³a
        private void ExecuteRecognizeTextCommand()
        {
            if (_documentAdv!=null)
                _dataExchangeViewModel.Add(EnumExchangeViewmodel.TextToRecognize,_documentAdv);

            new RecognizeView().Show();
        }

        //save page text to dictionary
        private void ExecuteSavePageCommand()
        {
            var dictionaryParagraph = GenerateDictionaryParagrapsFromDocumentAdv(_documentAdv);

            var saveFileDialog = new SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter =
                   "JSON (*.json)|*.json|" +
                    "html (*.html)|*.html|"+
                    "Plain text (*.txt)|*.txt",

               Title = "Zapis tekstu"
            };
            
            var result = saveFileDialog.ShowDialog();

            if (result != true) return;
            switch (saveFileDialog.FilterIndex)
            {
                case 1:
                    File.WriteAllText(saveFileDialog.FileName,JsonConvert.SerializeObject(dictionaryParagraph,Formatting.Indented));
                    break;

                case 2:
                    HTMLExporting.ConvertToHtml(_documentAdv, File.Create(saveFileDialog.FileName));
                    break;
                
                default:
                    File.WriteAllText(saveFileDialog.FileName,dictionaryParagraph);
                    break;
            }
            
        }

        //change ocr language and settings
        private void ExecuteSelectLanguage()
        {
            new OcrSettings().ShowDialog();

            if (_dataExchangeViewModel.ContainsKey(EnumExchangeViewmodel.Language))
            {
                _settingsModel = (SettingsModel)_dataExchangeViewModel.Item(EnumExchangeViewmodel.Language);

                _languages = _settingsModel.Language;
            }
        }

        //exit window
        private void ExecuteExitCommand()
        {
            //_dataExchangeViewModel.Add(EnumExchangeViewmodel.Dictionary,_dictionaryModel );
            Messenger.Default.Send(new NotificationMessage(this, "CloseOcr"));
        }
        
        //save pages text to dictionary
        private void ExecuteSavePagesCommand()
        {
            //TODO:SavePagesCommand
        }
        
        //show imge from left panel in image window
        private void ExecuteShowImage(object obj)
        {
            if (obj == null) return;
            
            _pageCounter=(int)obj<0 ? 0: (int) obj;  

            AddActualyImage();

            if (_documentsAdv.Count > 0 && _documentsAdv.Count >= _pageCounter)
            {
                _documentAdv = _documentsAdv[_pageCounter];
            }

            RaisePropertyChanged(BitmapImagePropertyName);
            RaisePropertyChanged(BitmapImagesPropertyName);
            RaisePropertyChanged(DocumentADVPropertyName);
        }

        
        //Metody podpiete do przycisków View
        #region Command
        private RelayCommand _openImageCommand;
        
        public RelayCommand OpenImageCommand => _openImageCommand
                                         ?? (_openImageCommand = new RelayCommand(ExecuteOpenImage));

        private RelayCommand<object> _showImageCommand;
        
        public RelayCommand<object> ShowImageCommand => _showImageCommand
                                                 ?? (_showImageCommand = new RelayCommand<object>(ExecuteShowImage));
        private RelayCommand _ocrPageCommand;
        
        public RelayCommand OcrPage => _ocrPageCommand
                                       ?? (_ocrPageCommand = new RelayCommand(ExecuteOcrPage));

        private RelayCommand _selectLanguageCommand;

        public RelayCommand SelectLanguageCommand => _selectLanguageCommand
                                              ?? (_selectLanguageCommand = new RelayCommand(ExecuteSelectLanguage));

        private RelayCommand _exitCommand;
        
        public RelayCommand ExitCommand => _exitCommand
                                           ?? (_exitCommand = new RelayCommand(ExecuteExitCommand));

        private RelayCommand _savePageCommand;

        public RelayCommand SavePageCommand => _savePageCommand
                                               ?? (_savePageCommand = new RelayCommand(ExecuteSavePageCommand));

        private RelayCommand _savePagesCommand;

        public RelayCommand SavePagesCommand => _savePagesCommand
                                               ?? (_savePagesCommand = new RelayCommand(ExecuteSavePagesCommand));

        private RelayCommand _newCommand;

        public RelayCommand NewNewCommand => _newCommand
                                         ?? (_newCommand = new RelayCommand(ExecuteNewCommand));

        private RelayCommand _recognizeTextCommand;

        public RelayCommand RecognizeTextCommand => _recognizeTextCommand
                                                    ?? (_recognizeTextCommand = new RelayCommand(ExecuteRecognizeTextCommand));

        #endregion

        //wybrany dokument
        #region SelectionADV
        /// <summary>
        /// The <see cref="SelectionText" /> property's name.
        /// </summary>
        public const string SelectionAdvTextPropertyName = "SelectionText";

        private SelectionAdv _selectionAdvtext   ;

        /// <summary>
        /// Sets and gets the SelectionText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SelectionAdv SelectionText
        {
            get
            {
                return _selectionAdvtext ;
            }

            set
            {
                if (_selectionAdvtext  == value)
                {
                    return;
                }

                _selectionAdvtext  = value;
                RaisePropertyChanged(SelectionAdvTextPropertyName);
            }
        }
        #endregion

        //wybrany dokument
        #region DocumentAdv
        /// <summary>
        /// The <see cref="DocumentAdv" /> property's name.
        /// </summary>
        public const string DocumentADVPropertyName = "DocumentAdv";

        private DocumentAdv _documentAdv;

        /// <summary>
        /// Sets and gets the DocumentAdv property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
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
                RaisePropertyChanged(DocumentADVPropertyName);
            }
        }
        #endregion
        
        //aktualny obraz
        #region BitmapImage
        /// <summary>
        /// The <see cref="BitmapImage" /> property's name.
        /// </summary>
        public const string BitmapImagePropertyName = "BitmapImage";
        
        private BitmapImage _bitmapImage;

        /// <summary>
        /// Sets and gets the BitmapImage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public BitmapImage BitmapImage
        {
            get => _bitmapImage;

            set
            {
                if (_bitmapImage == value)
                {
                    return;
                }

                _bitmapImage = value;
                RaisePropertyChanged(BitmapImagePropertyName);
            }
        }
        #endregion

        //wczytaneobrazy
        #region BitmapImages
        /// <summary>
        /// The <see cref="BitmapImages" /> property's name.
        /// </summary>
        public const string BitmapImagesPropertyName = "BitmapImages";

        private ObservableCollection<BitmapImage> _bitmapImages;

        /// <summary>
        /// Sets and gets the BitmapImages property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<BitmapImage> BitmapImages
        {
            get => _bitmapImages;

            set
            {
                if (_bitmapImages == value)
                {
                    return;
                }

                _bitmapImages = value;
                RaisePropertyChanged(BitmapImagesPropertyName);
            }
        }
        #endregion

        //licznik strony
        #region PageCount
        /// <summary>
        /// The <see cref="PageCounter" /> property's name.
        /// </summary>
        public const string PageCounterPropertyName = "PageCounter";

        private int _pageCounter;

        /// <summary>
        /// Sets and gets the PageCounter property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int PageCounter
        {
            get => _pageCounter;

            set
            {
                if (_pageCounter == value)
                {
                    return;
                }

                _pageCounter = value;
                RaisePropertyChanged(PageCounterPropertyName);
            }
        }
        #endregion

        //wiatrak dzi³ania tesseract
        #region ShowBusy
        public const string ShowBusyPropertyName = "ShowBusy";

        private bool _showBusy = false;

        public bool ShowBusy
        {
            get => _showBusy;

            set
            {
                if (_showBusy == value)
                {
                    return;
                }

                _showBusy = value;
                RaisePropertyChanged(ShowBusyPropertyName);
            }
        }
        #endregion

        //widocznoœc klawisza rozpoznania obrazu
        #region ButtonOcrEnabled

        public const string ButtonOcrEnabledPropertyName = "ButtonOcrEnabled";

        private bool _buttonOcrEnabled = false;

        /// <summary>
        /// Sets and gets the ButtonOcrEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ButtonOcrEnabled
        {
            get => _buttonOcrEnabled;

            set
            {
                if (_buttonOcrEnabled == value)
                {
                    return;
                }

                _buttonOcrEnabled = value;
                RaisePropertyChanged(ButtonOcrEnabledPropertyName);
            }
        }

        #endregion

        //widocznoœæ klawisza analizy has³a
        #region ButtonAnalyzeEnabled

        public const string ButtonAnalyzePropertyName = "ButtonAnalyzeEnabled";

        private bool _buttonAnalyzeEnabled = false;

        /// <summary>
        /// Sets and gets the ButtonOcrEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ButtonAnalyzeEnabled
        {
            get => _buttonAnalyzeEnabled;

            set
            {
                if (_buttonAnalyzeEnabled == value)
                {
                    return;
                }

                _buttonAnalyzeEnabled = value;
                RaisePropertyChanged(ButtonAnalyzePropertyName);
            }
        }

        #endregion

        //widocznoœc klawiasza zapisu
        #region ButtonSaveEnabled

        public const string ButtonSavePropertyName = "ButtonSaveEnabled";

        private bool _buttonSaveEnabled = false;

        /// <summary>
        /// Sets and gets the ButtonOcrEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool ButtonSaveEnabled
        {
            get
            {
                return _buttonSaveEnabled;
            }

            set
            {
                if (_buttonSaveEnabled == value)
                {
                    return;
                }

                _buttonSaveEnabled = value;
                RaisePropertyChanged(ButtonSavePropertyName);
            }
        }

        #endregion

        #region Private Method

        private void AddActualyImage()
        {
            if(_bitmapImages.Count>0)
                _bitmapImage = _bitmapImages[_pageCounter];
        }

        private string GenerateDictionaryParagrapsFromDocumentAdv(DocumentAdv documentAdv)
        {
            var dictionaryParagraph = "";

            foreach (var sectionAdv in documentAdv.Sections)
            {
                foreach (var blockAdv in sectionAdv.Blocks)
                {
                    var t = "";
                    foreach (var inline in blockAdv.Inlines)
                    {
                        var inline2 = (SpanAdv)inline;
                        t = t + inline2.Text;
                    }
                    dictionaryParagraph = dictionaryParagraph+t;
                }
            }
            return dictionaryParagraph;
        }
        #endregion
    }
}





