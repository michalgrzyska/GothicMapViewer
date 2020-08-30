using GalaSoft.MvvmLight;
using GothicMapViewer.Models.Main;

namespace GothicMapViewer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly TranslationService translationService;

        public Translations Translations { get; set; }
        public MainViewModel(TranslationService translationService)
        {
            this.translationService = translationService;
            ApplyTranslations();
        }

        private void ApplyTranslations()
        {
            Translations = translationService.GetTranslations();
        }
    }
}