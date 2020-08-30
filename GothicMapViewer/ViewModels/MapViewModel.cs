using GalaSoft.MvvmLight;
using GothicMapViewer.Models.Map;
using GothicMapViewer.Models.Map.Enums;
using System.Collections.ObjectModel;
using System.Windows;

namespace GothicMapViewer.ViewModels
{
    public class MapViewModel : ViewModelBase
    {
        private readonly MapModel mapModel;
        public string Map { get; set; }
        public ObservableCollection<MarkerViewModel> Markers { get; set; } = new ObservableCollection<MarkerViewModel>();
        public MapViewModel(MapModel mapModel)
        {
            this.mapModel = mapModel;
            LoadMapData(MapType.KHORINIS);   
        }

        private void LoadMapData(MapType mapType)
        {
            SetMarkerData(MapType.KHORINIS);
            SetMap(MapType.KHORINIS);
        }

        private void SetMap(MapType mapType)
        {
            Map = mapModel.GetMapFileName(mapType);
        }

        private void SetMarkerData(MapType mapType)
        {
            var markersData = mapModel.GetMarkers(mapType);

            foreach (var item in markersData.Herbs)
            {
                Markers.Add(new MarkerViewModel()
                {
                    Margin = new Thickness(item.PositionX, item.PositionY, 0, 0),
                    NameWithDescription = item.Title + (item.Description != "" ? $":\n{item.Description}" : "")
                });
            }
        }
    }
}