using Autodesk.Revit.DB;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitVector3DExtension
    /// </summary>
    public static class RevitVector3DExtension
    {
        /// <summary>
        /// ToVector3D
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector3D ToVector3D(this XYZ vector)
        {
            return new Vector3D(vector.X, vector.Y, vector.Z);
        }

        /// <summary>
        /// ToXYZ
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static XYZ ToXYZ(this Vector3D vector)
        {
            return new XYZ(vector.X, vector.Y, vector.Z);
        }
    }
}
