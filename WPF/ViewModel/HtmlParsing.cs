using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Media;
using Syncfusion.Windows.Tools.Controls;
using WPF.Model;

namespace WPF.ViewModel
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
                else if (element.Description.Contains("wyjaœnienie etymologiczne wyrazu"))
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
    }
}