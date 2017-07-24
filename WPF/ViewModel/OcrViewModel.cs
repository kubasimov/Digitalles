using System;
using Core.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Core.Interface;
using GalaSoft.MvvmLight.Messaging;
using WPF.Interface;
using WPF.Converter;
using WPF.Enum;
using WPF.Helpers;
using WPF.Model;
using WPF.View;

namespace WPF.ViewModel
{
    public class OcrViewModel : ViewModelBase
    {
        #region Private Field

        private readonly IDataService _dataService;
        private readonly ICoreOcr _coreOcr;
        private readonly IDataExchangeViewModel _dataExchangeViewModel;
        private readonly SettingsModel _settingsModel;
        private readonly List<LangModel> _languages;
        private ObservableCollection<DocumentAdv> _documentsAdv;
        private DictionaryModel _dictionaryModel;
        #endregion
        
        //constructor
        public OcrViewModel(IDataService dataService,ICoreOcr coreOcr,IDataExchangeViewModel dataExchangeViewModel)
        {
            _coreOcr = coreOcr;
            _dataService = dataService;
            _dataExchangeViewModel = dataExchangeViewModel;
            _settingsModel = _dataService.LoadSettings();
            _pageCounter = 0;
            _languages = _settingsModel.Language;
            _dictionaryModel=new DictionaryModel();

            if (IsInDesignMode)
            {
                _bitmapImages = new ObservableCollection<BitmapImage>
                {
                    new BitmapImage(new Uri(@"F:/1.jpg")),
                    new BitmapImage(new Uri(@"F:/3.jpg")),
                    new BitmapImage(new Uri(@"F:/1.jpg")),
                    new BitmapImage(new Uri(@"F:/3.jpg")),
                    new BitmapImage(new Uri(@"F:/1.jpg")),
                    new BitmapImage(new Uri(@"F:/3.jpg"))
                };

                _bitmapImage = _bitmapImages[_pageCounter];
            }
            else
            {
                _bitmapImages =new ObservableCollection<BitmapImage>();
            }
            
            _documentsAdv = new ObservableCollection<DocumentAdv>();
        }

        //restart all 
        private void ExecuteNewCommand()
        {
            _bitmapImage = null;
            _bitmapImages = new ObservableCollection<BitmapImage>();
            _pageCounter = 0;
            _dictionaryModel = new DictionaryModel() ;
            _documentsAdv = new ObservableCollection<DocumentAdv>();
            DocumentAdv = null;
            RaisePropertyChanged(BitmapImagePropertyName);
            RaisePropertyChanged(BitmapImagesPropertyName);
            RaisePropertyChanged(DocumentADVPropertyName);
            
            ExecuteShowImage(0);
        }

        //open image
        private void ExecuteOpenImage()
        {
            _bitmapImages = _dataService.LoadImages();
            _bitmapImage = _bitmapImages[_pageCounter];

            RaisePropertyChanged(BitmapImagePropertyName);
            RaisePropertyChanged(BitmapImagesPropertyName);
        }

        //ocr one page
        private async void ExecuteOcrPage()
        {
            await _coreOcr.LoadImage(_bitmapImage.UriSource.AbsolutePath);

            var text = await _coreOcr.OcrPages(LangListToString.Convert(_languages), _settingsModel.Pages);

            var page = await _coreOcr.DecodeHocr(text);

            _documentsAdv.Add(DocumentAdvCrud.LoadDocumentAdv(page));

            _documentAdv = _documentsAdv[_pageCounter];

            RaisePropertyChanged(DocumentADVPropertyName);
        }
        //TODO: dodac pinformacje o trwaj¹cym rozpoznawaniu
        //ocr many pages
        private async void ExecuteOcrPages()
        {
            foreach (var bitmapImage in _bitmapImages)
            {
                await _coreOcr.LoadImage(bitmapImage.UriSource.AbsolutePath);

                var text = await _coreOcr.OcrPages(LangListToString.Convert(_languages), _settingsModel.Pages);

                var page = await _coreOcr.DecodeHocr(text);

                _documentsAdv.Add(DocumentAdvCrud.LoadDocumentAdv(page));
            }

            _documentAdv = _documentsAdv[_pageCounter];

            RaisePropertyChanged(DocumentADVPropertyName);
        }

        //show paragraph
        private void ExecuteShowParagraphCommand()
        {
            foreach (var sectionAdv in _documentAdv.Sections)
            {
                foreach (var blockAdv in sectionAdv.Blocks)
                {
                    foreach (var inline1 in blockAdv.Inlines)
                    {
                        var inline = (SpanAdv) inline1;
                        inline.Foreground = Colors.Red;
                    }
                }
            }

            RaisePropertyChanged(DocumentADVPropertyName);
        }

        //change ocr language
        private void ExecuteSelectLanguage()
        {
            new OcrSettings().ShowDialog();

            if (_dataExchangeViewModel.ContainsKey(EnumExchangeViewmodel.Language))
            {
                var t = _dataExchangeViewModel.Item(EnumExchangeViewmodel.Language);
            }
        }

        //exit window
        private void ExecuteExitCommand()
        {
            _dataExchangeViewModel.Add(EnumExchangeViewmodel.Dictionary,_dictionaryModel );
            Messenger.Default.Send(new NotificationMessage(this, "CloseOcr"));
        }

        //save page text to dictionary
        private void ExecuteSavePageCommand()
        {
            var dictionaryParagraph = GenerateDictionaryParagrapsFromDocumentAdv(_documentAdv);

           
            foreach (var item in dictionaryParagraph)
            {
                _dictionaryModel.Add(item.Split(' ').First(), item.Substring(item.IndexOf(" ")+1));
            }

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
            //_pageCounter = (int)obj;
            //if (_pageCounter < 0) _pageCounter = 0;
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
        
        

        #region Command
        private RelayCommand _openImageCommand;
        
        public RelayCommand OpenImageCommand => _openImageCommand
                                         ?? (_openImageCommand = new RelayCommand(ExecuteOpenImage));

        private RelayCommand _ocrPagesCommand;

        public RelayCommand OcrPagesCommand => _ocrPagesCommand
                                       ?? (_ocrPagesCommand = new RelayCommand(ExecuteOcrPages));

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

        private RelayCommand _showParagraphCommand;

        public RelayCommand ShowParagraphCommand => _showParagraphCommand
                                                    ?? (_showParagraphCommand = new RelayCommand(ExecuteShowParagraphCommand));

        private RelayCommand _newCommand;

        public RelayCommand NewNewCommand => _newCommand
                                         ?? (_newCommand = new RelayCommand(ExecuteNewCommand));

        
        
        #endregion

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

        #region Private Method

        private void AddActualyImage()
        {
            if(_bitmapImages.Count>0)
                _bitmapImage = _bitmapImages[_pageCounter];
        }

        private IEnumerable<string> GenerateDictionaryParagrapsFromDocumentAdv(DocumentAdv documentAdv)
        {
            var dictionaryParagraph = new List<string>();

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
                    dictionaryParagraph.Add(t);
                }
            }
            return dictionaryParagraph;
        }
        #endregion
    }
}





