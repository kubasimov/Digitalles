using Core;
using Core.Decode;
using Core.Interface;
using Core.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using WPF.Interface;

namespace WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        readonly IMyImage _image = new MyImage();
        readonly Start _start = new Start();
        private List<TextPage> page;
        
        
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


        #endregion

        private void ExecuteOcrText()
        {
            if (_bitmapImage.UriSource.AbsolutePath!=" ")
            {
                _image.SetName(_bitmapImage.UriSource.AbsolutePath);

                _start.ReadFile(_image);

                var text = _start.Ocr();

                page = new DecodeHocr().Decode(text);

                LoadDocumentADV(page);

                RaisePropertyChanged(DocumentADVPropertyName);
            }
        }

        private void ExecuteOpenImage()
        {
            _bitmapImage=_dataService.LoadImage();

            RaisePropertyChanged(SourceImagePropertyName);
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
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
           
        }

        #region DocumentADV
        /// <summary>
        /// The <see cref="DocumentADV" /> property's name.
        /// </summary>
        public const string DocumentADVPropertyName = "DocumentADV";

        private DocumentAdv _documentAdv;

        /// <summary>
        /// Sets and gets the DocumentADV property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DocumentAdv DocumentADV
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
        
        #region SourceImage
        /// <summary>
        /// The <see cref="SourceImage" /> property's name.
        /// </summary>
        public const string SourceImagePropertyName = "SourceImage";

        private BitmapImage _bitmapImage;

        /// <summary>
        /// Sets and gets the SourceImage property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public BitmapImage SourceImage
        {
            get { return _bitmapImage; }

            set
            {
                if (_bitmapImage == value)
                {
                    return;
                }

                _bitmapImage = value;
                RaisePropertyChanged(SourceImagePropertyName);
            }
        }
        #endregion
    }
}





