using GothicMapViewer.Interfaces;
using GothicMapViewer.Models.Map.Enums;
using GothicMapViewer.Repositories.Helpers;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace GothicMapViewer.Models.Main
{
    public class TranslationService: ITranslationService
    {
        public Translations GetTranslations()
        {
            string fileName = "pl-PL.json";
            string translationFolder = PathFinder.TraslationFolder;
            string jsonFile = File.ReadAllText($"{translationFolder}/{fileName}", Encoding.Default);

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
