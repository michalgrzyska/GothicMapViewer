using GothicMapViewer.Interfaces;
using GothicMapViewer.Interfaces.Repositories;
using GothicMapViewer.Models.Map.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GothicMapViewer.Models.Main
{
    public class MainRepository : IMainRepository
    {
        private readonly ITranslationService translationService;

        public MainRepository(ITranslationService translationService)
        {
            this.translationService = translationService;
        }

        public List<MapSelection> GetMapSelections()
        {
            var mapTypes = Enum.GetValues(typeof(MapType))
                               .Cast<MapType>()
                               .ToList();

            List<MapSelection> mapSelections = new List<MapSelection>();

            foreach (var map in mapTypes)
            {
                mapSelections.Add(new MapSelection()
                {
                    Name = translationService.GetTranslationForMap(map),
                    Type = map
                });
            }

            return mapSelections;
        }   
    }
}
