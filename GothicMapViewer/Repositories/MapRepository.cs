using GothicMapViewer.Interfaces.Repositories;
using GothicMapViewer.Models.Main;
using GothicMapViewer.Models.Map.Enums;
using GothicMapViewer.Repositories.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace GothicMapViewer.Models.Map
{
    public class MapRepository : IMapRepository
    {
        public MarkerList GetMarkers(MapType mapType)
        {
            var mapFileNamePartial = GetMapPartialFileName(mapType);
            string jsonFile = File.ReadAllText($"../../Data/{mapFileNamePartial}_markers.json");
            return JsonConvert.DeserializeObject<MarkerList>(jsonFile);
        }

        public string GetMapFileName(MapType mapType)
        {
            var mapFileNamePartial = GetMapPartialFileName(mapType);
            return $"maps/{mapFileNamePartial}.jpg";
        }

        public List<Marker> GetMarkersDisplayList(MapType mapType)
        {
            var markersData = GetMarkers(mapType);
            List<Marker> markers = new List<Marker>();

            foreach (var type in markersData.ItemType)
            {
                foreach (var item in type.Markers)
                {
                    markers.Add(new Marker()
                    {
                        Margin = new Thickness(item.PositionX - 7, item.PositionY - 7, 0, 0),
                        NameWithDescription = type.Title + (item.Description != "" ? $":\n{item.Description}" : ""),
                        Color = ColorConverter.ConvertHexToBrush(type.Color),
                        ParentName = type.Title,
                        Visible = true
                    });
                }
            }

            return markers;
        }

        public List<MapLegend> GetMapLegends(MarkerList markerList)
        {
            List<MapLegend> mapLegend = new List<MapLegend>();

            foreach (var item in markerList.ItemType)
            {
                mapLegend.Add(new MapLegend()
                {
                    Name = item.Title,
                    Color = ColorConverter.ConvertHexToBrush(item.Color)
                });
            }
            return mapLegend;
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
