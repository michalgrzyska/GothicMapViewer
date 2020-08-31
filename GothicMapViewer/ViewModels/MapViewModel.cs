using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GothicMapViewer.Interfaces.Repositories;
using GothicMapViewer.Models;
using GothicMapViewer.Models.Map;
using GothicMapViewer.Models.Map.Enums;
using GothicMapViewer.Models.Messages;
using GothicMapViewer.Repositories.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GothicMapViewer.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        private readonly IMapRepository mapRepository;
        private List<Marker> markers;

        public string Map { get; private set; }
        public ObservableCollection<Marker> Markers { get; private set; } = new ObservableCollection<Marker>();

        public MapViewModel(IMapRepository mapRepository)
        {
            this.mapRepository = mapRepository;
            LoadMapData(MapType.KHORINIS);
            Messenger.Default.Register<SendMapTypeMessage>(this, this.ChangeMap);
            Messenger.Default.Register<SendLegendFilterDataMessage>(this, this.SetMarkerFilters);
        }

        private void LoadMapData(MapType mapType)
        {
            SetMarkerData(mapType);
            SetMap(mapType);
        }

        private void SetMap(MapType mapType)
        {
            Map = mapRepository.GetMapFileName(mapType);
            RaisePropertyChanged("Map");
        }

        private void SetMarkers(List<Marker> markers)
        {
            var markersFiltered = markers.Where(x => x.Visible == true);
            Markers = new ObservableCollection<Marker>(markersFiltered);
            RaisePropertyChanged("Markers");
        }

        private void SetMarkerData(MapType mapType)
        {
            DisplayLegend(mapRepository.GetMarkers(mapType));
            markers = mapRepository.GetMarkersDisplayList(mapType);
            SetMarkers(markers);
        }

        private void DisplayLegend(MarkerList markerList)
        {
            var mapLegend = mapRepository.GetMapLegends(markerList);
            MessageSender.Send(new SendLegendListMessage(mapLegend));
        }

        private void ChangeMap(SendMapTypeMessage map)
        {
            LoadMapData(map.MapSelection.Type);
        }

        private void SetMarkerFilters(SendLegendFilterDataMessage message)
        {
            markers = mapRepository.GetMarkersWithAppliedFilters(markers, message.MapLegendItems);
            SetMarkers(markers);
        }
    }
}