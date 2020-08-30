using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace GothicMapViewer.Models.Map
{
    public class MapModel
    {
        public Markers GetMarkers()
        {
            string jsonFile = File.ReadAllText($"../../Data/markers.json");
            return JsonConvert.DeserializeObject<Markers>(jsonFile);
        }

        public string GetMapFileName()
        {
            return "khorinis.jpg";
        }
    }
}
