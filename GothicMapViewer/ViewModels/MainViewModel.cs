using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace GothicMapViewer.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<MarkerViewModel> Markers { get; set; } = new ObservableCollection<MarkerViewModel>();
        public MainViewModel()
        {
            Markers.Add(new MarkerViewModel() { Margin = new Thickness(10, 10, 0, 0) });
            Markers.Add(new MarkerViewModel() { Margin = new Thickness(30, 10, 0, 0) });
            Markers.Add(new MarkerViewModel() { Margin = new Thickness(50, 10, 0, 0) });
            Markers.Add(new MarkerViewModel() { Margin = new Thickness(50, 40, 0, 0) });
        }
    }
}