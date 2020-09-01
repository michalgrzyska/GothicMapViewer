using GothicMapViewer.Models;
using GothicMapViewer.Models.Main;
using GothicMapViewer.Models.Map;
using GothicMapViewer.Models.Map.Enums;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace GothicMapViewer.Interfaces.Repositories
{
    public interface IMapRepository
    {
        MarkerList GetMarkers(MapType mapType);
        BitmapImage GetMapFileName(MapType mapType);
        List<MapLegend> GetMapLegends(MarkerList markerList);
        List<Marker> GetMarkersDisplayList(MapType mapType);
        List<Marker> GetMarkersWithAppliedFilters(List<Marker> markers, List<MapLegend> mapLegends);
    }
}
