using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GothicMapViewer.Models.Map;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

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

            SetMarkerData();
            SetMap();
        }

        private void SetMap()
        {
            Map = mapModel.GetMapFileName();
        }

        private void SetMarkerData()
        {
            var markersData = mapModel.GetMarkers();

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