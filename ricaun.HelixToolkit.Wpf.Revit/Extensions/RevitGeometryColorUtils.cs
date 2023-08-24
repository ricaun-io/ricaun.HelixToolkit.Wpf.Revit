using Autodesk.Revit.DB;
using ricaun.HelixToolkit.Wpf.Revit.Utils;
using System.Windows.Media;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitGeometryColorUtils
    /// </summary>
    public static class RevitGeometryColorUtils
    {
        /// <summary>
        /// GetColor
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static System.Windows.Media.Color GetColor(Face face)
        {
            var color = MaterialUtils.GetMaterialColorWithTransparency(face.MaterialElementId).ToColor();

            if (color == default)
            {
                if (face.IsTwoSided)
                {
                    color = GraphicsStyleUtils.GetLineColor(face.GraphicsStyleId).ToColor();
                    if (color == default)
                    {
                        color = Colors.White;
                    }
                }
            }

            return color;
        }

        /// <summary>
        /// GetColor
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static System.Windows.Media.Color GetColor(Mesh mesh)
        {
            var color = MaterialUtils.GetMaterialColorWithTransparency(mesh.MaterialElementId).ToColor();
            return color;
        }
    }
}
