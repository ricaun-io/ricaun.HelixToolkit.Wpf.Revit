using Autodesk.Revit.DB;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitGeometryModel3DExtension
    /// </summary>
    public static class RevitGeometryModel3DExtension
    {
        /// <summary>
        /// Revit Face to GeometryModel3D
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static GeometryModel3D ToModel3D(this Face face)
        {
            var color = RevitGeometryColorUtils.GetColor(face);
            return face.ToMesh().ToModel3D(color);
        }

        /// <summary>
        /// Revit Mesh to GeometryModel3D
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static GeometryModel3D ToModel3D(this Mesh mesh)
        {
            var color = RevitGeometryColorUtils.GetColor(mesh);
            return mesh.ToMesh().ToModel3D(color);
        }

        /// <summary>
        /// Convert Geometry3D to Model3D
        /// </summary>
        /// <param name="geometry">The Geometry3D</param>
        /// <param name="color">Color to the DiffuseMaterial</param>
        /// <returns></returns>
        public static GeometryModel3D ToModel3D(
            this Geometry3D geometry,
            System.Windows.Media.Color color = default)
        {
            if (color == default) color = Colors.Gray;

            return new GeometryModel3D()
            {
                Geometry = geometry,
                Material = new DiffuseMaterial(new SolidColorBrush(color)),
                BackMaterial = new DiffuseMaterial(new SolidColorBrush(color))
            };
        }
    }
}
