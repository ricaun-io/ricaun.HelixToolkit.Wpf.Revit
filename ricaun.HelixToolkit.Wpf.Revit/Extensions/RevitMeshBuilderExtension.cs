using Autodesk.Revit.DB;
using HelixToolkit.Wpf;
using System;
using System.Windows.Media.Media3D;

namespace ricaun.HelixToolkit.Wpf.Revit.Extensions
{
    /// <summary>
    /// RevitMeshBuilderExtension
    /// </summary>
    public static class RevitMeshBuilderExtension
    {
        /// <summary>
        /// CreateWithFreeze
        /// </summary>
        public const bool CreateWithFreeze = true;

        /// <summary>
        /// AddRevitMesh
        /// </summary>
        /// <param name="meshBuilder"></param>
        /// <param name="mesh"></param>
        public static void AddRevitMesh(this MeshBuilder meshBuilder, Mesh mesh)
        {
            var triangleCorners = new Point3D[3];
            for (int i = 0; i < mesh.NumTriangles; i++)
            {
                MeshTriangle triangle = mesh.get_Triangle(i);

                triangleCorners[0] = triangle.get_Vertex(0).ToPoint3D();
                triangleCorners[1] = triangle.get_Vertex(1).ToPoint3D();
                triangleCorners[2] = triangle.get_Vertex(2).ToPoint3D();

                meshBuilder.AddPolygon(triangleCorners);
            }
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="actionMeshBuilder"></param>
        /// <returns></returns>
        public static MeshGeometry3D Create(Action<MeshBuilder> actionMeshBuilder)
        {
            MeshBuilder meshBuilder = new MeshBuilder();
            actionMeshBuilder?.Invoke(meshBuilder);
            return meshBuilder.ToMesh(CreateWithFreeze);
        }
    }
}
