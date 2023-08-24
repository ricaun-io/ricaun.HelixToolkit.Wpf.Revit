using Autodesk.Revit.DB;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitMeshGeometry3DExtension
    /// </summary>
    public static class RevitMeshGeometry3DExtension
    {
        /// <summary>
        /// ToMesh
        /// </summary>
        /// <param name="solid"></param>
        /// <returns></returns>
        public static MeshGeometry3D ToMesh(this Solid solid)
        {
            return RevitMeshBuilderExtension.Create((meshBuilder) =>
            {
                foreach (Face face in solid.Faces)
                {
                    meshBuilder.AddRevitMesh(face.Triangulate());
                }
            });
        }

        /// <summary>
        /// ToMesh
        /// </summary>
        /// <param name="face"></param>
        /// <returns></returns>
        public static MeshGeometry3D ToMesh(this Face face)
        {
            return ToMesh(face.Triangulate());
        }

        /// <summary>
        /// ToMesh
        /// </summary>
        /// <param name="mesh"></param>
        /// <returns></returns>
        public static MeshGeometry3D ToMesh(this Mesh mesh)
        {
            return RevitMeshBuilderExtension.Create((meshBuilder) =>
            {
                meshBuilder.AddRevitMesh(mesh);
            });
        }
    }
}
