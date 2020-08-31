using System.Collections.Generic;

namespace GothicMapViewer.Models.Map
{
    public class MarkerType
    {
        public string Title { get; set; }
        public string Color { get; set; }
        public List<MarkerData> Markers { get; set; }
    }
}
