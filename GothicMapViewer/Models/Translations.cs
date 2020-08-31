namespace GothicMapViewer.Models.Main
{
    public class Translations
    {
        public string ChooseMap { get; set; }
        public string Legend { get; set; }
        public string Info { get; set; }
        public TranslationsMaps Maps { get; set; }
    }

    public class TranslationsMaps
    {
        public string Khorinis { get; set; }
        public string ValleyOfMines { get; set; }
        public string Jarkendar { get; set; }
    }
}
