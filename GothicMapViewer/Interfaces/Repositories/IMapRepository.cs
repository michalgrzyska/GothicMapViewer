using GothicMapViewer.Models.Map;
using GothicMapViewer.Models.Map.Enums;

namespace GothicMapViewer.Interfaces.Repositories
{
    public interface IMapRepository
    {
        Markers GetMarkers(MapType mapType);
        string GetMapFileName(MapType mapType);
    }
}
