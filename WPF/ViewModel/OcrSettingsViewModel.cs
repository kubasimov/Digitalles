using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPF.Enum;
using WPF.Interface;
using WPF.Model;

namespace WPF.ViewModel
{
    public class OcrSettingsViewModel : ViewModelBase
    {
        private SettingsModel settings;

        private readonly IDataExchangeViewModel _dataExchangeViewModel;
        
        public OcrSettingsViewModel(IDataExchangeViewModel dataExchangeViewModel, IDataService dataService)
        {
            settings = dataService.LoadSettings();

            _languages=new ObservableCollection<LangModel>();

            foreach (var langModel in settings.Language)
            {
                _languages.Add(langModel);
            }
            

            _dataExchangeViewModel = dataExchangeViewModel;

        }
        
        private void ExecuteOkCommand()
        {
            _dataExchangeViewModel.Add(EnumExchangeViewmodel.Language,settings);
            Messenger.Default.Send(new NotificationMessage(this, "CloseOcrSettings"));
        }

        private void ExecuteAbortCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseOcrSettings"));
        }

        private void ExecuteChcekedCommand(object obj)
        {
            System.Collections.IList ita = (System.Collections.IList)obj;

            settings = new SettingsModel
            {
                Pages = 1,
                Language = new List<LangModel>()
            };

            foreach (var o in ita)
            {
                var t = (LangModel) o;
                settings.Language.Add(t);

            }
            

            
        }

        #region RelayCommand

        private RelayCommand _okCommand;

        public RelayCommand OkCommand => _okCommand
                                         ?? (_okCommand = new RelayCommand(ExecuteOkCommand));

        private RelayCommand _abortCommand;

        public RelayCommand AbortCommand => _abortCommand
                                            ?? (_abortCommand = new RelayCommand(ExecuteAbortCommand));

        private RelayCommand<object> _checkedCommand;

        public RelayCommand<object> ChcekedCommand => _checkedCommand
                                                      ?? (_checkedCommand =
                                                          new RelayCommand<object>(ExecuteChcekedCommand));

        #endregion

        #region Language

        /// <summary>
        /// The <see cref="Language" /> property's name.
        /// </summary>
        public const string LanguagePropertyName = "Language";

        private ObservableCollection<LangModel> _languages;
        
        /// <summary>
        /// Sets and gets the Language property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<LangModel> Language
        {
            get => _languages;

            set
            {
                if (_languages == value)
                {
                    return;
                }

                _languages = value;
                RaisePropertyChanged(LanguagePropertyName);
            }
        }

        #endregion

    }
}