using GothicMapViewer.Models.Map;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace GothicMapViewer.Models.Main
{
    public class TranslationService
    {
        public Translations GetTranslations()
        {
            string jsonFile = File.ReadAllText($"../../Data/pl-PL.json", Encoding.Default);
            return JsonConvert.DeserializeObject<Translations>(jsonFile);
        }
    }
}
