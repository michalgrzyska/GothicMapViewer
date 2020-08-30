using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GothicMapViewer.Interfaces;
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

            SimpleIoc.Default.Register<ITranslationService, TranslationService>();



            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MarkerViewModel>();
            SimpleIoc.Default.Register(() => new MapViewModel(new MapRepository()));
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
