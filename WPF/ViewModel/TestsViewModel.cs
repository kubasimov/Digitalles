using GalaSoft.MvvmLight;
using Syncfusion.Windows.Tools.Controls;

namespace WPF.ViewModel
{
    public class TestsViewModel:ViewModelBase
    {
        public TestsViewModel()
        {
            
        }

        /// <summary>
        /// The <see cref="DocumentAdv" /> property's name.
        /// </summary>
        public const string DocumentAdvPropertyName = "DocumentAdv";

        private DocumentAdv _documentAdv;

        /// <summary>
        /// Sets and gets the DocumentAdv property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DocumentAdv DocumentAdv
        {
            get
            {
                return _documentAdv;
            }

            set
            {
                if (_documentAdv == value)
                {
                    return;
                }

                _documentAdv = value;
                RaisePropertyChanged(DocumentAdvPropertyName);
            }
        }
    }
}