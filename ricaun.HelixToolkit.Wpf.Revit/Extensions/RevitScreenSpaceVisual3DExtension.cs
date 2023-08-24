using Autodesk.Revit.DB;
using HelixToolkit.Wpf;
using ricaun.HelixToolkit.Wpf.Revit.Utils;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitScreenSpaceVisual3DExtension
    /// </summary>
    public static class RevitScreenSpaceVisual3DExtension
    {
        /// <summary>
        /// ApplyGraphicsStyle
        /// </summary>
        /// <param name="screenSpaceVisual3D"></param>
        /// <param name="geometryObject"></param>
        public static void ApplyGraphicsStyle(this ScreenSpaceVisual3D screenSpaceVisual3D, GeometryObject geometryObject)
        {
            if (geometryObject is null) return;

            screenSpaceVisual3D.Color = GraphicsStyleUtils.GetLineColor(geometryObject.GraphicsStyleId).ToColor();
        }
    }
}
