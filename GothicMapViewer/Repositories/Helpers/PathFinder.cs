using System.Configuration;

namespace GothicMapViewer.Repositories.Helpers
{
    public static class PathFinder
    {
        public static string MapFolder { get; set; }
        public static string DataFolder { get; set; }
        public static string TraslationFolder { get; set; }

        static PathFinder()
        {
#if DEBUG
            MapFolder = ConfigurationManager.AppSettings.Get("DebugMapPath");
            TraslationFolder = ConfigurationManager.AppSettings.Get("DebugTranslationPath");
            DataFolder = ConfigurationManager.AppSettings.Get("DebugDataPath");
#endif

#if (!DEBUG)
            MapFolder = ConfigurationManager.AppSettings.Get("ReleaseMapPath");
            TraslationFolder = ConfigurationManager.AppSettings.Get("ReleaseTranslationPath");
            DataFolder = ConfigurationManager.AppSettings.Get("ReleaseDataPath");
#endif
        }
    }
}
