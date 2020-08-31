using GothicMapViewer.Models;
using GothicMapViewer.Models.Main;
using GothicMapViewer.Models.Map;
using GothicMapViewer.Models.Map.Enums;
using System.Collections.Generic;

namespace GothicMapViewer.Interfaces.Repositories
{
    public interface IMapRepository
    {
        MarkerList GetMarkers(MapType mapType);
        string GetMapFileName(MapType mapType);
        List<MapLegend> GetMapLegends(MarkerList markerList);
        List<Marker> GetMarkersDisplayList(MapType mapType);
        List<Marker> GetMarkersWithAppliedFilters(List<Marker> markers, List<MapLegend> mapLegends);
    }
}
