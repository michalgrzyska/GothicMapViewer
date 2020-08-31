using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GothicMapViewer.Interfaces;
using GothicMapViewer.Interfaces.Repositories;
using GothicMapViewer.Models.Main;
using GothicMapViewer.Models.Map.Enums;
using GothicMapViewer.Models.Messages;
using GothicMapViewer.Repositories.Helpers;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;

namespace GothicMapViewer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ITranslationService translationService;
        private readonly IMainRepository mainRepository;
        private string selectedMap = "";
        private object selectedLegend;

        public object SelectedLegend
        {
            get
            {
                return selectedLegend;
            }
            set
            {
                selectedLegend = value;
                Console.WriteLine(value);
            }
        }

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

        public DelegateCommand<object> SelectedLegendChangedCommand { get; set; }

        public MainViewModel(ITranslationService translationService, IMainRepository mainRepository)
        {
            this.translationService = translationService;
            this.mainRepository = mainRepository;

            ApplyTranslations();
            SetMapSelection();
            SetEvents();

            Messenger.Default.Register<SendLegendListMessage>(this, this.DisplayLegend);
        }
        public void MapSelectionChanged(MapSelection map)
        {
            MessageSender.Send(new SendMapTypeMessage(map));
        }

        private void ApplyTranslations()
        {
            Translations = translationService.GetTranslations();
        }

        private void SetMapSelection()
        {
            MapSelection = new ObservableCollection<MapSelection>(mainRepository.GetMapSelections());
        }

        private void DisplayLegend(SendLegendListMessage mapLegend)
        {
            Legend = new ObservableCollection<MapLegend>(mapLegend.MapLegendItems);
            RaisePropertyChanged("Legend");
        }

        private void SetEvents()
        {
            SelectedLegendChangedCommand = new DelegateCommand<object>((selectedItems) =>
            {
                System.Collections.IList items = (System.Collections.IList)selectedItems;
                var collection = items.Cast<MapLegend>().ToList();
            });
        }
    }
}