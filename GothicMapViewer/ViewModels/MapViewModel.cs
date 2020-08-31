using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GothicMapViewer.Interfaces.Repositories;
using GothicMapViewer.Models;
using GothicMapViewer.Models.Map.Enums;
using GothicMapViewer.Repositories.Helpers;
using System.Collections.ObjectModel;
using System.Windows;

namespace GothicMapViewer.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        private readonly IMapRepository mapRepository;

        public string Map { get; set; }
        public ObservableCollection<Marker> Markers { get; set; } = new ObservableCollection<Marker>();

        public MapViewModel(IMapRepository mapRepository)
        {
            this.mapRepository = mapRepository;
            LoadMapData(MapType.KHORINIS);
            Messenger.Default.Register<MapType>(this, this.ChangeMap);
        }

        private void LoadMapData(MapType mapType)
        {
            SetMarkerData(mapType);
            SetMap(mapType);
            RaisePropertyChanged("Map");
            RaisePropertyChanged("Markers");
        }

        private void SetMap(MapType mapType)
        {
            Map = mapRepository.GetMapFileName(mapType);
        }

        private void SetMarkerData(MapType mapType)
        {
            var markersData = mapRepository.GetMarkers(mapType);
            var markers = new ObservableCollection<Marker>();

            foreach (var item in markersData.Herbs)
            {
                markers.Add(new Marker()
                {
                    Margin = new Thickness(item.PositionX - 7, item.PositionY - 7, 0, 0),
                    NameWithDescription = item.Title + (item.Description != "" ? $":\n{item.Description}" : ""),
                    Color = ColorConverter.ConvertHexToBrush(item.Color)
                });
            }

            Markers = markers;
        }

        private void ChangeMap(MapType map)
        {
            LoadMapData(map);
        }
    }
}