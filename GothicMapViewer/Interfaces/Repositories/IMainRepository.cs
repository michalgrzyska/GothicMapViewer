using GothicMapViewer.Models.Main;
using System.Collections.Generic;

namespace GothicMapViewer.Interfaces.Repositories
{
    public interface IMainRepository
    {
        List<MapSelection> GetMapSelections();
    }
}
