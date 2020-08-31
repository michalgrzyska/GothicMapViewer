using GothicMapViewer.Models.Main;
using System.Collections.Generic;

namespace GothicMapViewer.Models.Messages
{
    public class SendLegendListMessage
    {
        public List<MapLegend> MapLegendItems { get; set; }

        public SendLegendListMessage(List<MapLegend> mapLegendItems)
        {
            MapLegendItems = mapLegendItems;
        }
    }
}
