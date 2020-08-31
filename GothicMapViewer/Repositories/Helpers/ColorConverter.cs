using System.Windows.Media;

namespace GothicMapViewer.Repositories.Helpers
{
    public static class ColorConverter
    {
        public static Brush ConvertHexToBrush(string colorHex)
        {
            var converter = new System.Windows.Media.BrushConverter();
            return (Brush)new BrushConverter().ConvertFromString(colorHex);
        }
    }
}
