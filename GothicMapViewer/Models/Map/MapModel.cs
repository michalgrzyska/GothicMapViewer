using GothicMapViewer.Models.Map.Enums;
using Newtonsoft.Json;
using System.IO;

namespace GothicMapViewer.Models.Map
{
    public class MapModel
    {
        public Markers GetMarkers(MapType mapType)
        {
            var mapFileNamePartial = GetMapPartialFileName(mapType);
            string jsonFile = File.ReadAllText($"../../Data/{mapFileNamePartial}_markers.json");
            return JsonConvert.DeserializeObject<Markers>(jsonFile);
        }

        public string GetMapFileName(MapType mapType)
        {
            var mapFileNamePartial = GetMapPartialFileName(mapType);
            return $"maps/{mapFileNamePartial}.jpg";
        }

        private string GetMapPartialFileName(MapType mapType)
        {
            switch(mapType)
            {
                case MapType.KHORINIS:
                    return "khorinis";
                case MapType.VALLEY_OF_MINES:
                    return "valley_of_mines";
                case MapType.JARKENDAR:
                    return "jarkendar";
                default:
                    return "khorinis";
            }
        }
    }
}
