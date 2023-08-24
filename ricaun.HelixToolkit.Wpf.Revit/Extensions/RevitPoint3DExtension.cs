using Autodesk.Revit.DB;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitPoint3DExtension
    /// </summary>
    public static class RevitPoint3DExtension
    {
        /// <summary>
        /// ToPoint3D
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Point3D ToPoint3D(this XYZ point)
        {
            return new Point3D(point.X, point.Y, point.Z);
        }

        /// <summary>
        /// ToXYZ
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public static XYZ ToXYZ(this Point3D point)
        {
            return new XYZ(point.X, point.Y, point.Z);
        }
    }
}
