using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using RecognizePassword.Implement;
using RecognizePassword.Interface;
using RecognizePassword.Model;

namespace ConsoleCore
{
    class Program
    {

        private static Dictionary<string, string> _dictionary;
        //private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static readonly IFactoryRecognizePassword FactoryRecognize = new FactoryRecognizePassword();
        private static Dictionary<string, string> _settings;


        static void Main(string[] args)
        {
            //SaveSettings();
            LoadSettings();

            LoadDictionaryPassword();
            
            foreach (string file in Directory.EnumerateFiles(_settings["input"],"*.txt"))
            {
                var text = File.ReadAllText(file);

                if (!String.IsNullOrEmpty(text))
                {
                    var result = FactoryRecognize.Recognize(text, _dictionary);

                    GenerateAndSaveTest(result, text, file);

                    result.Insert(0, new DictionaryPasswordElement { Word = "Hasło", Description = text });

                    var saveJsonFile = _settings["output"] + @"\" + Path.GetFileNameWithoutExtension(file)+".json";
                    
                    File.WriteAllTextAsync(saveJsonFile, JsonConvert.SerializeObject(result, Formatting.Indented));
                    
                }
            }

            
            Console.WriteLine("All!");
            Console.ReadKey();
        }

        private static void GenerateAndSaveTest(ObservableCollection<DictionaryPasswordElement> result, string text,
            string file)
        {
            string textToSave = CreateTest(result, text);
            var saveTestFile = _settings["output"] + @"\Tests\" + Path.GetFileName(file);
            File.WriteAllTextAsync(saveTestFile, textToSave);
        }

        private static string CreateTest(ObservableCollection<DictionaryPasswordElement> result, string text)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("public string " + result[0].Word + " = \""+text+"\";");
            sb.AppendLine("public ObservableCollection<DictionaryPasswordElement> Result_" + result[0].Word + " =");
            sb.AppendLine("new ObservableCollection<DictionaryPasswordElement>");
            sb.AppendLine("{");
            foreach (var element in result)
            {
                sb.AppendLine("new DictionaryPasswordElement{Word = \"" + element.Word + "\", Description = \"" +
                              element.Description + "\"},");
            }

            sb.AppendLine("};");

            return sb.ToString();
        }

        private static void SaveSettings()
        {
            var filename = @"D:\Hasla\settings.json";
            var aaa = new Dictionary<string, string>
            {
                {"input", @"D:\Hasla\Input"},
                {"output", @"D:\Hasla\Output" }
            };

            File.WriteAllText(filename, JsonConvert.SerializeObject(aaa, Formatting.Indented));


        }

        private static void LoadSettings()
        {
            var filename = @"D:\Hasla\settings.json";
            _settings = File.Exists(filename)
                ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(filename))
                : new Dictionary<string, string>();
        }

        private static void LoadDictionaryPassword()
        {
            _dictionary = File.Exists(@"D:\Hasla\skroty.json") ? JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json")) : new Dictionary<string, string>();
        }
    }
}
