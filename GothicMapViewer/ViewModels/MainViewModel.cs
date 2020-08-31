using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GothicMapViewer.Interfaces;
using GothicMapViewer.Interfaces.Repositories;
using GothicMapViewer.Models.Main;
using GothicMapViewer.Models.Map.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Documents;

namespace GothicMapViewer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITranslationService translationService;
        private readonly IMainRepository mainRepository;
        private string selectedMap = "";

        public object SelectedMap 
        {
            get 
            {
                return selectedMap;
            }
            set
            {
                MapSelectionChanged((MapSelection)value);
            }
        }

        public Translations Translations { get; set; }
        public ObservableCollection<MapSelection> MapSelection { get; set; }
        public ObservableCollection<MapLegend> Legend { get; set; }

        public MainViewModel(ITranslationService translationService, IMainRepository mainRepository)
        {
            this.translationService = translationService;
            this.mainRepository = mainRepository;

            ApplyTranslations();
            SetMapSelection();

            Messenger.Default.Register<List<MapLegend>>(this, this.DisplayLegend);
        }

        private void ApplyTranslations()
        {
            Translations = translationService.GetTranslations();
        }

        private void SetMapSelection()
        {
            MapSelection = new ObservableCollection<MapSelection>(mainRepository.GetMapSelections());
        }

        public void MapSelectionChanged(MapSelection map)
        {
            Messenger.Default.Send(map.Type);
        }

        private void DisplayLegend(List<MapLegend> mapLegends)
        {
            Legend = new ObservableCollection<MapLegend>(mapLegends);
            RaisePropertyChanged("Legend");
        }
    }
}