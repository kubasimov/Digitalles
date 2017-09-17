using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPF.Enum;
using WPF.Interface;
using WPF.Model;

namespace WPF.ViewModel
{
    public class SpellerViewModel:ViewModelBase
    {
        private IDataExchangeViewModel _dataExchangeViewModel;

        public SpellerViewModel(IDataExchangeViewModel dataExchangeViewModel)
        {
            _dataExchangeViewModel = dataExchangeViewModel;
            if (IsInDesignMode)
            {
                _dictionaryElements = new ObservableCollection<SpellModel>
                    {
                        new SpellModel{Word="alibaba",ListSpell=" teraz potem jest" } ,
                        new SpellModel{Word="alibaba",ListSpell=" teraz potem jest" } ,
                        new SpellModel{Word="alibaba",ListSpell=" teraz potem jest" } ,
                        new SpellModel{Word="alibaba",ListSpell=" teraz potem jest" }
                    };
            }
            else
            {
                if (_dataExchangeViewModel.ContainsKey(EnumExchangeViewmodel.SpellDictionary))
                {
                    _dictionaryElements =
                        (ObservableCollection<SpellModel>)_dataExchangeViewModel.Item(EnumExchangeViewmodel
                            .SpellDictionary);
                }
                else
                {
                    _dictionaryElements = new ObservableCollection<SpellModel>();
                }
            }
            RaisePropertyChanged(DictionaryElementsPropertyName);
        }

        private void ExecuteOkCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseSpellerView"));
        }

        #region RelayMethod

        private RelayCommand _okCommand;

        public RelayCommand OkCommand => _okCommand
                                         ?? (_okCommand = new RelayCommand(ExecuteOkCommand));
        #endregion

        #region Mvvm members

        public const string DictionaryElementsPropertyName = "DictionaryElements";

        private ObservableCollection<SpellModel> _dictionaryElements  ;

        public ObservableCollection<SpellModel> DictionaryElements
        {
            get => _dictionaryElements;

            set
            {
                if (_dictionaryElements == value)
                {
                    return;
                }

                _dictionaryElements = value;
                RaisePropertyChanged(DictionaryElementsPropertyName);
            }
        }

        #endregion
    }
}
