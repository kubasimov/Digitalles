using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json;

namespace AddToDictionary.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {

        Dictionary<string, string> MyDictionary;


        public MainViewModel()
        {
            if (File.Exists(@"D:\dane\skroty.json"))
            {
                MyDictionary =
                    JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(@"D:\dane\skroty.json"));
                Dictio = CopyFromDictionary(MyDictionary);
            }
            else
            {
                MyDictionary = new Dictionary<string, string>();
                Dictio = new ObservableCollection<ItemMyDictionary>();
            }



        }

        private ObservableCollection<ItemMyDictionary> CopyFromDictionary(Dictionary<string, string> itemDictionary)
        {
            var temp = new ObservableCollection<ItemMyDictionary>();

            foreach (KeyValuePair<string, string> keyValuePair in itemDictionary)
            {
                temp.Add(new ItemMyDictionary { text1 = keyValuePair.Key, text2 = keyValuePair.Value });
            }

            return temp;
        }

        private Dictionary<string, string> CopyFromObservableCollection(ObservableCollection<ItemMyDictionary> itemMyDictionaries)
        {
            var temp = new Dictionary<string, string>();
            foreach (ItemMyDictionary itemMyDictionary in itemMyDictionaries)
            {
                temp.Add(itemMyDictionary.text1, itemMyDictionary.text2);
            }
            return temp;
        }


        private void ExecuteAddCommand()
        {



            if (_text1 != "" && _text2 != "" && !Dictio.Equals(new ItemMyDictionary { text1 = _text1, text2 = _text2 }))
            {
                Dictio.Add(new ItemMyDictionary { text1 = _text1, text2 = _text2 });
                _text1 = "";
                _text2 = "";
                RaisePropertyChanged(Text1PropertyName);
                RaisePropertyChanged(Text2PropertyName);
                RaisePropertyChanged(DictioPropertyName);
            }

        }
        private void ExecuteSaveCommand()
        {
            MyDictionary = CopyFromObservableCollection(Dictio);
            File.WriteAllText(@"D:\dane\skroty.json", JsonConvert.SerializeObject(MyDictionary, Formatting.Indented));
        }


        private void ExecuteExitCommand()
        {
            MyDictionary = CopyFromObservableCollection(Dictio);
            File.WriteAllText(@"D:\dane\skroty.json", JsonConvert.SerializeObject(MyDictionary, Formatting.Indented));
            Messenger.Default.Send(new NotificationMessage(this, "CloseMain"));
        }





        
        public const string DictioPropertyName = "Dictio";

        private ObservableCollection<ItemMyDictionary> _dictionary;

        public ObservableCollection<ItemMyDictionary> Dictio
        {
            get
            {
                return _dictionary;
            }

            set
            {
                if (_dictionary == value)
                {
                    return;
                }

                _dictionary = value;
                RaisePropertyChanged(DictioPropertyName);
            }
        }

        
        public const string Text1PropertyName = "Text1";

        private string _text1;

        public string Text1
        {
            get
            {
                return _text1;
            }

            set
            {
                if (_text1 == value)
                {
                    return;
                }

                _text1 = value;
                RaisePropertyChanged(Text1PropertyName);
            }
        }


        
        public const string Text2PropertyName = "Text2";

        private string _text2;

        public string Text2
        {
            get
            {
                return _text2;
            }

            set
            {
                if (_text2 == value)
                {
                    return;
                }

                _text2 = value;
                RaisePropertyChanged(Text2PropertyName);
            }
        }


        private RelayCommand _saveCommand;

        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand
                       ?? (_saveCommand = new RelayCommand(ExecuteSaveCommand));
            }
        }




        private RelayCommand _addCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand
                       ?? (_addCommand = new RelayCommand(ExecuteAddCommand));
            }
        }

        private RelayCommand _exitCommand;

        public RelayCommand ExitCommand
        {
            get
            {
                return _exitCommand
                       ?? (_exitCommand = new RelayCommand(ExecuteExitCommand));
            }
        }
    }


}