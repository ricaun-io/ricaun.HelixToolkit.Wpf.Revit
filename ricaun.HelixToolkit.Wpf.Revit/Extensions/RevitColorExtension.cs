using Autodesk.Revit.DB;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitColorExtension
    /// </summary>
    public static class RevitColorExtension
    {
        /// <summary>
        /// ToColor
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static Color ToColor(this System.Windows.Media.Color color)
        {
            return new Color(color.R, color.G, color.B);
        }

        /// <summary>
        /// ToColor
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static System.Windows.Media.Color ToColor(this Color color)
        {
            if (color is null) return default;
            return System.Windows.Media.Color.FromRgb(color.Red, color.Green, color.Blue);
        }

        /// <summary>
        /// ToColorWithTransparency
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static ColorWithTransparency ToColorWithTransparency(this System.Windows.Media.Color color)
        {
            return new ColorWithTransparency(color.R, color.G, color.B, color.A);
        }

        /// <summary>
        /// ToColor
        /// </summary>
        /// <param name="colorTransparency"></param>
        /// <returns></returns>
        public static System.Windows.Media.Color ToColor(this ColorWithTransparency colorTransparency)
        {
            if (colorTransparency is null) return default;
            return System.Windows.Media.Color.FromArgb(
                (byte)colorTransparency.GetTransparency(),
                (byte)colorTransparency.GetRed(),
                (byte)colorTransparency.GetGreen(),
                (byte)colorTransparency.GetBlue());
        }

    }
}
