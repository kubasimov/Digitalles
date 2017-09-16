using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WPF.View;


namespace WPF.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        private void ExecuteExitCommand()
        {
            Messenger.Default.Send(new NotificationMessage(this, "CloseMain"));
            
        }
        private void ExecuteOcrCommand()
        {
            new OcrView().Show();
        }

        private void ExecuteDictionaryCommand()
        {
            new DictionaryView().Show();
        }

        private void ExecuteRecognizeCommand()
        {
            new RecognizeView().Show();
        }

        
        private RelayCommand _ocrCommand;
        
        public RelayCommand OcrCommand => _ocrCommand
                                          ?? (_ocrCommand = new RelayCommand(ExecuteOcrCommand));

        private RelayCommand _exitCommand;

        public RelayCommand ExitCommand => _exitCommand
                                           ?? (_exitCommand = new RelayCommand(ExecuteExitCommand));

        private RelayCommand _recognizeCommand;

        public RelayCommand RecognizeCommand => _recognizeCommand
                                                ?? (_recognizeCommand = new RelayCommand(ExecuteRecognizeCommand));

        private RelayCommand _dictionaryCommand;

        public RelayCommand DictionaryCommand => _dictionaryCommand
                                                 ?? (_dictionaryCommand = new RelayCommand(ExecuteDictionaryCommand));

        
    }
}