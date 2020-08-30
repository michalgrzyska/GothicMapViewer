using GothicMapViewer.Models.Main;
using GothicMapViewer.Models.Map.Enums;

namespace GothicMapViewer.Interfaces
{
    public interface ITranslationService
    {
        Translations GetTranslations();
        string GetTranslationForMap(MapType map);
    }
}
