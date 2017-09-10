using System;
using System.Collections.Generic;
using static System.Console;
using System.IO;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
using RecognizePassword.Implement;
using RecognizePassword.Interface;
using RecognizePassword.Model;

namespace Console
{
    class Program
    {
        public static Dictionary<string, string> dic;
        public static  Dictionary<string, string> _dictionary;

        static void Main(string[] args)
        {
            LoadDictionaryPassword();

            //var text = "ewoluować ndk IV «rozwijać się; zmieniać się, przechodzić ewolucję»: Łatwiej zmienić przekonania polityczne lub religijne niż bardzo tylko powoli i częściowo ewoluujący język-styl. Jęz. Pol. 1935, s. 43.\r\n<fr. évoluer>\r\n";
            var flag = true;

            while (flag)
            {

                WriteLine("Wczytany tekst");

                var text = File.ReadAllText(@"D:\testWer\text.txt");
                WriteLine(text);

                WriteLine("Podaj numer algorytmu 0-6");
                var nr = Convert.ToInt32(ReadLine());

                switch (nr)
                {
                    case 0:
                    {
                        IRecognizePasswordText recognize = new RecognizePasswordTextType0();
                        RecognizeAndSave(text, recognize);
                        break;
                    }
                    case 1:
                    {
                        IRecognizePasswordText recognize = new RecognizePasswordTextType1();
                        RecognizeAndSave(text, recognize);
                        break;
                    }
                    case 2:
                    {
                        IRecognizePasswordText recognize = new RecognizePasswordTextType2();
                        RecognizeAndSave(text, recognize);
                        break;
                    }
                    case 3:
                    {
                        IRecognizePasswordText recognize = new RecognizePasswordTextType3();
                        RecognizeAndSave(text, recognize);
                        break;
                    }
                    case 4:
                    {
                        IRecognizePasswordText recognize = new RecognizePasswordTextType4();
                        RecognizeAndSave(text, recognize);
                        break;
                    }
                    case 5:
                    {
                        IRecognizePasswordText recognize = new RecognizePasswordTextType5();
                        RecognizeAndSave(text, recognize);
                        break;
                    }
                    case 6:
                    {
                        IRecognizePasswordText recognize = new RecognizePasswordTextType6();
                        RecognizeAndSave(text, recognize);
                        break;
                    }

                    default:
                        break;
                }
                WriteLine("jeszcze raz t/n");
                var end = ReadKey();
                if (end.KeyChar == 'n'||end.KeyChar=='T')
                {
                    flag = false;
                }

            }


        }
        private static void LoadDictionaryPassword()
        {
            _dictionary = File.Exists(@"D:\dane\skroty.json") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json")) : new Dictionary<string, string>();
        }

        private static void RecognizeAndSave(string text, IRecognizePasswordText recognize)
        {
            

            var result = recognize.Recognize(text, _dictionary);

            File.WriteAllText(@"D:\testWer\" + result[0].Word + ".json", JsonConvert.SerializeObject(result, Formatting.Indented));

            StringBuilder str = new StringBuilder();
            str.Append("public string Text1 = \"");
            str.Append(text + "\";\n");

            str.AppendLine(
                "public ObservableCollection<DictionaryPasswordElement> Result1 =\r\n            new ObservableCollection<DictionaryPasswordElement>\r\n            {");

            foreach (DictionaryPasswordElement element in result)
            {
                str.Append("new DictionaryPasswordElement{Word = \"");
                str.Append(element.Word);
                str.Append("\", Description = \"");
                str.Append(element.Description);
                str.Append("\"},\n");
            }
            str.AppendLine(" };");

            File.WriteAllText(@"D:\testWer\" + result[0].Word + ".txt",str.ToString());
        }
    }
}