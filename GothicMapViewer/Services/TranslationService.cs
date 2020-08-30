using GothicMapViewer.Interfaces;
using GothicMapViewer.Models.Map;
using GothicMapViewer.Models.Map.Enums;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace GothicMapViewer.Models.Main
{
    public class TranslationService: ITranslationService
    {
        public Translations GetTranslations()
        {
            string jsonFile = File.ReadAllText($"../../Data/pl-PL.json", Encoding.Default);
            return JsonConvert.DeserializeObject<Translations>(jsonFile);
        }

        public string GetTranslationForMap(MapType map)
        {
            var translations = GetTranslations().Maps;
            switch (map)
            {
                case MapType.KHORINIS:
                    return translations.Khorinis;
                case MapType.VALLEY_OF_MINES:
                    return translations.ValleyOfMines;
                case MapType.JARKENDAR:
                    return translations.Jarkendar;
                default:
                    return translations.Khorinis;
            }
        }
    }
}
