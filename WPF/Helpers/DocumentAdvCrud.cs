using System.Collections.Generic;
using System.Windows;
using Core.Model;
using Syncfusion.Windows.Tools.Controls;

namespace WPF.Helpers
{
    public static class DocumentAdvCrud
    {
        public static DocumentAdv LoadDocumentAdv(List<TextPage> pages)
        {   
            var documentAdv = new DocumentAdv();
            SectionAdv sectionAdv = new SectionAdv();
            documentAdv.Sections.Add(sectionAdv);

            foreach (var textPage in pages)
            {
                foreach (var paragraph in textPage.Paragraphs)
                {
                    var paragraphAdv = new ParagraphAdv();
                    sectionAdv.Blocks.Add(paragraphAdv);

                    foreach (var line in paragraph.Lines)
                    {
                        foreach (var word in line.Words)
                        {
                            
                            SpanAdv spanAdv = new SpanAdv {Text = word.Word + " "};
                            if(word.Bold)spanAdv.FontWeight = FontWeights.Bold;
                            paragraphAdv.Inlines.Add(spanAdv);
                            
                            
                        }
                    }


                }
            }
            return documentAdv;
        }
    }
}