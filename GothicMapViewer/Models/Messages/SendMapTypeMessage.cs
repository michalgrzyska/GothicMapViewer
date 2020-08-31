using GothicMapViewer.Models.Main;

namespace GothicMapViewer.Models.Messages
{
    public class SendMapTypeMessage
    {
        public MapSelection MapSelection { get; set; }

        public SendMapTypeMessage(MapSelection mapSelection)
        {
            MapSelection = mapSelection;
        }
    }
}
