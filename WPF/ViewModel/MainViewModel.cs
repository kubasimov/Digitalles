using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPF.Enum;
using WPF.Interface;
using WPF.Model;
using WPF.View;


namespace WPF.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private IDataService _dataService;
        private IDataExchangeViewModel _dataExchangeViewModel;
        private DictionaryModel _dictionaryModel;

        public MainViewModel(IDataExchangeViewModel dataExchangeViewModel,IDataService dataService)
        {
            _dataExchangeViewModel = dataExchangeViewModel;
            _dataService = dataService;
            _dictionaryModel=new DictionaryModel();
            
        }


        private void ExecuteExitCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseMain"));
        }
        private void ExecuteOcrCommand()
        {
            new OcrView().ShowDialog();
            if (_dataExchangeViewModel.ContainsKey(EnumExchangeViewmodel.Dictionary))
            {
                _dictionaryModel = (DictionaryModel)_dataExchangeViewModel.Item(EnumExchangeViewmodel.Dictionary);
            }
        }





        private RelayCommand _ocrCommand;
        
        public RelayCommand OcrCommand
        {
            get
            {
                return _ocrCommand
                    ?? (_ocrCommand = new RelayCommand(ExecuteOcrCommand));
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