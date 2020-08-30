using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GothicMapViewer.Models.Main;
using GothicMapViewer.Models.Map;

namespace GothicMapViewer.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            TranslationService translationService = new TranslationService();

            SimpleIoc.Default.Register(() => new MainViewModel(translationService));
            SimpleIoc.Default.Register<MarkerViewModel>();
            SimpleIoc.Default.Register(() => new MapViewModel(new MapModel()));
        }

        public MapViewModel MapViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MapViewModel>();
            }
        }

        public MarkerViewModel MarkerViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MarkerViewModel>();
            }
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    }
}
