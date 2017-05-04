using System;
using Core;
using Core.Decode;
using Core.Interface;
using Core.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WPF.Interface;
using Cursors = System.Windows.Input.Cursors;

namespace WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Interface to load data (image)
        /// </summary>
        private readonly IDataService _dataService;

        /// <summary>
        /// Collection DocumentAdv
        /// </summary>
        private ObservableCollection<TextPage> _pages;


        readonly Start _start = new Start();

        private List<TextPage> page;
        
        public MainViewModel(IDataService dataService)
        {
            if (IsInDesignMode)
            {
                _pageCounter = 0;
                _bitmapImages = new ObservableCollection<BitmapImage>();
                _bitmapImages.Add(new BitmapImage(new Uri(@"F:/1.jpg")));
                _bitmapImages.Add(new BitmapImage(new Uri(@"F:/3.jpg")));
                _bitmapImages.Add(new BitmapImage(new Uri(@"F:/1.jpg")));
                _bitmapImages.Add(new BitmapImage(new Uri(@"F:/3.jpg")));
                _bitmapImages.Add(new BitmapImage(new Uri(@"F:/1.jpg")));
                _bitmapImages.Add(new BitmapImage(new Uri(@"F:/3.jpg")));

                _bitmapImage = _bitmapImages[_pageCounter];
            }
            else
            {
                _pageCounter = 0;
                _bitmapImages =new ObservableCollection<BitmapImage>();
            }
            _dataService = dataService;
            
            _pages = new ObservableCollection<TextPage>();
        }

        private void ExecuteOpenImage()
        {
            _bitmapImages=_dataService.LoadImages();
            _bitmapImage = _bitmapImages[PageCounter];

            RaisePropertyChanged(BitmapImagePropertyName);
            RaisePropertyChanged(BitmapImagesPropertyName);
        }

        private void ExecuteOcrText()
        {
            foreach (var bitmapImage in _bitmapImages)
            {
                _start.ReadFile(bitmapImage.UriSource.AbsolutePath);

                var _pier = Mouse.OverrideCursor;

                Mouse.OverrideCursor=Cursors.Wait;
                
                var text = _start.Ocr();

                Mouse.OverrideCursor = _pier;

                page = new DecodeHocr().Decode(text);

                LoadDocumentADV(page);

                RaisePropertyChanged(DocumentADVPropertyName);
            }
                
            
        }

        private void ExecuteShowImage(object obj)
        {
            if (obj==null) return;
            _bitmapImage = _bitmapImages[(int)obj];
            RaisePropertyChanged(BitmapImagePropertyName);
            RaisePropertyChanged(BitmapImagesPropertyName);
        }

        private void LoadDocumentADV(List<TextPage> pages)
        {   
            _documentAdv = new DocumentAdv();
            SectionAdv sectionAdv = new SectionAdv();
            _documentAdv.Sections.Add(sectionAdv);

            foreach (var textPage in page)
            {
                foreach (var paragraph in textPage.Paragraphs)
                {
                    var paragraphAdv = new ParagraphAdv();
                    sectionAdv.Blocks.Add(paragraphAdv);

                    foreach (var line in paragraph.Lines)
                    {
                        
                        foreach (var word in line.Words)
                        {
                            SpanAdv spanAdv = new SpanAdv();
                            spanAdv.Text = word.Word;
                            paragraphAdv.Inlines.Add(spanAdv);
                        }
                    }


                }
            }

        }

        #region Command
        private RelayCommand _openImageCommand;
        
        public RelayCommand OpenImage
        {
            get
            {
                return _openImageCommand
                    ?? (_openImageCommand = new RelayCommand(ExecuteOpenImage));
            }
        }

        private RelayCommand _ocrTextCommand;

        public RelayCommand OcrText
        {
            get
            {
                return _ocrTextCommand
                    ?? (_ocrTextCommand = new RelayCommand(ExecuteOcrText));
            }
        }

        private RelayCommand<object> _showImageCommand;
        
        public RelayCommand<object> ShowImage
        {
            get
            {
                return _showImageCommand
                    ?? (_showImageCommand = new RelayCommand<object>(ExecuteShowImage));
            }
        }

        
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
            get
            {
                return _documentAdv;
            }

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
            get { return _bitmapImage; }

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
            get
            {
                return _bitmapImages;
            }

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
            get
            {
                return _pageCounter;
            }

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
    }
}





