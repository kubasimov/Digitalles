using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Core;
using Core.Decode;
using Core.Interface;
using Core.Model;
using Syncfusion.Windows.Tools.Controls;
using Path = System.IO.Path;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly IMyImage _image = new MyImage();
        readonly Start _start = new Start();
        List<TextLine> _lines = new List<TextLine>();

const string FileName = @"F:/3.jpg";

        public MainWindow()
        {
            InitializeComponent();
            

            var filename = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(FileName), Path.GetFileName(FileName));

            _image.SetName(filename);
            _start.ReadFile(_image);
            var text = _start.Ocr();

            var page = new DecodeHocr().Decode(text);

            
           BitmapImage bitmapImage= new BitmapImage(new Uri(_image.GetName()));


            image11.Source = bitmapImage;


            
            var documentAdv = new DocumentAdv();
            SectionAdv sectionAdv = new SectionAdv();
            documentAdv.Sections.Add(sectionAdv);

                foreach (var textPage in page)
                {
                   
                    foreach (var paragraph in textPage.Paragraphs)
                    {
                        var paragraphAdv = new ParagraphAdv();
                        sectionAdv.Blocks.Add(paragraphAdv);


                        foreach (var line in paragraph.Lines)
                        {
                            _lines.Add(line);
                            
                            
                            foreach (var word in line.Words)
                            {
                                SpanAdv spanAdv = new SpanAdv();
                                spanAdv.Text = word.Word;


                                paragraphAdv.Inlines.Add(spanAdv);
                            }

                            
                        }

                    }
                
            }

            BoxAdv.Document = documentAdv;
        }

        public string DisplayedImagePath => FileName;
    }
}
