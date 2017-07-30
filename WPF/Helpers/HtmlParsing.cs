using System.Collections.ObjectModel;
using System.Windows.Media;
using Syncfusion.Windows.Tools.Controls;
using WPF.Model;

namespace WPF.Helpers
{
    public static class HtmlParsing
    {
        public static DocumentAdv ParsowanieHtml(ObservableCollection<DictionaryPasswordElement> dictionaryPasswordElements)
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
                
                if (element.Description.Contains("has³o"))
                {
                    var spanAdv = new SpanAdv
                    {
                        Text = element.Word + " ",
                        Foreground = Color.FromRgb(0,128,0),
                        FontSize=24,
                        
                    };

                    paragraphPassword.Inlines.Add(spanAdv);
                }
                else if (element.Word.Contains("I,") || element.Word.Contains("II,") || element.Word.Contains("III,") || element.Word.Contains("IV,")||
                         element.Word.Contains("I ") || element.Word.Contains("II ") || element.Word.Contains("III ") || element.Word.Contains("IV "))
                {
                    var hyperlinkAdv = new HyperlinkAdv
                    {
                        Text = element.Word + " ",
                        NavigationUrl = @"tabele/meski_" + element.Word.Trim(',') + ".jpg",
                        Foreground = Colors.DarkBlue
                    };
                    
                    paragraphPassword.Inlines.Add(hyperlinkAdv);
                }
                else if (element.Description.Contains("definicja"))
                {
                    //var hyperlinkAdv = new HyperlinkAdv
                    //{
                    //    Text = element.Word + " \n",
                    //    NavigationUrl = "javascript:alert('" + element.Description + "')",
                    //    Foreground = Colors.Black
                    //};
                    //paragraphDescryption.Inlines.Add(shyperlinkAdv);
                    var spanAdv = new SpanAdv
                    {
                        Text = element.Word + " \n"
                    };
                    paragraphDescryption.Inlines.Add(spanAdv);
                }
                else if (element.Description.Contains("cytat"))
                {
                    var paragraphCitation = new ParagraphAdv
                    {
                        ListType = ListType.Bulleted
                    };
                    sectionAdv.Blocks.Add(paragraphCitation);

                    //var hyperlinkAdv = new HyperlinkAdv
                    //{
                    //    Text = element.Word + " \n",
                    //    NavigationUrl = "javascript:alert('" + element.Description + "')",
                    //    Foreground = Colors.Black
                    //};
                    //paragraphCitation.Inlines.Add(hyperlinkAdv);
                    var spanAdv = new SpanAdv
                    {
                        Text = element.Word + " \n"
                    };
                    paragraphCitation.Inlines.Add(spanAdv);
                }
                else if (element.Description.Contains("wyjaœnienie etymologiczne wyrazu"))
                {
                    var paragraphLatin = new ParagraphAdv();
                    sectionAdv.Blocks.Add(paragraphLatin);
                    //var hyperlinkAdv = new HyperlinkAdv
                    //{
                    //    Text = element.Word + " ",
                    //    NavigationUrl = "javascript:alert('" + element.Description + "')",
                    //    Foreground = Colors.Black
                    //};
                    //paragraphLatin.Inlines.Add(hyperlinkAdv);
                    var spanAdv = new SpanAdv
                    {
                        Text = element.Word + " "
                    };
                    paragraphLatin.Inlines.Add(spanAdv);
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
    }
}