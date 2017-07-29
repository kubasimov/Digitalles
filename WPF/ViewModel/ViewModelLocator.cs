/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:WPF"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Core.Implement;
using Core.Interface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using WPF.Implement;
using WPF.Interface;

namespace WPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<IDataService,DataService>(true);
            SimpleIoc.Default.Register<ICoreOcr,CoreOcr>(true);
            SimpleIoc.Default.Register<IDataExchangeViewModel, DataExchangeViewModel>(true);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<OcrViewModel>();
            //SimpleIoc.Default.Register<OcrSettingsViewModel>();
            //SimpleIoc.Default.Register<TestsViewModel>();
            SimpleIoc.Default.Register<RecognizeViewModel>();
            SimpleIoc.Default.Register<PreviewViewModel>();
            SimpleIoc.Default.Register<DictionaryViewModel>();
        }


        public MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }

        public OcrViewModel Ocr
        {
            get { return ServiceLocator.Current.GetInstance<OcrViewModel>(); }
            
        }

        public OcrSettingsViewModel OcrSettings
        {
            get { return ServiceLocator.Current.GetInstance<OcrSettingsViewModel>(); }

        }
        
        public TestsViewModel Tests
        {
            get { return ServiceLocator.Current.GetInstance<TestsViewModel>(); }

        }

        public RecognizeViewModel Recognize
        {
            get { return ServiceLocator.Current.GetInstance<RecognizeViewModel>(); }

        }

        public PreviewViewModel Preview
        {
            get { return ServiceLocator.Current.GetInstance<PreviewViewModel>(); }

        }

        public DictionaryViewModel Dictionary
        {
            get { return ServiceLocator.Current.GetInstance<DictionaryViewModel>(); }
        }
        public static void Cleanup()
        {
            SimpleIoc.Default.Unregister<DictionaryViewModel>();
        }

        public static void UnregisterRecognizeViewModel()
        {
            SimpleIoc.Default.Unregister<RecognizeViewModel>();
            SimpleIoc.Default.Register<RecognizeViewModel>();
        }

        public static void UnregisterDictionaryViewModel()
        {
            SimpleIoc.Default.Unregister<DictionaryViewModel>();
            SimpleIoc.Default.Register<DictionaryViewModel>();
        }

        public static void UnregisterOcrViewViewModel()
        {
            SimpleIoc.Default.Unregister<OcrViewModel>();
            SimpleIoc.Default.Register<OcrViewModel>();
        }

        public static void UnregisterPreviewViewModel()
        {
            SimpleIoc.Default.Unregister<PreviewViewModel>();
            SimpleIoc.Default.Register<PreviewViewModel>();
        }
    }
}