using System.Windows;
using System.Windows.Media;

namespace GothicMapViewer.Models
{
    public class Marker
    {
        public Thickness Margin { get; set; }
        public string NameWithDescription { get; set; }
        public Brush Color { get; set; }
    }
}
