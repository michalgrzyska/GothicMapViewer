using GothicMapViewer.Models.Main;
using System.Collections.Generic;

namespace GothicMapViewer.Models.Messages
{
    public class SendLegendFilterDataMessage
    {
        public List<MapLegend> MapLegendItems { get; set; }

        public SendLegendFilterDataMessage(List<MapLegend> mapLegendItems)
        {
            MapLegendItems = mapLegendItems;
        }
    }
}
