using GalaSoft.MvvmLight;
using System.Windows;

namespace GothicMapViewer.ViewModels
{
    public class MarkerViewModel : ViewModelBase
    {
        public Thickness Margin { get; set; }
        public string NameWithDescription { get; set; }
    }
}
